using Entidades.DTOs;
using Logica;
using Sistema_Gestion_de_Usuarios.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmListarCotizaciones : Form
    {
        private readonly CL_Cotizacion logicaCotizacion = new CL_Cotizacion();
        private List<DtoCotizacion> cotizaciones = new List<DtoCotizacion>();
        private List<DtoCotizacion> vistaFiltrada = new List<DtoCotizacion>(); // lista mostrada

        public frmListarCotizaciones()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            this.Load -= frmListarCotizaciones_Load;
            this.Load += frmListarCotizaciones_Load;
        }

        private void frmListarCotizaciones_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarDataGridView();
                ConfigurarEventosBusqueda();
                CargarCotizaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dvgCotizaciones.AutoGenerateColumns = false;
            dvgCotizaciones.AllowUserToAddRows = false;
            dvgCotizaciones.AllowUserToDeleteRows = false;
            dvgCotizaciones.ReadOnly = true;
            dvgCotizaciones.MultiSelect = false;
            dvgCotizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgCotizaciones.RowHeadersVisible = false;

            dvgCotizaciones.Columns.Clear();

            dvgCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id_Cotizacion",
                HeaderText = "ID",
                DataPropertyName = "Id_Cotizacion",
                Width = 60
            });

            dvgCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NumeroCotizacion",
                HeaderText = "Número",
                DataPropertyName = "NumeroCotizacion",
                Width = 120
            });

            dvgCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaCreacion",
                HeaderText = "Fecha",
                DataPropertyName = "FechaCreacion",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dvgCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionMueble",
                HeaderText = "Descripción",
                DataPropertyName = "DescripcionMueble",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dvgCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UsuarioNombre",
                HeaderText = "Usuario",
                DataPropertyName = "UsuarioNombre",
                Width = 140
            });

            dvgCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontoFinal",
                HeaderText = "Monto Final",
                DataPropertyName = "MontoFinal",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            // Eventos grilla
            dvgCotizaciones.SelectionChanged -= dvgCotizaciones_SelectionChanged;
            dvgCotizaciones.SelectionChanged += dvgCotizaciones_SelectionChanged;

            dvgCotizaciones.CellClick -= dvgCotizaciones_CellClick;
            dvgCotizaciones.CellClick += dvgCotizaciones_CellClick;

            dvgCotizaciones.CellDoubleClick -= dvgCotizaciones_CellDoubleClick;
            dvgCotizaciones.CellDoubleClick += dvgCotizaciones_CellDoubleClick;

            dvgCotizaciones.KeyDown -= dvgCotizaciones_KeyDown;
            dvgCotizaciones.KeyDown += dvgCotizaciones_KeyDown;
        }

        private void CargarCotizaciones()
        {
            try
            {
                // cargar solo activos desde la BD
                cotizaciones = (logicaCotizacion.ListarCotizaciones() ?? new List<DtoCotizacion>())
                                .Where(c => c.Activo)
                                .ToList();

                // Mostrar todo al abrir (sin filtro)
                vistaFiltrada = new List<DtoCotizacion>(cotizaciones);
                dvgCotizaciones.DataSource = null;
                dvgCotizaciones.DataSource = vistaFiltrada;
                dvgCotizaciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                dvgCotizaciones.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cotizaciones: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                vistaFiltrada = new List<DtoCotizacion>();
                dvgCotizaciones.DataSource = null;
                dvgCotizaciones.DataSource = vistaFiltrada;
            }
        }

        // Aplica filtro por descripción, vendedor y fecha (solo si chkFechaActivo está marcado)
        private void AplicarFiltro()
        {
            try
            {
                var descripcion = ObtenerTexto("txtDescripcion")?.ToLowerInvariant();
                var vendedor = ObtenerTexto("txtVendedor")?.ToLowerInvariant();

                IEnumerable<DtoCotizacion> lista = cotizaciones;

                if (!string.IsNullOrWhiteSpace(descripcion))
                    lista = lista.Where(c => (c.DescripcionMueble ?? "").ToLowerInvariant().Contains(descripcion));

                if (!string.IsNullOrWhiteSpace(vendedor))
                    lista = lista.Where(c => (c.UsuarioNombre ?? "").ToLowerInvariant().Contains(vendedor));

                // Solo filtrar por fecha si el checkbox de activación está marcado
                var chkFechaActivo = Controls.Find("chkFechaActivo", true).FirstOrDefault() as CheckBox;
                bool filtrarPorFecha = chkFechaActivo != null && chkFechaActivo.Checked;

                if (filtrarPorFecha)
                {
                    var chkRango = Controls.Find("chkRangoFechas", true).FirstOrDefault() as CheckBox;
                    var dtpDesde = Controls.Find("dtpDesde", true).FirstOrDefault() as DateTimePicker;
                    var dtpHasta = Controls.Find("dtpHasta", true).FirstOrDefault() as DateTimePicker;

                    if (chkRango != null && chkRango.Checked && dtpDesde != null && dtpHasta != null)
                    {
                        var desde = dtpDesde.Value.Date;
                        var hasta = dtpHasta.Value.Date;
                        if (hasta < desde) hasta = desde;

                        lista = lista.Where(c => c.FechaCreacion.Date >= desde && c.FechaCreacion.Date <= hasta);
                    }
                    else
                    {
                        var dtpFecha = Controls.Find("dateTimePicker1", true).FirstOrDefault() as DateTimePicker;
                        if (dtpFecha != null)
                        {
                            var fecha = dtpFecha.Value.Date;
                            lista = lista.Where(c => c.FechaCreacion.Date == fecha);
                        }
                    }
                }

                vistaFiltrada = lista.ToList();

                dvgCotizaciones.DataSource = null; // reasignación simple
                dvgCotizaciones.DataSource = vistaFiltrada;
                dvgCotizaciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                dvgCotizaciones.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEventosBusqueda()
        {
            // Botón buscar (aplica filtros)
            var btnBuscar = Controls.Find("btnBuscarCotización", true).FirstOrDefault() as Button
                            ?? Controls.Find("btnBuscarCotizacion", true).FirstOrDefault() as Button;
            if (btnBuscar != null)
            {
                btnBuscar.Click -= btnBuscarCotización_Click;
                btnBuscar.Click += btnBuscarCotización_Click;
            }

            // Rango de fechas (solo habilita/deshabilita, NO filtra automáticamente)
            var dtpDesde = Controls.Find("dtpDesde", true).FirstOrDefault() as DateTimePicker;
            var dtpHasta = Controls.Find("dtpHasta", true).FirstOrDefault() as DateTimePicker;
            var chkRango = Controls.Find("chkRangoFechas", true).FirstOrDefault() as CheckBox;

            if (dtpDesde != null) { dtpDesde.ValueChanged -= Dtp_ValueChanged; dtpDesde.ValueChanged += Dtp_ValueChanged; }
            if (dtpHasta != null) { dtpHasta.ValueChanged -= Dtp_ValueChanged; dtpHasta.ValueChanged += Dtp_ValueChanged; }
            if (chkRango != null) { chkRango.CheckedChanged -= ChkRango_CheckedChanged; chkRango.CheckedChanged += ChkRango_CheckedChanged; }

            // Activación del filtrado por fecha: habilita los DateTimePicker, NO filtra
            var chkFechaActivo = Controls.Find("chkFechaActivo", true).FirstOrDefault() as CheckBox;
            if (chkFechaActivo != null)
            {
                chkFechaActivo.CheckedChanged -= ChkFechaActivo_CheckedChanged;
                chkFechaActivo.CheckedChanged += ChkFechaActivo_CheckedChanged;

                // Estado inicial de habilitación
                ActualizarHabilitacionFechas(chkFechaActivo.Checked);
            }

            // Botones Editar/Eliminar
            var btnEditar = Controls.Find("btnEditarCotizacion", true).FirstOrDefault() as Button;
            if (btnEditar != null)
            {
                btnEditar.Click -= btnEditarCotizacion_Click;
                btnEditar.Click += btnEditarCotizacion_Click;
            }

            var btnEliminar = Controls.Find("btnEliminarCotizacion", true).FirstOrDefault() as Button;
            if (btnEliminar != null)
            {
                btnEliminar.Click -= btnEliminarCotizacion_Click;
                btnEliminar.Click += btnEliminarCotizacion_Click;
            }
        }


        // NO filtra: solo ajusta mínimos y UI
        private void Dtp_ValueChanged(object sender, EventArgs e)
        {
            var dtpDesde = Controls.Find("dtpDesde", true).FirstOrDefault() as DateTimePicker;
            var dtpHasta = Controls.Find("dtpHasta", true).FirstOrDefault() as DateTimePicker;
            if (dtpDesde != null && dtpHasta != null)
            {
                dtpHasta.MinDate = dtpDesde.Value.Date;
                if (dtpHasta.Value < dtpDesde.Value)
                    dtpHasta.Value = dtpDesde.Value;
            }
        }

        private void ChkRango_CheckedChanged(object sender, EventArgs e)
        {
            var chkFechaActivo = Controls.Find("chkFechaActivo", true).FirstOrDefault() as CheckBox;
            ActualizarHabilitacionFechas(chkFechaActivo != null && chkFechaActivo.Checked);
            // No aplicar filtro aquí
        }

        private void ChkFechaActivo_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            ActualizarHabilitacionFechas(chk != null && chk.Checked);
            // No aplicar filtro aquí
        }

        private string ObtenerTexto(string nombreTextBox)
        {
            var txt = Controls.Find(nombreTextBox, true).FirstOrDefault() as TextBox;
            return txt?.Text?.Trim();
        }

        private void dvgCotizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dvgCotizaciones.Rows[e.RowIndex].DataBoundItem as DtoCotizacion;
            if (fila == null) return;

            try
            {
                var colEditar = dvgCotizaciones.Columns["btnEditar"];
                var colEliminar = dvgCotizaciones.Columns["btnEliminar"];

                if (colEditar != null && e.ColumnIndex == colEditar.Index)
                    EditarCotizacion(fila);
                else if (colEliminar != null && e.ColumnIndex == colEliminar.Index)
                    EliminarCotizacion(fila);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la acción: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dvgCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dvgCotizaciones.Rows[e.RowIndex].DataBoundItem as DtoCotizacion;
            if (fila == null) return;

            EditarCotizacion(fila);
        }

        private void dvgCotizaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var seleccion = ObtenerCotizacionSeleccionada();
                if (seleccion != null)
                {
                    EliminarCotizacion(seleccion);
                    e.Handled = true;
                }
            }
        }

        private void EditarCotizacion(DtoCotizacion cotizacion)
        {
            try
            {
                var cotizacionCompleta = logicaCotizacion.ObtenerCotizacion(cotizacion.Id_Cotizacion);
                if (cotizacionCompleta == null)
                {
                    MessageBox.Show("No se encontró la cotización seleccionada.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var frm = new frmCotizador())
                {
                    EventHandler onLoad = null;
                    onLoad = (s, e) =>
                    {
                        frm.Load -= onLoad;
                        frm.CargarCotizacionParaEdicion(cotizacionCompleta);
                    };
                    frm.Load += onLoad;

                    frm.ShowDialog(this);
                }

                CargarCotizaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la cotización: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarCotizacion(DtoCotizacion cotizacion)
        {
            var resultado = MessageBox.Show(
                $"¿Está seguro que desea eliminar la cotización {cotizacion.NumeroCotizacion} (ID {cotizacion.Id_Cotizacion})?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    if (logicaCotizacion.EliminarCotizacion(cotizacion.Id_Cotizacion))
                    {
                        MessageBox.Show("Cotización eliminada correctamente.", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar SOLO ACTIVAS y refrescar de inmediato
                        CargarCotizaciones();
                        dvgCotizaciones.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la cotización.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscarCotización_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnEditarCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                var seleccion = ObtenerCotizacionSeleccionada();
                if (seleccion == null)
                {
                    MessageBox.Show("Seleccione una cotización de la lista.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cotizacionCompleta = logicaCotizacion.ObtenerCotizacion(seleccion.Id_Cotizacion);
                if (cotizacionCompleta == null)
                {
                    MessageBox.Show("No se encontró la cotización seleccionada.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var frm = new frmCotizador();

                EventHandler onLoad = null;
                onLoad = (s, args) =>
                {
                    frm.Load -= onLoad;
                    frm.CargarCotizacionParaEdicion(cotizacionCompleta);
                };
                frm.Load += onLoad;

                this.Hide();
                frm.FormClosed += (s, args) =>
                {
                    try { this.Close(); } catch { }
                };

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la cotización: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Tamaño total del formulario hijo
            int anchoTotal = this.Width;
            int altoTotal = this.Height;

            // Tamaño del área cliente (solo zona visible)
            int anchoCliente = this.ClientSize.Width;
            int altoCliente = this.ClientSize.Height;
               
        }

        private DtoCotizacion ObtenerCotizacionSeleccionada()
        {
            if (dvgCotizaciones.CurrentRow == null) return null;
            return dvgCotizaciones.CurrentRow.DataBoundItem as DtoCotizacion;
        }

        private void dvgCotizaciones_SelectionChanged(object sender, EventArgs e)
        {
            var btnEditar = Controls.Find("btnEditarCotizacion", true).FirstOrDefault() as Button;
            if (btnEditar != null)
                btnEditar.Enabled = dvgCotizaciones.CurrentRow != null;

            var btnEliminar = Controls.Find("btnEliminarCotizacion", true).FirstOrDefault() as Button;
            if (btnEliminar != null)
                btnEliminar.Enabled = dvgCotizaciones.CurrentRow != null;
        }

        private void btnEliminarCotizacion_Click(object sender, EventArgs e)
        {
            var seleccion = ObtenerCotizacionSeleccionada();
            if (seleccion == null)
            {
                MessageBox.Show("Seleccione una cotización de la lista.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EliminarCotizacion(seleccion);
        }

        private void ActualizarHabilitacionFechas(bool habilitar)
        {
            var chkRango = Controls.Find("chkRangoFechas", true).FirstOrDefault() as CheckBox;
            var dtpDesde = Controls.Find("dtpDesde", true).FirstOrDefault() as DateTimePicker;
            var dtpHasta = Controls.Find("dtpHasta", true).FirstOrDefault() as DateTimePicker;
            var dtpFecha = Controls.Find("dateTimePicker1", true).FirstOrDefault() as DateTimePicker;

            if (chkRango != null) chkRango.Enabled = habilitar;

            bool usarRango = habilitar && chkRango != null && chkRango.Checked;

            if (dtpDesde != null) dtpDesde.Enabled = usarRango;
            if (dtpHasta != null) dtpHasta.Enabled = usarRango;
            if (dtpFecha != null) dtpFecha.Enabled = habilitar && !usarRango;
        }

        private void frmListarCotizaciones_Load_1(object sender, EventArgs e)
        {

        }

        private void pnlOpciones_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarRectangulo(sender as Control, e, Color.White, 1f);
        }

        private void pnlFiltrarCotizaciones_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarRectangulo(sender as Control, e, Color.White, 1f);
        }
    }
}
