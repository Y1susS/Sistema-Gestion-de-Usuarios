using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.IO;

namespace Logica
{
    // Delegado para manejar el evento de progreso
    public delegate void ProgressChangedEventHandler(object sender, int progress);

    public class CL_BackUp
    {
        private readonly CD_BackUp oCD_Backup = new CD_BackUp();

        public event ProgressChangedEventHandler ProgressChanged;

        public CL_BackUp()
        {
            // Suscribe el evento de la capa de datos al evento de la capa de lógica
            // Esto permite que la capa de Lógica reenvíe el progreso a la Vista
            oCD_Backup.ProgressChanged += (sender, progress) => OnProgressChanged(progress);
        }

        // --- Método para Realizar Backup Rápido (Corregido para ruta segura) ---
        public string RealizarBackupRapido()
        {
            // CORRECCIÓN: Usamos una ruta fija (C:\Backups) que sabemos tiene permisos de SQL Server.
            string rutaPredeterminada = @"C:\Backups";

            return oCD_Backup.RealizarBackup(rutaPredeterminada);
        }

        // --- Método para Realizar Backup Personalizado ---
        public string RealizarBackupPersonalizado(string rutaDestino)
        {
            return oCD_Backup.RealizarBackup(rutaDestino);
        }

        // --- MÉTODO PARA REALIZAR RESTORE ---
        public string RealizarRestore(string rutaArchivoBackup)
        {
            // Llama al método de la capa de datos para ejecutar el restore
            return oCD_Backup.RealizarRestore(rutaArchivoBackup);
        }

        // Método que dispara el evento de progreso (pasa el progreso de Datos a Vista)
        protected virtual void OnProgressChanged(int progress)
        {
            ProgressChanged?.Invoke(this, progress);
        }
    }
}
