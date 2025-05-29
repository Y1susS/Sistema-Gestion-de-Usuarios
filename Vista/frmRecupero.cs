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
    public partial class frmRecupero : Form
    {
        private string dni = "";
        private string preguntaseleccionada = "";
        private string respuesta = "";

          
        public frmRecupero()
        {
            InitializeComponent();
            DoubleBuffered = true;
            pctFondo.Controls.Add(pctLogo);
            pctLogo.BackColor = Color.Transparent;
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
         
            bool ambosVacios = string.IsNullOrWhiteSpace(txtdni.Text) && string.IsNullOrWhiteSpace(txtContrasenia2.Text);

            if (ambosVacios == true)
            {
                this.Close();
                FrmLoguin FrmLoguin = new FrmLoguin();
                FrmLoguin.Show();
            }
            else
            {
                DialogResult opcion = MessageBox.Show("Hay datos ingresados, si cierra esta ventana se perderán \n ¿Seguro que quiere salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (opcion == DialogResult.Yes)
                {
                    this.Close();
                    FrmLoguin FrmLoguin = new FrmLoguin();
                    FrmLoguin.Show();
                }
            }
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

        private const string USER_PLACEHOLDER = "1ra pregunta";
        private const string PLACEHOLDER_PASS = "2ra pregunta";
        private const string PLACEHOLDER_3RDquestion = "3ra pregunta";


        private void frmRecupero_Load(object sender, EventArgs e)
        {
            txtContrasenia2.UseSystemPasswordChar = false;
            ClsPlaceHolder.Leave(USER_PLACEHOLDER, txtdni);
            ClsPlaceHolder.Leave(PLACEHOLDER_PASS, txtContrasenia2, true);
        }

        private void txtdni_TextChanged(object sender, EventArgs e)
        {
            string dni = txtrespuesta.Text.Trim();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void cmbpreguntasseg_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbpreguntasseg.Items.Add("¿Cuál es el nombre de tu primera mascota?");
            cmbpreguntasseg.Items.Add("¿Cuál es tu comida favorita?");
            cmbpreguntasseg.Items.Add("¿Cuál es el segundo nombre de tu madre?");

            string preguntaSeleccionada = cmbpreguntasseg.SelectedItem.ToString();


        }

        private void txtrespuesta_TextChanged(object sender, EventArgs e)
        {
            string respuestaIngresada = txtrespuesta.Text.Trim();
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
