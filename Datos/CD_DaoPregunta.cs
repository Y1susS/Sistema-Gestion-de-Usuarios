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
    }
}