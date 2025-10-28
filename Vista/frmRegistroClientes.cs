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
        private ClsArrastrarFormularios moverFormulario;
        private readonly CL_Clientes _logicaClientes = new CL_Clientes();
        private readonly CL_Partido _logicaPartido = new CL_Partido();
        private readonly CL_Localidad _logicaLocalidad = new CL_Localidad();
        private readonly CL_TipoDoc _logicaTipoDoc = new CL_TipoDoc();

        // Variables para manejar la edición
        private bool modoEdicion = false;
        private int idClienteSeleccionado = 0;

        public frmRegistroClientes()
        {
            this.ActiveControl = null;
            InitializeComponent();
            moverFormulario = new ClsArrastrarFormularios(this);
        }

        private void frmRegistroClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = false;

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
            btnAgregar.Text = "Nuevo cliente";
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

            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtapellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtapellido.Focus();
                return false;
            }

            if (cmbTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoDoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtnumerodocumento.Text))
            {
                MessageBox.Show("Debe ingresar el número de documento", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnumerodocumento.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtemail.Text) || !txtemail.Text.Contains("@") || !txtemail.Text.Contains("."))
            {
                MessageBox.Show("Debe ingresar un correo electrónico válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return false;
            }

            // Validacion de telefono
            if (string.IsNullOrWhiteSpace(txttelefono.Text))
            {
                MessageBox.Show("Debe ingresar el número de teléfono", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttelefono.Focus();
                return false;
            }

            if (cmbPartido.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un partido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPartido.Focus();
                return false;
            }

            if (cmbLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una localidad", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLocalidad.Focus();
                return false;
            }

            return true;
        }

        private DtoPersona CrearDtoPersonaDesdeFormulario()
        {
            var persona = new DtoPersona
            {
                Nombre = txtnombre.Text,
                Apellido = txtapellido.Text,
                Id_TipoDocumento = cmbTipoDoc?.SelectedValue?.ToString() ?? string.Empty,
                NroDocumento = txtnumerodocumento.Text,
                Email = txtemail.Text,
                Telefono = txttelefono.Text,
                Calle = txtcalle.Text,
                Nro = ObtenerNumero(txtnumerocalle),
                Piso = txtpiso.Text,
                Depto = txtderpatamento.Text,
                Id_Localidad = cmbLocalidad?.SelectedValue != null ?
                              (int)cmbLocalidad.SelectedValue : 1 // Valor por defecto
            };

            return persona;
        }

        private string ObtenerTextoSinEspacios(TextBox textBox)
        {
            return textBox.Text.Trim();
        }

        private int ObtenerNumero(TextBox textBox)
        {
            string texto = ObtenerTextoSinEspacios(textBox);
            return int.TryParse(texto, out int numero) ? numero : 0;
        }

        private void LimpiarFormulario()
        {
            // Limpia TextBoxes
            txtnombre.Clear();
            txtapellido.Clear();
            txtnumerodocumento.Clear();
            txtemail.Clear();
            txttelefono.Clear();
            txtcalle.Clear();
            txtnumerocalle.Clear();
            txtpiso.Clear();
            txtderpatamento.Clear();

            // Limpia ComboBoxes si existen
            if (cmbTipoDoc != null)
                cmbTipoDoc.SelectedIndex = -1;
            if (cmbPartido != null)
                cmbPartido.SelectedIndex = -1;
            if (cmbLocalidad != null)
                cmbLocalidad.DataSource = null;

            // Resetea modo edición
            modoEdicion = false;
            idClienteSeleccionado = 0;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAgregar.Text = "Nuevo cliente";
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

        private void pnlBuscar_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, pnlBuscar.Width - 1, pnlBuscar.Height - 1);
            }
        }

        private void frmRegistroClientes_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
