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
using Sesion;
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
            moverFormulario.HabilitarMovimiento(pctBorde);
            moverFormulario.HabilitarMovimiento(lblLogin);

            ClsFondoTransparente.Aplicar(
            pctFondo,
            pctLogo,
            lnkRecuperar,
            pctMostrar,
            pctOcultar);
        }

        private void FrmLoguin_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => this.ActiveControl = null)); // Evita que un TextBox tenga el foco inicial
            txtContrasenia.UseSystemPasswordChar = false;
            ClsPlaceHolder.Leave(USER_PLACEHOLDER, txtUsuario);
            ClsPlaceHolder.Leave(PLACEHOLDER_PASS, txtContrasenia, true);
        }

        private void PctClose_Click(object sender, EventArgs e)
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

        private void PctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

            // Si quedó con el placeholder, asegurarse de que se muestre el ícono de "mostrar"
            if (txtContrasenia.Text == "Contraseña" && txtContrasenia.ForeColor == Color.Gray)
            {
                pctMostrar.BringToFront();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool usuarioVacio = string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == USER_PLACEHOLDER;
            bool contraseniaVacia = string.IsNullOrWhiteSpace(txtContrasenia.Text) || txtContrasenia.Text == PLACEHOLDER_PASS;

            if (usuarioVacio || contraseniaVacia)
            {
                MessageBox.Show("Hay campos vacíos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string user = txtUsuario.Text.Trim();
                string pass = txtContrasenia.Text;
                string hashCalculadoParaLogin = ClsSeguridad.SHA256(user + pass);

                if (objCL.Autenticar(user, pass, out string msg))
                { 
                    // Verificar si es primera contraseña
                    if (ClsSesionActual.Usuario.PrimeraPass)
                    {
                        MessageBox.Show("Debe cambiar su contraseña por primera vez", 
                            "Cambio de contraseña requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        frmPrimerIngreso frmPrimer = new frmPrimerIngreso();
                        frmPrimer.Show();
                        this.Hide();
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
                    txtContrasenia.Focus();
                }
            }
        }

        private void pctMostrar_Click(object sender, EventArgs e)
        {
            // Si el campo está vacío o con placeholder, no mostrar nada
            if (txtContrasenia.ForeColor == Color.Gray)
                return;

            pctOcultar.BringToFront();
            txtContrasenia.UseSystemPasswordChar = false;
        }

        private void pctOcultar_Click(object sender, EventArgs e)
        {
            // Si el campo está vacío o con placeholder, no ocultar nada
            if (txtContrasenia.ForeColor == Color.Gray)
                return;

            pctMostrar.BringToFront();
            txtContrasenia.UseSystemPasswordChar = true;
        }
    }
}

