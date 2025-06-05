using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesion;

namespace Datos
{
    public class CD_Usuarios
    {
        CD_Conexion conexion = new CD_Conexion();
        
        public bool AgregarUsuario(string id, string usuario, string email, string password, string rol)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "altaUsuario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id:User", id);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@Password", password);
            comando.Parameters.AddWithValue("@Rol", rol);

            int filasAfectadas = comando.ExecuteNonQuery();
            conexion.CerrarConexion();

            return filasAfectadas > 0;
        }

        public bool ModificarUsuario(int id, string usuario, string email, string password, bool activo, int rol)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "modificarUsuario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_user", id);
            comando.Parameters.AddWithValue("@User", usuario);
            comando.Parameters.AddWithValue("@Password", password);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@Activo", activo);
            comando.Parameters.AddWithValue("@Id_Rol", rol);

            int filasAfectadas = comando.ExecuteNonQuery();
            conexion.CerrarConexion();

            return filasAfectadas > 0;
        }

        public bool ValidarUsuario(string usuario, string password)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "validarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            //comando.CommandText = "SELECT * FROM Usuario WHERE User = @User";
            //comando.CommandType = CommandType.Text;
            
            comando.Parameters.AddWithValue("@User", usuario);
            comando.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = comando.ExecuteReader();
            //if (reader.HasRows)  return true;
            //else return false;
            if (reader.Read())
            {
                //CS_userAtributos.Id_user = reader.GetInt32(0);
                CD_UsuarioAtributos.User = reader.GetString(1);
                CD_UsuarioAtributos.Password = reader.GetString(2);
                //CS_userAtributos.Activo = reader.GetBoolean(3);
                //CS_userAtributos.Id_Rol = reader.GetInt32(4);

                reader.Close();
                conexion.CerrarConexion();
                return true;
            }

            reader.Close();
            conexion.CerrarConexion();
            return false;

            

            //object resultado = (int)comando.ExecuteScalar();
            //conexion.CerrarConexion();

            //if (resultado != null && int.TryParse(resultado.ToString(), out int valor))
            //{
            //    return valor == 1;
            //}
            //else
            //{
            //    return false;

            //}
        }
    }
}
