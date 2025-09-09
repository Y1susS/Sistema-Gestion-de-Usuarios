using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoPartido : CD_Conexion
    {
        public List<DtoPartido> ListarPartidos()
        {
            List<DtoPartido> lista = new List<DtoPartido>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarPartido", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoPartido
                            {
                                Id_Partido = Convert.ToInt32(dr["Id_Partido"]),
                                Partido = dr["Partido"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar partidos: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }
    }
}