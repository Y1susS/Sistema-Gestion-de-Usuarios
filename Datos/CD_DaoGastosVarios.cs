using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class CD_DaoGastosVarios : CD_Conexion
    {
        public int InsertarGastoVario(DtoGastoVario gasto)
        {
            int idGasto = 0;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_InsertarGastoVario", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
                cmd.Parameters.AddWithValue("@Monto", gasto.Monto);
                cmd.Parameters.AddWithValue("@Id_Cotizacion", gasto.IdCotizacion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_Presupuesto", gasto.IdPresupuesto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoGasto", gasto.TipoGasto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaCreacion", gasto.FechaCreacion);
                cmd.Parameters.AddWithValue("@Activo", gasto.Activo);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        idGasto = Convert.ToInt32(dr["Id_GastoVario"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar gasto vario: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return idGasto;
        }

        public List<DtoGastoVario> ListarGastosPorCotizacion(int idCotizacion)
        {
            List<DtoGastoVario> gastos = new List<DtoGastoVario>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ListarGastosPorCotizacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Cotizacion", idCotizacion);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        gastos.Add(MapearLectorAGastoVario(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar gastos varios: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return gastos;
        }

        private DtoGastoVario MapearLectorAGastoVario(SqlDataReader dr)
        {
            return new DtoGastoVario
            {
                IdGastoVario = Convert.ToInt32(dr["Id_GastoVario"]),
                Descripcion = dr["Descripcion"].ToString(),
                Monto = Convert.ToDecimal(dr["Monto"]),
                IdCotizacion = dr["Id_Cotizacion"] as int?,
                IdPresupuesto = dr["Id_Presupuesto"] as int?,
                TipoGasto = dr["TipoGasto"].ToString(),
                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]),
                Activo = Convert.ToBoolean(dr["Activo"])
            };
        }
    }
}
