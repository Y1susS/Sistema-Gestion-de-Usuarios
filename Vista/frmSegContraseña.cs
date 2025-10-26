using Logica;
using Entidades;
using Entidades.DTOs;
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
    public partial class frmSegContraseña : Form
    {
        private ClsArrastrarFormularios moverFormulario;

        public frmSegContraseña()
        {
            InitializeComponent();

            this.AcceptButton = btnGuardarCambios;
            moverFormulario = new ClsArrastrarFormularios(this);
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

                // btnVolveradmin.Enabled = false; // Habilitar boton volver solo después de guardar. VER

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
                DiasCambioPassword = (int)nudDiasCambio.Value
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
            this.AcceptButton = btnGuardarCambios;
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

