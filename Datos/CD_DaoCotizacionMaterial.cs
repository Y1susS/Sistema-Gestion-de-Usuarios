using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoCotizacionMaterial : CD_Conexion
    {
        public int InsertarMaterialVario(int idCotizacion, DtoCotizacionMaterial d)
        {
            SqlConnection conn = null;
            try
            {
                conn = AbrirConexion();
                using (var cmd = new SqlCommand("SP_InsertarCotizacionMaterial", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);
                    cmd.Parameters.AddWithValue("@Id_Material", d.IdMaterial);
                    cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                    // Manejo correcto de nulos
                    cmd.Parameters.AddWithValue("@Unidad", (object)d.Unidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", (object)d.PrecioUnitario ?? DBNull.Value);

                    // El SP devuelve SCOPE_IDENTITY()
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar material vario: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<DtoCotizacionMaterial> ListarPorCotizacion(int idCotizacion)
        {
            var lista = new List<DtoCotizacionMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                using (var cmd = new SqlCommand("SP_ListarCotizacionMaterialPorCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoCotizacionMaterial
                            {
                                IdCotizacionMaterial = GetInt(dr, "Id_CotizacionMaterial"),
                                IdCotizacion = GetInt(dr, "Id_Cotizacion"),
                                IdMaterial = GetInt(dr, "Id_Material"),
                                NombreMaterial = GetStringOrNull(dr, "NombreMaterial"),
                                Cantidad = GetInt(dr, "Cantidad"),
                                Unidad = GetStringOrNull(dr, "Unidad"),
                                PrecioUnitario = GetDecimalOrNull(dr, "PrecioUnitario")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar materiales varios: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return lista;
        }

        public void EliminarPorCotizacion(int idCotizacion)
        {
            SqlConnection conn = null;
            try
            {
                conn = AbrirConexion();
                using (var cmd = new SqlCommand("SP_EliminarCotizacionMaterialPorCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar materiales varios: " + ex.Message, ex);
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
        private static string GetStringOrNull(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? null : r.GetString(i);
        }
        private static decimal? GetDecimalOrNull(SqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i);
        }
    }
}