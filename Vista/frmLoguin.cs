using Entidades;
using Entidades.DTOs;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization; // Asegúrate de tener este using aquí también para CultureInfo
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Vista.Lenguajes;


namespace Vista
{
    public partial class FrmLoguin : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private readonly CL_Loguin objCL = new CL_Loguin();

        // Constantes para PlaceHolder (asegúrate de que estén aquí o sean accesibles)
        private const string USER_PLACEHOLDER = "Usuario";
        private const string PLACEHOLDER_PASS = "Contraseña";

        public FrmLoguin()
        {
            Properties.Settings.Default.Reset();
            InitializeComponent();
               
            cboIdioma.DataSource = new BindingSource(Idioma.ObtenerIdiomasDisponibles(), null);
            cboIdioma.DisplayMember = "Value";  // Lo que se muestra (ej: "English (United States)")
            cboIdioma.ValueMember = "Key";      // Lo que se usa internamente (ej: "en-US")
            
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);

            string idiomaActual = Properties.Settings.Default.Idioma;
            if (!string.IsNullOrEmpty(idiomaActual) && cboIdioma.Items.Count > 0)
            {
                cboIdioma.SelectedValue = idiomaActual;
            }
            // Si el idioma no está guardado o no se encuentra, seleccionar el idioma actual de la app
            else if (Idioma.CulturaActual != null)
            {
                cboIdioma.SelectedValue = Idioma.CulturaActual.Name;
            }


            // ** ASIGNACIÓN DEL EVENTO DEL COMBOBOX - CRÍTICO para CS1061 **
            // DEBE ESTAR DESPUÉS de InitializeComponent() y la configuración del cboIdioma.
            this.cboIdioma.SelectionChangeCommitted += new System.EventHandler(this.cboIdioma_SelectionChangeCommitted);

            DoubleBuffered = true;

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            // Si lblTitulo no existe en tu formulario, elimina esta línea
            // moverFormulario.HabilitarMovimiento(lblTitulo); 

            // Revisa si ClsFondoTransparente.Aplicar necesita las imágenes aquí.
            // Si es así, las imágenes deben haber sido cargadas por el diseñador o en FrmLoguin_Load.
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
            // --- 1. Inicialización de UI ---
            this.BeginInvoke(new Action(() => this.ActiveControl = null)); // Evita que un TextBox tenga el foco inicial
            txtContrasenia.UseSystemPasswordChar = false;
            ClsPlaceHolder.Leave(USER_PLACEHOLDER, txtUsuario);
            ClsPlaceHolder.Leave(PLACEHOLDER_PASS, txtContrasenia, true);

            // --- 2. CARGA DE IMÁGENES ELIMINADA ---
            // Hemos eliminado todas las líneas que intentaban cargar imágenes de Vista.Lenguajes.Strings.
            // Las imágenes DEBEN ser cargadas por el diseñador o desde Properties.Resources.
        }

        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            frmRecupero frmRecupero = new frmRecupero();
            Idioma.AplicarTraduccion(frmRecupero); // Aplica traducción al nuevo formulario
            frmRecupero.ShowDialog();
        }

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
                    CL_Usuarios objUsuarios = new CL_Usuarios();

                    if (objUsuarios.UsuarioTienePreguntasDeSeguridad(user))
                    {
                        MessageBox.Show("Debe cambiar su contraseña.",
                            "Cambio de contraseña requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmCambioPass frmCambio = new frmCambioPass(user, this, false);
                        Idioma.AplicarTraduccion(frmCambio); // Aplica traducción al nuevo formulario
                        frmCambio.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Debe cambiar su contraseña por primera vez y configurar sus preguntas de seguridad.",
                            "Primer Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmPrimerIngreso frmPrimer = new frmPrimerIngreso();
                        Idioma.AplicarTraduccion(frmPrimer); // Aplica traducción al nuevo formulario
                        frmPrimer.Show();
                        this.Hide();
                    }
                    // *** FIN DE LA LÓGICA DE DISTINCIÓN ***
                }
                else
                {
                    frmPanelUsuarios panel = new frmPanelUsuarios();
                    Idioma.AplicarTraduccion(panel);
                    panel.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasenia.Clear();
            }
        }

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

        // ** MÉTODO DEL EVENTO DEL COMBOBOX - CRÍTICO para CS1061 **
        private void cboIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Obtener el código de idioma seleccionado (ej: "es-AR" o "en-US")
            string nuevoIdioma = cboIdioma.SelectedValue.ToString();

            // Cambiar el idioma y guardar la preferencia
            Idioma.CambiarIdioma(nuevoIdioma);

            // Aplicar la traducción al formulario actual
            Idioma.AplicarTraduccion(this);

            // Como las imágenes se gestionan por el diseñador/Load, no necesitamos recargarlas aquí.
        }
    }
}