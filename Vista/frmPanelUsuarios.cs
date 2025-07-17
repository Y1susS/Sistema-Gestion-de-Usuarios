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
        private ClsArrastrarFormularios moverFormulario;
        private bool esAdministrador = false;
        private CL_Usuarios logicaUsuario = new CL_Usuarios();
        public frmPanelUsuarios()
        {
                InitializeComponent();

            this.Load += frmPanelUsuarios_Load;

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pctBorde);
            moverFormulario.HabilitarMovimiento(lblAdministrador);

            ClsFondoTransparente.Aplicar(
            pctFondo,
            btnGestionUsuarios,
            btnGestionPermisos,
            btnGestionValidaciones,
            btnRegistroClientes,
            btnCambiarContrasena,
            btnPreguntas,
            pctLogo,
            lblDiasRestantesContrasena);

            // Verificar si el usuario actual es administrador
            if (ClsSesionActual.EstaLogueado())
            {
                esAdministrador = ClsSesionActual.Usuario.Id_Rol == 1;
            }
        }

        private void frmPanelUsuarios_Load(object sender, EventArgs e)
        {
            AjustarInterfazPorRol();

            this.BeginInvoke(new Action(() => this.ActiveControl = null));

            int diasRestantes = logicaUsuario.ObtenerDiasRestantesCambioContrasena(ClsSesionActual.Usuario.Id_user);

            // Si devuelve -1, significa que no aplica vencimiento (CambiaCada = 0)
            if (diasRestantes == -1)
            {
                lblDiasRestantesContrasena.Visible = false;
            }
            else if (diasRestantes > 0)
            {
                lblDiasRestantesContrasena.Text = $"Faltan {diasRestantes} días para cambiar su contraseña.";
                lblDiasRestantesContrasena.ForeColor = Color.White;
                lblDiasRestantesContrasena.Visible = true;
            }
            else // 0 o menos → vencida
            {
                lblDiasRestantesContrasena.Text = "Su contraseña ha expirado o debe cambiarla. ¡ACTUALICE AHORA!";
                lblDiasRestantesContrasena.ForeColor = Color.Red;
                lblDiasRestantesContrasena.Visible = true;
            }
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

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLoguin FrmLoguin = new FrmLoguin();
            FrmLoguin.Show();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AjustarInterfazPorRol()
        {
            if (!esAdministrador)
            {
                btnGestionUsuarios.Visible = false;
                btnGestionUsuarios.Enabled = false;

                btnGestionPermisos.Visible = false;
                btnGestionPermisos.Enabled = false;

                btnGestionValidaciones.Visible = false;
                btnGestionValidaciones.Enabled = false;

                btnRegistroClientes.Location = new Point(111, 187);
                btnCambiarContrasena.Location = new Point(111, 237);
                btnPreguntas.Location = new Point(111, 287);

                lblAdministrador.Text = "Menú de Vendedor";
            }
        }
    }
}
