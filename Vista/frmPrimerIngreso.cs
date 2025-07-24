using Logica;
using Sesion;
using Sesion.Entidades;
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

namespace Vista
{
    public partial class frmPrimerIngreso : Form
    {
        private readonly CL_Usuarios objUsuarios = new CL_Usuarios();
        private ClsArrastrarFormularios moverFormulario;
        public frmPrimerIngreso()
        {
            InitializeComponent();

            ClsFondoTransparente.Aplicar(
            pctFondo,
            pctLogo,
            lblMensaje,
            lblUsuario,
            pctMostrar,
            pctOcultar,
            pctMostrar2,
            pctOcultar2,
            lblRestriccionesTexto);

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pctBorde);
            moverFormulario.HabilitarMovimiento(lblLogin);
        }

        private const string NUEVA_PASS_PLACEHOLDER = "Nueva contraseña";
        private const string CONFIRMA_PASS_PLACEHOLDER = "Confirmar contraseña";

        private void frmPrimerIngreso_Load(object sender, EventArgs e)
        {
            txtNuevaPass.UseSystemPasswordChar = false;
            txtConfirmaPass.UseSystemPasswordChar = false;
            ClsPlaceHolder.Leave(NUEVA_PASS_PLACEHOLDER, txtNuevaPass, true);
            ClsPlaceHolder.Leave(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass, true);
            lblUsuario.Text = $"Usuario: {ClsSesionActual.Usuario.User}";
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
                    lblRestriccionesTexto.Visible = true; 
                    StringBuilder sb = new StringBuilder(); 
                                        
                    if (config.MinimoCaracteres > 0)
                    {
                        sb.Append($"Mínimo: {config.MinimoCaracteres} caracteres - ");
                    }
                    if (config.RequiereMayusMinus)
                    {
                        sb.Append("Combinación de mayúsculas y minúsculas - ");
                    }
                    if (config.RequiereNumLetra)
                    {
                        sb.Append("Números y letras - ");
                    }
                    if (config.RequiereEspecial)
                    {
                        sb.Append("Al menos 1 carácter especial - ");
                    }
                    if (config.EvitarRepetidas)
                    {
                        sb.Append("No reutilizar contraseñas anteriores - ");
                    }
                    if (config.EvitarDatosPersonales)
                    {
                        sb.Append("No contener datos personales - ");
                    }

                    
                    if (sb.Length > 0)
                    {
                        sb.Length -= 3; // Elimina los últimos 3 caracteres (" - ")
                        lblRestriccionesTexto.Text = sb.ToString();
                    }
                    else
                    {
                        // Si no hay restricciones configuradas, muestra por defecto
                        lblRestriccionesTexto.Text = "No hay restricciones de contraseña configuradas.";
                    }
                }
                else
                {
                    lblRestriccionesTexto.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las restricciones de contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblRestriccionesTexto.Visible = false;
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
            if (txtNuevaPass.Text == "Nueva contraseña" && txtNuevaPass.ForeColor == Color.Gray)
            {
                pctMostrar.BringToFront();
            }
        }

        private void txtConfirmaPass_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass, true);

        }

        private void txtConfirmaPass_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass, true);
            if (txtConfirmaPass.Text == "Confirmar contraseña" && txtConfirmaPass.ForeColor == Color.Gray)
            {
                pctMostrar2.BringToFront();
            }
        }

        private void pctMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pctMostrar_Click(object sender, EventArgs e)
        {
            if (txtNuevaPass.ForeColor == Color.Gray)
                return;

            pctOcultar.BringToFront();
            txtNuevaPass.UseSystemPasswordChar = false;
        }

        private void pctOcultar_Click(object sender, EventArgs e)
        {
            if (txtNuevaPass.ForeColor == Color.Gray)
                return;

            pctMostrar.BringToFront();
            txtNuevaPass.UseSystemPasswordChar = true;
        }

        private void pctMostrar2_Click(object sender, EventArgs e)
        {
            if (txtConfirmaPass.ForeColor == Color.Gray)
                return;

            pctOcultar2.BringToFront();
            txtConfirmaPass.UseSystemPasswordChar = false;
        }

        private void pctOcultar2_Click(object sender, EventArgs e)
        {
            if (txtConfirmaPass.ForeColor == Color.Gray)
                return;

            pctMostrar2.BringToFront();
            txtConfirmaPass.UseSystemPasswordChar = true;
        }

        private void txtNuevaPass_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(NUEVA_PASS_PLACEHOLDER, txtNuevaPass, true);
        }
    }
}
