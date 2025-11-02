using Entidades;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class CD_DaoPresupuesto : CD_Conexion
    {

        public List<DtoPresupuestoFiltro> FiltrarPresupuestos(
            string descripcion,
            DateTime? fechaValidez,
            string vendedor,
            string documentoCliente)
        {
            List<DtoPresupuestoFiltro> lista = new List<DtoPresupuestoFiltro>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_FiltrarPresupuestos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DescripcionPresupuesto", descripcion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaValidez", fechaValidez.HasValue ? fechaValidez.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NombreVendedor", vendedor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NroDocumentoCliente", documentoCliente ?? (object)DBNull.Value);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DtoPresupuestoFiltro dto = new DtoPresupuestoFiltro();

                            dto.IdPresupuesto = Convert.ToInt32(dr["Id_Presupuesto"]);
                            dto.NumeroPresupuesto = dr["NumeroPresupuesto"].ToString();
                            dto.Observaciones = dr["Observaciones"].ToString();

                            // Campos que vienen del JOIN y son calculados
                            dto.ClienteNombreCompleto = dr["ClienteNombreCompleto"].ToString();
                            dto.EstadoPresupuesto = dr["EstadoPresupuesto"].ToString();

                            dto.FechaValidez = Convert.ToDateTime(dr["FechaValidez"]);
                            dto.MontoFinal = Convert.ToDecimal(dr["MontoFinal"]);

                            lista.Add(dto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al filtrar presupuestos desde la base de datos.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }
        public Presupuesto ObtenerEncabezado(int idPresupuesto)
        {
            Presupuesto presupuesto = null;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerPresupuestoEncabezado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPresupuesto", idPresupuesto);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            presupuesto = new Presupuesto();

                            // Mapeo de DtoDocumentoComercial
                            presupuesto.Id = Convert.ToInt32(dr["Id_Presupuesto"]); 
                            presupuesto.Numero = dr["Numero"].ToString();
                            presupuesto.Fecha = Convert.ToDateTime(dr["FechaCreacion"]);
                            presupuesto.MontoTotal = Convert.ToDecimal(dr["MontoTotal"]);
                            presupuesto.Descuento = Convert.ToDecimal(dr["Descuento"]);
                            presupuesto.MontoFinal = Convert.ToDecimal(dr["MontoFinal"]);
                            presupuesto.Observaciones = dr["Observaciones"].ToString();
                            presupuesto.Activo = Convert.ToBoolean(dr["Activo"]);

                            // Mapeo de Presupuesto
                            presupuesto.IdPresupuesto = presupuesto.Id;
                            presupuesto.Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]);
                            presupuesto.IdUser = Convert.ToInt32(dr["Id_User"]);
                            presupuesto.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                            presupuesto.FechaValidez = dr.IsDBNull(dr.GetOrdinal("FechaValidez")) ? (DateTime?)null : Convert.ToDateTime(dr["FechaValidez"]);
                            presupuesto.IdEstadoPresupuesto = Convert.ToInt32(dr["Id_EstadoPresupuesto"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el encabezado del presupuesto.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return presupuesto;
        }
        public List<DtoPresupuestoDetalle> ObtenerDetalles(int idPresupuesto)
        {
            List<DtoPresupuestoDetalle> detalles = new List<DtoPresupuestoDetalle>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerPresupuestoDetalles", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPresupuesto", idPresupuesto);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DtoPresupuestoDetalle detalle = new DtoPresupuestoDetalle();


                            detalle.IdCotizacion = Convert.ToInt32(dr["Id_Cotizacion"]);
                            detalle.NumeroCotizacion = dr["NumeroCotizacion"].ToString(); 
                            detalle.Observaciones = dr["DescripcionMueble"].ToString();
                            detalle.PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]);
                            detalle.Cantidad = Convert.ToInt32(dr["Cantidad"]);

                            detalles.Add(detalle);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los detalles del presupuesto.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return detalles;
        }

        public int InsertarPresupuesto(Presupuesto presupuesto, List<DtoPresupuestoDetalle> detalles)
        {
            int idGenerado = 0;
            string spName = "SP_Presupuesto_Insertar";

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Cliente", presupuesto.Id_Cliente);
                    cmd.Parameters.AddWithValue("@Id_User", presupuesto.IdUser ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaCreacion", presupuesto.FechaCreacion);

                    cmd.Parameters.AddWithValue("@FechaValidez", presupuesto.FechaValidez.HasValue ? (object)presupuesto.FechaValidez.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@MontoTotal", presupuesto.MontoTotal);

                    cmd.Parameters.AddWithValue("@Descuento", presupuesto.Descuento);

                    cmd.Parameters.AddWithValue("@MontoFinal", presupuesto.MontoFinal);
                    cmd.Parameters.AddWithValue("@Id_EstadoPresupuesto", presupuesto.IdEstadoPresupuesto);
                    cmd.Parameters.AddWithValue("@Observaciones", string.IsNullOrEmpty(presupuesto.Observaciones) ? (object)DBNull.Value : presupuesto.Observaciones);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        idGenerado = Convert.ToInt32(resultado);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar la cabecera del presupuesto.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return idGenerado;
        }
        public void InsertarDetallePresupuesto(DtoPresupuestoDetalle detalle)
        {
            string spName = "SP_PresupuestoCotizacion_InsertarDetalle";

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Presupuesto", detalle.IdPresupuesto); 
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", detalle.IdCotizacion);
                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

                    cmd.Parameters.AddWithValue("@Observaciones", string.IsNullOrEmpty(detalle.Observaciones) ? (object)DBNull.Value : detalle.Observaciones);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar un detalle del presupuesto.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public void ActualizarEstadosVencidos()
        {
            string spName = "sp_ActualizarPresupuestosVencidos";

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los estados de los presupuestos vencidos en la base de datos.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }


    }
}
