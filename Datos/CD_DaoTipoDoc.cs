using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sesion.Entidades;

namespace Datos
{
    public class CD_DaoTipoDoc
    {
        public List<DtoTipoDoc> ListarTiposDocumento()
        {
            var lista = new List<DtoTipoDoc>();
            var conexion = new CD_Conexion();
            using (var conn = conexion.AbrirConexion())
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
                    conexion.CerrarConexion();
                }
            }
            return lista;
        }
    }
}