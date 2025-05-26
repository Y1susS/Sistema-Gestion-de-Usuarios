using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal class CD_Usuarios
    {
        public CD_Conexion conexion = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public bool AgregarUsuario(string id, string usuario, string email, string password, string rol)
        {
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
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "validarUsuario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@User", usuario);
            comando.Parameters.AddWithValue("@Password", password);

            object resultado = (int)comando.ExecuteScalar();
            conexion.CerrarConexion();

            if (resultado != null && int.TryParse(resultado.ToString(), out int valor))
            {
                return valor == 1;
            }
            else
            {
                return false;

            }
        }
    }
}
