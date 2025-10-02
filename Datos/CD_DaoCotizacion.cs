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

                cmd.Parameters.AddWithValue("@NumeroCotizacion", cotizacion.NumeroCotizacion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_User", cotizacion.IdUser ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DescripcionMueble", cotizacion.DescripcionMueble ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Largo", cotizacion.Largo);
                cmd.Parameters.AddWithValue("@Ancho", cotizacion.Ancho);
                cmd.Parameters.AddWithValue("@Alto", cotizacion.Alto);
                cmd.Parameters.AddWithValue("@UnidadMedida", cotizacion.UnidadMedida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaCreacion", cotizacion.FechaCreacion);
                cmd.Parameters.AddWithValue("@MontoMateriales", cotizacion.MontoMateriales);
                cmd.Parameters.AddWithValue("@MontoManoObra", cotizacion.MontoManoObra);
                cmd.Parameters.AddWithValue("@MontoTotal", cotizacion.MontoTotal);
                cmd.Parameters.AddWithValue("@Observaciones", cotizacion.Observaciones ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", cotizacion.Activo ? 1 : 0);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        idCotizacion = Convert.ToInt32(dr["Id_Cotizacion"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar cotización: " + ex.Message, ex);
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

                cmd.Parameters.AddWithValue("@Id_Cotizacion", cotizacion.IdCotizacion);
                cmd.Parameters.AddWithValue("@NumeroCotizacion", cotizacion.NumeroCotizacion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_User", cotizacion.IdUser ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DescripcionMueble", cotizacion.DescripcionMueble ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Largo", cotizacion.Largo);
                cmd.Parameters.AddWithValue("@Ancho", cotizacion.Ancho);
                cmd.Parameters.AddWithValue("@Alto", cotizacion.Alto);
                cmd.Parameters.AddWithValue("@UnidadMedida", cotizacion.UnidadMedida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MontoMateriales", cotizacion.MontoMateriales);
                cmd.Parameters.AddWithValue("@MontoManoObra", cotizacion.MontoManoObra);
                cmd.Parameters.AddWithValue("@MontoTotal", cotizacion.MontoTotal);
                cmd.Parameters.AddWithValue("@Observaciones", cotizacion.Observaciones ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", cotizacion.Activo ? 1 : 0);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cotización: " + ex.Message, ex);
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
            return new DtoCotizacion
            {
                IdCotizacion = dr.GetInt32(dr.GetOrdinal("Id_Cotizacion")),
                NumeroCotizacion = dr.IsDBNull(dr.GetOrdinal("NumeroCotizacion")) ? null : dr.GetString(dr.GetOrdinal("NumeroCotizacion")),
                IdUser = dr.IsDBNull(dr.GetOrdinal("Id_User")) ? (int?)null : dr.GetInt32(dr.GetOrdinal("Id_User")),
                DescripcionMueble = dr.IsDBNull(dr.GetOrdinal("DescripcionMueble")) ? null : dr.GetString(dr.GetOrdinal("DescripcionMueble")),
                Largo = dr.GetDecimal(dr.GetOrdinal("Largo")),
                Ancho = dr.GetDecimal(dr.GetOrdinal("Ancho")),
                Alto = dr.GetDecimal(dr.GetOrdinal("Alto")),
                UnidadMedida = dr.IsDBNull(dr.GetOrdinal("UnidadMedida")) ? null : dr.GetString(dr.GetOrdinal("UnidadMedida")),
                FechaCreacion = dr.GetDateTime(dr.GetOrdinal("FechaCreacion")),
                MontoMateriales = dr.GetDecimal(dr.GetOrdinal("MontoMateriales")),
                MontoManoObra = dr.GetDecimal(dr.GetOrdinal("MontoManoObra")),
                MontoTotal = dr.GetDecimal(dr.GetOrdinal("MontoTotal")),
                Observaciones = dr.IsDBNull(dr.GetOrdinal("Observaciones")) ? null : dr.GetString(dr.GetOrdinal("Observaciones")),
                Activo = dr.GetBoolean(dr.GetOrdinal("Activo")),

                // Si tienes el campo de usuario en el JOIN
                UsuarioNombre = dr.IsDBNull(dr.GetOrdinal("UsuarioNombre")) ? null : dr.GetString(dr.GetOrdinal("UsuarioNombre"))
            };
        }
    }
}
