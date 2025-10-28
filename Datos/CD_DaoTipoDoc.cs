using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoTipoDoc : CD_Conexion
    {
        public List<DtoTipoDoc> ListarTiposDocumento()
        {
            List<DtoTipoDoc> lista = new List<DtoTipoDoc>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarTipoDocumento", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoTipoDoc
                            {
                                Id_TipoDocumento = dr["Id_TipoDocumento"].ToString(),
                                DescDocumento = dr["DescDocumento"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar tipos de documento: " + ex.Message, ex);
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