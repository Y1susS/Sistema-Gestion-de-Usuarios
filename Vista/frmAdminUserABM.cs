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
using Sesion;
using Sesion.Entidades;


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

        private void ConfigurarControlesNumericos()
        {
            txtNroDoc.KeyPress += (sender, e) => ClsSoloNumeros.ValidarNro(e);
            txtNroCalle.KeyPress += (sender, e) => ClsSoloNumeros.ValidarNro(e);
            txtTelefono.KeyPress += (sender, e) => ClsSoloNumeros.ValidarNro(e);
        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartido.SelectedValue != null && int.TryParse(cmbPartido.SelectedValue.ToString(), out int idPartido))
            {
                cmbLocalidad.DataSource = objLocalidad.MostrarLocalidades(idPartido);
                cmbLocalidad.DisplayMember = "Localidad";
                cmbLocalidad.ValueMember = "Id_Localidad";
                cmbLocalidad.SelectedIndex = -1;
            }
            else
            {
                cmbLocalidad.DataSource = null;
            }
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            ClsUtilidadesForms.DesbloquearControles(groupBox1);
            ClsUtilidadesForms.LimpiarControles(groupBox1);

            modoEdicion = false;
            idUsuarioSeleccionado = 0;

            button2.Enabled = true;
            btneliminar.Enabled = false;

            txtUsuario.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                DtoPersona persona = new DtoPersona
                {
                    Nombre = txtNombres.Text.Trim(),
                    Apellido = txtApellidos.Text.Trim(),
                    Id_TipoDocumento = cmbTipoDoc.SelectedValue.ToString(),
                    NroDocumento = txtNroDoc.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Calle = txtCalle.Text.Trim(),
                    Nro = int.Parse(txtNroCalle.Text),
                    Piso = txtPiso.Text.Trim(),
                    Depto = txtDepart.Text.Trim(),
                    Id_Localidad = (int)cmbLocalidad.SelectedValue
                };

                DtoUsuario usuario = new DtoUsuario
                {
                    User = txtUsuario.Text.Trim(),
                    Id_Rol = (int)cmbRol.SelectedValue,
                    Activo = true,
                    PrimeraPass = true
                };

                string contrasenaPlana = ClsAleatorios.Armar(true, 10, 2);

                if (modoEdicion)
                {
                    usuario.Id_user = idUsuarioSeleccionado;

                    if (objCL.ActualizarUsuario(persona, usuario, out string mensaje))
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarUsuarios();
                        ClsUtilidadesForms.BloquearControles(groupBox1);
                        button2.Enabled = false;
                        btneliminar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (objCL.RegistrarUsuario(persona, usuario, contrasenaPlana, out string mensaje))
                    {
                        MessageBox.Show($"{mensaje}\n\nContraseña generada: {contrasenaPlana}\n\nSe ha enviado un correo al usuario con sus credenciales.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        EnviarCorreoNuevoUsuario(txtEmail.Text, txtUsuario.Text, contrasenaPlana);

                        MostrarUsuarios();
                        ClsUtilidadesForms.BloquearControles(groupBox1);
                        button2.Enabled = false;
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

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este usuario?\nEsta acción no se puede deshacer.",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (objCL.EliminarUsuario(idUsuarioSeleccionado, out string mensaje))
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarUsuarios();
                    ClsUtilidadesForms.LimpiarControles(groupBox1);
                    ClsUtilidadesForms.BloquearControles(groupBox1);
                    button2.Enabled = false;
                    btneliminar.Enabled = false;
                    modoEdicion = false;
                    idUsuarioSeleccionado = 0;
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idUsuarioSeleccionado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                var usuario = objCL.ObtenerUsuario(idUsuarioSeleccionado);
                if (usuario != null)
                {
                    ClsUtilidadesForms.DesbloquearControles(groupBox1);

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

                    cmbTipoDoc.SelectedValue = usuario.Id_TipoDocumento;
                    cmbPartido.SelectedValue = usuario.Id_Partido;

                    cmbLocalidad.SelectedValue = usuario.Id_Localidad;

                    cmbRol.SelectedValue = usuario.Id_Rol;

                    modoEdicion = true;
                    button2.Enabled = true;
                    btneliminar.Enabled = true;
                }
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
            frmAdministrador frm = new frmAdministrador();
            frm.Show();
            this.Close();
        }

        
    }
}
