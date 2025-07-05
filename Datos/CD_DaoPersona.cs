using System;
using System.Data;
using System.Data.SqlClient;
using Sesion.Entidades;

namespace Datos
{
    public class CD_DaoPersona
    {
        public int AgregarPersona(DtoPersona persona)
        {
            int idPersona = 0;
            CD_Conexion conexion = new CD_Conexion();
            
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarPersona", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    cmd.Parameters.AddWithValue("@Id_TipoDocumento", persona.Id_TipoDocumento);
                    cmd.Parameters.AddWithValue("@NroDocumento", persona.NroDocumento);
                    cmd.Parameters.AddWithValue("@Email", persona.Email);
                    cmd.Parameters.AddWithValue("@Calle", persona.Calle);
                    cmd.Parameters.AddWithValue("@Nro", persona.Nro);
                    cmd.Parameters.AddWithValue("@Piso", string.IsNullOrEmpty(persona.Piso) ? DBNull.Value : (object)persona.Piso);
                    cmd.Parameters.AddWithValue("@Depto", string.IsNullOrEmpty(persona.Depto) ? DBNull.Value : (object)persona.Depto);
                    cmd.Parameters.AddWithValue("@Id_Localidad", persona.Id_Localidad);
                    
                    // Modificar el SP para que devuelva el ID generado
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        idPersona = Convert.ToInt32(result);
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            
            return idPersona;
        }

        public bool ActualizarPersona(DtoPersona persona)
        {
            CD_Conexion Conexion = new CD_Conexion();
            bool resultado = false;
            try
            {
                using (SqlConnection conexion = Conexion.AbrirConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarPersona", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros para el procedimiento almacenado
                        cmd.Parameters.AddWithValue("@Id_Persona", persona.Id_Persona);
                        cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                        cmd.Parameters.AddWithValue("@Id_TipoDocumento", persona.Id_TipoDocumento);
                        cmd.Parameters.AddWithValue("@NroDocumento", persona.NroDocumento);
                        cmd.Parameters.AddWithValue("@Email", persona.Email);
                        cmd.Parameters.AddWithValue("@Calle", persona.Calle);
                        cmd.Parameters.AddWithValue("@Nro", persona.Nro);
                        cmd.Parameters.AddWithValue("@Piso", persona.Piso ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Depto", persona.Depto ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Id_Localidad", persona.Id_Localidad);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar persona: " + ex.Message);
                resultado = false;
            }
            return resultado;
        }
    }
}