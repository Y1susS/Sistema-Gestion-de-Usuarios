using Entidades;
using Entidades.DTOs;
using Logica;
using Servicios;
using Sesion;
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
    public partial class frmRecupero : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private string dni = "";
        private string preguntaseleccionada = "";
        private string respuesta = "";

          
        public frmRecupero()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);

            this.AcceptButton = btnSiguienterecupero;

            DoubleBuffered = true;

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblRecuperacion);

            ClsFondoTransparente.Aplicar(
            pctFondo,
            pctLogo,
            lblPreguntarecupero,
            btnSiguienterecupero);
        }

        private const string DNI_PLACEHOLDER = "Ingrese DNI";
        private const string RESPUESTA_PLACEHOLDER = "Ingrese su respuesta";

        private void txtdni_TextChanged_1(object sender, EventArgs e)
        {
            string dni = txtrespuesta.Text.Trim();
        }

        private void txtrespuesta_TextChanged(object sender, EventArgs e)
        {
            string respuestaIngresada = txtrespuesta.Text.Trim();
        }

        CL_VerificarRecupero objUsuario = new CL_VerificarRecupero();

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CL_Usuarios objUsuarios = new CL_Usuarios();

            // Validaciones de campos de entrada
            if (string.IsNullOrWhiteSpace(txtdni.Text) || txtdni.Text == DNI_PLACEHOLDER)
            {
                MessageBox.Show("Ingrese su documento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nueva validación: DNI registrado pero sin preguntas configuradas → bloquear recuperación
            string documento = txtdni.Text.Trim();
            try
            {
                var datosUsuario = objUsuarios.ObtenerUsuarioDetallePorDni(documento);
                if (datosUsuario == null)
                {
                    MessageBox.Show("El documento ingresado no corresponde a un usuario registrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool tienePreguntas = objUsuarios.UsuarioTienePreguntasDeSeguridad(datosUsuario.User);
                if (!tienePreguntas)
                {
                    MessageBox.Show("El usuario no posee preguntas de seguridad configuradas. Comuníquese con el administrador.",
                                    "Recuperación no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al validar el estado de seguridad del usuario: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbpreguntasseg.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una pregunta de seguridad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtrespuesta.Text) || txtrespuesta.Text == RESPUESTA_PLACEHOLDER)
            {
                MessageBox.Show("Ingrese la respuesta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPregunta = Convert.ToInt32(cmbpreguntasseg.SelectedValue);
            string respuesta = txtrespuesta.Text.Trim().ToLower();

            try
            {
                bool valido = objUsuario.VerificarRecupero(documento, idPregunta, respuesta);

                if (valido)
                {
                    // Obtiene los datos del usuario para el email
                    DtoDatosPersonalesPw usuarioRecuperado = objUsuarios.ObtenerUsuarioDetallePorDni(documento);

                    if (usuarioRecuperado == null || string.IsNullOrEmpty(usuarioRecuperado.Email) || string.IsNullOrEmpty(usuarioRecuperado.User))
                    {
                        MessageBox.Show("No se pudo obtener la información de contacto del usuario o el email no está registrado para ese DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string passGenerada = ClsAleatorios.Armar(true, 10, 1);

                    // Actualiza la contraseña en la base de datos
                    bool actualizacionExitosa = objUsuarios.ActualizarContrasenaUsuario(usuarioRecuperado.User, passGenerada);

                    if (actualizacionExitosa)
                    {
                        // Después de actualizar la contraseña, se marca al usuario para que deba cambiarla en el próximo inicio de sesión.
                        bool actualizacionPrimeraClaveExitosa = objUsuarios.ActualizarPrimeraClave(usuarioRecuperado.User, true);

                        if (!actualizacionPrimeraClaveExitosa)
                        {
                            MessageBox.Show("La contraseña se actualizó, pero no se pudo marcar el estado para cambio forzado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        try
                        {
                            ClsArmarMail.DireccionCorreo = usuarioRecuperado.Email;
                            ClsArmarMail.Asunto = "Recuperación de Contraseña - Sistema ReMuebla";
                            ClsArmarMail.NuevaContraseña = passGenerada;
                            ClsArmarMail.Preparar();
                            MessageBox.Show($"¡Contraseña restablecida y enviada!\n\nSe ha enviado un correo a '{usuarioRecuperado.Email}' con su nueva contraseña.",
                                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Volver a un login limpio (sin crear una segunda instancia si ya existe)
                            var login = Application.OpenForms.OfType<FrmLoguin>().FirstOrDefault();
                            if (login == null) login = new FrmLoguin();
                            try { login.ReiniciarEstado(); } catch { }
                            if (!login.Visible) login.Show();
                            login.Activate();

                            this.Close();
                        }
                        catch (Exception exMail)
                        {
                            MessageBox.Show($"La contraseña se actualizó en el sistema, pero hubo un error al enviar el correo electrónico: {exMail.Message}\nPor favor, contacte al soporte técnico.",
                                            "Error de Envío de Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            // Si falla el envío de mail, volvemos al login limpio igual.
                            var login = Application.OpenForms.OfType<FrmLoguin>().FirstOrDefault();
                            if (login == null) login = new FrmLoguin();
                            try { login.ReiniciarEstado(); } catch { }
                            if (!login.Visible) login.Show();
                            login.Activate();

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la contraseña en la base de datos. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("DNI o respuesta de seguridad incorrecta. Verifique sus datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error inesperado durante el proceso de recuperación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //COMBO PREGUNTAS//

        CL_Preguntas objPreguntas = new CL_Preguntas();

        private void LlenarCombo()
        {
            cmbpreguntasseg.DataSource = objPreguntas.MostrarPreguntas();
            cmbpreguntasseg.DisplayMember = "Pregunta";
            cmbpreguntasseg.ValueMember = "Id_Pregunta";
            cmbpreguntasseg.SelectedIndex = -1;
        }

        private void frmRecupero_Load(object sender, EventArgs e)
        {

            LlenarCombo();
            txtdni.KeyPress += txtdni_KeyPress;
            cmbpreguntasseg.DropDownStyle = ComboBoxStyle.DropDownList;
            txtrespuesta.KeyPress += txtrespuesta_KeyPress;
            ClsPlaceHolder.Leave(DNI_PLACEHOLDER, txtdni);
            ClsPlaceHolder.Leave(RESPUESTA_PLACEHOLDER, txtrespuesta);
            this.BeginInvoke(new Action(() => this.ActiveControl = null)); // Evita que un TextBox tenga el foco inicial
        }

        private void txtdni_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(DNI_PLACEHOLDER, txtdni);
        }

        private void txtdni_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(DNI_PLACEHOLDER, txtdni);
        }

        private void txtrespuesta_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(RESPUESTA_PLACEHOLDER, txtrespuesta);
        }

        private void txtrespuesta_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(RESPUESTA_PLACEHOLDER, txtrespuesta);
        }

        private void txtdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo se permiten números 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
            // solo permite 8 digitos max
            if (char.IsDigit(e.KeyChar) && txtdni.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtrespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo letras, espacios y teclas de control (backspace, etc.)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            // Si el usuario cierra este formulario, volver a un login limpio si existe
            var login = Application.OpenForms.OfType<FrmLoguin>().FirstOrDefault();
            if (login != null)
            {
                try { login.ReiniciarEstado(); } catch { }
                if (!login.Visible) login.Show();
                login.Activate();
            }
            this.Close();
        }

        private void frmRecupero_Shown(object sender, EventArgs e)
        {
            this.AcceptButton = btnSiguienterecupero;
        }
    }
}
