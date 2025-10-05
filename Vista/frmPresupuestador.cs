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

        private CL_Clientes clClientes;
        private DtoCliente clienteActual;
        private CL_TipoDoc _logicaTipoDoc = new CL_TipoDoc();

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
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtMail.ReadOnly = true;

            // Configurar colores para campos de solo lectura
            txtNombre.BackColor = System.Drawing.SystemColors.Control;
            txtApellido.BackColor = System.Drawing.SystemColors.Control;
            txtTelefono.BackColor = System.Drawing.SystemColors.Control;
            txtMail.BackColor = System.Drawing.SystemColors.Control;

            // Limpiar campos al inicio
            LimpiarDatosCliente();
        }
        private void CargarEventos()
        {
            // Evento del botón buscar
            btnBuscarDni.Click += btnBuscarDni_Click;

            // Validación de entrada solo números en documento
            txtDni.KeyPress += txtDni_Keypress;

            // Enter en el campo documento ejecuta la búsqueda
            txtDni.KeyDown += txtDni_KeyDown;
        }

        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void TxtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control (backspace, delete, etc)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtNroDocumento_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void BuscarCliente()
        {
            try
            {
                // Validar que se haya ingresado un documento
                if (string.IsNullOrWhiteSpace(txtDni.Text))
                {
                    MessageBox.Show("Por favor, ingrese un número de documento",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtDni.Focus();
                    return;
                }

                // Validar longitud mínima del documento
                string nroDocumento = txtDni.Text.Trim();

                if (nroDocumento.Length < 7)
                {
                    MessageBox.Show("El número de documento debe tener al menos 7 dígitos",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtDni.Focus();
                    return;
                }

                // Cambiar cursor a espera
                this.Cursor = Cursors.WaitCursor;
                btnBuscarDni.Enabled = false;

                // Obtener todos los clientes y buscar por documento
                var clientes = clClientes.ListarClientes();

                if (clientes == null || clientes.Count == 0)
                {
                    MessageBox.Show("No hay clientes registrados en el sistema",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Buscar el cliente por número de documento (activos solamente)
                DtoCliente cliente = clientes.FirstOrDefault(c =>
                    c.NroDocumento == nroDocumento && c.Activo);

                if (cliente != null)
                {
                    // Cliente encontrado
                    clienteActual = cliente;
                    MostrarDatosCliente(cliente);

                    MessageBox.Show($"Cliente encontrado:\n{cliente.Apellido}, {cliente.Nombre}",
                        "Búsqueda Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    // Verificar si existe pero está inactivo
                    DtoCliente clienteInactivo = clientes.FirstOrDefault(c =>
                        c.NroDocumento == nroDocumento && !c.Activo);

                    if (clienteInactivo != null)
                    {
                        MessageBox.Show("El cliente con ese documento existe pero está inactivo en el sistema",
                            "Cliente Inactivo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        LimpiarDatosCliente();
                        clienteActual = null;
                    }
                    else
                    {
                        // Cliente no encontrado
                        MostrarOpcionRegistrarCliente(nroDocumento);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar cliente:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar cursor y botón
                this.Cursor = Cursors.Default;
                btnBuscarDni.Enabled = true;
            }
        }
        private void MostrarOpcionRegistrarCliente(string nroDocumento)
        {
            LimpiarDatosCliente();
            clienteActual = null;

            DialogResult resultado = MessageBox.Show(
                $"No se encontró ningún cliente con el documento: {nroDocumento}\n\n" +
                "¿Desea registrar un nuevo cliente?",
                "Cliente no encontrado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                AbrirFormularioRegistroCliente(nroDocumento);
            }
            else
            {
                txtDni.Focus();
            }
        }
        private void AbrirFormularioRegistroCliente(string nroDocumento)
        {
            try
            {
                // Aquí deberías abrir tu formulario de registro de cliente
                // Pasándole el número de documento como parámetro

                // Ejemplo (descomenta cuando tengas el formulario):
                // frmRegistroCliente frmRegistro = new frmRegistroCliente(nroDocumento);
                // DialogResult resultado = frmRegistro.ShowDialog();

                // if (resultado == DialogResult.OK)
                // {
                //     // Cliente registrado exitosamente, buscarlo nuevamente
                //     BuscarCliente();
                // }

                MessageBox.Show(
                    "El formulario de registro de cliente se abrirá próximamente.\n" +
                    $"Documento a registrar: {nroDocumento}",
                    "Funcionalidad en desarrollo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de registro:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void MostrarDatosCliente(DtoCliente cliente)
        {
            if (cliente == null)
            {
                LimpiarDatosCliente();
                return;
            }

            // Cargar datos en los controles
            txtNombre.Text = cliente.Nombre ?? string.Empty;
            txtApellido.Text = cliente.Apellido ?? string.Empty;
            txtTelefono.Text = cliente.Telefono ?? string.Empty;
            txtMail.Text = cliente.Email ?? string.Empty;

            // Cambiar color de fondo para indicar que hay datos cargados (verde claro)
            System.Drawing.Color colorExito = System.Drawing.Color.FromArgb(230, 255, 230);

            txtNombre.BackColor = colorExito;
            txtApellido.BackColor = colorExito;
            txtTelefono.BackColor = colorExito;
            txtMail.BackColor = colorExito;

            // Deshabilitar el campo de documento una vez encontrado el cliente
            txtDni.ReadOnly = true;
            txtDni.BackColor = System.Drawing.SystemColors.Control;
        }

        /// <summary>
        /// Limpia los datos del cliente de los controles
        /// </summary>
        private void LimpiarDatosCliente()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtMail.Text = string.Empty;

            // Restaurar color de fondo
            txtNombre.BackColor = System.Drawing.SystemColors.Control;
            txtApellido.BackColor = System.Drawing.SystemColors.Control;
            txtTelefono.BackColor = System.Drawing.SystemColors.Control;
            txtMail.BackColor = System.Drawing.SystemColors.Control;

            // Habilitar el campo de documento
            txtDni.ReadOnly = false;
            txtDni.BackColor = System.Drawing.SystemColors.Window;

            // Limpiar referencia al cliente actual
            clienteActual = null;
        }




        /// <summary>
        /// Valida que haya un cliente seleccionado antes de continuar
        /// </summary>
        private bool ValidarClienteSeleccionado()
        {
            if (clienteActual == null)
            {
                MessageBox.Show(
                    "Debe buscar y seleccionar un cliente antes de continuar con el presupuesto",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDni.Focus();
                return false;
            }

            if (!clienteActual.Activo)
            {
                MessageBox.Show(
                    "El cliente seleccionado está inactivo. No se pueden crear presupuestos para clientes inactivos",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                LimpiarDatosCliente();
                return false;
            }

            return true;
        }

        //Métodos Auxiliares

        /// <summary>
        /// Limpia todos los campos del formulario de presupuesto
        /// </summary>
        private void LimpiarFormularioPresupuesto()
        {
            // Limpiar datos del cliente
            txtDni.Text = string.Empty;
            LimpiarDatosCliente();

            // Limpiar tipo de documento
            cmbDni.SelectedIndex = 0;

            // Aquí limpiarías otros controles del formulario
            // - DataGridView de cotizaciones
            // - Descripción del presupuesto
            // - Totales
            // - Observaciones
            // - Fecha de validez

            // Enfocar en el campo de documento
            txtDni.Focus();
        }

        /// <summary>
        /// Obtiene el cliente actual seleccionado
        /// </summary>
        public DtoCliente ObtenerClienteActual()
        {
            return clienteActual;
        }

        /// <summary>
        /// Obtiene información completa del cliente para el presupuesto
        /// </summary>
        public string ObtenerInfoCliente()
        {
            if (clienteActual == null)
                return "No hay cliente seleccionado";

            return $"Cliente: {clienteActual.Apellido}, {clienteActual.Nombre}\n" +
                   $"Documento: {clienteActual.NroDocumento}\n" +
                   $"Email: {clienteActual.Email}\n" +
                   $"Teléfono: {clienteActual.Telefono}";
        }

        /// <summary>
        /// Permite cambiar de cliente (limpiar selección actual)
        /// </summary>
        private void CambiarCliente()
        {
            if (clienteActual != null)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea cambiar el cliente?\n" +
                    "Se perderán los datos del presupuesto actual si no los guardó.",
                    "Confirmar cambio de cliente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    LimpiarFormularioPresupuesto();
                }
            }
            else
            {
                LimpiarFormularioPresupuesto();
            }
        }


        // Métodos para otros eventos del formulario

        // Estos métodos serán útiles cuando implementes el resto del formulario

        /// <summary>
        /// Evento del botón Nuevo (si lo tienes)
        /// </summary>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            CambiarCliente();
        }

        /// <summary>
        /// Evento de carga del formulario
        /// </summary>
        private void FrmPresupuesto_Load(object sender, EventArgs e)
        {
            try
            {
                // Enfocar en el campo de documento al cargar
                txtDni.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al cerrar el formulario
        /// </summary>
        private void FrmPresupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Validar si hay cambios sin guardar
            // if (HayCambiosSinGuardar())
            // {
            //     DialogResult resultado = MessageBox.Show(
            //         "Hay cambios sin guardar. ¿Está seguro que desea salir?",
            //         "Confirmar salida",
            //         MessageBoxButtons.YesNo,
            //         MessageBoxIcon.Question);
            //     
            //     if (resultado == DialogResult.No)
            //     {
            //         e.Cancel = true;
            //     }
            // }
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDni_Keypress(object sender, KeyPressEventArgs e)
        {

        }
    }

}
