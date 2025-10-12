using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Logica;
using Entidades.DTOs;

namespace Vista
{
    public partial class frmListarCotizaciones : Form
    {
        private readonly CL_Cotizacion logicaCotizacion = new CL_Cotizacion();
        private List<DtoCotizacion> cotizaciones = new List<DtoCotizacion>();

        // Fuente de datos para filtrar/ordenar sin perder el binding
        private readonly BindingSource bsCotizaciones = new BindingSource();

        public frmListarCotizaciones()
        {
            InitializeComponent();
            // Asegurar que el Load esté enganchado
            this.Load -= frmListarCotizaciones_Load;
            this.Load += frmListarCotizaciones_Load;
        }

        // Carga inicial garantizada al mostrarse el form (por si el Load del diseñador no se ejecuta)
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            CargarCotizaciones();
            AplicarFiltro();
        }

        private void frmListarCotizaciones_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarDataGridView();

                // Enganchar eventos de UI (si existen los controles)
                ConfigurarEventosBusqueda();

                CargarCotizaciones();         // Carga inicial
                AplicarFiltro();              // Aplica filtro inicial (vacío = muestra todo)
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
                Name = "IdCotizacion",
                HeaderText = "ID",
                DataPropertyName = "IdCotizacion",
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

            // Sin columnas de botones
            dvgCotizaciones.DataSource = bsCotizaciones;

            // Habilitar/deshabilitar botón Editar según selección
            dvgCotizaciones.SelectionChanged -= dvgCotizaciones_SelectionChanged;
            dvgCotizaciones.SelectionChanged += dvgCotizaciones_SelectionChanged;
        }

        private void CargarCotizaciones()
        {
            try
            {
                cotizaciones = logicaCotizacion.ListarCotizaciones() ?? new List<DtoCotizacion>();

                // BindingList para notificaciones y refresco consistente
                bsCotizaciones.DataSource = new BindingList<DtoCotizacion>(cotizaciones);
                dvgCotizaciones.DataSource = bsCotizaciones;

                dvgCotizaciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                dvgCotizaciones.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cotizaciones: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Mostrar grilla vacía si hubo error
                bsCotizaciones.DataSource = new BindingList<DtoCotizacion>();
                dvgCotizaciones.DataSource = bsCotizaciones;
            }
        }

        // Aplica filtro por texto y (opcional) rango de fechas si los controles existen
        private void AplicarFiltro()
        {
            try
            {
                var texto = ObtenerTexto("txtBuscar")?.ToLowerInvariant();
                var lista = cotizaciones.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    lista = lista.Where(c =>
                        (c.NumeroCotizacion ?? "").ToLowerInvariant().Contains(texto) ||
                        (c.DescripcionMueble ?? "").ToLowerInvariant().Contains(texto) ||
                        (c.UsuarioNombre ?? "").ToLowerInvariant().Contains(texto) ||
                        c.Id_Cotizacion.ToString().Contains(texto)
                    );
                }

                // Filtro por rango de fechas si existe un CheckBox para habilitarlo
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

                bsCotizaciones.DataSource = lista.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEventosBusqueda()
        {
            // Buscar por texto incremental
            var txtBuscar = Controls.Find("txtBuscar", true).FirstOrDefault() as TextBox;
            if (txtBuscar != null)
            {
                txtBuscar.TextChanged -= TxtBuscar_TextChanged;
                txtBuscar.TextChanged += TxtBuscar_TextChanged;
            }

            // Botón buscar (si existe en el diseñador)
            var btnBuscar = Controls.Find("btnBuscarCotización", true).FirstOrDefault() as Button;
            if (btnBuscar != null)
            {
                btnBuscar.Click -= btnBuscarCotización_Click;
                btnBuscar.Click += btnBuscarCotización_Click;
            }

            // Rango de fechas (si existen)
            var dtpDesde = Controls.Find("dtpDesde", true).FirstOrDefault() as DateTimePicker;
            var dtpHasta = Controls.Find("dtpHasta", true).FirstOrDefault() as DateTimePicker;
            var chkRango = Controls.Find("chkRangoFechas", true).FirstOrDefault() as CheckBox;

            if (dtpDesde != null) { dtpDesde.ValueChanged -= Dtp_ValueChanged; dtpDesde.ValueChanged += Dtp_ValueChanged; }
            if (dtpHasta != null) { dtpHasta.ValueChanged -= Dtp_ValueChanged; dtpHasta.ValueChanged += Dtp_ValueChanged; }
            if (chkRango != null) { chkRango.CheckedChanged -= ChkRango_CheckedChanged; chkRango.CheckedChanged += ChkRango_CheckedChanged; }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e) => AplicarFiltro();
        private void Dtp_ValueChanged(object sender, EventArgs e) => AplicarFiltro();
        private void ChkRango_CheckedChanged(object sender, EventArgs e) => AplicarFiltro();

        private string ObtenerTexto(string nombreTextBox)
        {
            var txt = Controls.Find(nombreTextBox, true).FirstOrDefault() as TextBox;
            return txt?.Text?.Trim();
        }

        private void dvgCotizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Tomar la entidad enlazada a la fila (no por índice de la lista)
            var fila = dvgCotizaciones.Rows[e.RowIndex].DataBoundItem as DtoCotizacion;
            if (fila == null) return;

            try
            {
                if (e.ColumnIndex == dvgCotizaciones.Columns["btnEditar"].Index)
                {
                    EditarCotizacion(fila);
                }
                else if (e.ColumnIndex == dvgCotizaciones.Columns["btnEliminar"].Index)
                {
                    EliminarCotizacion(fila);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la acción: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        frm.Load -= onLoad; // evitar múltiple invocación
                        frm.CargarCotizacionParaEdicion(cotizacionCompleta);
                    };
                    frm.Load += onLoad;

                    frm.ShowDialog(this);
                }

                CargarCotizaciones();
                AplicarFiltro();
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
                $"¿Está seguro que desea eliminar la cotización {cotizacion.NumeroCotizacion}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                if (logicaCotizacion.EliminarCotizacion(cotizacion.Id_Cotizacion))
                {
                    MessageBox.Show("Cotización eliminada correctamente.", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCotizaciones();
                    AplicarFiltro();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la cotización.", "Error",
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

                // Diferir la carga hasta que el formulario haya inicializado los combos
                EventHandler onLoad = null;
                onLoad = (s, args) =>
                {
                    frm.Load -= onLoad; // evitar múltiples ejecuciones
                    frm.CargarCotizacionParaEdicion(cotizacionCompleta);
                };
                frm.Load += onLoad;

                // Ocultar este formulario y cerrarlo al cerrar el cotizador
                this.Hide();
                frm.FormClosed += (s, args) =>
                {
                    try { this.Close(); } catch { /* silencioso */ }
                };

                // Mostrar el cotizador de forma no modal
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la cotización: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        }
    }
}
