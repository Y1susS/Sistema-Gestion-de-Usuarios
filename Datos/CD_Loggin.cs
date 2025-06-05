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


        public bool Login(string user, string password)
        {
            SqlConnection conn = null;
            try
            {
                conn = conexion.AbrirConexion();

                using (SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", user);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            {

                                CD_UsuarioAtributos.User = reader["User"].ToString();
                                CD_UsuarioAtributos.Password = reader["Password"].ToString();
                                return true;
                            };
                            
                        }
                        else
                        {
                            return false; // Usuario no encontrado
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al hacer login: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
