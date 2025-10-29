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

        private void ConfigurarDatagrid()
        {
            dgvPresupuesto.ReadOnly = false; 

            dgvPresupuesto.AllowUserToAddRows = false;
            dgvPresupuesto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPresupuesto.MultiSelect = false;
            dgvPresupuesto.RowHeadersVisible = false;

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
            // Configurar ComboBox de Tipo Documento
            var tiposDocumento = _logicaTipoDoc.MostrarTiposDocumento();
            if (cmbDni != null) // Si tienes ComboBox para tipo documento
            {
                cmbDni.DataSource = tiposDocumento;
                cmbDni.DisplayMember = "Id_TipoDocumento"; 
                cmbDni.ValueMember = "Id_TipoDocumento";
                cmbDni.SelectedIndex = -1;
            }
            // Configurar campos como solo lectura
            txtNombreCliente.ReadOnly = true;
            txtApellidoCliente.ReadOnly = true;
            txtTelefonoCliente.ReadOnly = true;
            txtMailCliente.ReadOnly = true;

            // Configurar colores para campos de solo lectura
            txtNombreCliente.BackColor = System.Drawing.SystemColors.Control;
            txtApellidoCliente.BackColor = System.Drawing.SystemColors.Control;
            txtTelefonoCliente.BackColor = System.Drawing.SystemColors.Control;
            txtMailCliente.BackColor = System.Drawing.SystemColors.Control;

            LimpiarCamposCliente();
        }
        private void CargarEventos()
        {
            // Validación de entrada solo números en documento
            txtDni.KeyPress += txtDni_Keypress;

            // Enter en el campo documento ejecuta la búsqueda
            txtDni.KeyDown += txtDni_KeyDown;
        }
        #region Seccion Cliente
        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            string tipoDoc = cmbDni.SelectedValue.ToString();
            string dni = txtDni.Text.Trim();


            // Limpiar los campos de cliente antes de la búsqueda
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
                    // Cliente encontrado: Cargar datos en los TextBoxes
                    txtNombreCliente.Text = cliente.Nombre;
                    txtApellidoCliente.Text = cliente.Apellido;
                    txtTelefonoCliente.Text = cliente.Telefono;
                    txtMailCliente.Text = cliente.Email;
                    // Aquí podrías guardar el ID del cliente o el objeto DtoCliente
                    // en una variable a nivel de formulario para usarlo al Guardar el Presupuesto.
                    this.clienteActual = cliente;
                    MessageBox.Show("Cliente encontrado exitosamente.", "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cliente no encontrado
                    MessageBox.Show($"No se encontró un cliente con el DNI: {dni}.", "Cliente No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Opcional: Podrías abrir un formulario para registrar el nuevo cliente aquí.
                }
            }
            catch (ArgumentException argEx)
            {
                // Manejo de la validación de DNI vacío de la capa de Lógica
                MessageBox.Show(argEx.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejo de errores de la lógica o del DAO (conexión, BD, etc.)
                MessageBox.Show("Ocurrió un error al buscar el cliente. Por favor, intente de nuevo.\nDetalle: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDni_Keypress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control (backspace, delete, etc)
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
            // 1. Instanciar el formulario de búsqueda
            using (frmBuscarPresupuesto frmBusqueda = new frmBuscarPresupuesto())
            {
                // 2. Mostrarlo como diálogo (bloquea el formulario principal)
                if (frmBusqueda.ShowDialog() == DialogResult.OK)
                {
                    // 3. Si el resultado es OK, recupera el DTO devuelto
                    DtoPresupuestoFiltro filtroSeleccionado = frmBusqueda.PresupuestoSeleccionado;

                    if (filtroSeleccionado != null)
                    {
                        try
                        {
                            // 4. Usar el ID para cargar el DTO Presupuesto completo desde la DB
                            Presupuesto presupuestoCompleto = clPresupuesto.CargarPresupuestoCompleto(filtroSeleccionado.IdPresupuesto);
                            
                            //  Cargar los detalles para la grilla
                            this.detallesCotizacion = clPresupuesto.ObtenerDetalles(filtroSeleccionado.IdPresupuesto);

                            // 5. Rellenar los campos del formulario principal (frmPresupuestador)
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

        // B. Método de Relleno (Ejemplo)

        private void CargarPresupuestoEnFormulario(Presupuesto p)
        {
            if (p != null)
            {
                // Ejemplo de relleno de campos:
                // Cargar Cliente:
                // this.CargarClientePorId(p.IdCliente);

                // Cargar Datos del Presupuesto:

                txtDescripcion.Text = p.Observaciones;

                // Si la fechaValidez es nullable (DateTime?), usar GetValueOrDefault
                dtpVigencia.Value = p.FechaValidez.GetValueOrDefault(DateTime.Now);

                // Cargar totales

                lblValorSubtotal.Text = "$ " + p.MontoTotal.ToString();
                txtDescuento.Text = p.PorcentajeDescuento.ToString();
                lblValorPresupuesto.Text = "$ " + p.MontoFinal.ToString();

                // Cargar DataGrid:
                ActualizarDataGridCotizaciones();
                ConfigurarDatagrid();



                MessageBox.Show($"Presupuesto N° {p.Numero} cargado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void ActualizarDataGridCotizaciones()
        {
            // dgvCotizaciones es el nombre de tu DataGrid
            dgvPresupuesto.DataSource = null;
            dgvPresupuesto.DataSource = this.detallesCotizacion;
            // Puedes llamar a este método también para limpiar la grilla al iniciar un nuevo presupuesto.
        }
        #endregion

        // PRESUPUESTADOR POR CLAUDIO
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

            // Agregar nueva fila
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
                // ... (tu código de cálculo del subtotal) ...
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

            // --- 1. Obtener Subtotal y Limpiar (CRÍTICO) ---
            string subtotalTexto = lblValorSubtotal.Text.Trim();

            // 1a. Limpiar el símbolo '$' y el separador de miles (el punto en formato local: $ 21.450,00)
            string subtotalLimpio = subtotalTexto
                .Replace("$", "")
                .Replace(" ", "")
                .Replace(".", "") // Elimina el separador de miles (el punto)
                .Replace(",", "."); // 🛑 Convierte el separador decimal (la coma) en punto

            // 1b. Usamos TryParse con InvariantCulture (espera punto como decimal)
            if (!decimal.TryParse(subtotalLimpio,
                                  System.Globalization.NumberStyles.Any, // Acepta cualquier estilo de número
                                  System.Globalization.CultureInfo.InvariantCulture, // Espera punto como decimal
                                  out subtotal))
            {
                MessageBox.Show("Error de formato: El subtotal no pudo ser interpretado como número.", "Error de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 2. Obtener Porcentaje de Descuento de forma segura ---
            if (!decimal.TryParse(txtDescuento.Text.Trim(), out porcentajeDescuento))
            {
                porcentajeDescuento = 0;
            }
            porcentajeDescuento = Math.Max(0, Math.Min(100, porcentajeDescuento));


            // --- 3. Cálculo Final ---
            decimal total = subtotal * (1 - (porcentajeDescuento / 100));

            // --- 4. Asignación del Resultado ---
            // Usamos InvariantCulture para la asignación para consistencia.
            lblValorPresupuesto.Text = "$ " + total.ToString("N2", System.Globalization.CultureInfo.CurrentCulture);
        }




        //private void btnVenta_Click(object sender, EventArgs e)
        //{
        //    // Validaciones
        //    if (clienteActual == null)
        //    {
        //        MessageBox.Show("Debe seleccionar un cliente.");
        //        return;
        //    }

        //    if (dgvPresupuesto.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Debe agregar al menos una cotización.");
        //        return;
        //    }

        //    // Guardar presupuesto
        //    try
        //    {
        //        int idPresupuesto = GuardarPresupuesto();
        //        GuardarPresupuestoCotizaciones(idPresupuesto);

        //        MessageBox.Show("Presupuesto guardado exitosamente.");
        //        LimpiarFormulario();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al guardar: " + ex.Message);
        //    }
        //}


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int? idUsuarioActual = ClsSesionActual.ObtenerUsuario()?.Id_user; 

            // 🛑 Nueva Validación: Usuario logueado (CRÍTICO)
            if (idUsuarioActual == null || idUsuarioActual == 0)
            {
                MessageBox.Show("No se pudo identificar al usuario logueado. Cierre sesión y vuelva a iniciar.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validar datos básicos
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
                // 1. Obtener los valores numéricos del pie del presupuesto

                // Usamos los métodos de TryParse robustos que ya implementamos
                decimal.TryParse(txtDescuento.Text.Trim(), out decimal porcentajeDescuento);

                // Usar los valores limpios de los labels (necesitan la limpieza si no están como decimales puros)
                decimal subtotal = ObtenerDecimalDesdeLabel(lblValorSubtotal);
                decimal totalFinal = ObtenerDecimalDesdeLabel(lblValorPresupuesto);

                // 2. Crear el objeto Presupuesto de Entidades
                Presupuesto nuevoPresupuesto = new Presupuesto()
                {
                    // Parámetros obligatorios
                    IdUser = idUsuarioActual,
                    FechaCreacion = DateTime.Now,
                    FechaValidez = dtpVigencia.Value, // La fecha de vigencia del DateTimePicker
                    Id_Cliente = clienteActual.Id_Cliente,
                    // Totales (sin formato de moneda, solo el valor decimal)
                    MontoTotal = subtotal,          // El subtotal (antes de descuento)
                    Descuento = porcentajeDescuento, // El porcentaje de descuento
                    MontoFinal = totalFinal,        // El monto final (aplicado el descuento)

                    // Otros parámetros (si los tienes)
                    Observaciones = txtDescripcion.Text.Trim(),
                    IdEstadoPresupuesto = 1,
                };

                // 3. Almacenar el Presupuesto y sus Detalles en la Lógica
                // La lista 'this.detallesCotizacion' ya está actualizada con todos los ítems.
                int idPresupuestoCreado = clPresupuesto.GuardarNuevoPresupuesto(nuevoPresupuesto, this.detallesCotizacion);

                MessageBox.Show($"Presupuesto N° {idPresupuestoCreado} guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Limpiar el formulario para un nuevo presupuesto
                // LimpiarFormulario(); 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el presupuesto: " + ex.Message, "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para obtener el decimal de los Labels con formato de moneda
        private decimal ObtenerDecimalDesdeLabel(Label lbl)
        {
            string textoLimpio = lbl.Text
                .Replace("$", "")
                .Replace(" ", "")
                .Replace(".", "") // Elimina el separador de miles (punto)
                .Replace(",", "."); // Convierte el separador decimal (coma) a punto

            decimal valor = 0;
            decimal.TryParse(textoLimpio, System.Globalization.NumberStyles.Any,
                             System.Globalization.CultureInfo.InvariantCulture, out valor);
            return valor;
        }

        private void frmPresupuestador_Load(object sender, EventArgs e)
        {

        }

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

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }

}
