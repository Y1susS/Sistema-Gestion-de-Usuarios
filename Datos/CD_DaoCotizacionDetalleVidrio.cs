using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoCotizacionDetalleVidrio : CD_Conexion
    {
        public int InsertarDetalleVidrio(int idCotizacion, DtoCotizacionDetalleVidrio d)
        {
            SqlConnection conn = null;
            try
            {
                conn = AbrirConexion();
                using (var cmd = new SqlCommand("SP_InsertarDetalleVidrio", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);
                    cmd.Parameters.AddWithValue("@NumeroLinea", d.NumeroLinea);
                    cmd.Parameters.AddWithValue("@Id_Material", d.IdMaterial);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)d.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LargoCm", d.LargoCm);
                    cmd.Parameters.AddWithValue("@AnchoCm", d.AnchoCm);
                    cmd.Parameters.AddWithValue("@Piezas", d.Piezas);
                    cmd.Parameters.AddWithValue("@M2PorPieza", d.M2PorPieza);
                    cmd.Parameters.AddWithValue("@PrecioPorM2", d.PrecioPorM2);
                    cmd.Parameters.AddWithValue("@PrecioPorUnidad", d.PrecioPorUnidad);
                    cmd.Parameters.AddWithValue("@Subtotal", d.Subtotal);

                    using (var dr = cmd.ExecuteReader())
                    {
                        return dr.Read() ? Convert.ToInt32(dr[0]) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar detalle de vidrio: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<DtoCotizacionDetalleVidrio> ListarDetallesPorCotizacion(int idCotizacion)
        {
            var lista = new List<DtoCotizacionDetalleVidrio>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                using (var cmd = new SqlCommand("SP_ListarDetallesVidrioPorCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoCotizacionDetalleVidrio
                            {
                                IdDetalleVidrio = GetInt(dr, "Id_DetalleVidrio"),
                                IdCotizacion = GetInt(dr, "Id_Cotizacion"),
                                NumeroLinea = GetInt(dr, "NumeroLinea"),
                                IdMaterial = GetInt(dr, "Id_Material"),
                                Descripcion = GetStringOrNull(dr, "Descripcion"),
                                LargoCm = GetDecimal(dr, "LargoCm"),
                                AnchoCm = GetDecimal(dr, "AnchoCm"),
                                Piezas = GetInt(dr, "Piezas"),
                                M2PorPieza = GetDecimal(dr, "M2PorPieza"),
                                PrecioPorM2 = GetDecimal(dr, "PrecioPorM2"),
                                PrecioPorUnidad = GetDecimal(dr, "PrecioPorUnidad"),
                                Subtotal = GetDecimal(dr, "Subtotal"),
                                Observaciones = GetStringOrNull(dr, "Observaciones")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar detalles de vidrio: " + ex.Message, ex);
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
                using (var cmd = new SqlCommand("SP_EliminarDetallesVidrioPorCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar detalles de vidrio: " + ex.Message, ex);
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
        private static string GetStringOrNull(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? null : r.GetString(i);
        }
    }
}