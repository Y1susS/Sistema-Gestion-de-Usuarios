using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sesion.Entidades;

namespace Datos
{
    public class CD_DaoLocalidad
    {
        public List<DtoLocalidad> ListarLocalidadesPorPartido(int idPartido)
        {
            var lista = new List<DtoLocalidad>();
            var conexion = new CD_Conexion();
            using (var conn = conexion.AbrirConexion())
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
                    conexion.CerrarConexion();
                }
            }
            return lista;
        }
    }
}