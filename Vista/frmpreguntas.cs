using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Logica;
using Sesion;
using Sesion.Entidades;

namespace Vista
{
    public partial class frmPreguntas : Form
    {
        private readonly CL_Preguntas objPreguntas = new CL_Preguntas();
        private List<ComboBox> combosPreguntas;
        private List<TextBox> txtRespuestas;
        private Form _formularioAnterior;


        public frmPreguntas(Form formularioAnterior)
        {
            InitializeComponent();
            _formularioAnterior = formularioAnterior;

            combosPreguntas = new List<ComboBox> { cmbPregunta1, cmbPregunta2, cmbPregunta3 };
            txtRespuestas = new List<TextBox> { txtRespuesta1, txtRespuesta2, txtRespuesta3 };
        }

        private void frmPreguntas_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"Usuario: {ClsSesionActual.Usuario.User}";
            lblInstrucciones.Text = "Por favor, seleccione 3 preguntas de seguridad y proporcione sus respuestas." +
                                  Environment.NewLine +
                                  "Estas preguntas serán utilizadas para verificar su identidad si necesita recuperar su contraseña.";
            
            CargarPreguntas();
        }

        private void CargarPreguntas()
        {
            var preguntas = objPreguntas.ObtenerPreguntas();
            
            foreach (var combo in combosPreguntas)
            {
                combo.DataSource = new List<DtoPregunta>(preguntas);
                combo.DisplayMember = "Pregunta";
                combo.ValueMember = "Id_Pregunta";
                combo.SelectedIndex = -1;
            }
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (ValidarSelecciones())
            {
                List<DtoRespuesta> respuestas = new List<DtoRespuesta>();
                
                // Recopilar las respuestas
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
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Redirigir al formulario principal
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
            // Verificar que todas las preguntas están seleccionadas
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
            
            // Verificar que no hay preguntas repetidas
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

        private void btnvolver_Click(object sender, EventArgs e)
        {
            _formularioAnterior.Show();  // Muestra el formulario anterior (frmPanelUsuarios)
            this.Close();
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPanelUsuarios frmPanelUsuarios = new frmPanelUsuarios();
            frmPanelUsuarios.Show();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
