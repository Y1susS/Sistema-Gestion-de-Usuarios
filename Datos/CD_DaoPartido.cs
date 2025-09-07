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
            var lista = new List<DtoPartido>();

            using (var conn = AbrirConexion())
            {
                try
                {
                    var cmd = new SqlCommand("sp_ListarPartido", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoPartido
                            {
                                Id_Partido = dr.GetInt32(0),
                                Partido = dr.GetString(1)
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