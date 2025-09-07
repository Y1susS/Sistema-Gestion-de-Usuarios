using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoLocalidad : CD_Conexion
    {
        public List<DtoLocalidad> ListarLocalidadesPorPartido(int idPartido)
        {
            var lista = new List<DtoLocalidad>();
            using (var conn = AbrirConexion())
            {
                try
                {
                    var cmd = new SqlCommand("sp_FiltrarLocalidadxPartido", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@filtroPartido", idPartido);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoLocalidad
                            {
                                Id_Localidad = dr.GetInt32(0),
                                Localidad = dr.GetString(1)
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