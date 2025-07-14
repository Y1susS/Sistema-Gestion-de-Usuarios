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
using Sesion.Entidades;

namespace Vista
{
    public partial class frmPrimerIngreso : Form
    {
        private readonly CL_Usuarios objUsuarios = new CL_Usuarios();
        private const string NUEVA_PASS_PLACEHOLDER = "Nueva contraseña";
        private const string CONFIRMA_PASS_PLACEHOLDER = "Confirmar contraseña";

        public frmPrimerIngreso()
        {
            InitializeComponent();
            DoubleBuffered = true;

            // Asociar manualmente el evento Click al botón
           // btnCambiar.Click += new EventHandler(btnCambiar_Click);

            // Aplicar estilo similar a los otros formularios
            //if (pctFondo != null && pctLogo != null)
            //{
            //    pctFondo.Controls.Add(pctLogo);
            //    pctLogo.BackColor = Color.Transparent;
            //}
        }

        private void frmPrimerIngreso_Load(object sender, EventArgs e)
        {
            // Configurar placeholder para contraseñas
            ClsPlaceHolder.Leave(NUEVA_PASS_PLACEHOLDER, txtNuevaPass);
            ClsPlaceHolder.Leave(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass);

            lblUsuario.Text = $"Usuario: {ClsSesionActual.Usuario.User}";
            lblMensaje.Text = "Por seguridad, debe cambiar su contraseña en su primer ingreso";
        }

        private void txtNuevaPass_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(NUEVA_PASS_PLACEHOLDER, txtNuevaPass, true);
        }

        private void txtNuevaPass_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(NUEVA_PASS_PLACEHOLDER, txtNuevaPass, true);
        }

        private void txtConfirmaPass_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass, true);
        }

        private void txtConfirmaPass_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass, true);
        }
        private void btnCambiar_Click(object sender, EventArgs e) 
        {
            try
            {
                if (!ValidarCampos()) 
                {
                    return;
                }

                string nuevaContraseña = txtNuevaPass.Text;

                if (ClsSesionActual.Usuario == null || string.IsNullOrEmpty(ClsSesionActual.Usuario.User))
                {
                    MessageBox.Show("No se encontró información del usuario en sesión. Por favor, inicie sesión nuevamente.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombreUsuarioActual = ClsSesionActual.Usuario.User;

                DtoDatosPersonalesPw usuarioParaPoliticas = objUsuarios.ObtenerDatosPersonalesPwPorNombreUsuario(nombreUsuarioActual);

                if (usuarioParaPoliticas == null)
                {
                    MessageBox.Show("No se pudieron cargar los datos personales del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CL_ConfiguracionContraseña logicaConfig = new CL_ConfiguracionContraseña();
                DtoConfiguracionContraseña config = logicaConfig.ObtenerConfiguracion();

                if (config == null)
                {
                    MessageBox.Show("No se pudo cargar la configuración de seguridad de la contraseña. No se puede validar la contraseña.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!objUsuarios.ValidarNuevaContrasenaSegunPoliticas(nuevaContraseña, usuarioParaPoliticas, out string mensajeValidacionPoliticas))
                {
                    MessageBox.Show(mensajeValidacionPoliticas, "Contraseña no Válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (objUsuarios.CambiarPrimeraContraseña(nombreUsuarioActual, nuevaContraseña, out string mensajeCambioPass))
                {
                    MessageBox.Show(mensajeCambioPass, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmPreguntas frmPreguntas = new frmPreguntas(this);
                    frmPreguntas.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensajeCambioPass, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar contraseña: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtNuevaPass.Text) ||
                txtNuevaPass.Text == NUEVA_PASS_PLACEHOLDER)
            {
                MessageBox.Show("Debe ingresar una nueva contraseña", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtConfirmaPass.Text) ||
                txtConfirmaPass.Text == CONFIRMA_PASS_PLACEHOLDER)
            {
                MessageBox.Show("Debe confirmar la nueva contraseña", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que las contraseñas coincidan
            if (txtNuevaPass.Text != txtConfirmaPass.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            // No permitir salir sin cambiar la contraseña
            MessageBox.Show("Debe cambiar su contraseña para continuar",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}
