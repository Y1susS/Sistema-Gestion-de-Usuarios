using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sesion.Entidades;

namespace Datos
{
    public class CD_DaoPregunta
    {
        CD_Conexion conexion = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        public List<DtoPregunta> ObtenerPreguntas()
        {
            List<DtoPregunta> preguntas = new List<DtoPregunta>();
            CD_Conexion conexion = new CD_Conexion();
            
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarPregunta", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            preguntas.Add(new DtoPregunta
                            {
                                Id_Pregunta = dr.GetInt32(0),
                                Pregunta = dr.GetString(1)
                            });
                        }
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            
            return preguntas;
        }

        public DataTable MostrarPreguntas()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_ListarPregunta";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public bool UsuarioYaConfiguroPreguntas(string nombreUsuario)
        {
            bool tienePreguntas = false;

            // Consulta SQL para verificar si el usuario tiene una respuesta de seguridad registrada.
            // Se realiza un JOIN con la tabla de usuarios para usar el 'nombreUsuario' como filtro.
            string query = @"
        SELECT COUNT(r.Id_Respuesta)
        FROM dbo.Respuestas r
        INNER JOIN dbo.Usuario u ON r.Id_User = u.Id_User
        WHERE u.User = @nombreUsuario";

            try
            {
                // Se utiliza tu objeto de conexión 'conexion' para abrir la conexión a la base de datos.
                using (SqlConnection connection = conexion.AbrirConexion())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agrega el parámetro para evitar inyecciones SQL.
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        // ExecuteScalar devuelve el valor de la primera columna de la primera fila.
                        object result = command.ExecuteScalar();

                        // Verifica si el resultado es válido y lo convierte a entero.
                        if (result != null && result != DBNull.Value)
                        {
                            int count = Convert.ToInt32(result);
                            if (count > 0)
                            {
                                tienePreguntas = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de fallo de conexión o consulta.
                // Puedes registrar este error para depuración.
                Console.WriteLine($"Error en UsuarioYaConfiguroPreguntas: {ex.Message}");
            }
            finally
            {
                // Asegúrate de que la conexión se cierre correctamente.
                conexion.CerrarConexion();
            }
            return tienePreguntas;
        }

        //metodo para verificar si es primera contraseña

        public bool VerificarExistencia(string nombreUsuario)
        {
            bool tienePreguntas = false;
            string query = @"
        SELECT COUNT(r.Id_Respuesta)
        FROM dbo.Respuestas r
        INNER JOIN dbo.Usuario u ON r.Id_User = u.Id_User
        WHERE u.User = @nombreUsuario";

            using (SqlConnection connection = conexion.AbrirConexion())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int count = Convert.ToInt32(result);
                            if (count > 0)
                            {
                                tienePreguntas = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Puedes registrar el error aquí
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            return tienePreguntas;
        }
    }
}