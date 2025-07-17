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
using Logica;
using Sesion;

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

            DoubleBuffered = true;

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pctBorde);
            moverFormulario.HabilitarMovimiento(lblRecuperacion);

            ClsFondoTransparente.Aplicar(
            pctFondo,
            pctLogo,
            lblPregunta);
        }
        private void PctClose_Click(object sender, EventArgs e)
        {
            {
                bool dniVacio = string.IsNullOrWhiteSpace(txtdni.Text) || txtdni.Text == DNI_PLACEHOLDER;
                bool respuestaVacia = string.IsNullOrWhiteSpace(txtrespuesta.Text) || txtrespuesta.Text == RESPUESTA_PLACEHOLDER;

                if (respuestaVacia && dniVacio == true)
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

        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private const string DNI_PLACEHOLDER = "Ingrese DNI";
        private const string RESPUESTA_PLACEHOLDER = "Ingrese su respuesta";

        private void txtdni_TextChanged_1(object sender, EventArgs e)
        {
            string dni = txtrespuesta.Text.Trim();
        }

        private void cmbpreguntasseg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string preguntaSeleccionada = cmbpreguntasseg.SelectedItem.ToString();
        }

        private void txtrespuesta_TextChanged(object sender, EventArgs e)
        {
            string respuestaIngresada = txtrespuesta.Text.Trim();
        }

        CL_VerificarRecupero objUsuario = new CL_VerificarRecupero();

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            {
                bool dniVacio = string.IsNullOrWhiteSpace(txtdni.Text) || txtdni.Text == DNI_PLACEHOLDER;
                bool respuestaVacia = string.IsNullOrWhiteSpace(txtrespuesta.Text) || txtrespuesta.Text == RESPUESTA_PLACEHOLDER;
                string documento = txtdni.Text.Trim();

                if (dniVacio)
                {
                  MessageBox.Show("Ingrese su documento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
                }

                if (cmbpreguntasseg.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una pregunta de seguridad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (respuestaVacia)
                {
                    MessageBox.Show("Ingrese la respuesta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPregunta = Convert.ToInt32(cmbpreguntasseg.SelectedValue);
                string respuesta = txtrespuesta.Text.Trim().ToLower();

                bool valido = objUsuario.VerificarRecupero(documento, idPregunta, respuesta);

                if (valido)
                {
                    MessageBox.Show("Respuesta correcta. Se enviará la nueva contraseña.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Aquí seguir con el flujo (ej: envío de mail)
                    FrmLoguin frmloggin = new FrmLoguin();
                    frmloggin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Respuesta incorrecta. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //enviar E-Mail

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

    }
}
