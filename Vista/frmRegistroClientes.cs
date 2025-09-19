using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Entidades.DTOs;
using Entidades;

namespace Vista
{
    public partial class frmRegistroClientes : Form
    {
        private const string PLACEHOLDER_APELLIDO = "Apellido";
        private const string PLACEHOLDER_NOMBRE = "Nombres";
        private const string PLACEHOLDER_TIPO_DOCUMENTO = "Tipo de Documento";
        private const string PLACEHOLDER_NUMERO_DOCUMENTO = "Numero de documento";
        private const string PLACEHOLDER_TELEFONO = "Telefono";
        private const string PLACEHOLDER_EMAIL = "E-mail";
        private const string PLACEHOLDER_CALLE = "Calle";
        private const string PLACEHOLDER_NUMERO_CALLE = "Altura";
        private const string PLACEHOLDER_PISO = "Piso";
        private const string PLACEHOLDER_DEPARTAMENTO = "Dpto";

        private readonly CL_Clientes _logicaClientes = new CL_Clientes();
        private readonly CL_Partido _logicaPartido = new CL_Partido();
        private readonly CL_Localidad _logicaLocalidad = new CL_Localidad();
        private readonly CL_TipoDoc _logicaTipoDoc = new CL_TipoDoc();

        // Variables para manejar la edición
        private bool modoEdicion = false;
        private int idClienteSeleccionado = 0;

        public frmRegistroClientes()
        {
            InitializeComponent();
        }

        private void frmRegistroClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.BeginInvoke(new Action(() => this.ActiveControl = null));
                InicializarFormulario();
                LimpiarFormulario();
                CargarCombos();
                ConfigurarComboBoxes();
                MostrarClientes(); // Cargar los clientes al inicio
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarFormulario()
        {
            // Configurar el DataGridView
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Id_Cliente", "ID");
                dataGridView1.Columns["Id_Cliente"].Visible = false; // Ocultar ID
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Apellido", "Apellido");
                dataGridView1.Columns.Add("NroDocumento", "Documento");
                dataGridView1.Columns.Add("Email", "Email");
                dataGridView1.Columns.Add("Telefono", "Teléfono");
                dataGridView1.Columns.Add("FechaRegistro", "Fecha Registro");
                dataGridView1.Columns.Add("Activo", "Activo");
            }

            // Configurar eventos
            dataGridView1.CellClick += DataGridView1_CellClick;

            // Configurar botones inicialmente
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void MostrarClientes()
        {
            try
            {
                var clientes = _logicaClientes.ListarClientes();
                dataGridView1.Rows.Clear();

                foreach (var cliente in clientes)
                {
                    int rowIdx = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIdx].Cells["Id_Cliente"].Value = cliente.Id_Cliente;
                    dataGridView1.Rows[rowIdx].Cells["Nombre"].Value = cliente.Nombre;
                    dataGridView1.Rows[rowIdx].Cells["Apellido"].Value = cliente.Apellido;
                    dataGridView1.Rows[rowIdx].Cells["NroDocumento"].Value = cliente.NroDocumento;
                    dataGridView1.Rows[rowIdx].Cells["Email"].Value = cliente.Email;
                    dataGridView1.Rows[rowIdx].Cells["Telefono"].Value = cliente.Telefono;
                    dataGridView1.Rows[rowIdx].Cells["FechaRegistro"].Value = cliente.FechaRegistro.ToString("dd/MM/yyyy");
                    dataGridView1.Rows[rowIdx].Cells["Activo"].Value = cliente.Activo ? "Sí" : "No";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que sea una fila válida
            {
                try
                {
                    // Obtener el ID del cliente seleccionado
                    idClienteSeleccionado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Cliente"].Value);
                    
                    // Obtener los datos del cliente para cargar en el formulario
                    var cliente = _logicaClientes.ObtenerClientePorId(idClienteSeleccionado);
                    
                    if (cliente != null)
                    {
                        CargarDatosClienteEnFormulario(cliente);
                        ActivarModoEdicion();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarDatosClienteEnFormulario(DtoCliente cliente)
        {
            // Cargar datos en los campos de texto
            txtnombre.Text = cliente.Nombre;
            txtapellido.Text = cliente.Apellido;
            txtnumerodocumento.Text = cliente.NroDocumento;
            txtemail.Text = cliente.Email;
            txttelefono.Text = cliente.Telefono;
            txtcalle.Text = cliente.Calle;
            txtnumerocalle.Text = cliente.Nro.ToString();
            txtpiso.Text = cliente.Piso;
            txtderpatamento.Text = cliente.Depto;

            // Cargar ComboBoxes
            if (cmbTipoDoc != null)
                cmbTipoDoc.SelectedValue = cliente.Id_TipoDocumento;

            // Cargar partido y localidad (requiere lógica especial)
            CargarPartidoYLocalidadCliente(cliente);
        }

        private void CargarPartidoYLocalidadCliente(DtoCliente cliente)
        {
            try
            {
                // Obtener información completa de la localidad
                var localidad = _logicaLocalidad.ObtenerLocalidadPorId(cliente.Id_Localidad);
                
                if (localidad != null && cmbPartido != null && cmbLocalidad != null)
                {
                    // Desconectar evento temporalmente
                    cmbPartido.SelectedIndexChanged -= CmbPartido_SelectedIndexChanged;
                    
                    // Seleccionar el partido
                    cmbPartido.SelectedValue = localidad.Id_Partido;
                    
                    // Reconectar evento
                    cmbPartido.SelectedIndexChanged += CmbPartido_SelectedIndexChanged;
                    
                    // Cargar localidades del partido
                    CargarLocalidadesPorPartido(localidad.Id_Partido);
                    
                    // Seleccionar la localidad específica
                    cmbLocalidad.SelectedValue = cliente.Id_Localidad;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ubicación del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivarModoEdicion()
        {
            modoEdicion = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnAgregar.Text = "Nuevo"; // Cambiar texto del botón
        }

        private void CargarCombos()
        {
            try
            {
                // Cargar Tipos de Documento
                var tiposDocumento = _logicaTipoDoc.MostrarTiposDocumento();
                if (cmbTipoDoc != null) // Si tienes ComboBox para tipo documento
                {
                    cmbTipoDoc.DataSource = tiposDocumento;
                    cmbTipoDoc.DisplayMember = "Id_TipoDocumento"; // Cambiar para mostrar descripción
                    cmbTipoDoc.ValueMember = "Id_TipoDocumento";
                    cmbTipoDoc.SelectedIndex = -1;
                }

                // Cargar Partidos
                var partidos = _logicaPartido.MostrarPartidos();
                if (cmbPartido != null) // Si tienes ComboBox para partido
                {
                    cmbPartido.DataSource = partidos;
                    cmbPartido.DisplayMember = "Partido";
                    cmbPartido.ValueMember = "Id_Partido";
                    cmbPartido.SelectedIndex = -1;
                }

                // Limpiar Localidades inicialmente
                if (cmbLocalidad != null)
                {
                    cmbLocalidad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarComboBoxes()
        {
            // Configurar ComboBoxes como DropDownList
            if (cmbTipoDoc != null)
                cmbTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            
            if (cmbPartido != null)
            {
                cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPartido.SelectedIndexChanged += CmbPartido_SelectedIndexChanged;
            }
            
            if (cmbLocalidad != null)
                cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPartido.SelectedValue != null && int.TryParse(cmbPartido.SelectedValue.ToString(), out int idPartido))
                {
                    CargarLocalidadesPorPartido(idPartido);
                }
                else
                {
                    if (cmbLocalidad != null)
                        cmbLocalidad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (cmbLocalidad != null)
                    cmbLocalidad.DataSource = null;
            }
        }

        private void CargarLocalidadesPorPartido(int idPartido)
        {
            try
            {
                if (idPartido > 0)
                {
                    var localidades = _logicaLocalidad.MostrarLocalidades(idPartido);
                    if (cmbLocalidad != null)
                    {
                        cmbLocalidad.DataSource = localidades;
                        cmbLocalidad.DisplayMember = "Localidad";
                        cmbLocalidad.ValueMember = "Id_Localidad";
                        cmbLocalidad.SelectedIndex = -1;
                    }
                }
                else
                {
                    if (cmbLocalidad != null)
                        cmbLocalidad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (cmbLocalidad != null)
                    cmbLocalidad.DataSource = null;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(ObtenerTextoSinPlaceholder(txtnombre, PLACEHOLDER_NOMBRE)))
            {
                MessageBox.Show("Debe ingresar el nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(ObtenerTextoSinPlaceholder(txtapellido, PLACEHOLDER_APELLIDO)))
            {
                MessageBox.Show("Debe ingresar el apellido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtapellido.Focus();
                return false;
            }

            // Validar Tipo de Documento
            if (cmbTipoDoc != null && cmbTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoDoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(ObtenerTextoSinPlaceholder(txtnumerodocumento, PLACEHOLDER_NUMERO_DOCUMENTO)))
            {
                MessageBox.Show("Debe ingresar el número de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnumerodocumento.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(ObtenerTextoSinPlaceholder(txtemail, PLACEHOLDER_EMAIL)) || 
                !ObtenerTextoSinPlaceholder(txtemail, PLACEHOLDER_EMAIL).Contains("@"))
            {
                MessageBox.Show("Debe ingresar un email válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return false;
            }

            // Validar Partido y Localidad
            if (cmbPartido != null && cmbPartido.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un partido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPartido.Focus();
                return false;
            }

            if (cmbLocalidad != null && cmbLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una localidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLocalidad.Focus();
                return false;
            }

            return true;
        }

        private DtoPersona CrearDtoPersonaDesdeFormulario()
        {
            var persona = new DtoPersona
            {
                Nombre = ObtenerTextoSinPlaceholder(txtnombre, PLACEHOLDER_NOMBRE),
                Apellido = ObtenerTextoSinPlaceholder(txtapellido, PLACEHOLDER_APELLIDO),
                Id_TipoDocumento = cmbTipoDoc?.SelectedValue?.ToString() ?? string.Empty,
                NroDocumento = ObtenerTextoSinPlaceholder(txtnumerodocumento, PLACEHOLDER_NUMERO_DOCUMENTO),
                Email = ObtenerTextoSinPlaceholder(txtemail, PLACEHOLDER_EMAIL),
                Telefono = ObtenerTextoSinPlaceholder(txttelefono, PLACEHOLDER_TELEFONO),
                Calle = ObtenerTextoSinPlaceholder(txtcalle, PLACEHOLDER_CALLE),
                Nro = ObtenerNumeroDesdeTexto(txtnumerocalle, PLACEHOLDER_NUMERO_CALLE),
                Piso = ObtenerTextoSinPlaceholder(txtpiso, PLACEHOLDER_PISO),
                Depto = ObtenerTextoSinPlaceholder(txtderpatamento, PLACEHOLDER_DEPARTAMENTO),
                Id_Localidad = cmbLocalidad?.SelectedValue != null ?
                              (int)cmbLocalidad.SelectedValue : 1 // Valor por defecto
            };

            return persona;
        }

        private string ObtenerTextoSinPlaceholder(TextBox textBox, string placeholder)
        {
            return textBox.Text == placeholder ? string.Empty : textBox.Text.Trim();
        }

        private int ObtenerNumeroDesdeTexto(TextBox textBox, string placeholder)
        {
            string texto = ObtenerTextoSinPlaceholder(textBox, placeholder);
            return int.TryParse(texto, out int numero) ? numero : 0;
        }

        private void LimpiarFormulario()
        {
            // Restaurar placeholders en todos los campos de texto
            ClsPlaceHolder.Leave(PLACEHOLDER_APELLIDO, txtapellido);
            ClsPlaceHolder.Leave(PLACEHOLDER_NOMBRE, txtnombre);
            ClsPlaceHolder.Leave(PLACEHOLDER_NUMERO_DOCUMENTO, txtnumerodocumento);
            ClsPlaceHolder.Leave(PLACEHOLDER_TELEFONO, txttelefono);
            ClsPlaceHolder.Leave(PLACEHOLDER_EMAIL, txtemail);
            ClsPlaceHolder.Leave(PLACEHOLDER_CALLE, txtcalle);
            ClsPlaceHolder.Leave(PLACEHOLDER_NUMERO_CALLE, txtnumerocalle);
            ClsPlaceHolder.Leave(PLACEHOLDER_PISO, txtpiso);
            ClsPlaceHolder.Leave(PLACEHOLDER_DEPARTAMENTO, txtderpatamento);

            // Limpiar ComboBoxes si existen
            if (cmbTipoDoc != null)
                cmbTipoDoc.SelectedIndex = -1;
            if (cmbPartido != null)
                cmbPartido.SelectedIndex = -1;
            if (cmbLocalidad != null)
                cmbLocalidad.DataSource = null;

            // Resetear modo edición
            modoEdicion = false;
            idClienteSeleccionado = 0;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAgregar.Text = "Agregar";
        }

        private void btnVolverRegCliente_Click(object sender, EventArgs e)
        {
            frmPanelUsuarios frm = new frmPanelUsuarios();
            frm.Show();
            this.Close();
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPanelUsuarios frmPanelUsuarios = new frmPanelUsuarios();
            frmPanelUsuarios.Show();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Eventos de placeholders...
        private void txtapellido_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_APELLIDO, txtapellido);
        }

        private void txtapellido_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_APELLIDO, txtapellido);
        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_NOMBRE, txtnombre);
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_NOMBRE, txtnombre);
        }

        private void txtnumerodocumento_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_NUMERO_DOCUMENTO, txtnumerodocumento);
        }

        private void txtnumerodocumento_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_NUMERO_DOCUMENTO, txtnumerodocumento);
        }

        private void txttelefono_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_TELEFONO, txttelefono);
        }

        private void txttelefono_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_TELEFONO, txttelefono);
        }

        private void txtemail_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_EMAIL, txtemail);
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_EMAIL, txtemail);
        }

        private void txtcalle_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_CALLE, txtcalle);
        }

        private void txtcalle_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_CALLE, txtcalle);
        }

        private void txtnumerocalle_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_NUMERO_CALLE, txtnumerocalle);
        }

        private void txtnumerocalle_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_NUMERO_CALLE, txtnumerocalle);
        }

        private void txtpiso_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_PISO, txtpiso);
        }

        private void txtpiso_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_PISO, txtpiso);
        }

        private void txtdepartamento_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_DEPARTAMENTO, txtderpatamento);
        }

        private void txtdepartamento_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_DEPARTAMENTO, txtderpatamento);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                // Si está en modo edición, limpiar formulario para agregar nuevo
                LimpiarFormulario();
                return;
            }

            try
            {
                if (!ValidarCampos())
                    return;

                // Crear el DTO del cliente con los datos del formulario
                DtoPersona cliente = CrearDtoPersonaDesdeFormulario();

                // Llamar a la lógica de negocio para registrar
                if (_logicaClientes.RegistrarCliente(cliente, out string mensaje))
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    MostrarClientes(); // Refrescar la lista
                }
                else
                {
                    MessageBox.Show(mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado <= 0)
            {
                MessageBox.Show("Debe seleccionar un cliente para modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ValidarCampos())
                    return;

                // Crear el DTO del cliente con los datos del formulario
                DtoPersona persona = CrearDtoPersonaDesdeFormulario();

                // Llamar a la lógica de negocio para actualizar
                if (_logicaClientes.ActualizarCliente(idClienteSeleccionado, persona, out string mensaje))
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    MostrarClientes(); // Refrescar la lista
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado <= 0)
            {
                MessageBox.Show("Debe seleccionar un cliente para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreCliente = $"{txtnombre.Text} {txtapellido.Text}";
            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea dar de baja al cliente '{nombreCliente}'?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_logicaClientes.EliminarCliente(idClienteSeleccionado, out string mensaje))
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        MostrarClientes(); // Refrescar la lista
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
