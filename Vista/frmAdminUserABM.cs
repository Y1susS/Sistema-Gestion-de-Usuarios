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
using Servicios;
using Entidades;
using Entidades.DTOs;


namespace Vista
{
    public partial class frmAdminUserABM : Form
    {
        private readonly CL_Usuarios objCL = new CL_Usuarios();
        private readonly CL_Partido objPartido = new CL_Partido();
        private readonly CL_Rol objRol = new CL_Rol();
        private readonly CL_TipoDoc objTipoDoc = new CL_TipoDoc();
        private readonly CL_Localidad objLocalidad = new CL_Localidad();

        private bool modoEdicion = false;
        private int idUsuarioSeleccionado = 0;

        public frmAdminUserABM()
        {
            InitializeComponent();
            cmbTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void frmAdministrador_Load(object sender, EventArgs e)
        {
            try
            {
                InicializarFormulario();
                MostrarUsuarios();
                CargarCombos();
                ConfigurarControlesNumericos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarFormulario()
        {
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Id", "ID");
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns.Add("Usuario", "Usuario");
                dataGridView1.Columns.Add("Nombres", "Nombres");
                dataGridView1.Columns.Add("Apellidos", "Apellidos");
                dataGridView1.Columns.Add("Email", "Email");
                dataGridView1.Columns.Add("Rol", "Rol");
                dataGridView1.Columns.Add("Activo", "Activo");
            }

            ClsUtilidadesForms.BloquearControles(groupBox1);

            btnAgregarNuevo.Text = "Nuevo";
            button2.Text = "Guardar";
            button2.Enabled = false;
            btneliminar.Text = "Eliminar";
            btneliminar.Enabled = false;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void MostrarUsuarios()
        {
            try
            {
                var usuarios = objCL.ListarUsuarios();
                dataGridView1.Rows.Clear();

                foreach (var usuario in usuarios)
                {
                    int rowIdx = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIdx].Cells["Id"].Value = usuario.Id_user;
                    dataGridView1.Rows[rowIdx].Cells["Usuario"].Value = usuario.User;
                    dataGridView1.Rows[rowIdx].Cells["Nombres"].Value = usuario.Nombre;
                    dataGridView1.Rows[rowIdx].Cells["Apellidos"].Value = usuario.Apellido;
                    dataGridView1.Rows[rowIdx].Cells["Email"].Value = usuario.Email;
                    dataGridView1.Rows[rowIdx].Cells["Rol"].Value = usuario.Rol;
                    dataGridView1.Rows[rowIdx].Cells["Activo"].Value = usuario.Activo ? "Sí" : "No";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            try
            {
                cmbPartido.DataSource = objPartido.MostrarPartidos();
                cmbPartido.DisplayMember = "Partido";
                cmbPartido.ValueMember = "Id_Partido";
                cmbPartido.SelectedIndex = -1;

                cmbRol.DataSource = objRol.MostrarRoles();
                cmbRol.DisplayMember = "Rol";
                cmbRol.ValueMember = "Id_Rol";
                cmbRol.SelectedIndex = -1;

                cmbTipoDoc.DataSource = objTipoDoc.MostrarTiposDocumento();
                cmbTipoDoc.DisplayMember = "Id_TipoDocumento";
                cmbTipoDoc.ValueMember = "Id_TipoDocumento";
                cmbTipoDoc.SelectedIndex = -1;

                cmbLocalidad.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControlesNumericos()
        {
            txtNroDoc.KeyPress += (sender, e) => ClsSoloNumeros.ValidarNro(e);
            txtNroCalle.KeyPress += (sender, e) => ClsSoloNumeros.ValidarNro(e);
            txtTelefono.KeyPress += (sender, e) => ClsSoloNumeros.ValidarNro(e);
        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPartido.SelectedValue != null && int.TryParse(cmbPartido.SelectedValue.ToString(), out int idPartido))
                {
                    CargarLocalidadesPorPartido(idPartido);
                }
                else
                {
                    cmbLocalidad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLocalidad.DataSource = null;
            }
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            ClsUtilidadesForms.DesbloquearControles(groupBox1);

            modoEdicion = false;
            idUsuarioSeleccionado = 0;

            button2.Enabled = true;
            btneliminar.Enabled = false;

            txtApellidos.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                
                // AGREGAR esta validación que faltaba
                if (!ValidarDatosEspeciales()) return;

                // CREAR objetos DTO con los datos del formulario
                DtoPersona persona = CrearDtoPersonaDesdeFormulario();
                DtoUsuario usuario = CrearDtoUsuarioDesdeFormulario();

                if (modoEdicion) // MODO EDICIÓN
                {
                    usuario.Id_user = idUsuarioSeleccionado;

                    // LLAMAR a la capa lógica para actualizar
                    if (objCL.ActualizarUsuario(persona, usuario, out string mensaje))
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarUsuarios();      // Refrescar grid
                        LimpiarFormulario();    // Resetear formulario
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // MODO NUEVO USUARIO
                {
                    string passGenerada = ClsAleatorios.Armar(true, 10, 1);

                    if (objCL.RegistrarUsuario(persona, usuario, passGenerada, out string mensaje))
                    {
                        MessageBox.Show($"{mensaje}\n\nContraseña generada exitosamente! \n\nSe ha enviado un correo al usuario con sus credenciales.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        EnviarCorreoNuevoUsuario(persona.Email, usuario.User, passGenerada);

                        MostrarUsuarios();
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show("Debe seleccionar un usuario para eliminar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ClsSesionActual.EstaLogueado() && ClsSesionActual.Usuario.Id_user == idUsuarioSeleccionado)
            {
                MessageBox.Show("No puede eliminar su propio usuario", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea dar de baja al usuario '{txtUsuario.Text}'?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (objCL.EliminarUsuario(idUsuarioSeleccionado, out string mensaje))
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarUsuarios();
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que sea una fila válida
            {
                try
                {
                    // OBTENER EL ID del usuario seleccionado desde la celda "Id"
                    idUsuarioSeleccionado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    
                    // LLAMAR a la capa lógica para obtener todos los datos del usuario
                    var usuario = objCL.ObtenerUsuario(idUsuarioSeleccionado);
                    
                    if (usuario != null)
                    {
                        // CARGAR los datos en los controles del formulario
                        CargarDatosUsuarioEnFormulario(usuario);
                        
                        // ACTIVAR el modo edición
                        ActivarModoEdicion();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar usuario: {ex.Message}");
                }
            }
        }

        private void CargarLocalidadesPorPartido(int idPartido)
        {
            try
            {
                if (idPartido > 0)
                {
                    var localidades = objLocalidad.MostrarLocalidades(idPartido);
                    cmbLocalidad.DataSource = localidades;
                    cmbLocalidad.DisplayMember = "Localidad";
                    cmbLocalidad.ValueMember = "Id_Localidad";
                    cmbLocalidad.SelectedIndex = -1;
                }
                else
                {
                    cmbLocalidad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLocalidad.DataSource = null;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Debe ingresar el apellido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }

            if (cmbTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoDoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNroDoc.Text))
            {
                MessageBox.Show("Debe ingresar el número de documento", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroDoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Debe ingresar un correo electrónico válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
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

        private bool ValidarDatosEspeciales()
        {
            // Validar que el número de calle sea válido
            if (!string.IsNullOrWhiteSpace(txtNroCalle.Text))
            {
                if (!int.TryParse(txtNroCalle.Text, out int numero) || numero <= 0)
                {
                    MessageBox.Show("El número de calle debe ser un número válido mayor a 0", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroCalle.Focus();
                    return false;
                }
            }

            // Validar duplicación de nombre de usuario (solo en modo nuevo o si cambió el nombre)
            if (!modoEdicion)
            {
                // Modo nuevo: verificar que no exista el usuario
                if (objCL.ListarUsuarios().Any(u => u.User.Equals(txtUsuario.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ya existe un usuario con ese nombre", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return false;
                }
            }
            else
            {
                // Modo edición: verificar solo si cambió el nombre
                var usuarioOriginal = objCL.ObtenerUsuario(idUsuarioSeleccionado);
                if (usuarioOriginal != null && !usuarioOriginal.User.Equals(txtUsuario.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    if (objCL.ListarUsuarios().Any(u => u.User.Equals(txtUsuario.Text.Trim(), StringComparison.OrdinalIgnoreCase) && u.Id_user != idUsuarioSeleccionado))
                    {
                        MessageBox.Show("Ya existe un usuario con ese nombre", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsuario.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            ClsUtilidadesForms.LimpiarControles(groupBox1);
            ClsUtilidadesForms.BloquearControles(groupBox1);

            cmbPartido.SelectedIndex = -1;
            cmbRol.SelectedIndex = -1;
            cmbTipoDoc.SelectedIndex = -1;
            cmbLocalidad.DataSource = null;

            button2.Enabled = false;
            btneliminar.Enabled = false;
            modoEdicion = false;
            idUsuarioSeleccionado = 0;
        }

        private void EnviarCorreoNuevoUsuario(string email, string usuario, string contrasena)
        {
            try
            {
                ClsArmarMail.DireccionCorreo = email;
                ClsArmarMail.Asunto = "Bienvenido al Sistema - Sus Credenciales";
                ClsArmarMail.NuevaContraseña = $"Usuario: {usuario}\nContraseña: {contrasena}";
                ClsArmarMail.Preparar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar correo: {ex.Message}\nPor favor, notifique al usuario sus credenciales manualmente.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPanelUsuarios frm = new frmPanelUsuarios();
            frm.Show();
            this.Close();
        }

        private void CargarDatosUsuarioEnFormulario(DtoUsuarioDetalle usuario)
        {
            // DESBLOQUEAR controles para permitir edición
            ClsUtilidadesForms.DesbloquearControles(groupBox1);

            // CARGAR datos básicos
            txtNombres.Text = usuario.Nombre;
            txtApellidos.Text = usuario.Apellido;
            txtNroDoc.Text = usuario.NroDocumento;
            txtEmail.Text = usuario.Email;
            txtCalle.Text = usuario.Calle;
            txtNroCalle.Text = usuario.Nro.ToString();
            txtPiso.Text = usuario.Piso;
            txtDepart.Text = usuario.Depto;
            txtTelefono.Text = usuario.Telefono;
            txtUsuario.Text = usuario.User;

            // CARGAR combos simples
            cmbTipoDoc.SelectedValue = usuario.Id_TipoDocumento;
            cmbRol.SelectedValue = usuario.Id_Rol;

            // CARGAR combos dependientes (partido -> localidad)
            CargarCombosPartidoLocalidad(usuario);
        }

        private void ActivarModoEdicion()
        {
            modoEdicion = true;
            button2.Enabled = true;       // Habilitar botón Guardar
            btneliminar.Enabled = true;   // Habilitar botón Eliminar
            txtApellidos.Focus();           // Enfocar primer campo
        }

        private void CargarCombosPartidoLocalidad(DtoUsuarioDetalle usuario)
        {
            // DESCONECTAR evento temporalmente para evitar conflictos
            cmbPartido.SelectedIndexChanged -= cmbPartido_SelectedIndexChanged;
            
            // SELECCIONAR el partido
            cmbPartido.SelectedValue = usuario.Id_Partido;
            
            // RECONECTAR el evento
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;

            // CARGAR localidades del partido seleccionado
            CargarLocalidadesPorPartido(usuario.Id_Partido);
            
            // SELECCIONAR la localidad específica
            cmbLocalidad.SelectedValue = usuario.Id_Localidad;
        }

        private DtoPersona CrearDtoPersonaDesdeFormulario()
        {
            var persona = new DtoPersona
            {
                Nombre = txtNombres.Text.Trim(),
                Apellido = txtApellidos.Text.Trim(),
                Id_TipoDocumento = cmbTipoDoc.SelectedValue.ToString(),
                NroDocumento = txtNroDoc.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Calle = txtCalle.Text.Trim(),
                Nro = string.IsNullOrWhiteSpace(txtNroCalle.Text) ? 0 : int.Parse(txtNroCalle.Text),
                Piso = txtPiso.Text.Trim(),
                Depto = txtDepart.Text.Trim(),
                Id_Localidad = (int)cmbLocalidad.SelectedValue,
                Telefono = txtTelefono.Text.Trim() // ← AGREGAR ESTA LÍNEA
            };

            // Si estamos en modo edición, necesitamos el ID de la persona
            if (modoEdicion && idUsuarioSeleccionado > 0)
            {
                var usuarioActual = objCL.ObtenerUsuario(idUsuarioSeleccionado);
                if (usuarioActual != null)
                {
                    persona.Id_Persona = usuarioActual.Id_Persona;
                }
            }

            return persona;
        }

        private DtoUsuario CrearDtoUsuarioDesdeFormulario()
        {
            CL_ConfiguracionContraseña logicaConfig = new CL_ConfiguracionContraseña();
            DtoConfiguracionContraseña config = logicaConfig.ObtenerConfiguracion();


            return new DtoUsuario
            {
                User = txtUsuario.Text.Trim(),
                Id_Rol = (int)cmbRol.SelectedValue,
                Activo = true,
                PrimeraPass = true,
                CambiaCada = config.DiasCambioPassword
            };
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
    }
}
