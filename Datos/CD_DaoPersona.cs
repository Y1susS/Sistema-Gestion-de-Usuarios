using System;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoPersona : CD_Conexion
    {
        public CD_DaoPersona() : base()
        {
        }

        public int AgregarPersona(DtoPersona persona)
        {
            int idPersona = 0;

            using (SqlConnection conn = AbrirConexion())
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
                    cmd.Parameters.AddWithValue("@Calle", persona.Calle ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Nro", persona.Nro);
                    cmd.Parameters.AddWithValue("@Piso", persona.Piso ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Depto", persona.Depto ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Id_Localidad", persona.Id_Localidad);
                    cmd.Parameters.AddWithValue("@Telefono", persona.Telefono ?? string.Empty);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            idPersona = Convert.ToInt32(dr["Id_Persona"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar persona: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return idPersona;
        }

        public bool ActualizarPersona(DtoPersona persona)
        {
            bool resultado = false;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarPersona", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Persona", persona.Id_Persona);
                    cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    cmd.Parameters.AddWithValue("@Id_TipoDocumento", persona.Id_TipoDocumento);
                    cmd.Parameters.AddWithValue("@NroDocumento", persona.NroDocumento);
                    cmd.Parameters.AddWithValue("@Email", persona.Email);
                    cmd.Parameters.AddWithValue("@Calle", persona.Calle ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Nro", persona.Nro);
                    cmd.Parameters.AddWithValue("@Piso", persona.Piso ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Depto", persona.Depto ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Id_Localidad", persona.Id_Localidad);
                    cmd.Parameters.AddWithValue("@Telefono", persona.Telefono ?? string.Empty);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar persona: " + ex.Message, ex);
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