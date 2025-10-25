using Entidades;
using Entidades.DTOs;
using Logica;
using Sistema_Gestion_de_Usuarios.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmPrimerIngreso : Form
    {
        private ClsMensajeEmergente mensajes = new ClsMensajeEmergente();
        private readonly CL_Usuarios objUsuarios = new CL_Usuarios();
        private ClsArrastrarFormularios moverFormulario;
        public frmPrimerIngreso()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);

            this.AcceptButton = btnCambiarcont;

            ClsFondoTransparente.Aplicar(
            pctFondo,
            pctLogo,
            lblMensaje,
            lblUsuariocambiarcont,
            pctMostrar,
            pctOcultar,
            pctMostrar2,
            pctOcultar2,
            pctValidaciones,
            btnCambiarcont);

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblPrimerIngreso);

            ClsMostrarOcultarClave.Configurar(txtNuevaPass, pctMostrar, pctOcultar, "Nueva contraseña");
            ClsMostrarOcultarClave.Configurar(txtConfirmaPass, pctMostrar2, pctOcultar2, "Confirmar contraseña");
        }

        private const string NUEVA_PASS_PLACEHOLDER = "Nueva contraseña";
        private const string CONFIRMA_PASS_PLACEHOLDER = "Confirmar contraseña";

        private void frmPrimerIngreso_Load(object sender, EventArgs e)
        {
            txtNuevaPass.UseSystemPasswordChar = false;
            txtConfirmaPass.UseSystemPasswordChar = false;
            ClsPlaceHolder.Leave(NUEVA_PASS_PLACEHOLDER, txtNuevaPass, true);
            ClsPlaceHolder.Leave(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass, true);
            lblUsuariocambiarcont.Text = $"Usuario: {ClsSesionActual.Usuario.User}";
            lblMensaje.Text = "Debido a su primer ingreso, escriba una nueva contraseña y repítala para confirmar el cambio";
            MostrarRestriccionesContrasena();

        }

        private void MostrarRestriccionesContrasena()
        {
            try
            {
                CL_ConfiguracionContraseña configLogic = new CL_ConfiguracionContraseña();
                DtoConfiguracionContraseña config = configLogic.ObtenerConfiguracion();

                if (config != null)
                {
                    StringBuilder sb = new StringBuilder();

                    if (config.MinimoCaracteres > 0)
                    {
                        sb.AppendLine($"• Mínimo: {config.MinimoCaracteres} caracteres");
                    }
                    if (config.RequiereMayusMinus)
                    {
                        sb.AppendLine("• Combinación de mayúsculas y minúsculas");
                    }
                    if (config.RequiereNumLetra)
                    {
                        sb.AppendLine("• Números y letras");
                    }
                    if (config.RequiereEspecial)
                    {
                        sb.AppendLine("• Al menos 1 carácter especial");
                    }
                    if (config.EvitarRepetidas)
                    {
                        sb.AppendLine("• No reutilizar contraseñas anteriores");
                    }
                    if (config.EvitarDatosPersonales)
                    {
                        sb.AppendLine("• No contener datos personales");
                    }

                    string mensaje = sb.Length > 0
                        ? sb.ToString()
                        : "No hay restricciones de contraseña configuradas.";

                    ClsMensajeEmergente mensajes = new ClsMensajeEmergente();
                    mensajes.AsignarMensaje(pctValidaciones, mensaje);
                }
                else
                {
                    ClsMensajeEmergente mensajes = new ClsMensajeEmergente();
                    mensajes.AsignarMensaje(pctValidaciones, "No hay restricciones configuradas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las restricciones de contraseña: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClsMensajeEmergente mensajes = new ClsMensajeEmergente();
                mensajes.AsignarMensaje(pctValidaciones, string.Empty);
            }
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

        private void pctClose_Click_1(object sender, EventArgs e)
        {
            bool NuevaPass = string.IsNullOrWhiteSpace(txtNuevaPass.Text) || txtNuevaPass.Text == NUEVA_PASS_PLACEHOLDER;
            bool ConfirmaPass = string.IsNullOrWhiteSpace(txtConfirmaPass.Text) || txtConfirmaPass.Text == CONFIRMA_PASS_PLACEHOLDER;

            if (NuevaPass && ConfirmaPass == true)
            {
                this.Close();
                FrmLoguin FrmLoguin = new FrmLoguin();
                FrmLoguin.Show();
            }
            else
            {
                DialogResult opcion = MessageBox.Show("Si cierra esta ventana se perderán los datos ingresados \n ¿Seguro que quiere salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (opcion == DialogResult.Yes)
                {
                    this.Close();
                    FrmLoguin FrmLoguin = new FrmLoguin();
                    FrmLoguin.Show();
                }
            }
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

        private void pctMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtNuevaPass_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(NUEVA_PASS_PLACEHOLDER, txtNuevaPass, true);
        }

        private void frmPrimerIngreso_Shown(object sender, EventArgs e)
        {
            this.AcceptButton = btnCambiarcont;
            txtNuevaPass.Focus();
        }
    }
}
