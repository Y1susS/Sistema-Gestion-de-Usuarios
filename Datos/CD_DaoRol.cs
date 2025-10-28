using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoRol : CD_Conexion
    {
        public List<DtoRol> ListarRoles()
        {
            var lista = new List<DtoRol>();
            using (var conn = AbrirConexion())
            {
                try
                {
                    var cmd = new SqlCommand("sp_ListarRol", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoRol
                            {
                                Id_Rol = dr.GetInt32(0),
                                Rol = dr.GetString(1)
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