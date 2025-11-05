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
    public partial class frmBackUp : Form
    {
        private ClsArrastrarFormularios moverFormulario;

        private readonly CL_BackUp oCL_BackUp = new CL_BackUp();

        public frmBackUp()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            moverFormulario = new ClsArrastrarFormularios(this);

            oCL_BackUp.ProgressChanged += OnBackupProgressChanged;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtRutaBackup.Text = fbd.SelectedPath;
            }
        }

        private void btnGuardarrapido_Click(object sender, EventArgs e)
        {
            btnGuardarrapido.Enabled = false;
            btnGuardarUbicacionSeleccionada.Enabled = false;

            if (pgbGuardadoPersonalizado != null) pgbGuardadoPersonalizado.Value = 0;

            Task.Run(() =>
            {
                string resultado = oCL_BackUp.RealizarBackupRapido();

                // Usamos Invoke para actualizar la UI desde otro hilo
                Invoke(new Action(() =>
                {
                    MessageBox.Show(resultado, "Información de Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardarrapido.Enabled = true;
                    btnGuardarUbicacionSeleccionada.Enabled = true;
                    if (pgbGuardadoRapido != null) pgbGuardadoRapido.Value = 0; // Reiniciamos la barra
                }));
            });
        }

        private void btnGuardarUbicacionSeleccionada_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRutaBackup.Text))
            {
                MessageBox.Show("Por favor, seleccione una ruta de destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnGuardarrapido.Enabled = false;
            btnGuardarUbicacionSeleccionada.Enabled = false;

            if (pgbGuardadoRapido != null) pgbGuardadoRapido.Value = 0;

            string rutaSeleccionada = txtRutaBackup.Text;

            Task.Run(() =>
            {
                string resultado = oCL_BackUp.RealizarBackupPersonalizado(rutaSeleccionada);

                Invoke(new Action(() =>
                {
                    MessageBox.Show(resultado, "Información de Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardarrapido.Enabled = true;
                    btnGuardarUbicacionSeleccionada.Enabled = true;
                    if (pgbGuardadoPersonalizado != null) pgbGuardadoPersonalizado.Value = 0; // Reiniciamos la barra
                }));
            });
        }

        private void OnBackupProgressChanged(object sender, int progress)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action(() => OnBackupProgressChanged(sender, progress)));
                return;
            }

            if (!btnGuardarrapido.Enabled && pgbGuardadoRapido != null)
            {
                pgbGuardadoRapido.Value = progress;
            }
            else if (!btnGuardarUbicacionSeleccionada.Enabled && pgbGuardadoPersonalizado != null)
            {
                pgbGuardadoPersonalizado.Value = progress;
            }
        }

        private void frmBackUp_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnExaminarBackup_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Archivos de Backup SQL (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                    ofd.Title = "Seleccione el archivo de Backup para restaurar";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtExaminarBackup.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar abrir el explorador de archivos. Verifique que el TextBox de ruta se llame 'txtExaminarBackup'. Detalles: {ex.Message}", "Error de Conexión de Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCargarBackup_Click_1(object sender, EventArgs e)
        {
            string rutaArchivoBackup = txtExaminarBackup.Text;

            if (string.IsNullOrWhiteSpace(rutaArchivoBackup))
            {
                MessageBox.Show("Por favor, seleccione el archivo de backup (.bak) a restaurar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                "ADVERTENCIA CRÍTICA: La base de datos actual será REEMPLAZADA por el archivo de backup seleccionado. Perderá todos los cambios realizados desde que se creó ese archivo. ¿Desea continuar?",
                "Confirmar Restauración de Base de Datos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.No)
            {
                return; // El usuario canceló la operación
            }

            btnCargarBackup.Enabled = false;
            btnExaminarBackup.Enabled = false;

            string resultado = string.Empty;

            try
            {
                resultado = await Task.Run(() => oCL_BackUp.RealizarRestore(rutaArchivoBackup));
            }
            catch (Exception ex)
            {
                resultado = $"Error inesperado al intentar restaurar: {ex.Message}";
            }

            MessageBox.Show(resultado,
                            resultado.StartsWith("Error") ? "Error en Restauración" : "Restauración Exitosa",
                            MessageBoxButtons.OK,
                            resultado.StartsWith("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);

            btnCargarBackup.Enabled = true;
            btnExaminarBackup.Enabled = true;
        }

    }
}