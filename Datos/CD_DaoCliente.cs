using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoCliente : CD_Conexion
    {
        public CD_DaoCliente() : base()
        {
        }

        public int AgregarCliente(DtoCliente cliente)
        {
            int idCliente = 0;
            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarCliente", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Persona", cliente.Id_Persona);
                    cmd.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);
                    cmd.Parameters.AddWithValue("@TotalCompras", 0);
                    cmd.Parameters.AddWithValue("@CantidadCompras", 0);
                    cmd.Parameters.AddWithValue("@Activo", cliente.Activo);
                    cmd.Parameters.AddWithValue("@Observaciones", cliente.Observaciones ?? string.Empty);

                    SqlParameter paramId = new SqlParameter("@Id_Cliente", SqlDbType.Int);
                    paramId.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramId);

                    cmd.ExecuteNonQuery();

                    if (paramId.Value != DBNull.Value)
                    {
                        idCliente = Convert.ToInt32(paramId.Value);
                    }
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return idCliente;
        }

        public List<DtoCliente> ListarClientes()
        {
            List<DtoCliente> lista = new List<DtoCliente>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarClientes", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DtoCliente cliente = new DtoCliente();
                            
                            // Datos del cliente
                            cliente.Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]);
                            cliente.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                            cliente.Activo = Convert.ToBoolean(dr["Activo"]);
                            cliente.Observaciones = dr["Observaciones"].ToString();
                            
                            // Datos de la persona (herencia)
                            cliente.Id_Persona = Convert.ToInt32(dr["Id_Persona"]);
                            cliente.Nombre = dr["Nombre"].ToString();
                            cliente.Apellido = dr["Apellido"].ToString();
                            cliente.Id_TipoDocumento = dr["Id_TipoDocumento"].ToString();
                            cliente.NroDocumento = dr["NroDocumento"].ToString();
                            cliente.Email = dr["Email"].ToString();
                            cliente.Calle = dr["Calle"].ToString();
                            cliente.Nro = dr.IsDBNull(dr.GetOrdinal("Nro")) ? 0 : Convert.ToInt32(dr["Nro"]);
                            cliente.Piso = dr["Piso"].ToString();
                            cliente.Depto = dr["Depto"].ToString();
                            cliente.Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]);
                            cliente.Telefono = dr.IsDBNull(dr.GetOrdinal("NroTelefono")) ? string.Empty : dr["NroTelefono"].ToString();

                            lista.Add(cliente);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar clientes: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public DtoCliente ObtenerClientePorId(int idCliente)
        {
            DtoCliente cliente = null;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerClientePorId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cliente", idCliente);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cliente = new DtoCliente();
                            
                            // Datos del cliente
                            cliente.Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]);
                            cliente.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                            cliente.Activo = Convert.ToBoolean(dr["Activo"]);
                            cliente.Observaciones = dr["Observaciones"].ToString();
                            
                            // Datos de la persona
                            cliente.Id_Persona = Convert.ToInt32(dr["Id_Persona"]);
                            cliente.Nombre = dr["Nombre"].ToString();
                            cliente.Apellido = dr["Apellido"].ToString();
                            cliente.Id_TipoDocumento = dr["Id_TipoDocumento"].ToString();
                            cliente.NroDocumento = dr["NroDocumento"].ToString();
                            cliente.Email = dr["Email"].ToString();
                            cliente.Calle = dr["Calle"].ToString();
                            cliente.Nro = dr.IsDBNull(dr.GetOrdinal("Nro")) ? 0 : Convert.ToInt32(dr["Nro"]);
                            cliente.Piso = dr["Piso"].ToString();
                            cliente.Depto = dr["Depto"].ToString();
                            cliente.Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]);
                            cliente.Telefono = dr.IsDBNull(dr.GetOrdinal("NroTelefono")) ? string.Empty : dr["NroTelefono"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener cliente: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return cliente;
        }

        public bool ExisteClientePorDocumento(string nroDocumento)
        {
            bool existe = false;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ExisteCliente", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NroDocumento", nroDocumento);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    existe = count > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar existencia de cliente: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return existe;
        }

        public bool BajaCliente(int idCliente)
        {
            bool resultado = false;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BajaCliente", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cliente", idCliente);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al dar de baja cliente: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return resultado;
        }

        public DtoCliente ObtenerClientePorDocumento(string tipoDocumento, string nroDocumento)
        {
            DtoCliente cliente = null;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerClientePorDocumento", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_TipoDocumento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@NroDocumento", nroDocumento);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cliente = new DtoCliente();

                            cliente.Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]);
                            cliente.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                            cliente.Activo = Convert.ToBoolean(dr["Activo"]);
                            cliente.Observaciones = dr["Observaciones"].ToString();

                            cliente.Id_Persona = Convert.ToInt32(dr["Id_Persona"]);
                            cliente.Nombre = dr["Nombre"].ToString();
                            cliente.Apellido = dr["Apellido"].ToString();
                            cliente.Id_TipoDocumento = dr["Id_TipoDocumento"].ToString();
                            cliente.NroDocumento = dr["NroDocumento"].ToString();
                            cliente.Email = dr["Email"].ToString();
                            cliente.Calle = dr["Calle"].ToString();
                            cliente.Nro = dr.IsDBNull(dr.GetOrdinal("Nro")) ? 0 : Convert.ToInt32(dr["Nro"]);
                            cliente.Piso = dr["Piso"].ToString();
                            cliente.Depto = dr["Depto"].ToString();
                            cliente.Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]);
                            cliente.Telefono = dr.IsDBNull(dr.GetOrdinal("NroTelefono")) ? string.Empty : dr["NroTelefono"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener cliente por documento: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return cliente;
        }
    }
}
