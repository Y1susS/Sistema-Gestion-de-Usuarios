using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sesion;

namespace Datos
{
    public class CD_DaoUsuarios
    {

        private CD_Usuario usuarioAValidar = new CD_Usuario();

        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_ListarUsuariosDatos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

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
        {   //CD_Usuario usuarioAValidar = new CD_Usuario();
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


                usuarioAValidar.User = reader.GetString(1);
                usuarioAValidar.Password = reader.GetString(2);
                usuarioAValidar.PrimeraPass = reader.GetBoolean(5);
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

        public CD_Usuario UsuarioValidado
        {
            get { return usuarioAValidar; }
        }

        public bool VerificarParametrosRecupero(string NroDocumento, int Id_Pregunta, string Respuesta)
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "XXXXcontrastarrespuesta hasheadaXXX";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NroDocumento", NroDocumento);
            comando.Parameters.AddWithValue("@IdPregunta", Id_Pregunta);
            comando.Parameters.AddWithValue("@Respuesta", Respuesta);

            int resultado = Convert.ToInt32(comando.ExecuteScalar());

            conexion.CerrarConexion();

            if (resultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
