using Entidades;
using Entidades.DTOs;
using Logica;
using Sistema_Gestion_de_Usuarios.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmPreguntas : Form
    {
        private readonly CL_Preguntas objPreguntas = new CL_Preguntas();
        private List<ComboBox> combosPreguntas;
        private List<TextBox> txtRespuestas;
        private Form _formularioAnterior;
        private List<DtoPregunta> todasLasPreguntas;
        private ClsArrastrarFormularios moverFormulario;
        private bool _configuracionCompletada = false; // Flag para impedir cierre

        public frmPreguntas()
        {
            InitializeComponent();
            InicializarControles();

            this.FormClosing += FrmPreguntas_FormClosing;
        }

        public frmPreguntas(Form formularioAnterior)
        {
            InitializeComponent();
            _formularioAnterior = formularioAnterior;
            this.AcceptButton = btnsigpregseg;
            InicializarControles();
            this.FormClosing += FrmPreguntas_FormClosing;
        }


        private void frmPreguntas_Load(object sender, EventArgs e)
        {

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(lbltitpregsegu);
            moverFormulario.HabilitarMovimiento(pctLogo);

            this.AcceptButton = btnsigpregseg;
            lblUsuariopregserg.Text = $"Usuario: {ClsSesionActual.Usuario.User}";
            lblInstrucciones.Text = "Por favor, seleccione 3 preguntas de seguridad y proporcione sus respuestas." +
                                  Environment.NewLine +
                                  "Estas preguntas serán utilizadas para verificar su identidad si necesita recuperar su contraseña.";

            CargarPreguntas();

            // Permitir cerrar el formulario solo si ya tiene preguntas configuradas
            try
            {
                var usuariosSvc = new CL_Usuarios();
                bool tienePreguntas = usuariosSvc.UsuarioTienePreguntasDeSeguridad(ClsSesionActual.Usuario.User);

                if (tienePreguntas)
                {
                    _configuracionCompletada = true;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error al cargar configuracion de preguntas: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarControles()
        {
            combosPreguntas = new List<ComboBox> { cmbPregunta1, cmbPregunta2, cmbPregunta3 };
            txtRespuestas = new List<TextBox> { txtRespuesta1, txtRespuesta2, txtRespuesta3 };

            foreach (TextBox txt in txtRespuestas)
            {
                txt.KeyPress += TxtRespuesta_KeyPress;
            }

            foreach (ComboBox combo in combosPreguntas)
            {
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        }


        private void CargarPreguntas()
        {
            todasLasPreguntas = objPreguntas.ObtenerPreguntas();

            foreach (var combo in combosPreguntas)
            {
                combo.SelectedIndexChanged += ComboPreguntas_SelectedIndexChanged;
            }

            ActualizarCombos();
        }
        private void ActualizarCombos()
        {
            for (int i = 0; i < combosPreguntas.Count; i++)
            {
                var comboActual = combosPreguntas[i];

                var idsSeleccionados = combosPreguntas
                    .Where((c, index) => index != i && c.SelectedValue is int)
                    .Select(c => (int)c.SelectedValue)
                    .ToHashSet();

                var preguntasDisponibles = todasLasPreguntas
                    .Where(p => !idsSeleccionados.Contains(p.Id_Pregunta))
                    .ToList();

                var seleccionAnterior = comboActual.SelectedValue;

                comboActual.SelectedIndexChanged -= ComboPreguntas_SelectedIndexChanged;

                comboActual.DataSource = null;
                comboActual.DataSource = preguntasDisponibles;
                comboActual.DisplayMember = "Pregunta";
                comboActual.ValueMember = "Id_Pregunta";

                if (seleccionAnterior != null && preguntasDisponibles.Any(p => p.Id_Pregunta.Equals(seleccionAnterior)))
                {
                    comboActual.SelectedValue = seleccionAnterior;
                }
                else
                {
                    comboActual.SelectedIndex = -1;
                }

                comboActual.SelectedIndexChanged += ComboPreguntas_SelectedIndexChanged;
            }
        }
        private void ComboPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCombos();
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (ValidarSelecciones())
            {
                List<DtoRespuesta> respuestas = new List<DtoRespuesta>();

                for (int i = 0; i < combosPreguntas.Count; i++)
                {
                    respuestas.Add(new DtoRespuesta
                    {
                        Id_Pregunta = (int)combosPreguntas[i].SelectedValue,
                        Respuesta = txtRespuestas[i].Text.Trim()
                    });
                }

                if (objPreguntas.RegistrarRespuestas(respuestas, out string mensaje))
                {
                    _configuracionCompletada = true; // permitir cierre
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmPanelUsuarios frmAdmin = new frmPanelUsuarios();
                    frmAdmin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarSelecciones()
        {
            for (int i = 0; i < combosPreguntas.Count; i++)
            {
                if (combosPreguntas[i].SelectedIndex == -1)
                {
                    MessageBox.Show($"Por favor seleccione la pregunta {i + 1}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtRespuestas[i].Text))
                {
                    MessageBox.Show($"Por favor responda a la pregunta {i + 1}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            HashSet<int> preguntasSeleccionadas = new HashSet<int>();
            foreach (var combo in combosPreguntas)
            {
                int idPregunta = (int)combo.SelectedValue;
                if (preguntasSeleccionadas.Contains(idPregunta))
                {
                    MessageBox.Show("No puede seleccionar la misma pregunta más de una vez",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                preguntasSeleccionadas.Add(idPregunta);
            }

            return true;
        }

        private void TxtRespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void FrmPreguntas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_configuracionCompletada && e.CloseReason == CloseReason.UserClosing)
            {
                MessageBox.Show("Debe completar la configuración de preguntas de seguridad antes de cerrar esta ventana.",
                    "Acción requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void pctClose_Click_1(object sender, EventArgs e)
        {
            if (!_configuracionCompletada)
            {
                MessageBox.Show("Debe completar la configuración de preguntas de seguridad antes de cerrar esta ventana.",
                    "Acción requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmPreguntas_Shown(object sender, EventArgs e)
        {
            this.AcceptButton = btnsigpregseg;
            cmbPregunta1.Focus();

        }
    }
}

