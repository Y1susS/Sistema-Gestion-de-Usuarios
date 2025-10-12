using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoCotizacionDetalleMadera : CD_Conexion
    {
        public int InsertarDetalleMadera(int idCotizacion, DtoCotizacionDetalle d)
        {
            SqlConnection conn = null;
            try
            {
                conn = AbrirConexion();
                using (var cmd = new SqlCommand("SP_InsertarDetalleMadera", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);
                    cmd.Parameters.AddWithValue("@NumeroLinea", d.NumeroLinea);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)d.Descripcion ?? "");
                    cmd.Parameters.AddWithValue("@EspesorCm", d.EspesorCm);
                    cmd.Parameters.AddWithValue("@AnchoCm", d.AnchoCm);
                    cmd.Parameters.AddWithValue("@LargoCm", d.LargoCm);
                    cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                    cmd.Parameters.AddWithValue("@EspesorPulgadas", d.EspesorPulgadas);
                    cmd.Parameters.AddWithValue("@AnchoPulgadas", d.AnchoPulgadas);
                    cmd.Parameters.AddWithValue("@Pies", d.Pies);
                    cmd.Parameters.AddWithValue("@Subtotal", d.SubTotal);

                    using (var dr = cmd.ExecuteReader())
                    {
                        return dr.Read() ? Convert.ToInt32(dr[0]) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar detalle de madera: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<DtoCotizacionDetalle> ListarDetallesPorCotizacion(int idCotizacion)
        {
            var lista = new List<DtoCotizacionDetalle>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                using (var cmd = new SqlCommand("SP_ListarDetallesMaderaPorCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoCotizacionDetalle
                            {
                                NumeroLinea     = GetInt(dr, "NumeroLinea"),
                                Descripcion     = GetStringOrEmpty(dr, "Descripcion"),
                                EspesorCm       = GetDecimal(dr, "EspesorCm"),
                                AnchoCm         = GetDecimal(dr, "AnchoCm"),
                                LargoCm         = GetDecimal(dr, "LargoCm"),
                                Cantidad        = GetInt(dr, "Cantidad"),
                                EspesorPulgadas = GetDecimal(dr, "EspesorPulgadas"),
                                AnchoPulgadas   = GetDecimal(dr, "AnchoPulgadas"),
                                Pies            = GetDecimal(dr, "Pies"),
                                SubTotal        = GetDecimal(dr, "Subtotal")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar detalles de madera: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return lista;
        }

        public void EliminarDetallesPorCotizacion(int idCotizacion)
        {
            SqlConnection conn = null;
            try
            {
                conn = AbrirConexion();
                using (var cmd = new SqlCommand("SP_EliminarDetallesMaderaPorCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar detalles de madera: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }
        }

        private static int GetInt(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0 : r.GetInt32(i);
        }

        private static decimal GetDecimal(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0m : r.GetDecimal(i);
        }

        private static string GetStringOrEmpty(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? "" : r.GetString(i);
        }
    }
}