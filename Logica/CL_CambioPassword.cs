using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    internal class CL_CambioPassword
    {
        private readonly CD_Conexion conexion = new CD_Conexion();

        public bool VerificarClave(string nombreUsuario, string claveIngresada)
        {
            SqlConnection conn = conexion.AbrirConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_VerificassActual", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Password", claveIngresada);

                    object resultado = cmd.ExecuteScalar();

                    // Si se devuelve un Id_user (no null), entonces la clave es válida
                    return resultado != null;
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void ActualizarClave(string nombreUsuario, string nuevaClave)
        {
            SqlConnection conn = conexion.AbrirConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_CambiarPassword", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", nombreUsuario);
                    cmd.Parameters.AddWithValue("@NuevaPassword", nuevaClave);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
        //VERIFICACIONES PARA FILTRAR EL FORM DE INGRESO DE VIEJA Y NUEVA PW


        //public bool CambiarClave(string nombreUsuario, string claveActual, string nuevaClave1, string nuevaClave2, out string mensaje)
        //{
        //    if (VerificarClave(nombreUsuario, claveActual))
        //    {
        //        mensaje = "❌ La contraseña actual es incorrecta.";
        //        return false;
        //    }

        //    if (nuevaClave1 != nuevaClave2)
        //    {
        //        mensaje = "❌ Las nuevas contraseñas no coinciden.";
        //        return false;
        //    }

        //    if (nuevaClave1 == claveActual)
        //    {
        //        mensaje = "❌ La nueva contraseña no puede ser igual a la anterior.";
        //        return false;
        //    }

        //    ActualizarClave(nombreUsuario, nuevaClave1);
        //    mensaje = "✅ Contraseña cambiada correctamente.";
        //    return true;
        //}
    }
}