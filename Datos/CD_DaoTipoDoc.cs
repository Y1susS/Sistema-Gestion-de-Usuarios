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
            var lista = new List<DtoTipoDoc>();

            using (var conn = AbrirConexion())
            {
                try
                {
                    var cmd = new SqlCommand("sp_ListarTipoDocumento", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoTipoDoc
                            {
                                Id_TipoDocumento = dr.GetString(0),
                                DescDocumento = dr.GetString(1)
                            });
                        }
                    }
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