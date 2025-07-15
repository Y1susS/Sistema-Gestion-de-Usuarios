using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sesion.Entidades;

namespace Datos
{
    public class CD_DaoRespuesta
    {
        public bool RegistrarRespuesta(int idUsuario, int idPregunta, string respuesta)
        {
            bool resultado = false;
            CD_Conexion conexion = new CD_Conexion();
            
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    // Intentar eliminar respuesta previa en caso de que exista
                    SqlCommand cmdDelete = new SqlCommand("sp_EliminarRespuesta", conn);
                    cmdDelete.CommandType = CommandType.StoredProcedure;
                    cmdDelete.Parameters.AddWithValue("@Id_User", idUsuario);
                    cmdDelete.Parameters.AddWithValue("@Id_Pregunta", idPregunta);
                    cmdDelete.ExecuteNonQuery();
                    
                    // Registrar nueva respuesta
                    SqlCommand cmd = new SqlCommand("sp_RegistrarRespuesta", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_User", idUsuario);
                    cmd.Parameters.AddWithValue("@Id_Pregunta", idPregunta);
                    cmd.Parameters.AddWithValue("@Respuesta", respuesta);
                    
                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                catch (SqlException)
                {
                    resultado = false;
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            
            return resultado;
        }
        
        public bool VerificarRespuesta(int idUsuario, int idPregunta, string respuesta)
        {
            bool resultado = false;
            CD_Conexion conexion = new CD_Conexion();
            
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VerificarRespuesta", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_User", idUsuario);
                    cmd.Parameters.AddWithValue("@Id_Pregunta", idPregunta);
                    cmd.Parameters.AddWithValue("@Respuesta", respuesta);
                    
                    object result = cmd.ExecuteScalar();
                    resultado = (result != null && result != DBNull.Value);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            
            return resultado;
        }
        
        public List<DtoRespuesta> ObtenerRespuestasUsuario(int idUsuario)
        {
            List<DtoRespuesta> respuestas = new List<DtoRespuesta>();
            CD_Conexion conexion = new CD_Conexion();
            
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerRespuestasPorUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_User", idUsuario);
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            respuestas.Add(new DtoRespuesta
                            {
                                Id_User = dr.GetInt32(0),
                                Id_Pregunta = dr.GetInt32(1),
                                Pregunta = dr.GetString(2),
                                Respuesta = dr.GetString(3)
                            });
                        }
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            
            return respuestas;
        }
    }
}