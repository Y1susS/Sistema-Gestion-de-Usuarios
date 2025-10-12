using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoCotizacion : CD_Conexion
    {
        public CD_DaoCotizacion() : base() { }

        public int InsertarCotizacion(DtoCotizacion cotizacion)
        {
            int idCotizacion = 0;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_InsertarCotizacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NumeroCotizacion", (object)cotizacion.NumeroCotizacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_User", (object)cotizacion.IdUser ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DescripcionMueble", (object)cotizacion.DescripcionMueble ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaCreacion", cotizacion.FechaCreacion);

                // Nombres exactos (sin typos)
                cmd.Parameters.AddWithValue("@PorcentajeGanancia", cotizacion.PorcentajeGanancia);
                cmd.Parameters.AddWithValue("@Id_Madera", (object)cotizacion.Id_Madera ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PrecioPorPie", (object)cotizacion.PrecioPorPie ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SubTotalMateriales", cotizacion.SubTotalMateriales);
                cmd.Parameters.AddWithValue("@PorcentajeDesperdicio", cotizacion.PorcentajeDesperdicio);

                cmd.Parameters.AddWithValue("@MontoTotal", cotizacion.MontoTotal);
                cmd.Parameters.AddWithValue("@MontoFinal", cotizacion.MontoFinal);
                cmd.Parameters.AddWithValue("@Observaciones", (object)cotizacion.Observaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", cotizacion.Activo ? 1 : 0);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        idCotizacion = Convert.ToInt32(dr["Id_Cotizacion"]);
                    }
                }
            }
            finally
            {
                CerrarConexion();
            }

            return idCotizacion;
        }

        public bool ActualizarCotizacion(DtoCotizacion cotizacion)
        {
            bool resultado = false;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ActualizarCotizacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Cotizacion", cotizacion.Id_Cotizacion);
                cmd.Parameters.AddWithValue("@NumeroCotizacion", (object)cotizacion.NumeroCotizacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_User", (object)cotizacion.IdUser ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DescripcionMueble", (object)cotizacion.DescripcionMueble ?? DBNull.Value);

                // Nombres exactos (sin typos)
                cmd.Parameters.AddWithValue("@PorcentajeGanancia", cotizacion.PorcentajeGanancia);
                cmd.Parameters.AddWithValue("@Id_Madera", (object)cotizacion.Id_Madera ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PrecioPorPie", (object)cotizacion.PrecioPorPie ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SubTotalMateriales", cotizacion.SubTotalMateriales);
                cmd.Parameters.AddWithValue("@PorcentajeDesperdicio", cotizacion.PorcentajeDesperdicio);

                cmd.Parameters.AddWithValue("@MontoTotal", cotizacion.MontoTotal);
                cmd.Parameters.AddWithValue("@MontoFinal", cotizacion.MontoFinal);
                cmd.Parameters.AddWithValue("@Observaciones", (object)cotizacion.Observaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", cotizacion.Activo ? 1 : 0);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            finally
            {
                CerrarConexion();
            }

            return resultado;
        }

        public DtoCotizacion ObtenerCotizacion(int id)
        {
            DtoCotizacion cotizacion = null;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ObtenerCotizacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Cotizacion", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        cotizacion = MapearLectorACotizacion(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cotización: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return cotizacion;
        }

        public List<DtoCotizacion> ListarCotizaciones()
        {
            List<DtoCotizacion> cotizaciones = new List<DtoCotizacion>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ListarCotizaciones", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cotizaciones.Add(MapearLectorACotizacion(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar cotizaciones: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return cotizaciones;
        }

        public List<DtoCotizacion> ListarCotizacionesPorUsuario(int idUsuario)
        {
            List<DtoCotizacion> cotizaciones = new List<DtoCotizacion>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ListarCotizacionesPorUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_User", idUsuario);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cotizaciones.Add(MapearLectorACotizacion(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar cotizaciones por usuario: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return cotizaciones;
        }

        public bool EliminarCotizacion(int id)
        {
            bool resultado = false;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_EliminarCotizacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Cotizacion", id);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cotización: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return resultado;
        }

        private DtoCotizacion MapearLectorACotizacion(SqlDataReader dr)
        {
            var cotizacion = new DtoCotizacion
            {
                Id_Cotizacion       = GetInt(dr, "Id_Cotizacion"),
                NumeroCotizacion    = GetStringOrNull(dr, "NumeroCotizacion"),
                IdUser              = GetNullableInt(dr, "Id_User"),
                DescripcionMueble   = GetStringOrNull(dr, "DescripcionMueble"),
                FechaCreacion       = GetDateTimeOrNow(dr, "FechaCreacion"),

                SubTotalMateriales  = GetDecimalOrZero(dr, "SubTotalMateriales"),
                MontoTotal          = GetDecimalOrZero(dr, "MontoTotal"),
                MontoFinal          = GetDecimalOrZero(dr, "MontoFinal"),

                PorcentajeGanancia    = GetDecimalOrZero(dr, "PorcentajeGanancia"),
                // Fallback correcto al nombre antiguo si apareciera
                PorcentajeDesperdicio = HasColumn(dr, "PorcentajeDesperdicio")
                                        ? GetDecimalOrZero(dr, "PorcentajeDesperdicio")
                                        : GetDecimalOrZero(dr, "PorcentajeDeperdicio"),

                Id_Madera           = GetNullableInt(dr, "Id_Madera"),
                PrecioPorPie        = GetNullableDecimal(dr, "PrecioPorPie"),

                Observaciones       = GetStringOrNull(dr, "Observaciones"),
                Activo              = GetBoolOrFalse(dr, "Activo"),
                UsuarioNombre       = HasColumn(dr, "UsuarioNombre") ? GetStringOrNull(dr, "UsuarioNombre") : null,
                NombreMadera        = HasColumn(dr, "NombreMadera") ? GetStringOrNull(dr, "NombreMadera") : null
            };

            cotizacion.Id    = cotizacion.Id_Cotizacion;
            cotizacion.Fecha = cotizacion.FechaCreacion;
            cotizacion.Descuento = 0m;

            return cotizacion;
        }

        // NUEVO helper nullable decimal
        private static decimal? GetNullableDecimal(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i);
        }

        // Helpers
        private static int GetInt(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0 : r.GetInt32(i);
        }

        private static int? GetNullableInt(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? (int?)null : r.GetInt32(i);
        }

        private static decimal GetDecimalOrZero(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0m : r.GetDecimal(i);
        }

        private static string GetStringOrNull(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? null : r.GetString(i);
        }

        private static DateTime GetDateTimeOrNow(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? DateTime.Now : r.GetDateTime(i);
        }

        private static bool GetBoolOrFalse(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return !r.IsDBNull(i) && r.GetBoolean(i);
        }

        private static bool HasColumn(SqlDataReader r, string name)
        {
            try { r.GetOrdinal(name); return true; }
            catch (IndexOutOfRangeException) { return false; }
        }
    }
}
