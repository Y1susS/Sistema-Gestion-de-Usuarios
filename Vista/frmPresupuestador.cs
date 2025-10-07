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
            // Evento del botón buscar
            btnBuscarDni.Click += btnBuscarDni_Click;

            // Validación de entrada solo números en documento
            txtDni.KeyPress += txtDni_Keypress;

            // Enter en el campo documento ejecuta la búsqueda
            txtDni.KeyDown += txtDni_KeyDown;
        }

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
                    // this.clienteActual = cliente;
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
    }

}
