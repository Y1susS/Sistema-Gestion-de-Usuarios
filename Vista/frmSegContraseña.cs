using Sesion;
using Entidades.DTOs;
using Logica;
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
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmSegContraseña : Form
    {
        private ClsArrastrarFormularios moverFormulario;

        public frmSegContraseña()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);

            this.AcceptButton = btnGuardarCambioscont;
            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblTitulovalidaciones);
        }

        private void frmadmin_Load(object sender, EventArgs e)
        {
            CL_ConfiguracionContraseña logicaConfig = new CL_ConfiguracionContraseña();
            DtoConfiguracionSeguridad config = logicaConfig.ObtenerConfiguracion();
            if (config == null)
            {
                MessageBox.Show(
                    "No se ha encontrado ninguna configuración de seguridad de contraseña. Por favor, establezca los parámetros iniciales.",
                    "Configuración Inicial Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                chkMinCarac.Checked = false;
                nudCaractMin.Value = 0;
                chkMayusyMin.Checked = false;
                chkNumyLet.Checked = false;
                chkCaractEsp.Checked = false;
                chkReutContra.Checked = false;
                chkDatosPerson.Checked = false;

                // Intentos/minutos quedan sin valor por defecto: el usuario debe establecerlos y guardar
                nudCantidadIntentos.Value = nudCantidadIntentos.Minimum;
                nudMinutosBloqueo.Value = nudMinutosBloqueo.Minimum;
            }
            else
            {
                // Si existe la configuración, se carga
                chkMinCarac.Checked = config.MinimoCaracteres > 0;
                nudCaractMin.Value = config.MinimoCaracteres;
                chkMayusyMin.Checked = config.RequiereMayusMinus;
                chkNumyLet.Checked = config.RequiereNumLetra;
                chkCaractEsp.Checked = config.RequiereEspecial;
                chkReutContra.Checked = config.EvitarRepetidas;
                chkDatosPerson.Checked = config.EvitarDatosPersonales;
                nudDiasCambio.Value = config.DiasCambioPassword;
                // nuevos: intentos y minutos de bloqueo
                if (config.MaxIntentosLogin >= (int)nudCantidadIntentos.Minimum && config.MaxIntentosLogin <= (int)nudCantidadIntentos.Maximum)
                    nudCantidadIntentos.Value = config.MaxIntentosLogin;
                else
                    nudCantidadIntentos.Value = Math.Min(Math.Max(config.MaxIntentosLogin, (int)nudCantidadIntentos.Minimum), (int)nudCantidadIntentos.Maximum);

                if (config.MinutosBloqueoLogin >= (int)nudMinutosBloqueo.Minimum && config.MinutosBloqueoLogin <= (int)nudMinutosBloqueo.Maximum)
                    nudMinutosBloqueo.Value = config.MinutosBloqueoLogin;
                else
                    nudMinutosBloqueo.Value = Math.Min(Math.Max(config.MinutosBloqueoLogin, (int)nudMinutosBloqueo.Minimum), (int)nudMinutosBloqueo.Maximum);
            }
        }
        //si esta habilitado el checkbox, habilita el num updown
        private void chkMinCarac_CheckedChanged(object sender, EventArgs e)
        {
            nudCaractMin.Enabled = chkMinCarac.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DtoConfiguracionSeguridad dto = new DtoConfiguracionSeguridad()
            {
                Id = 1, 
                MinimoCaracteres = chkMinCarac.Checked ? (int)nudCaractMin.Value : 0,
                RequiereMayusMinus = chkMayusyMin.Checked,
                RequiereNumLetra = chkNumyLet.Checked,
                RequiereEspecial = chkCaractEsp.Checked,
                EvitarRepetidas = chkReutContra.Checked,
                EvitarDatosPersonales = chkDatosPerson.Checked,
                DiasCambioPassword = (int)nudDiasCambio.Value,
                // nuevos campos tomados 100% desde la UI (que refleja BD si existía)
                MaxIntentosLogin = (int)nudCantidadIntentos.Value,
                MinutosBloqueoLogin = (int)nudMinutosBloqueo.Value
            };

            CL_ConfiguracionContraseña logicaConfig = new CL_ConfiguracionContraseña();
            bool ok = false;

            try
            {
                ok = logicaConfig.GuardarConfiguracion(dto);

                if (ok)
                {
                    MessageBox.Show("Configuración guardada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClsSesionActual.SetConfiguracionContrasena(dto);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la configuración. La base de datos no fue afectada. (Verifique los datos o la lógica de negocio)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ApplicationException ex) 
            {
                MessageBox.Show($"Error de validación: {ex.Message}", "Error de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Ocurrió un error inesperado al guardar la configuración: {ex.Message}\nPor favor, contacte a soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSegContraseña_Shown(object sender, EventArgs e)
        {
            this.AcceptButton = btnGuardarCambioscont;
            this.ActiveControl = null;
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

