using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoVenta : CD_Conexion
    {
        public CD_DaoVenta() : base()
        {
        }

        public List<DtoVenta> ListarVentas()
        {
            List<DtoVenta> lista = new List<DtoVenta>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_ListarVentas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearDtoVenta(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar ventas: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public List<DtoVenta> FiltrarVentas(DateTime? fechaDesde, DateTime? fechaHasta, int? idVendedor, int? idCliente, int? idEstadoVenta)
        {
            List<DtoVenta> lista = new List<DtoVenta>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_FiltrarVentas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FechaDesde", (object)fechaDesde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaHasta", (object)fechaHasta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id_Vendedor", (object)idVendedor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id_Cliente", (object)idCliente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id_EstadoVenta", (object)idEstadoVenta ?? DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearDtoVenta(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al filtrar ventas: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public List<DtoUsuario> ListarUsuariosConVentas()
        {
            List<DtoUsuario> lista = new List<DtoUsuario>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_ListarUsuariosConVentas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DtoUsuario
                            {
                                Id_user = reader["IdUser"] != DBNull.Value ? Convert.ToInt32(reader["IdUser"]) : 0,
                                User = reader["UserName"]?.ToString(),
                                Id_Rol = reader["IdRol"] != DBNull.Value ? Convert.ToInt32(reader["IdRol"]) : 0
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar usuarios con ventas: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public List<DtoCliente> ListarClientesVentas()
        {
            List<DtoCliente> lista = new List<DtoCliente>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_ListarClientesVentas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DtoCliente
                            {
                                Id_Cliente = reader["IdCliente"] != DBNull.Value ? Convert.ToInt32(reader["IdCliente"]) : 0,
                                Nombre = reader["NombreCompleto"]?.ToString()
                            });
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

        // Helper
        private DtoVenta MapearDtoVenta(SqlDataReader r)
        {
            return new DtoVenta
            {
                IdVenta = r["Id_Venta"] != DBNull.Value ? Convert.ToInt32(r["Id_Venta"]) : 0,
                NumeroVenta = r["NumeroVenta"]?.ToString(),
                FechaVenta = r["FechaVenta"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(r["FechaVenta"]) : null,
                MontoTotal = r["MontoTotal"] != DBNull.Value ? (decimal?)Convert.ToDecimal(r["MontoTotal"]) : null,
                Descuento = r["Descuento"] != DBNull.Value ? (decimal?)Convert.ToDecimal(r["Descuento"]) : null,
                MontoFinal = r["MontoFinal"] != DBNull.Value ? (decimal?)Convert.ToDecimal(r["MontoFinal"]) : null,
                Observaciones = r["Observaciones"]?.ToString(),
                Activo = r["Activo"] != DBNull.Value && Convert.ToBoolean(r["Activo"]),

                IdPresupuesto = r["Id_Presupuesto"] != DBNull.Value ? (int?)Convert.ToInt32(r["Id_Presupuesto"]) : null,
                IdCliente = r["Id_Cliente"] != DBNull.Value ? (int?)Convert.ToInt32(r["Id_Cliente"]) : null,
                ClienteNombre = r["ClienteNombre"]?.ToString(),

                IdVendedor = r["IdVendedor"] != DBNull.Value ? (int?)Convert.ToInt32(r["IdVendedor"]) : null,
                VendedorUserName = r["VendedorUserName"]?.ToString(),
                VendedorNombre = r["VendedorNombre"]?.ToString(),
                IdRolVendedor = r["IdRolVendedor"] != DBNull.Value ? (int?)Convert.ToInt32(r["IdRolVendedor"]) : null,

                IdEstadoVenta = r["Id_EstadoVenta"] != DBNull.Value ? (int?)Convert.ToInt32(r["Id_EstadoVenta"]) : null,
                EstadoVenta = r["EstadoVenta"]?.ToString()
            };
        }


        public List<DtoEstadoVenta> ListarEstadosVenta()
        {
            List<DtoEstadoVenta> lista = new List<DtoEstadoVenta>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    // CAMBIO: Llamada al Stored Procedure
                    SqlCommand cmd = new SqlCommand("dbo.sp_ListarEstadosVenta", conn);
                    cmd.CommandType = CommandType.StoredProcedure; // Establecer tipo StoredProcedure

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DtoEstadoVenta
                            {
                                IdEstadoVenta = Convert.ToInt32(reader["Id_EstadoVenta"]),
                                Estado = reader["Estado"]?.ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Se propaga la excepción, permitiendo que la capa superior la capture.
                    throw new Exception("Error al listar estados de venta: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public void ActualizarEstadoVenta(int idVenta, int idEstadoVenta)
        {
            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_ActualizarEstadoVenta", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros del SP
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmd.Parameters.AddWithValue("@IdEstadoVenta", idEstadoVenta);

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Manejar errores específicos lanzados por el RAISERROR del SP
                    throw new Exception("Error SQL al actualizar estado: " + ex.Message, ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar estado de la venta: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }


    }
}

