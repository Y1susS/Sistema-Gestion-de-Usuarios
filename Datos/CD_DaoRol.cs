using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sesion.Entidades;

namespace Datos
{
    public class CD_DaoRol
    {
        public List<DtoRol> ListarRoles()
        {
            var lista = new List<DtoRol>();
            var conexion = new CD_Conexion();
            using (var conn = conexion.AbrirConexion())
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
                    conexion.CerrarConexion();
                }
            }
            return lista;
        }
    }
}