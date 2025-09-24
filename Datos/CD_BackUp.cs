using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public delegate void ProgressChangedEventHandler(object sender, int progress);

    public class CD_BackUp
    {

        private readonly CD_Conexion oConexion = new CD_Conexion();
        public event ProgressChangedEventHandler ProgressChanged;

        public string RealizarBackup(string rutaDestino)
        {
            string resultado = string.Empty;

            try
            {
                // Asegurar que la carpeta de destino exista
                if (!Directory.Exists(rutaDestino))
                {
                    Directory.CreateDirectory(rutaDestino);
                }

                // Generar un nombre de archivo único para el backup
                string nombreArchivo = $"SistemaIntegralRemuebla_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.bak";
                string rutaCompleta = Path.Combine(rutaDestino, nombreArchivo);

                // Cadena de comando para el backup de SQL Server
                string query = $"BACKUP DATABASE [Sistema Integral Remuebla] TO DISK = '{rutaCompleta}' WITH NOFORMAT, NOINIT, NAME = N'Backup completo', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                using (SqlCommand cmd = new SqlCommand(query, oConexion.AbrirConexion()))
                {
                    cmd.CommandTimeout = 0; // Tiempo de espera ilimitado para bases de datos grandes
                    cmd.ExecuteNonQuery();
                }

                oConexion.CerrarConexion();
                resultado = "Copia de seguridad realizada con éxito.";
            }
            catch (Exception ex)
            {
                resultado = $"Error al realizar la copia de seguridad: {ex.Message}";
            }

            return resultado;
        }
        protected virtual void OnProgressChanged(int progress)
        {
            ProgressChanged?.Invoke(this, progress);
        }
    }
}

