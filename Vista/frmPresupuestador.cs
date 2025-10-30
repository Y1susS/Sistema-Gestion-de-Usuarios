using Entidades;
using Entidades.DTOs;
using Logica;
using Sistema_Gestion_de_Usuarios.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmPresupuestador : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        public frmPresupuestador()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            ConfigurarControles();
            CargarEventos();

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblTitulo);
        }


        private CL_Clientes clCliente = new CL_Clientes();
        private DtoCliente clienteActual;
        private CL_TipoDoc _logicaTipoDoc = new CL_TipoDoc();
        private CL_Presupuesto clPresupuesto = new CL_Presupuesto();
        private List<DtoPresupuestoDetalle> detallesCotizacion = new List<DtoPresupuestoDetalle>();
        private CL_Ventas clVenta = new CL_Ventas();

        private void ConfigurarDatagrid()
        {
            dgvPresupuesto.ReadOnly = false;

            dgvPresupuesto.AllowUserToAddRows = false;
            dgvPresupuesto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPresupuesto.MultiSelect = false;
            dgvPresupuesto.RowHeadersVisible = false;
            dgvPresupuesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (DataGridViewColumn col in dgvPresupuesto.Columns)
            {
                col.ReadOnly = true;

                if (col.DataPropertyName != null && col.DataPropertyName.Equals("Cantidad", StringComparison.OrdinalIgnoreCase))
                {
                    col.ReadOnly = false;
                }
            }
        }
        private void ConfigurarControles()
        {
            var tiposDocumento = _logicaTipoDoc.MostrarTiposDocumento();
            if (cmbDni != null) 
            {
                cmbDni.DataSource = tiposDocumento;
                cmbDni.DisplayMember = "Id_TipoDocumento";
                cmbDni.ValueMember = "Id_TipoDocumento";
                cmbDni.SelectedIndex = -1;
            }
            txtNombreCliente.ReadOnly = true;
            txtApellidoCliente.ReadOnly = true;
            txtTelefonoCliente.ReadOnly = true;
            txtMailCliente.ReadOnly = true;

            txtNombreCliente.BackColor = System.Drawing.SystemColors.Control;
            txtApellidoCliente.BackColor = System.Drawing.SystemColors.Control;
            txtTelefonoCliente.BackColor = System.Drawing.SystemColors.Control;
            txtMailCliente.BackColor = System.Drawing.SystemColors.Control;

            LimpiarCamposCliente();
        }
        private void CargarEventos()
        {
            txtDni.KeyPress += txtDni_Keypress;

            txtDni.KeyDown += txtDni_KeyDown;
        }
        #region Seccion Cliente
        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            string tipoDoc = cmbDni.SelectedValue.ToString();
            string dni = txtDni.Text.Trim();


            LimpiarCamposCliente();

            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Debe ingresar un DNI para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tipoDoc) || string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Debe seleccionar un Tipo de Documento e ingresar un DNI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DtoCliente cliente = clCliente.BuscarClientePorDocumento(tipoDoc, dni);

                if (cliente != null)
                {
                    txtNombreCliente.Text = cliente.Nombre;
                    txtApellidoCliente.Text = cliente.Apellido;
                    txtTelefonoCliente.Text = cliente.Telefono;
                    txtMailCliente.Text = cliente.Email;
                    this.clienteActual = cliente;
                    MessageBox.Show("Cliente encontrado exitosamente.", "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"No se encontró un cliente con el DNI: {dni}.", "Cliente No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar el cliente. Por favor, intente de nuevo.\nDetalle: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDni_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void LimpiarCamposCliente()
        {
            txtNombreCliente.Text = string.Empty;
            txtApellidoCliente.Text = string.Empty;
            txtTelefonoCliente.Text = string.Empty;
            txtMailCliente.Text = string.Empty;
            this.clienteActual = null;
        }

        private void btnBuscarPresupuesto_Click(object sender, EventArgs e)
        {
            using (frmBuscarPresupuesto frmBusqueda = new frmBuscarPresupuesto())
            {
                if (frmBusqueda.ShowDialog() == DialogResult.OK)
                {
                    DtoPresupuestoFiltro filtroSeleccionado = frmBusqueda.PresupuestoSeleccionado;

                    if (filtroSeleccionado != null)
                    {
                        try
                        {
                            Presupuesto presupuestoCompleto = clPresupuesto.CargarPresupuestoCompleto(filtroSeleccionado.IdPresupuesto);

                            this.detallesCotizacion = clPresupuesto.ObtenerDetalles(filtroSeleccionado.IdPresupuesto);

                            CargarPresupuestoEnFormulario(presupuestoCompleto);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cargar el presupuesto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void CargarPresupuestoEnFormulario(Presupuesto p)
        {
            if (p != null)
            {

                // Cargar Datos del Presupuesto:

                txtDescripcion.Text = p.Observaciones;

                dtpVigencia.Value = p.FechaValidez.GetValueOrDefault(DateTime.Now);

                // Cargar totales

                lblValorSubtotal.Text = "$ " + p.MontoTotal.ToString();
                txtDescuento.Text = p.PorcentajeDescuento.ToString();
                lblValorPresupuesto.Text = "$ " + p.MontoFinal.ToString();

                // Cargar DataGrid:
                ActualizarDataGridCotizaciones();

                ConfigurarDatagrid();

                if (dgvPresupuesto.Rows.Count > 0)
                {
                    dgvPresupuesto.ClearSelection();

                    dgvPresupuesto.Rows[0].Selected = true;

                    dgvPresupuesto.CurrentCell = dgvPresupuesto.Rows[0].Cells[0];
                }

                if (dgvPresupuesto.Columns.Contains("Idpresupuesto"))
                {
                    dgvPresupuesto.Columns["Idpresupuesto"].Visible = false;
                }
                if (dgvPresupuesto.Columns.Contains("Idcotizacion"))
                {
                    dgvPresupuesto.Columns["Idcotizacion"].Visible = false;
                }

                MessageBox.Show($"Presupuesto N° {p.Numero} cargado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
        private void ActualizarDataGridCotizaciones()
        {
            dgvPresupuesto.DataSource = null;
            dgvPresupuesto.DataSource = this.detallesCotizacion;
        }
        #endregion

        public void AgregarCotizacion(int idCotizacion, string numeroCotizacion,
                               string descripcion, decimal montoTotal)
        {
            // Verificar que no esté ya agregada
            foreach (DataGridViewRow row in dgvPresupuesto.Rows)
            {
                if (Convert.ToInt32(row.Cells["Id_Cotizacion"].Value) == idCotizacion)
                {
                    MessageBox.Show("Esta cotización ya está en el presupuesto.");
                    return;
                }
            }

            dgvPresupuesto.Rows.Add(idCotizacion, numeroCotizacion, descripcion, montoTotal);
            CalcularSubtotal();
        }

        // O mejor aún, recibir el objeto completo
        //public void AgregarCotizacion(Cotizacion cotizacion)
        //{
        //    AgregarCotizacion(cotizacion.Id_Cotizacion,
        //                     cotizacion.NumeroCotizacion,
        //                     cotizacion.DescripcionMueble,
        //                     cotizacion.MontoTotal);
        //}
        //private void btnCotizar_Click(object sender, EventArgs e)
        //{
        //    // Abrir el formulario de cotización en modo "nuevo"
        //    frmCotizador frmCotizador = new frmCotizador();

        //    // Cuando se cierre y haya guardado, agregar al presupuesto
        //    if (frmCotizador.ShowDialog() == DialogResult.OK)
        //    {
        //        // La cotización se guardó exitosamente
        //        var cotizacion = frmCotizador.CotizacionCreada;
        //        AgregarCotizacion(cotizacion);
        //    }
        //}
        //private void btnBuscarCotizacion_Click(object sender, EventArgs e)
        //{
        //    // Abrir formulario de búsqueda de cotizaciones
        //    frmListarCotizaciones frmBuscar = new frmListarCotizaciones();

        //    if (frmBuscar.ShowDialog() == DialogResult.OK)
        //    {
        //        var cotizacion = frmBuscar.CotizacionSeleccionada;
        //        AgregarCotizacion(cotizacion);
        //    }
        //}
        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    if (dgvPresupuesto.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Seleccione una cotización para editar.");
        //        return;
        //    }

        //    int idCotizacion = Convert.ToInt32(dgvPresupuesto.SelectedRows[0].Cells["Id_Cotizacion"].Value);

        //    // Abrir cotizador en modo edición
        //    frmCotizador frmCotizador = new frmCotizador(idCotizacion);

        //    if (frmCotizador.ShowDialog() == DialogResult.OK)
        //    {
        //        // Actualizar la fila en el DataGridView con los nuevos valores
        //        var cotizacion = frmCotizador.CotizacionEditada;
        //        var row = dataGridView1.SelectedRows[0];
        //        row.Cells["NumeroCotizacion"].Value = cotizacion.NumeroCotizacion;
        //        row.Cells["DescripcionMueble"].Value = cotizacion.DescripcionMueble;
        //        row.Cells["MontoTotal"].Value = cotizacion.MontoTotal;

        //        CalcularSubtotal();
        //    }
        //}
        private void btnBorrarCotizacion_Click(object sender, EventArgs e)
        {
            if (dgvPresupuesto.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cotización para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dgvPresupuesto.SelectedRows[0];
            int indiceFila = filaSeleccionada.Index;

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar esta cotización del presupuesto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                DtoPresupuestoDetalle detalleParaBorrar = filaSeleccionada.DataBoundItem as DtoPresupuestoDetalle;

                if (detalleParaBorrar != null)
                {
                    this.detallesCotizacion.Remove(detalleParaBorrar);

                    dgvPresupuesto.DataSource = null;
                    dgvPresupuesto.DataSource = this.detallesCotizacion;

                    CalcularSubtotal();
                }
                else
                {
                    dgvPresupuesto.Rows.RemoveAt(indiceFila);
                    CalcularSubtotal();
                }
            }
        }
        private void btnSubtotal_Click(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row in dgvPresupuesto.Rows)
            {
                if (row.Cells["Subtotal"].Value != null && decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal monto))
                {
                    subtotal += monto;
                }
            }

            lblValorSubtotal.Text = "$ " + subtotal.ToString();

        }
        private void btnDescuento_Click(object sender, EventArgs e)
        {
            AplicarDescuento();
        }

        private void AplicarDescuento()
        {
            decimal subtotal = 0;
            decimal porcentajeDescuento = 0;

            string subtotalTexto = lblValorSubtotal.Text.Trim();

            string subtotalLimpio = subtotalTexto
                .Replace("$", "")
                .Replace(" ", "")
                .Replace(".", "") 
                .Replace(",", "."); 

            if (!decimal.TryParse(subtotalLimpio,
                                  System.Globalization.NumberStyles.Any, 
                                  System.Globalization.CultureInfo.InvariantCulture, 
                                  out subtotal))
            {
                MessageBox.Show("Error de formato: El subtotal no pudo ser interpretado como número.", "Error de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtDescuento.Text.Trim(), out porcentajeDescuento))
            {
                porcentajeDescuento = 0;
            }
            porcentajeDescuento = Math.Max(0, Math.Min(100, porcentajeDescuento));


            decimal total = subtotal * (1 - (porcentajeDescuento / 100));

            lblValorPresupuesto.Text = "$ " + total.ToString("N2", System.Globalization.CultureInfo.CurrentCulture);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int? idUsuarioActual = ClsSesionActual.ObtenerUsuario()?.Id_user;

            if (idUsuarioActual == null || idUsuarioActual == 0)
            {
                MessageBox.Show("No se pudo identificar al usuario logueado. Cierre sesión y vuelva a iniciar.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.clienteActual == null || this.clienteActual.Id_Cliente == 0)
            {
                MessageBox.Show("Debe buscar y seleccionar un cliente válido antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.detallesCotizacion.Count == 0)
            {
                MessageBox.Show("El presupuesto debe contener al menos una cotización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal.TryParse(txtDescuento.Text.Trim(), out decimal porcentajeDescuento);

                decimal subtotal = ObtenerDecimalDesdeLabel(lblValorSubtotal);
                decimal totalFinal = ObtenerDecimalDesdeLabel(lblValorPresupuesto);

                Presupuesto nuevoPresupuesto = new Presupuesto()
                {
                    IdUser = idUsuarioActual,
                    FechaCreacion = DateTime.Now,
                    FechaValidez = dtpVigencia.Value, 
                    Id_Cliente = clienteActual.Id_Cliente,
                    MontoTotal = subtotal,          
                    Descuento = porcentajeDescuento, 
                    MontoFinal = totalFinal,        

                    Observaciones = txtDescripcion.Text.Trim(),
                    IdEstadoPresupuesto = 1,
                };

                int idPresupuestoCreado = clPresupuesto.GuardarNuevoPresupuesto(nuevoPresupuesto, this.detallesCotizacion);

                MessageBox.Show($"Presupuesto N° {idPresupuestoCreado} guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el presupuesto: " + ex.Message, "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal ObtenerDecimalDesdeLabel(Label lbl)
        {
            string textoLimpio = lbl.Text
                .Replace("$", "")
                .Replace(" ", "")
                .Replace(".", "") 
                .Replace(",", "."); 

            decimal valor = 0;
            decimal.TryParse(textoLimpio, System.Globalization.NumberStyles.Any,
                             System.Globalization.CultureInfo.InvariantCulture, out valor);
            return valor;
        }

        private void frmPresupuestador_Load(object sender, EventArgs e)
        {

        }

        #region Estetica Form
        private void pnlVigencia_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarRectangulo(sender as Control, e, Color.White, 1f);
        }

        private void pnlTotales_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarRectangulo(sender as Control, e, Color.White, 1f);
        }

        private void pnlPresupuesto_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarRectangulo(sender as Control, e, Color.White, 1f);
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion
        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void LimpiarFormulario()
        {
            Servicios.ClsUtilidadesForms.LimpiarControles(this);
            LimpiarCamposCliente();

            this.detallesCotizacion.Clear();
            ActualizarDataGridCotizaciones();
            lblValorSubtotal.Text = "$ 0,00";
            lblValorPresupuesto.Text = "$ 0,00";

            dtpVigencia.Value = DateTime.Now;
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            int? idUsuarioActual = ClsSesionActual.ObtenerUsuario()?.Id_user;

            if (idUsuarioActual == null || idUsuarioActual == 0)
            {
                MessageBox.Show("No se pudo identificar al usuario logueado.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.clienteActual == null || this.clienteActual.Id_Cliente == 0)
            {
                MessageBox.Show("Debe buscar y seleccionar un cliente válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.detallesCotizacion.Count == 0)
            {
                MessageBox.Show("La venta debe contener al menos una cotización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal.TryParse(txtDescuento.Text.Trim(), out decimal porcentajeDescuento);
                decimal subtotal = ObtenerDecimalDesdeLabel(lblValorSubtotal);
                decimal totalFinal = ObtenerDecimalDesdeLabel(lblValorPresupuesto);

                Presupuesto nuevoPresupuesto = new Presupuesto()
                {
                    IdUser = idUsuarioActual,
                    FechaCreacion = DateTime.Now,
                    FechaValidez = dtpVigencia.Value,
                    Id_Cliente = clienteActual.Id_Cliente,
                    MontoTotal = subtotal,
                    Descuento = porcentajeDescuento,
                    MontoFinal = totalFinal,
                    Observaciones = txtDescripcion.Text.Trim(),
                    IdEstadoPresupuesto = 1, // Estado inicial del nuevo Presupuesto
                };

                int idPresupuestoAsociado = clPresupuesto.GuardarNuevoPresupuesto(nuevoPresupuesto, this.detallesCotizacion);

                DtoVenta nuevaVenta = new DtoVenta()
                {
                    MontoTotal = subtotal,
                    Descuento = porcentajeDescuento,
                    MontoFinal = totalFinal,
                    Observaciones = txtDescripcion.Text.Trim(),
                    Activo = true,

                    IdPresupuesto = idPresupuestoAsociado, 
                    IdVendedor = idUsuarioActual,          
                    IdEstadoVenta = 1,                     
                    FechaVenta = DateTime.Now,
                };

                int idVentaCreada = clVenta.RegistrarNuevaVenta(nuevaVenta);

                MessageBox.Show($"Venta N° {idVentaCreada} registrada exitosamente. Presupuesto N° {idPresupuestoAsociado} asociado.", "Éxito de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta. Por favor, revise la conexión y los datos.\nDetalle: " + ex.Message, "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
