using Logica;
using Sesion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmPanelUsuarios : Form
    {
        private bool esAdministrador = false;
        private CL_Usuarios logicaUsuario = new CL_Usuarios();
        public frmPanelUsuarios()
        {
            InitializeComponent();
            
            // Verificar si el usuario actual es administrador
            if (ClsSesionActual.EstaLogueado())
            {
                esAdministrador = ClsSesionActual.Usuario.Id_Rol == 1;
            }
        }

        private void frmPanelUsuarios_Load(object sender, EventArgs e)
        {
            // Configurar la interfaz según el rol del usuario
            ConfigurarInterfazSegunRol();

            int diasRestantes = logicaUsuario.ObtenerDiasRestantesCambioContrasena(ClsSesionActual.Usuario.Id_user);

            // Si devuelve -1, significa que no aplica vencimiento (CambiaCada = 0)
            if (diasRestantes == -1)
            {
                lblDiasRestantesContrasena.Visible = false;
            }
            else if (diasRestantes > 0)
            {
                lblDiasRestantesContrasena.Text = $"Faltan {diasRestantes} días para cambiar su contraseña.";
                lblDiasRestantesContrasena.ForeColor = Color.Black;
                lblDiasRestantesContrasena.Visible = true;
            }
            else // 0 o menos → vencida
            {
                lblDiasRestantesContrasena.Text = "Su contraseña ha expirado o debe cambiarla. ¡ACTUALICE AHORA!";
                lblDiasRestantesContrasena.ForeColor = Color.Red;
                lblDiasRestantesContrasena.Visible = true;
            }
        }

        private void ConfigurarInterfazSegunRol()
        {
            // Cambiar el título según el rol
            lblAdministrador.Text = esAdministrador ? "Panel de Administración" : "Panel de Usuario Vendedor";
            
            // Configurar visibilidad de botones según el rol
            btnGestionUsuarios.Visible = esAdministrador;
            btnGestionPermisos.Visible = esAdministrador;
            btnGestionContraseñas.Visible = esAdministrador;
            
            btnRegistroClientes.Visible = true;
            btnCambiarContrasena.Visible = true;
            btnPreguntas.Visible = true;
            
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            if (esAdministrador)
            {
                frmAdminUserABM frmalta = new frmAdminUserABM();
                frmalta.Show();
                this.Close();
            }
        }

        private void btnGestionPermisos_Click(object sender, EventArgs e)
        {
            if (esAdministrador)
            {
                frmPermisos frmPermisos = new frmPermisos();
                frmPermisos.Show();
                this.Hide();
            }
        }

        private void btnGestionContraseñas_Click(object sender, EventArgs e)
        {
            if (esAdministrador)
            {
                frmSegContraseña frmSegContraseña = new frmSegContraseña();
                frmSegContraseña.Show();
                this.Hide();
            }
        }

        private void btnRegistroClientes_Click(object sender, EventArgs e)
        {
            
            
                frmRegistroClientes frmRegistro = new frmRegistroClientes();
                frmRegistro.Show();
                this.Hide();
            
        }

        private void btnPreguntas_Click(object sender, EventArgs e)
        {
            frmPreguntas frmPreg = new frmPreguntas(this);
            frmPreg.Show();
            this.Hide();
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            string usuario = ClsSesionActual.Usuario.User;
            frmCambioPass frmCambio = new frmCambioPass(usuario, this, true);
            frmCambio.Show();
            this.Hide(); // Oculta el panel mientras se cambia la contraseña
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FrmLoguin frm = new FrmLoguin();
            frm.Show();
            this.Close();
        }

    }
}
