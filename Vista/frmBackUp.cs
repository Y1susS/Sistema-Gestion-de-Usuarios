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

        // 1. Instanciamos la clase de lógica en el nivel de la clase
        private readonly CL_BackUp oCL_BackUp = new CL_BackUp();

        public frmBackUp()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
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
            // Se asume que tienes un control llamado pgbGuardadoPersonalizado
            // Se asume que tienes un control llamado pgbGuardadoRapido
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
            // 3. Modificamos el botón para que corra en segundo plano
            if (string.IsNullOrWhiteSpace(txtRutaBackup.Text))
            {
                MessageBox.Show("Por favor, seleccione una ruta de destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnGuardarrapido.Enabled = false;
            btnGuardarUbicacionSeleccionada.Enabled = false;

            // Reiniciamos la otra barra
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
            // Nota: Se asume que tienes pgbGuardadoRapido y pgbGuardadoPersonalizado
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


        // ***************************************************************
        // LÓGICA DE RESTAURACIÓN (USANDO SUFIJO _1)
        // ***************************************************************

        // Método para seleccionar el archivo .bak (Botón Examinar de Cargar Back Up)
        private void btnExaminarBackup_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Usamos OpenFileDialog para seleccionar un archivo, no una carpeta
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Archivos de Backup SQL (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                    ofd.Title = "Seleccione el archivo de Backup para restaurar";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        // Se asume que el TextBox de la ruta de Restore se llama txtExaminarBackup
                        txtExaminarBackup.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                // Este error ocurre si el control txtExaminarBackup no existe o no es accesible.
                MessageBox.Show($"Error al intentar abrir el explorador de archivos. Verifique que el TextBox de ruta se llame 'txtExaminarBackup'. Detalles: {ex.Message}", "Error de Conexión de Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para iniciar la restauración (Botón Cargar Back Up)
        private async void btnCargarBackup_Click_1(object sender, EventArgs e)
        {
            // Asume que el TextBox de la ruta de Restore se llama txtExaminarBackup
            string rutaArchivoBackup = txtExaminarBackup.Text;

            if (string.IsNullOrWhiteSpace(rutaArchivoBackup))
            {
                MessageBox.Show("Por favor, seleccione el archivo de backup (.bak) a restaurar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Advertencia crítica de seguridad: la restauración es destructiva.
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

            // Deshabilitar controles para evitar interacción durante el proceso
            // Se asume que los botones se llaman btnCargarBackup y btnExaminarBackup
            btnCargarBackup.Enabled = false;
            btnExaminarBackup.Enabled = false;

            string resultado = string.Empty;

            try
            {
                // Ejecutamos la operación pesada en un hilo de trabajo (Task.Run)
                resultado = await Task.Run(() => oCL_BackUp.RealizarRestore(rutaArchivoBackup));
            }
            catch (Exception ex)
            {
                resultado = $"Error inesperado al intentar restaurar: {ex.Message}";
            }

            // Volvemos al hilo de la UI para mostrar el resultado y re-habilitar
            MessageBox.Show(resultado,
                            resultado.StartsWith("Error") ? "Error en Restauración" : "Restauración Exitosa",
                            MessageBoxButtons.OK,
                            resultado.StartsWith("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);

            // Re-habilitar botones
            btnCargarBackup.Enabled = true;
            btnExaminarBackup.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}