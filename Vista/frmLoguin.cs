using Logica;
using Entidades;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class FrmLoguin : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private readonly CL_Loguin objCL = new CL_Loguin();
        public FrmLoguin()
        {
            InitializeComponent();

            DoubleBuffered = true;
            
            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblLogin);

            ClsFondoTransparente.Aplicar(
            pctFondo,
            pctLogo,
            lnkRecuperar,
            pctMostrar,
            pctOcultar,
            btnLogin);

            ClsMostrarOcultarClave.Configurar(txtContrasenia, pctMostrar, pctOcultar, "Contraseña");
        }

        private void FrmLoguin_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => this.ActiveControl = null)); // Evita que un TextBox tenga el foco inicial
            txtContrasenia.UseSystemPasswordChar = false;
            ClsPlaceHolder.Leave(USER_PLACEHOLDER, txtUsuario);
            ClsPlaceHolder.Leave(PLACEHOLDER_PASS, txtContrasenia, true);
        }

        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            frmRecupero frmRecupero = new frmRecupero();
            frmRecupero.ShowDialog();
        }

        private const string USER_PLACEHOLDER = "Usuario";
        private const string PLACEHOLDER_PASS = "Contraseña";

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(USER_PLACEHOLDER, txtUsuario);
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(USER_PLACEHOLDER, txtUsuario);
        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_PASS, txtContrasenia, true);
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_PASS, txtContrasenia, true);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ... (Tu código de validación de campos) ...

            string user = txtUsuario.Text.Trim();
            string pass = txtContrasenia.Text;

            if (objCL.Autenticar(user, pass, out string msg))
            {
                // Verificar si es primera contraseña o contraseña temporal
                if (ClsSesionActual.Usuario.PrimeraPass)
                {
                    // *** INICIO DE LA LÓGICA DE DISTINCIÓN ***
                    // La instancia de CL_Usuarios debe ser utilizada aquí.
                    // Si no la tienes, debes crearla:
                    CL_Usuarios objUsuarios = new CL_Usuarios();

                    // Llama al método para verificar si el usuario ya tiene preguntas de seguridad.
                    // Asegúrate de que el método UsuarioTienePreguntasDeSeguridad esté en la clase CL_Usuarios
                    if (objUsuarios.UsuarioTienePreguntasDeSeguridad(user))
                    {
                        // Si el usuario ya configuró preguntas, es una recuperación de contraseña.
                        MessageBox.Show("Debe cambiar su contraseña.",
                            "Cambio de contraseña requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Redirigimos al formulario de cambio de contraseña que no requiere la contraseña actual.
                        frmCambioPass frmCambio = new frmCambioPass(user, this, false);
                        frmCambio.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Si no tiene preguntas, es un usuario nuevo.
                        MessageBox.Show("Debe cambiar su contraseña por primera vez y configurar sus preguntas de seguridad.",
                            "Primer Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Redirigimos al formulario de primer ingreso que incluye la configuración de preguntas.
                        frmPrimerIngreso frmPrimer = new frmPrimerIngreso();
                        frmPrimer.Show();
                        this.Hide();
                    }
                    // *** FIN DE LA LÓGICA DE DISTINCIÓN ***
                }
                else
                {
                    MessageBox.Show(msg);
                    new frmPanelUsuarios().Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasenia.Clear();
            }
        }


        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    bool usuarioVacio = string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == USER_PLACEHOLDER;
        //    bool contraseniaVacia = string.IsNullOrWhiteSpace(txtContrasenia.Text) || txtContrasenia.Text == PLACEHOLDER_PASS;

        //    if (usuarioVacio || contraseniaVacia)
        //    {
        //        MessageBox.Show("Hay campos vacíos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    else
        //    {
        //        string user = txtUsuario.Text.Trim();
        //        string pass = txtContrasenia.Text;
        //        string hashCalculadoParaLogin = ClsSeguridad.SHA256(user + pass);

        //        if (objCL.Autenticar(user, pass, out string msg))
        //        {
        //            // Verificar si es primera contraseña
        //            if (ClsSesionActual.Usuario.PrimeraPass)
        //            {
        //                MessageBox.Show("Debe cambiar su contraseña por primera vez",
        //                    "Cambio de contraseña requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                frmPrimerIngreso frmPrimer = new frmPrimerIngreso();
        //                frmPrimer.Show();
        //                this.Hide();
        //            }
        //            else
        //            {
        //                MessageBox.Show(msg);
        //                new frmPanelUsuarios().Show();
        //                this.Hide();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtContrasenia.Clear();
        //            txtContrasenia.Focus();
        //        }
        //    }
        //}

        private void pctMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pctClose_Click_1(object sender, EventArgs e)
        {
            bool UsarioVacio = string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == USER_PLACEHOLDER;
            bool ContraseniaVacia = string.IsNullOrWhiteSpace(txtContrasenia.Text) || txtContrasenia.Text == PLACEHOLDER_PASS;

            if (UsarioVacio && ContraseniaVacia == true)
            {
                Application.Exit();
            }
            else
            {
                DialogResult opcion = MessageBox.Show("Si cierra esta ventana se perderán los datos ingresados \n ¿Seguro que quiere salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (opcion == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void FrmLoguin_Shown(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }
    }
}

