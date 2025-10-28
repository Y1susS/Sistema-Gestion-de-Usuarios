using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoPassUsada : CD_Conexion
    {
        public bool AgregarPassUsada(int idUsuario, string password)
        {
            bool resultado = false;

            using (SqlConnection conn = AbrirConexion())
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
                    CerrarConexion();
                }
            }

            return resultado;
        }

        public bool VerificarPassUsada(int idUsuario, string password)
        {
            bool resultado = false;
            
            using (SqlConnection conn = AbrirConexion())
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
                    CerrarConexion();
                }
            }
            
            return resultado;
        }
    }
}