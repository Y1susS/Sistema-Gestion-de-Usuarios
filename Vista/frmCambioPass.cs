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
using Sesion.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class frmCambioPass : Form
    {
        private readonly CL_Usuarios objUsuarios = new CL_Usuarios();
        private readonly string usuario;
        private readonly bool requiereContraseñaActual;
        private Form _formularioAnterior;
        private const string PASS_ACTUAL_PLACEHOLDER = "Contraseña actual";
        private const string NUEVA_PASS_PLACEHOLDER = "Nueva contraseña";
        private const string CONFIRMA_PASS_PLACEHOLDER = "Confirmar contraseña";
        private readonly CL_ConfiguracionContraseña configLogic = new CL_ConfiguracionContraseña();

        public frmCambioPass(string usuario, Form formularioAnterior, bool requiereContraseñaActual = true)
        {
            InitializeComponent();
            DoubleBuffered = true;
            pctFondo.Controls.Add(pctLogo);
            pctLogo.BackColor = Color.Transparent;
            this.usuario = usuario;
            this.requiereContraseñaActual = requiereContraseñaActual;
            this._formularioAnterior = formularioAnterior;
            txtPassActual.Visible = requiereContraseñaActual;
            ClsFondoTransparente.Aplicar(
                pctFondo,
                pctLogo,
                lblUsuario,
                lblRestriccionesPassCambio);
        }

        private void frmCambioPass_Load(object sender, EventArgs e)
        {
            if (requiereContraseñaActual)
                ClsPlaceHolder.Leave(PASS_ACTUAL_PLACEHOLDER, txtPassActual, true);

            ClsPlaceHolder.Leave(NUEVA_PASS_PLACEHOLDER, txtNuevaPass, true);
            ClsPlaceHolder.Leave(CONFIRMA_PASS_PLACEHOLDER, txtConfirmaPass, true);
            MostrarRestriccionesContrasena();
            lblUsuario.Text = $"Usuario: {usuario}";
            this.ActiveControl = lblUsuario;

        }
        private void MostrarRestriccionesContrasena()
        {
            try
            {
                DtoConfiguracionContraseña config = configLogic.ObtenerConfiguracion();

                if (config != null)
                {
                    lblRestriccionesPassCambio.Visible = true; // Hacer visible el Label

                    StringBuilder sb = new StringBuilder();

                    if (config.MinimoCaracteres > 0)
                    {
                        sb.Append($"Mínimo: {config.MinimoCaracteres} caracteres - ");
                    }
                    if (config.RequiereMayusMinus)
                    {
                        sb.Append("Mayúsculas y minúsculas - ");
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
                        sb.Append("No reutilizar anteriores - ");
                    }
                    if (config.EvitarDatosPersonales)
                    {
                        sb.Append("No contener datos personales - ");
                    }

                    if (sb.Length > 0)
                    {
                        sb.Length -= 3; 
                        lblRestriccionesPassCambio.Text = sb.ToString();
                    }
                    else
                    {
                        lblRestriccionesPassCambio.Text = "No hay restricciones de contraseña configuradas.";
                    }
                }
                else
                {
                    // Si 'config' es null, ocultar el Label.
                    lblRestriccionesPassCambio.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las restricciones de contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblRestriccionesPassCambio.Visible = false;
            }
        }



        private void pctClose_Click(object sender, EventArgs e)
        {

            this.Close();
            frmPanelUsuarios frmPanelUsuarios = new frmPanelUsuarios();
            frmPanelUsuarios.Show();
            //bool ambosVacios = string.IsNullOrWhiteSpace(txtPassActual.Text) && string.IsNullOrWhiteSpace(txtNuevaPass.Text);


            //if (ambosVacios == true)
            //{
            //    this.Close();
            //    FrmLoguin FrmLoguin = new FrmLoguin();
            //    FrmLoguin.Show();
            //}
            //else
            //{
            //    DialogResult opcion = MessageBox.Show("Hay datos ingresados, si cierra esta ventana se perderán \n ¿Seguro que quiere salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //    if (opcion == DialogResult.Yes)
            //    {
            //        this.Close();
            //        FrmLoguin FrmLoguin = new FrmLoguin();
            //        FrmLoguin.Show();
            //    }
            //}
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int mouse, mousex, mousey;

        private void pctBorde_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = 0;
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
                            // Se vuelve al formulario anterior (en este caso, frmPanelUsuarios).
                            _formularioAnterior.Show();
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

        //private void btnCambiar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ValidarCampos())
        //        {
        //            string passActual = requiereContraseñaActual ? txtPassActual.Text : string.Empty;
        //            string nuevaPass = txtNuevaPass.Text;
        //            bool resultado;
        //            string mensaje;

        //            if (requiereContraseñaActual)
        //            {
        //                // Cambio normal con verificación de contraseña actual
        //                resultado = objUsuarios.CambiarContraseña(usuario, passActual, nuevaPass, out mensaje);
        //            }
        //            else
        //            {
        //                // Cambio por administrador (primera contraseña)
        //                resultado = objUsuarios.CambiarPrimeraContraseña(usuario, nuevaPass, out mensaje);
        //            }

        //            if (resultado)
        //            {
        //                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                // Redirigir al panel de usuarios
        //                frmPanelUsuarios frm = new frmPanelUsuarios();
        //                frm.Show();
        //                this.Close();
        //            }
        //            else
        //            {
        //                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cambiar contraseña: " + ex.Message,
        //            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // Métodos para los placeholders (entrada y salida del foco)
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

        // Método para validar campos
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _formularioAnterior.Show();
            this.Close();
        }

        private void pctBorde_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse == 1)
            {
                int newX = MousePosition.X - mousex;
                int newY = MousePosition.Y - mousey;

                // Obtener el área de trabajo de la pantalla (sin la barra de tareas)
                Rectangle screenBounds = Screen.FromControl(this).WorkingArea;

                // Limitar la nueva posición del formulario dentro de la pantalla
                if (newX < screenBounds.Left)
                    newX = screenBounds.Left;
                if (newY < screenBounds.Top)
                    newY = screenBounds.Top;
                if (newX + this.Width > screenBounds.Right)
                    newX = screenBounds.Right - this.Width;
                if (newY + this.Height > screenBounds.Bottom)
                    newY = screenBounds.Bottom - this.Height;

                this.SetDesktopLocation(newX, newY);
            }
        }

        private void pctBorde_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = 1;
            mousex = e.X;
            mousey = e.Y;
        }
    }
}
