using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoPregunta : CD_Conexion
    {
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        public List<DtoPregunta> ObtenerPreguntas()
        {
            List<DtoPregunta> preguntas = new List<DtoPregunta>();

            using (SqlConnection conn = AbrirConexion())
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
                    CerrarConexion();
                }
            }
            
            return preguntas;
        }

        public DataTable MostrarPreguntas()
        {
            DataTable tabla = new DataTable();
            comando.Connection = AbrirConexion();
            comando.CommandText = "sp_ListarPregunta";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            CerrarConexion();
            return tabla;
        }

        //metodo para verificar si el usuario ya configuró sus preguntas (requiere 3 preguntas con respuesta no vacía)
        public bool VerificarExistencia(string nombreUsuario)
        {
            bool tienePreguntas = false;

            using (SqlConnection connection = AbrirConexion())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_VerificarExistenciaPreguntas", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value) tienePreguntas = Convert.ToInt32(result) == 1;
                    }
                }
                catch (Exception)
                {
                    // Log opcional
                    tienePreguntas = false;
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return tienePreguntas;
        }
    }
}