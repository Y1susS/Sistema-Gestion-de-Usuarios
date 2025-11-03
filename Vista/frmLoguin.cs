using Entidades;
using Entidades.DTOs;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class FrmLoguin : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private readonly CL_Loguin objCL = new CL_Loguin();
        private bool _inicializando = true;
        public FrmLoguin()
        {
            InitializeComponent();
            cmbIdioma.DataSource = new BindingSource(Idioma.ObtenerIdiomasDisponibles(), null);
            cmbIdioma.DisplayMember = "Value";  // Muestra el nombre completo
            cmbIdioma.ValueMember = "Key";      // Usa el código de cultura ("es-AR")
            
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged); DoubleBuffered = true;
            
            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblTitulo);

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
            // CARGAR Y ESTABLECER el idioma (Aquí se maneja la cultura, se guarda el valor, y se limpia el corrupto)
            Idioma.CargarIdiomaGuardado();

            // APLICAR la traducción a todos los controles (Usa la cultura establecida en el paso 1)
            Idioma.AplicarTraduccion(this);

            // SELECCIONAR el idioma cargado en el ComboBox (para que coincida con la UI)
            string idiomaActual = Properties.Settings.Default.Idioma;

            if (!string.IsNullOrEmpty(idiomaActual) && cmbIdioma.Items.Count > 0)
            {
                cmbIdioma.SelectedValue = idiomaActual;
            }
            else if (Idioma.CulturaActual != null)
            {
                // Si no hay valor guardado, usa la cultura que se estableció por defecto ("es-AR")
                cmbIdioma.SelectedValue = Idioma.CulturaActual.Name;
            }
            _inicializando = false;

            // LÓGICA DE FOCO Y PLACEHOLDERS (Tu código original)
            this.BeginInvoke(new Action(() => this.ActiveControl = null));
            txtContrasenia.UseSystemPasswordChar = false;
            ClsPlaceHolder.Leave(USER_PLACEHOLDER, txtUsuario);
            ClsPlaceHolder.Leave(PLACEHOLDER_PASS, txtContrasenia, true);
        }
        

        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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
                    // La instancia de CL_Usuarios debe ser utilizada aquí.
                    // Si no la tienes, debes crearla:
                    CL_Usuarios objUsuarios = new CL_Usuarios();

                    // Llama al método para verificar si el usuario ya tiene preguntas de seguridad.
                    // Asegúrate de que el método UsuarioTienePreguntasDeSeguridad esté en la clase CL_Usuarios
                    if (objUsuarios.UsuarioTienePreguntasDeSeguridad(user))
                    {
                        // Si el usuario ya configuró preguntas, es una recuperación de contraseña.
                        MessageBox.Show("Debe cambiar su contraseña.",
                            "Cambio de contraseña requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Redirigimos al formulario de cambio de contraseña que no requiere la contraseña actual.
                        frmCambioPass frmCambio = new frmCambioPass(user, this, false);
                        frmCambio.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Si no tiene preguntas, es un usuario nuevo.
                        MessageBox.Show("Debe cambiar su contraseña por primera vez y configurar sus preguntas de seguridad.",
                            "Primer Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Redirigimos al formulario de primer ingreso que incluye la configuración de preguntas.
                        frmPrimerIngreso frmPrimer = new frmPrimerIngreso();
                        frmPrimer.Show();
                        this.Hide();
                    }
                    // *** FIN DE LA LÓGICA DE DISTINCIÓN ***
                }
                else
                {
                    // Asegurar que las preguntas de seguridad estén configuradas antes de permitir el acceso
                    CL_Usuarios objUsuarios = new CL_Usuarios();
                    if (!objUsuarios.UsuarioTienePreguntasDeSeguridad(user))
                    {
                        MessageBox.Show("Debe configurar sus preguntas de seguridad antes de continuar.",
                            "Configuración requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmPreguntas frm = new frmPreguntas(this);
                        frm.Show();
                        this.Hide();
                        return;
                    }

                    new frmPanelUsuarios().Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pctClose_Click_1(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void FrmLoguin_Shown(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bloqueo de inicialización: Ignoramos la llamada si estamos inicializando
            if (_inicializando)
            {
                return;
            }

            //Bloqueo de valor corrupto: Si el SelectedValue todavía contiene el error, lo ignoramos.
            if (cmbIdioma.SelectedValue == null || cmbIdioma.SelectedValue.ToString().Contains(","))
            {
                return;
            }

            if (cmbIdioma.SelectedValue.ToString() == Idioma.CulturaActual.Name)
            {
                return;
            }

            string nuevoIdioma = cmbIdioma.SelectedValue.ToString(); // Esto debe ser "es-AR" o "en-US"

            Idioma.CambiarIdioma(nuevoIdioma);
            Idioma.AplicarTraduccion(this);
        }
    }
}

