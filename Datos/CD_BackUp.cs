
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datos
{
    public delegate void ProgressChangedEventHandler(object sender, int progress);

    public class CD_BackUp
    {

        private readonly CD_Conexion oConexion = new CD_Conexion();
        public event ProgressChangedEventHandler ProgressChanged;

        // Nombre de la base de datos hardcodeado en la query de Backup y Restore
        private const string DbName = "Sistema Integral Remuebla";

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
                string nombreArchivo = $"{DbName.Replace(" ", "")}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.bak";
                string rutaCompleta = Path.Combine(rutaDestino, nombreArchivo);

                // Cadena de comando para el backup de SQL Server
                string query = $"BACKUP DATABASE [{DbName}] TO DISK = '{rutaCompleta}' WITH NOFORMAT, NOINIT, NAME = N'Backup completo', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

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

        /// <summary>
        /// Restaura la base de datos a partir de un archivo .bak.
        /// Requiere la CadenaConexionMaestra (en CD_Conexion) para cambiar modos de usuario.
        /// </summary>
        /// <param name="rutaArchivoBackup">Ruta completa del archivo .bak</param>
        /// <returns>Mensaje de resultado.</returns>
        public string RealizarRestore(string rutaArchivoBackup)
        {
            // Usamos la CadenaConexionMaestra (conexión a 'master') para las operaciones de administración de BD
            string resultado = string.Empty;

            using (SqlConnection masterConn = new SqlConnection(oConexion.CadenaConexionMaestra))
            {
                try
                {
                    // 1. Verificar si el archivo existe
                    if (!File.Exists(rutaArchivoBackup))
                    {
                        return $"Error: El archivo de backup no fue encontrado en la ruta: {rutaArchivoBackup}";
                    }

                    masterConn.Open();

                    oConexion.CerrarConexion();

                    // 2. Poner la BD en modo SINGLE_USER para liberar todos los locks
                    // El comando ROLLBACK IMMEDIATE cierra todas las conexiones activas a la BD.
                    string setSingleUserQuery = $"ALTER DATABASE [{DbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    using (SqlCommand cmdSingle = new SqlCommand(setSingleUserQuery, masterConn))
                    {
                        cmdSingle.CommandTimeout = 300;
                        cmdSingle.ExecuteNonQuery();
                    }

                    // 3. Ejecutar el comando RESTORE.
                    string restoreQuery = $"RESTORE DATABASE [{DbName}] FROM DISK = '{rutaArchivoBackup}' WITH REPLACE, STATS = 10";

                    using (SqlCommand cmdRestore = new SqlCommand(restoreQuery, masterConn))
                    {
                        cmdRestore.CommandTimeout = 0; // Sin tiempo de espera
                        cmdRestore.ExecuteNonQuery();
                    }

                    // 4. Poner la BD de vuelta en modo MULTI_USER (para uso normal)
                    string setMultiUserQuery = $"ALTER DATABASE [{DbName}] SET MULTI_USER";
                    using (SqlCommand cmdMulti = new SqlCommand(setMultiUserQuery, masterConn))
                    {
                        cmdMulti.CommandTimeout = 300;
                        cmdMulti.ExecuteNonQuery();
                    }

                    resultado = "Restauración de base de datos completada con éxito.";
                }
                catch (Exception ex)
                {
                    resultado = $"Error al realizar la restauración de la base de datos: {ex.Message}";

                    // Si hubo un error, intentamos asegurarnos de que la BD no quede en SINGLE_USER
                    try
                    {
                        if (masterConn.State == ConnectionState.Open)
                        {
                            string setMultiUserQuery = $"ALTER DATABASE [{DbName}] SET MULTI_USER";
                            using (SqlCommand cmdMulti = new SqlCommand(setMultiUserQuery, masterConn))
                            {
                                cmdMulti.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception cleanupEx)
                    {
                        // Si falla la limpieza, avisamos que puede haber un problema
                        resultado = $"Error CRÍTICO: La restauración falló Y no se pudo devolver la BD a MULTI_USER. Error: {ex.Message}. Limpieza fallida: {cleanupEx.Message}";
                    }
                }
                finally
                {
                    // Asegurar que la conexión maestra se cierre
                    if (masterConn.State == ConnectionState.Open)
                    {
                        masterConn.Close();
                    }
                }
            }
            return resultado;
        }

        protected virtual void OnProgressChanged(int progress)
        {
            ProgressChanged?.Invoke(this, progress);
        }
    }
}
