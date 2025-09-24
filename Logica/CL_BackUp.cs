using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Configuration;

namespace Logica
{
    // El evento 'ProgressChanged' debe ir dentro de la clase 'CL_BackUp'
    public class CL_BackUp
    {
        // Acá lo declarás, dentro de la clase.
        public event EventHandler<int> ProgressChanged;

        private readonly CD_BackUp oCD_Backup = new CD_BackUp();

        // Te faltaba el constructor de la clase para suscribir el evento.
        public CL_BackUp()
        {
            oCD_Backup.ProgressChanged += (sender, progress) =>
            {
                ProgressChanged?.Invoke(this, progress);
            };
        }

        // Método para el backup en modo rápido (usa la ruta de App.config)
        public string RealizarBackupRapido()
        {
            // Obtener la ruta del archivo de configuración
            string ruta = ConfigurationManager.AppSettings["RutaBackupRapido"];

            // Llamar al método de la capa de datos para hacer el backup
            return oCD_Backup.RealizarBackup(ruta);
        }

        // Método para el backup en modo personalizado (usa la ruta elegida por el usuario)
        public string RealizarBackupPersonalizado(string rutaSeleccionada)
        {
            // Llamar al método de la capa de datos para hacer el backup
            return oCD_Backup.RealizarBackup(rutaSeleccionada);
        }
    }
}