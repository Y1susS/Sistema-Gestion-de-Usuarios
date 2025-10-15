using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Vista
{
    public partial class frmBackUp : Form
    {
        private ClsArrastrarFormularios moverFormulario;

        // 1. Instanciamos la clase de lógica en el nivel de la clase
        private readonly CL_BackUp oCL_BackUp = new CL_BackUp();

        public frmBackUp()
        {
            InitializeComponent();

            moverFormulario = new ClsArrastrarFormularios(this);

            // 2. Suscribimos el evento de progreso en el constructor
            oCL_BackUp.ProgressChanged += OnBackupProgressChanged;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            // Creo una instancia del FolderBrowserDialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            // Muestro el cuadro de diálogo
            DialogResult result = fbd.ShowDialog();

            // Si el usuario seleccionó una carpeta y presionó Aceptar
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                // Asigna la ruta seleccionada al TextBox
                txtRutaBackup.Text = fbd.SelectedPath;
            }
        }

        private void btnGuardarrapido_Click(object sender, EventArgs e)
        {
            // 3. Modificamos el botón para que corra en segundo plano
            btnGuardarrapido.Enabled = false;
            btnGuardarUbicacionSeleccionada.Enabled = false;

            // Reiniciamos la otra barra para que no genere confusión
            pgbGuardadoPersonalizado.Value = 0;

            Task.Run(() =>
            {
                string resultado = oCL_BackUp.RealizarBackupRapido();

                // Usamos Invoke para actualizar la UI desde otro hilo
                Invoke(new Action(() =>
                {
                    MessageBox.Show(resultado, "Información de Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardarrapido.Enabled = true;
                    btnGuardarUbicacionSeleccionada.Enabled = true;
                    pgbGuardadoRapido.Value = 0; // Reiniciamos la barra
                }));
            });
        }

        private void btnGuardarUbicacionSeleccionada_Click(object sender, EventArgs e)
        {
            // 3. Modificamos el botón para que corra en segundo plano
            if (string.IsNullOrWhiteSpace(txtRutaBackup.Text))
            {
                MessageBox.Show("Por favor, seleccione una ruta de destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnGuardarrapido.Enabled = false;
            btnGuardarUbicacionSeleccionada.Enabled = false;

            // Reiniciamos la otra barra
            pgbGuardadoRapido.Value = 0;

            string rutaSeleccionada = txtRutaBackup.Text;

            Task.Run(() =>
            {
                string resultado = oCL_BackUp.RealizarBackupPersonalizado(rutaSeleccionada);

                Invoke(new Action(() =>
                {
                    MessageBox.Show(resultado, "Información de Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardarrapido.Enabled = true;
                    btnGuardarUbicacionSeleccionada.Enabled = true;
                    pgbGuardadoPersonalizado.Value = 0; // Reiniciamos la barra
                }));
            });
        }

        // 4. Creamos el método para manejar el evento de progreso
        private void OnBackupProgressChanged(object sender, int progress)
        {
            // Verificamos si la invocación es necesaria (si el hilo no es el de la UI)
            if (this.InvokeRequired)
            {
                Invoke(new Action(() => OnBackupProgressChanged(sender, progress)));
                return;
            }

            // Actualizamos la barra de progreso según el botón que esté deshabilitado.
            if (!btnGuardarrapido.Enabled)
            {
                pgbGuardadoRapido.Value = progress;
            }
            else if (!btnGuardarUbicacionSeleccionada.Enabled)
            {
                pgbGuardadoPersonalizado.Value = progress;
            }
        }

        private void frmBackUp_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}