using Datos;
using Entidades;
using Entidades.DTOs;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmPresupuestador : Form
    {
        public frmPresupuestador()
        {
            InitializeComponent();
            ConfigurarControles();
            CargarEventos();
        }

        private CL_Clientes clCliente = new CL_Clientes();
        private DtoCliente clienteActual = new DtoCliente();
        private CL_TipoDoc _logicaTipoDoc = new CL_TipoDoc();
        private CL_Presupuesto clPresupuesto = new CL_Presupuesto();
        private List<DtoPresupuestoDetalle> detallesCotizacion = new List<DtoPresupuestoDetalle>(); 

        private void ConfigurarControles()
        {
            // Configurar ComboBox de Tipo Documento
            var tiposDocumento = _logicaTipoDoc.MostrarTiposDocumento();
            if (cmbDni != null) // Si tienes ComboBox para tipo documento
            {
                cmbDni.DataSource = tiposDocumento;
                cmbDni.DisplayMember = "Id_TipoDocumento"; // Cambiar para mostrar descripción
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

            // Limpiar campos al inicio
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
            // Limpiar otras propiedades del cliente si es necesario
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
                lblValorSubtotal.Text = p.MontoTotal.ToString("C2");
                txtDescuento.Text = p.Descuento.ToString("N2"); // Descuento sin símbolo de moneda
                lvlValorPresupuesto.Text = p.MontoFinal.ToString("C2");

                // Cargar DataGrid:
                detallesCotizacion = clPresupuesto.ObtenerDetalles(p.IdPresupuesto);
                ActualizarDataGridCotizaciones();

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

        //// PRESUPUESTADOR POR CLAUDIO
        //public void AgregarCotizacion(int idCotizacion, string numeroCotizacion,
        //                       string descripcion, decimal montoTotal)
        //{
        //    // Verificar que no esté ya agregada
        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        if (Convert.ToInt32(row.Cells["Id_Cotizacion"].Value) == idCotizacion)
        //        {
        //            MessageBox.Show("Esta cotización ya está en el presupuesto.");
        //            return;
        //        }
        //    }

        //    // Agregar nueva fila
        //    dataGridView1.Rows.Add(idCotizacion, numeroCotizacion, descripcion, montoTotal);
        //    CalcularSubtotal();
        //}

        //// O mejor aún, recibir el objeto completo
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
        //private void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    // Abrir formulario de búsqueda de cotizaciones
        //    frmBuscarCotizacion frmBuscar = new frmBuscarCotizacion();

        //    if (frmBuscar.ShowDialog() == DialogResult.OK)
        //    {
        //        var cotizacion = frmBuscar.CotizacionSeleccionada;
        //        AgregarCotizacion(cotizacion);
        //    }
        //}
        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Seleccione una cotización para editar.");
        //        return;
        //    }

        //    int idCotizacion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Cotizacion"].Value);

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
        //private void btnBorrar_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Seleccione una cotización para eliminar.");
        //        return;
        //    }

        //    DialogResult resultado = MessageBox.Show(
        //        "¿Está seguro de eliminar esta cotización del presupuesto?",
        //        "Confirmar eliminación",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question
        //    );

        //    if (resultado == DialogResult.Yes)
        //    {
        //        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        //        CalcularSubtotal();
        //    }
        //}
        //private void btnSubtotal_Click(object sender, EventArgs e)
        //{
        //    CalcularSubtotal();
        //}

        //private void CalcularSubtotal()
        //{
        //    decimal subtotal = 0;

        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        if (row.Cells["MontoTotal"].Value != null)
        //        {
        //            subtotal += Convert.ToDecimal(row.Cells["MontoTotal"].Value);
        //        }
        //    }

        //    lblValorSubtotal.Text = subtotal.ToString("N2");
        //    AplicarDescuento(); // Si ya hay descuento aplicado
        //}
        //private void btnAplicar_Click(object sender, EventArgs e)
        //{
        //    AplicarDescuento();
        //}

        //private void AplicarDescuento()
        //{
        //    if (string.IsNullOrEmpty(lblValorSubtotal.Text)) return;

        //    decimal subtotal = Convert.ToDecimal(lblValorSubtotal.Text);
        //    decimal porcentajeDescuento = 0;

        //    if (!string.IsNullOrEmpty(txtDescuento.Text))
        //    {
        //        porcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
        //    }

        //    decimal montoDescuento = subtotal * (porcentajeDescuento / 100);
        //    decimal total = subtotal - montoDescuento;

        //    lvlValorPresupuesto.Text = total.ToString("N2");
        //}
        //private void btnVenta_Click(object sender, EventArgs e)
        //{
        //    // Validaciones
        //    if (clienteActual == null)
        //    {
        //        MessageBox.Show("Debe seleccionar un cliente.");
        //        return;
        //    }

        //    if (dataGridView1.Rows.Count == 0)
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




    }

}
