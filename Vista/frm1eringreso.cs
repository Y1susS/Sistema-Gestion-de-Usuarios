using Logica;
using Sesion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frm1eringreso : Form
    {
        public frm1eringreso()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            frmPreguntas frmpreguntas = new frmPreguntas(this);
            frmpreguntas.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            string nuevaPass = txtContraNueva1.Text;
            string confirmarPass = txtContraNueva2.Text;

            if (nuevaPass != confirmarPass)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            CL_ConfiguracionContraseña logicaConfig = new CL_ConfiguracionContraseña();
            DtoConfiguracionContraseña config = logicaConfig.ObtenerConfiguracion();
            CL_Usuarios objPoliticas = new CL_Usuarios();
            DtoDatosPersonalesPw usuarioActualDetalle = null;


            if (config == null)
            {
                MessageBox.Show("No se pudo cargar la configuración de seguridad de la contraseña. No se puede validar la contraseña.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar la contraseña según las políticas obtenidas
            if (!objPoliticas.ValidarNuevaContrasenaSegunPoliticas(nuevaPass, usuarioActualDetalle, out string mensaje))
            {
                MessageBox.Show(mensaje, "Contraseña no Válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Contraseña válida. Se puede proceder con el guardado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
