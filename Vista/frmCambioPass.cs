using Entidades;
using Entidades.DTOs;
using Logica;
using Sistema_Gestion_de_Usuarios.Vista;
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
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmCambioPass : Form
    {
        private readonly CL_Usuarios objUsuarios = new CL_Usuarios();
        private readonly string usuario;
        private readonly bool requiereContraseñaActual;
        private Form _formularioAnterior;
        private readonly CL_ConfiguracionContraseña configLogic = new CL_ConfiguracionContraseña();
        private ClsArrastrarFormularios moverFormulario;

        public frmCambioPass()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            // Aseguramos usuario y requerimos contraseña actual cuando se usa el ctor por defecto
            usuario = ClsSesionActual.Usuario != null ? ClsSesionActual.Usuario.User : null;
            requiereContraseñaActual = true;
            InicializarControles(true);
            this.AcceptButton = btnCambiar;
            txtPassActual.Visible = true;
            txtPassActual.BringToFront();
        }

        public frmCambioPass(string usuario, Form formularioAnterior, bool requiereContraseñaActual = true)
        {
            InitializeComponent();
            this.AcceptButton = btnCambiar;
            DoubleBuffered = true;
            this.usuario = usuario;
            this.requiereContraseñaActual = requiereContraseñaActual;
            this._formularioAnterior = formularioAnterior;
            InicializarControles(requiereContraseñaActual);
        }

        private void InicializarControles(bool mostrarPassActual = true)
        {
            pctFondo.Controls.Add(pctLogo);
            pctLogo.BackColor = Color.Transparent;

            ClsFondoTransparente.Aplicar(
                pctFondo,
                pctLogo,
                lblUsuariocont,
                pctValidaciones,
                pctOcultar, pctOcultar2, pctOcultar3,
                pctMostrar, pctMostrar2, pctMostrar3,
                btnCambiar);

            pctMostrar.BringToFront();
            pctMostrar2.BringToFront();
            pctMostrar3.BringToFront();

            ClsMostrarOcultarClave.Configurar(txtPassActual, pctMostrar, pctOcultar, "Contraseña actual");
            ClsMostrarOcultarClave.Configurar(txtNuevaPass, pctMostrar2, pctOcultar2, "Nueva contraseña");
            ClsMostrarOcultarClave.Configurar(txtConfirmaPass, pctMostrar3, pctOcultar3, "Confirmar contraseña");

        }


        private const string PASS_ACTUAL_PLACEHOLDER = "Contraseña actual";
        private const string NUEVA_PASS_PLACEHOLDER = "Nueva contraseña";
        private const string CONFIRMA_PASS_PLACEHOLDER = "Confirmar contraseña";

        private void frmCambioPass_Load(object sender, EventArgs e)
        {
            if (requiereContraseñaActual)
                ClsPlaceHolder.Leave(PASS_ACTUAL_PLACEHOLDER, txtPassActual, true);

            ClsPlaceHolder.Leave(NUEVA_PASS_PLACEHOLDER, txtNuevaPass, true);
            ClsPlaceHolder.Leave(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass, true);

            MostrarRestriccionesContrasena();
            lblUsuariocont.Text = $"Usuario: {ClsSesionActual.Usuario.User}";
            this.ActiveControl = lblUsuariocont;

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblTituloCambioPass);
        }
        private void MostrarRestriccionesContrasena()
        {
            try
            {
                CL_ConfiguracionContraseña configLogic = new CL_ConfiguracionContraseña();
                DtoConfiguracionSeguridad config = configLogic.ObtenerConfiguracion();

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
                if (ValidarCampos())
                {
                    string passActual = requiereContraseñaActual ? txtPassActual.Text : string.Empty;
                    string nuevaPass = txtNuevaPass.Text;
                    bool resultado;
                    string mensaje;

                    if (requiereContraseñaActual)
                    {
                        // Cambio normal con verificación de contraseña actual
                        resultado = objUsuarios.CambiarContraseña(usuario, passActual, nuevaPass, out mensaje);
                    }
                    else
                    {
                        // Cambio por administrador o por recuperación (primera contraseña)
                        resultado = objUsuarios.CambiarPrimeraContraseña(usuario, nuevaPass, out mensaje);
                    }

                    if (resultado)
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!requiereContraseñaActual)
                        {
                            // Si no se requirió la contraseña actual, es una primera contraseña
                            // o una recuperación. Redirigimos al formulario de Login.
                            FrmLoguin frmLogin = new FrmLoguin();
                            frmLogin.Show();
                            this.Close();
                        }
                        else
                        {
                            // Si se requirió la contraseña actual, es un cambio normal.
                            // Se asume que el usuario ya estaba logueado.
                            // Volver al formulario anterior (si corresponde) y cerrar.
                            if (_formularioAnterior != null)
                            {
                                _formularioAnterior.Show();
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar contraseña: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassActual_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PASS_ACTUAL_PLACEHOLDER, txtPassActual, true);
        }

        private void txtPassActual_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PASS_ACTUAL_PLACEHOLDER, txtPassActual, true);
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

        private bool ValidarCampos()
        {
            // Validar contraseña actual si se requiere
            if (requiereContraseñaActual)
            {
                if (string.IsNullOrEmpty(txtPassActual.Text) || txtPassActual.Text == PASS_ACTUAL_PLACEHOLDER)
                {
                    MessageBox.Show("Debe ingresar su contraseña actual", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Validar nueva contraseña
            if (string.IsNullOrEmpty(txtNuevaPass.Text) || txtNuevaPass.Text == NUEVA_PASS_PLACEHOLDER)
            {
                MessageBox.Show("Debe ingresar una nueva contraseña", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar confirmación
            if (string.IsNullOrEmpty(txtConfirmaPass.Text) || txtConfirmaPass.Text == CONFIRMA_PASS_PLACEHOLDER)
            {
                MessageBox.Show("Debe confirmar la nueva contraseña", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que coincidan
            if (txtNuevaPass.Text != txtConfirmaPass.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void frmCambioPass_Shown(object sender, EventArgs e)
        {
            this.AcceptButton = btnCambiar;
            this.BeginInvoke(new Action(() => this.ActiveControl = null));
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
