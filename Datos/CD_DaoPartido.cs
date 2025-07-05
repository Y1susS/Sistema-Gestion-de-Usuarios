using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sesion.Entidades;

namespace Datos
{
    public class CD_DaoPartido
    {
        public List<DtoPartido> ListarPartidos()
        {
            var lista = new List<DtoPartido>();
            var conexion = new CD_Conexion();
            using (var conn = conexion.AbrirConexion())
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
                    conexion.CerrarConexion();
                }
            }
            return lista;
        }
    }
}