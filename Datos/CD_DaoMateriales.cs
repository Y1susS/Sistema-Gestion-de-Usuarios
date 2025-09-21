using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_DaoMateriales : CD_Conexion
    {
        public int InsertarMaterial(DtoMaterial material)
        {
            int idMaterial = 0;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_InsertarMaterial", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreMaterial", material.NombreMaterial);
                cmd.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                cmd.Parameters.AddWithValue("@Id_TipoMaterial", material.TipoMaterial.IdTipoMaterial);
                cmd.Parameters.AddWithValue("@Unidad", material.Unidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", material.PrecioUnitario ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaActualizacion", material.FechaActualizacion);
                cmd.Parameters.AddWithValue("@StockActual", material.StockActual ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@StockMinimo", material.StockMinimo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", material.Activo ? 1 : 0);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        idMaterial = Convert.ToInt32(dr["Id_Material"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar material: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return idMaterial;
        }

        public bool ActualizarMaterial(DtoMaterial material)
        {
            bool resultado = false;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ActualizarMaterial", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Material", material.IdMaterial);
                cmd.Parameters.AddWithValue("@NombreMaterial", material.NombreMaterial);
                cmd.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                cmd.Parameters.AddWithValue("@Id_TipoMaterial", material.TipoMaterial.IdTipoMaterial);
                cmd.Parameters.AddWithValue("@Unidad", material.Unidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", material.PrecioUnitario ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaActualizacion", material.FechaActualizacion);
                cmd.Parameters.AddWithValue("@StockActual", material.StockActual ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@StockMinimo", material.StockMinimo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", material.Activo ? 1 : 0);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar material: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return resultado;
        }

        public DtoMaterial ObtenerMaterial(int id)
        {
            DtoMaterial material = null;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ObtenerMaterial", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Material", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        material = MapearLectorAMaterial(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener material: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return material;
        }

        public List<DtoMaterial> ListarMateriales()
        {
            List<DtoMaterial> materiales = new List<DtoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ListarMateriales", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        materiales.Add(MapearLectorAMaterial(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar materiales: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return materiales;
        }

        private DtoMaterial MapearLectorAMaterial(SqlDataReader dr)
        {
            var dtoMaterial = new DtoMaterial
            {
                IdMaterial = dr.GetInt32(dr.GetOrdinal("Id_Material")),
                NombreMaterial = dr.GetString(dr.GetOrdinal("NombreMaterial")),
                Descripcion = dr.GetString(dr.GetOrdinal("Descripcion")),
                Unidad = dr.GetString(dr.GetOrdinal("Unidad")),
                PrecioUnitario = dr.IsDBNull(dr.GetOrdinal("PrecioUnitario")) ? (decimal?)null : dr.GetDecimal(dr.GetOrdinal("PrecioUnitario")),
                FechaActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaActualizacion")) ? (DateTime?)null : dr.GetDateTime(dr.GetOrdinal("FechaActualizacion")),
                StockActual = dr.IsDBNull(dr.GetOrdinal("StockActual")) ? (decimal?)null : dr.GetDecimal(dr.GetOrdinal("StockActual")),
                StockMinimo = dr.IsDBNull(dr.GetOrdinal("StockMinimo")) ? (decimal?)null : dr.GetDecimal(dr.GetOrdinal("StockMinimo")),
                Activo = dr.GetInt32(dr.GetOrdinal("Activo")) == 1,

                TipoMaterial = new DtoTipoMaterial
                {
                    IdTipoMaterial = dr.GetInt32(dr.GetOrdinal("Id_TipoMaterial")),
                    NombreTipoMaterial = dr.GetString(dr.GetOrdinal("NombreTipoMaterial")),
                    DescripcionTipoMaterial = dr.IsDBNull(dr.GetOrdinal("DescripcionTipoMaterial")) ? string.Empty : dr.GetString(dr.GetOrdinal("DescripcionTipoMaterial")),
                    ActivoTipoMaterial = dr.IsDBNull(dr.GetOrdinal("ActivoTipoMaterial")) ? false : dr.GetBoolean(dr.GetOrdinal("ActivoTipoMaterial"))
                }
            };

            return dtoMaterial;
        }

        public List<DtoMaterial> ListarMaterialesPorTipo(int idTipoMaterial)
        {
            List<DtoMaterial> materiales = new List<DtoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ListarMaterialesPorTipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoMaterial", idTipoMaterial);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        materiales.Add(MapearLectorAMaterial(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar materiales por tipo: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return materiales;
        }

        public List<DtoTipoMaterial> ListarTiposMateriales()
        {
            List<DtoTipoMaterial> listaTipos = new List<DtoTipoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("sp_ListarTiposMaterial", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaTipos.Add(MapearLectorATipoMaterial(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar tipos de material: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return listaTipos;
        }
        private DtoTipoMaterial MapearLectorATipoMaterial(SqlDataReader dr)
        {
            return new DtoTipoMaterial
            {
                IdTipoMaterial = dr.GetInt32(dr.GetOrdinal("IdTipoMaterial")),
                NombreTipoMaterial = dr.GetString(dr.GetOrdinal("NombreTipoMaterial")),
                DescripcionTipoMaterial = dr.IsDBNull(dr.GetOrdinal("DescripcionTipoMaterial")) ? null : dr.GetString(dr.GetOrdinal("DescripcionTipoMaterial")),
                ActivoTipoMaterial = dr.GetBoolean(dr.GetOrdinal("ActivoTipoMaterial"))
            };
        }
    }
}

