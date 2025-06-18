using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Loggin
    {
        private CD_Conexion conexion = new CD_Conexion();

        public CD_Usuario Login(string user, string password)
        {
            SqlConnection conn = null;
            try
            {
                conn = conexion.AbrirConexion();
                CD_Usuario usuario = new CD_Usuario();

                // Primer query: verificar login y cargar datos del usuario
                using (SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", user);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario.Id_user = Convert.ToInt32(reader["Id_user"]);
                            usuario.User = reader["User"].ToString();
                            usuario.Password = reader["Password"].ToString();
                            usuario.Activo = Convert.ToBoolean(reader["Activo"]);
                            usuario.FechaBloqueo = reader["FechaBloqueo"] == DBNull.Value ? null : (DateTime?)reader["FechaBloqueo"];
                            usuario.PrimeraPass = Convert.ToBoolean(reader["PrimeraPass"]);
                            usuario.Id_Rol = Convert.ToInt32(reader["Id_Rol"]);
                            usuario.FechaBaja = reader["FechaBaja"] == DBNull.Value ? null : (DateTime?)reader["FechaBaja"];
                            usuario.Id_Persona = Convert.ToInt32(reader["Id_Persona"]);
                            usuario.Intentos = Convert.ToInt32(reader["Intentos"]);
                            usuario.CambiaCada = Convert.ToInt32(reader["CambiaCada"]);
                            usuario.FechaUltimoCambio = reader["FechaUltimoCambio"] == DBNull.Value ? null : (DateTime?)reader["FechaUltimoCambio"];
                        }
                        else
                        {
                            return null; // Login fallido
                        }
                    }
                }

                // Segundo query: cargar datos personales
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerPersonaPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Persona", usuario.Id_Persona);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario.Nombre = reader["Nombre"].ToString();
                            usuario.Apellido = reader["Apellido"].ToString();
                            usuario.Id_TipoDocumento = reader["Id_TipoDocumento"].ToString();
                            usuario.NroDocumento = reader["NroDocumento"].ToString();
                            usuario.Email = reader["Email"].ToString();
                            usuario.Calle = reader["Calle"].ToString();
                            usuario.Nro = Convert.ToInt32(reader["Nro"]);
                            usuario.Piso = reader["Piso"].ToString();
                            usuario.Depto = reader["Depto"].ToString();
                            usuario.Id_Localidad = Convert.ToInt32(reader["Id_Localidad"]);
                        }
                    }
                }

                return usuario; // Login exitoso y datos cargados
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Login: " + ex.Message);
                return null;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
