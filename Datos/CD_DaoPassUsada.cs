using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoPassUsada
    {
        public bool AgregarPassUsada(int idUsuario, string password)
        {
            CD_Conexion conexion = new CD_Conexion();
            bool resultado = false;

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarPassUsada", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_User", idUsuario);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@FechaCambio", DateTime.Now);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return resultado;
        }

        public bool VerificarPassUsada(int idUsuario, string password)
        {
            CD_Conexion conexion = new CD_Conexion();
            bool resultado = false;
            
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VerificarPassUsada", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_User", idUsuario);
                    cmd.Parameters.AddWithValue("@Password", password);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        resultado = reader.HasRows;
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            
            return resultado;
        }
    }
}