using Entidades;
using Entidades.DTOs;
using Sesion;
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
using System.Drawing.Printing;

namespace Vista
{
    public partial class frmPresupuestador : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private string numeroPresupuestoActual; // Número del presupuesto actual (cargado o recién guardado)
        private bool presupuestoExportado = false;
        public frmPresupuestador()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            ConfigurarControles();
            CargarEventos();
            clPresupuesto.ActualizarEstadosVencidos();

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblPresupuestador);
            lblTituloNumeroPresupuesto.Visible = false;
            lblValorNumeroPresupuesto.Visible = false;

            numeroPresupuestoActual = string.Empty;
        }

        private CL_Clientes clCliente = new CL_Clientes();
        private DtoCliente clienteActual;
        private CL_TipoDoc _logicaTipoDoc = new CL_TipoDoc();
        private CL_Presupuesto clPresupuesto = new CL_Presupuesto();
        private List<DtoPresupuestoDetalle> detallesCotizacion = new List<DtoPresupuestoDetalle>();
        private CL_Ventas clVenta = new CL_Ventas();
        private CL_Cotizacion clCotizacion = new CL_Cotizacion();

        private int idPresupuestoGuardado = 0;

        private void frmPresupuestador_Load(object sender, EventArgs e)
        {
        }
        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        #region Configuraciones y Utilidades
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

            System.Globalization.CultureInfo culturaArg = new System.Globalization.CultureInfo("es-AR");

            if (dgvPresupuesto.Columns.Contains("Subtotal"))
            {
                dgvPresupuesto.Columns["Subtotal"].DefaultCellStyle.Format = "N2"; 
                dgvPresupuesto.Columns["Subtotal"].DefaultCellStyle.FormatProvider = culturaArg;
                dgvPresupuesto.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvPresupuesto.Columns.Contains("PrecioUnitario")) 
            {
                dgvPresupuesto.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2";
                dgvPresupuesto.Columns["PrecioUnitario"].DefaultCellStyle.FormatProvider = culturaArg;
                dgvPresupuesto.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                cmbDni.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void LimpiarCamposCliente()
        {
            txtNombreCliente.Text = string.Empty;
            txtApellidoCliente.Text = string.Empty;
            txtTelefonoCliente.Text = string.Empty;
            txtMailCliente.Text = string.Empty;
            this.clienteActual = null;
        }
        private void ActualizarDataGridCotizaciones()
        {
            dgvPresupuesto.DataSource = null;
            dgvPresupuesto.DataSource = this.detallesCotizacion;
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

        private void LimpiarFormulario()
        {
            Servicios.ClsUtilidadesForms.LimpiarControles(this);
            LimpiarCamposCliente();

            this.detallesCotizacion.Clear();
            ActualizarDataGridCotizaciones();
            lblValorSubtotal.Text = "$ 0,00";
            lblValorPresupuesto.Text = "$ 0,00";
            dgvPresupuesto.DataSource = null;

            dtpVigencia.CustomFormat = " ";
            dtpVigencia.Format = DateTimePickerFormat.Custom;
            numeroPresupuestoActual = string.Empty;
            if (lblValorNumeroPresupuesto != null)
            {
                lblValorNumeroPresupuesto.Text = string.Empty;
                lblValorNumeroPresupuesto.Visible = false;
                lblTituloNumeroPresupuesto.Visible = false;
            }
            idPresupuestoGuardado = 0;

        }

        #endregion

        #region Cliente
        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            if (cmbDni.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Documento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarCamposCliente();
                return;
            }
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

        #endregion

        #region Seleccion Presupuesto
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

                            if (presupuestoCompleto.Id_Cliente.HasValue)
                            {
                                clienteActual = clCliente.ObtenerClientePorId(presupuestoCompleto.Id_Cliente.Value);
                                presupuestoCompleto.Cliente = clienteActual; // Opcional: para consistencia si agregas la propiedad Cliente en Presupuesto.
                            }
                            else
                            {
                                clienteActual = null;
                            }

                            CargarPresupuestoEnFormulario(presupuestoCompleto);
                            CargarDatosClienteEnFormulario(presupuestoCompleto);
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
                const int ESTADO_VENCIDO = 2;

                if (p.IdEstadoPresupuesto == ESTADO_VENCIDO)
                {
                    MessageBox.Show("¡Advertencia! Este presupuesto se encuentra en estado VENCIDO y puede que necesite una revisión de precios.",
                                    "Presupuesto Vencido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }

                // Cargar Datos del Presupuesto:
                txtDescripcion.Text = p.Observaciones;
                dtpVigencia.Value = p.FechaValidez.GetValueOrDefault(DateTime.Now);

                // Cargar totales
                lblValorSubtotal.Text = "$ " + p.MontoTotal.ToString("N2"); 
                txtDescuento.Text = p.Descuento.ToString();
                lblValorPresupuesto.Text = "$ " + p.MontoFinal.ToString("N2"); 

                if (p.IdPresupuesto > 0)
                {
                    this.idPresupuestoGuardado = p.IdPresupuesto;

                    string parteNumericaFormateada = p.IdPresupuesto.ToString("D6");
                    string numeroPresupuestoFormateado = "P00-" + parteNumericaFormateada;

                    if (lblValorNumeroPresupuesto != null) // <-- AGREGAR ESTA VERIFICACIÓN
                    {
                        lblValorNumeroPresupuesto.Text = numeroPresupuestoFormateado;
                        lblTituloNumeroPresupuesto.Visible = true;
                        lblValorNumeroPresupuesto.Visible = true;
                        numeroPresupuestoActual = numeroPresupuestoFormateado;
                    }
                }
                else
                {
                    this.idPresupuestoGuardado = 0;
                }

                ActualizarDataGridCotizaciones();
                ConfigurarDatagrid();

                MessageBox.Show($"Presupuesto N° {this.numeroPresupuestoActual} cargado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.presupuestoExportado = false; // Resetear estado de exportación
            }
        }

        private void CargarDatosClienteEnFormulario(Presupuesto p)
        {
            // Verifica que tanto el presupuesto como el objeto Cliente dentro del presupuesto no sean nulos.
            if (p != null && p.Cliente != null)
            {
                this.clienteActual = p.Cliente;

                // 2. Llenar los TextBoxes de Cliente
                txtNombreCliente.Text = clienteActual.Nombre;
                txtApellidoCliente.Text = clienteActual.Apellido;
                txtTelefonoCliente.Text = clienteActual.Telefono;
                txtMailCliente.Text = clienteActual.Email;

                // 3. Llenar DNI (TextBox y ComboBox)
                txtDni.Text = clienteActual.NroDocumento;
                int idTipoDocumento = 0;
                int.TryParse(clienteActual.Id_TipoDocumento, out idTipoDocumento);

                if (cmbDni.DataSource != null && !string.IsNullOrEmpty(clienteActual.Id_TipoDocumento))
                {
                    // Seleccionar el item en el ComboBox usando el Id_TipoDocumento
                    cmbDni.SelectedValue = clienteActual.Id_TipoDocumento;
                }
                else
                {
                    cmbDni.SelectedIndex = -1;
                }
            }
            else
            {
                // Si el cliente no está asociado o es nulo, limpiamos los campos del cliente.
                LimpiarCamposCliente();
                MessageBox.Show("Advertencia: El presupuesto cargado no tiene datos de cliente asociados.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Calculos para Total



        private void btnSubtotal_Click(object sender, EventArgs e)
        {
            CalcularSubtotal();
            AplicarDescuento();
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
            lblValorSubtotal.Text = "$ " + subtotal.ToString("N2", System.Globalization.CultureInfo.CurrentCulture);
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
        #endregion

        #region Manejo de Cotizaciones
        private void btnBuscarCotizacion_Click(object sender, EventArgs e)
        {
            using (frmListarCotizaciones frmBuscar = new frmListarCotizaciones(true))
            {
                if (frmBuscar.ShowDialog() == DialogResult.OK)
                {
                    if (frmBuscar.CotizacionesSeleccionadas != null && frmBuscar.CotizacionesSeleccionadas.Count > 0)
                    {
                        foreach (var detalle in frmBuscar.CotizacionesSeleccionadas)
                        {
                            AgregarDetalleCotizacion(detalle);
                        }

                        ActualizarDataGridCotizaciones();
                        ConfigurarDatagrid();
                        CalcularSubtotal();
                        AplicarDescuento();
                    }
                }
            }
        }

        private void AgregarDetalleCotizacion(DtoPresupuestoDetalle nuevoDetalle)
        {
            var existe = this.detallesCotizacion.Any(d => d.IdCotizacion == nuevoDetalle.IdCotizacion);
            if (existe)
            {
                MessageBox.Show($"La cotización N° {nuevoDetalle.NumeroCotizacion} ya fue agregada al presupuesto.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nuevoDetalle.Cantidad <= 0)
            {
                nuevoDetalle.Cantidad = 1;
            }
            this.detallesCotizacion.Add(nuevoDetalle);
        }

        private void btnEditarCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                var dgvPresupuesto = this.Controls.Find("dgvPresupuesto", true).FirstOrDefault() as DataGridView;

                if (dgvPresupuesto == null || dgvPresupuesto.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una cotización de la lista.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filaSeleccionada = dgvPresupuesto.SelectedRows[0];
                var detalleOriginal = filaSeleccionada.DataBoundItem as DtoPresupuestoDetalle;
                var listaDetalles = detallesCotizacion;

                if (detalleOriginal == null || detalleOriginal.IdCotizacion <= 0 || listaDetalles == null)
                {
                    MessageBox.Show("La cotización seleccionada no es válida o la lista de datos es inaccesible.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Guardar datos importantes antes de editar
                int indiceOriginal = listaDetalles.IndexOf(detalleOriginal);
                int cantidadOriginal = detalleOriginal.Cantidad;

                // Obtener la cotización completa desde la base de datos (plantilla)
                var cotizacionCompleta = clCotizacion.ObtenerCotizacion(detalleOriginal.IdCotizacion);
                if (cotizacionCompleta == null)
                {
                    MessageBox.Show("No se pudo cargar la cotización desde la base de datos.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir formulario de cotización para editar
                using (var frmCotizador = new frmCotizador())
                {
                    EventHandler onLoad = null;
                    onLoad = (s, ev) =>
                    {
                        frmCotizador.Load -= onLoad;
                        frmCotizador.InicializarModoPresupuestador(cotizacionCompleta);
                    };
                    frmCotizador.Load += onLoad;

                    var resultado = frmCotizador.ShowDialog(this);
                    if (resultado == DialogResult.OK)
                    {
                        int idGuardado = frmCotizador.IdCotizacionGuardada;
                        if (idGuardado > 0)
                        {
                            var nuevaCotizacionDB = clCotizacion.ObtenerCotizacion(idGuardado);
                            if (nuevaCotizacionDB != null)
                            {
                                var nuevoDetalle = new DtoPresupuestoDetalle
                                {
                                    IdPresupuesto = detalleOriginal.IdPresupuesto,
                                    IdCotizacion = nuevaCotizacionDB.Id_Cotizacion,
                                    NumeroCotizacion = nuevaCotizacionDB.NumeroCotizacion,
                                    Observaciones = nuevaCotizacionDB.DescripcionMueble,
                                    PrecioUnitario = nuevaCotizacionDB.MontoFinal,
                                    Cantidad = cantidadOriginal
                                };

                                dgvPresupuesto.EndEdit();

                                // Eliminar el detalle anterior
                                listaDetalles.Remove(detalleOriginal);

                                // Insertar el nuevo en la posición original
                                if (indiceOriginal >= 0 && indiceOriginal <= listaDetalles.Count)
                                {
                                    listaDetalles.Insert(indiceOriginal, nuevoDetalle);
                                }
                                else
                                {
                                    listaDetalles.Add(nuevoDetalle);
                                    indiceOriginal = listaDetalles.Count - 1;
                                }

                                dgvPresupuesto.Refresh();

                                MessageBox.Show($"Cotización reemplazada exitosamente con nuevo ID: {nuevoDetalle.IdCotizacion}",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Se generó un nuevo ID pero no se pudo cargar la cotización actualizada.",
                                                "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La cotización se actualizó/guardó, pero no se pudo recuperar el ID generado.",
                                            "Error de ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (resultado == DialogResult.Cancel)
                    {
                        MessageBox.Show("Edición cancelada. No se realizaron cambios.",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar la cotización: {ex.Message}\n\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
                }
                else
                {
                    dgvPresupuesto.Rows.RemoveAt(indiceFila);
                }
                CalcularSubtotal();
                AplicarDescuento();
                ConfigurarDatagrid();
                ActualizarDataGridCotizaciones();
            }
        }


        #endregion

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
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción u observación para el presupuesto.",
                                "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
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
                this.idPresupuestoGuardado = idPresupuestoCreado;

                string parteNumericaFormateada = idPresupuestoCreado.ToString("D6");
                string numeroPresupuestoFormateado = "P00-" + parteNumericaFormateada;

                if (lblValorNumeroPresupuesto != null) // <-- AGREGAR ESTA VERIFICACIÓN
                {
                    lblValorNumeroPresupuesto.Text = numeroPresupuestoFormateado;
                    lblTituloNumeroPresupuesto.Visible = true;
                    lblValorNumeroPresupuesto.Visible = true;
                    numeroPresupuestoActual = numeroPresupuestoFormateado;
                }

                MessageBox.Show($"Presupuesto N° {idPresupuestoCreado} guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el presupuesto: " + ex.Message, "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            int? idUsuarioActual = ClsSesionActual.ObtenerUsuario()?.Id_user;

            if (this.idPresupuestoGuardado == 0)
            {
                MessageBox.Show("Debe guardar el presupuesto antes de registrar la venta. Por favor, presione el botón 'Guardar'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción u observación para la venta.",
                                "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            try
            {
                decimal.TryParse(txtDescuento.Text.Trim(), out decimal porcentajeDescuento);
                decimal subtotal = ObtenerDecimalDesdeLabel(lblValorSubtotal);
                decimal totalFinal = ObtenerDecimalDesdeLabel(lblValorPresupuesto);

                DtoVenta nuevaVenta = new DtoVenta()
                {
                    MontoTotal = subtotal,
                    Descuento = porcentajeDescuento,
                    MontoFinal = totalFinal,
                    Observaciones = txtDescripcion.Text.Trim(),
                    Activo = true,
                    IdPresupuesto = this.idPresupuestoGuardado,
                    IdVendedor = idUsuarioActual,
                    IdEstadoVenta = 1,
                    FechaVenta = DateTime.Now,
                };

                int idVentaCreada = clVenta.RegistrarNuevaVenta(nuevaVenta);

                if (this.presupuestoExportado == false)
                {
                    DialogResult result = MessageBox.Show(
                        "El presupuesto no ha sido exportado. ¿Desea registrar la venta sin exportar el documento?",
                        "Confirmar Venta",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                MessageBox.Show($"Venta N° {idVentaCreada} registrada exitosamente. Presupuesto N° {this.idPresupuestoGuardado} asociado.", "Éxito de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta. Por favor, revise la conexión y los datos.\nDetalle: " + ex.Message, "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas antes de exportar
            if (this.detallesCotizacion.Count == 0)
            {
                MessageBox.Show("El presupuesto debe contener al menos una cotización para ser exportado.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";

                    string numeroParaArchivo = !string.IsNullOrWhiteSpace(numeroPresupuestoActual)
                        ? numeroPresupuestoActual
                        : (lblValorNumeroPresupuesto.Visible && !string.IsNullOrWhiteSpace(lblValorNumeroPresupuesto.Text)
                            ? lblValorNumeroPresupuesto.Text
                            : null);

                    if (string.IsNullOrWhiteSpace(numeroParaArchivo))
                    {
                        numeroParaArchivo = DateTime.Now.ToString("yyyyMMdd_HHmm");
                        MessageBox.Show("Aún no hay un número de presupuesto asignado. Se usará la fecha y hora en el nombre del archivo.",
                                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    {
                        numeroParaArchivo = numeroParaArchivo.Replace(c.ToString(), "-");
                    }

                    saveDialog.FileName = $"Presupuesto_{numeroParaArchivo}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pdfPrinterName = null;
                        foreach (string printer in PrinterSettings.InstalledPrinters)
                        {
                            if (printer.IndexOf("Microsoft Print to PDF", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                pdfPrinterName = printer;
                                break;
                            }
                        }

                        if (string.IsNullOrEmpty(pdfPrinterName))
                        {
                            MessageBox.Show("No se encontró la impresora 'Microsoft Print to PDF'. Instale una impresora PDF para exportar.",
                                            "Impresora no disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        PrintDocument pd = new PrintDocument();
                        pd.PrinterSettings.PrinterName = pdfPrinterName;
                        pd.PrinterSettings.PrintToFile = true;
                        pd.PrinterSettings.PrintFileName = saveDialog.FileName;
                        pd.PrintController = new StandardPrintController();
                        pd.DocumentName = $"Presupuesto {numeroParaArchivo}";

                        pd.PrintPage += (s, ev) =>
                        {
                            // Configuración de fuentes y layout
                            var g = ev.Graphics;
                            float y = ev.MarginBounds.Top;
                            float left = ev.MarginBounds.Left;
                            float right = ev.MarginBounds.Right;
                            float lineHeight = 18f;


                            float logoDrawnHeight = 0f;
                            try
                            {
                                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                                string logoPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, "..", "..", "Resources", "logo.png"));

                                if (System.IO.File.Exists(logoPath))
                                {
                                    using (Image logo = Image.FromFile(logoPath))
                                    {
                                        float maxLogoWidth = 170f;
                                        float scale = Math.Min(1f, maxLogoWidth / logo.Width);
                                        float logoWidth = logo.Width * scale;
                                        float logoHeight = logo.Height * scale;
                                        float logoX = left;
                                        float logoY = ev.MarginBounds.Top;
                                        g.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);
                                        logoDrawnHeight = logoHeight;
                                    }
                                }
                            }
                            catch { }

                            using (Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold))
                            using (Font subTitleFont = new Font("Segoe UI", 10, FontStyle.Regular))
                            using (Font headerFont = new Font("Segoe UI", 11, FontStyle.Bold))
                            using (Font textFont = new Font("Segoe UI", 10))
                            using (Pen pen = new Pen(Color.Black, 1))
                            {
                                float contentTop = Math.Max(y, ev.MarginBounds.Top + logoDrawnHeight + 8);

                                // Dos columnas a la misma altura: izquierda Cliente, derecha datos del documento
                                float yLeft = contentTop;
                                float yRight = contentTop;
                                float rightBlockWidth = 320f;
                                float rightX = right - rightBlockWidth;

                                // Derecha: Título, Número, Fecha, Vigencia
                                string titulo = "Presupuesto";
                                g.DrawString(titulo, titleFont, Brushes.Black, rightX, yRight);
                                yRight += titleFont.GetHeight(g) + 4;

                                g.DrawString($"N° {numeroParaArchivo}", headerFont, Brushes.Black, rightX, yRight);
                                yRight += lineHeight;

                                string fechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
                                g.DrawString($"Fecha: {fechaHoy}", subTitleFont, Brushes.Black, rightX, yRight);
                                yRight += lineHeight;

                                if (dtpVigencia.Value != DateTime.MinValue)
                                {
                                    g.DrawString($"Vigencia hasta: {dtpVigencia.Value:dd/MM/yyyy}", subTitleFont, Brushes.Black, rightX, yRight);
                                    yRight += lineHeight;
                                }

                                // Izquierda: Cliente
                                g.DrawString("Cliente", headerFont, Brushes.Black, left, yLeft);
                                yLeft += lineHeight;

                                if (clienteActual != null)
                                {
                                    g.DrawString($"Nombre: {clienteActual.Apellido}, {clienteActual.Nombre}", textFont, Brushes.Black, left, yLeft); yLeft += lineHeight;
                                    g.DrawString($"Documento: {clienteActual.Id_TipoDocumento} {clienteActual.NroDocumento}", textFont, Brushes.Black, left, yLeft); yLeft += lineHeight;
                                    g.DrawString($"Teléfono: {clienteActual.Telefono}", textFont, Brushes.Black, left, yLeft); yLeft += lineHeight;
                                    g.DrawString($"Email: {clienteActual.Email}", textFont, Brushes.Black, left, yLeft); yLeft += lineHeight;
                                }
                                else
                                {
                                    g.DrawString("Sin datos de cliente", textFont, Brushes.Black, left, yLeft); yLeft += lineHeight;
                                }

                                // Continuar debajo del bloque mayor
                                y = Math.Max(yLeft, yRight) + 10;

                                // Observaciones
                                g.DrawString("Observaciones", headerFont, Brushes.Black, left, y);
                                y += lineHeight;
                                var obs = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? "-" : txtDescripcion.Text.Trim();
                                g.DrawString(obs, textFont, Brushes.Black, new RectangleF(left, y, right - left, lineHeight * 3));
                                y += lineHeight * 3 + 6;

                                // Detalles
                                g.DrawString("Detalles", headerFont, Brushes.Black, left, y);
                                y += lineHeight;

                                float col1 = left;
                                float col2 = left + 140;
                                float col3 = right - 260;
                                float col4 = right - 180;
                                float col5 = right - 80;

                                g.DrawString("N° Cot.", textFont, Brushes.Black, col1, y);
                                g.DrawString("Descripción", textFont, Brushes.Black, col2, y);
                                g.DrawString("Cant.", textFont, Brushes.Black, col3, y);
                                g.DrawString("Precio", textFont, Brushes.Black, col4, y);
                                g.DrawString("Subtotal", textFont, Brushes.Black, col5, y);
                                y += lineHeight;
                                g.DrawLine(pen, left, y, right, y);
                                y += 4;

                                foreach (var d in detallesCotizacion)
                                {
                                    if (y + lineHeight > ev.MarginBounds.Bottom - 140)
                                    {
                                        g.DrawString("...", textFont, Brushes.Black, col2, y);
                                        y += lineHeight;
                                        break;
                                    }

                                    string precio = d.PrecioUnitario.ToString("N2");
                                    string subtotal = (d.Cantidad * d.PrecioUnitario).ToString("N2");

                                    g.DrawString(d.NumeroCotizacion, textFont, Brushes.Black, col1, y);
                                    g.DrawString(d.Observaciones, textFont, Brushes.Black, new RectangleF(col2, y, col3 - col2 - 10, lineHeight * 2));
                                    g.DrawString(d.Cantidad.ToString(), textFont, Brushes.Black, col3, y);
                                    g.DrawString(precio, textFont, Brushes.Black, col4, y);
                                    g.DrawString(subtotal, textFont, Brushes.Black, col5, y);

                                    y += lineHeight;
                                }

                                y += 8;
                                g.DrawLine(pen, left, y, right, y);
                                y += 8;

                                // Totales
                                decimal sub = ObtenerDecimalDesdeLabel(lblValorSubtotal);
                                decimal desc = 0m;
                                decimal.TryParse(txtDescuento.Text.Trim(), out desc);
                                decimal total = ObtenerDecimalDesdeLabel(lblValorPresupuesto);

                                string sSub = sub.ToString("N2");
                                string sDesc = $"{desc:N2}%";
                                string sTotal = total.ToString("N2");

                                float labelX = right - 220;
                                g.DrawString("Subtotal:", headerFont, Brushes.Black, labelX, y);
                                g.DrawString(sSub, headerFont, Brushes.Black, right - 30, y, new StringFormat { Alignment = StringAlignment.Far });
                                y += lineHeight;
                                g.DrawString("Descuento:", headerFont, Brushes.Black, labelX, y);
                                g.DrawString(sDesc, headerFont, Brushes.Black, right - 30, y, new StringFormat { Alignment = StringAlignment.Far });
                                y += lineHeight;
                                g.DrawString("Total:", headerFont, Brushes.Black, labelX, y);
                                g.DrawString(sTotal, headerFont, Brushes.Black, right - 30, y, new StringFormat { Alignment = StringAlignment.Far });
                                y += lineHeight;
                            }
                        };

                        pd.Print();

                        MessageBox.Show("Presupuesto exportado exitosamente.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.presupuestoExportado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el presupuesto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.presupuestoExportado = false;
            }
        }

    }
}
