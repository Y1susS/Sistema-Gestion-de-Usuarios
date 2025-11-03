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

        public bool EliminarMaterial(int id)
        {
            bool resultado = false;
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_EliminarMaterial", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Material", id);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar material: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return resultado;
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
                        material = MapearLectorAMaterialSeguro(dr);
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
                        materiales.Add(MapearLectorAMaterialSeguro(dr));
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
                        materiales.Add(MapearLectorAMaterialSeguro(dr));
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
                        listaTipos.Add(MapearLectorATipoMaterialSeguro(dr));
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

        public List<DtoMaterial> ListarMaderas()
        {
            List<DtoMaterial> maderas = new List<DtoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                using (SqlCommand cmd = new SqlCommand("SP_ListarMadera", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            maderas.Add(MapearLectorAMaterialSeguro(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar maderas: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return maderas;
        }

        public List<DtoMaterial> ListarVidrios()
        {
            List<DtoMaterial> vidrios = new List<DtoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                using (SqlCommand cmd = new SqlCommand("SP_ListarVidrios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            vidrios.Add(MapearLectorAMaterialSeguro(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar vidrios: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return vidrios;
        }

        public List<DtoTipoMaterial> ListarTiposMaterialesVarios()
        {
            List<DtoTipoMaterial> listaTipos = new List<DtoTipoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                using (SqlCommand cmd = new SqlCommand("SP_ListarTiposMaterialesVarios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            listaTipos.Add(MapearLectorATipoMaterialSeguro(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar tipos de materiales varios: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return listaTipos;
        }


        public bool ActualizarStockMaterial(int idMaterial, int cantidadVendida)
        {
            bool resultado = false;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DescontarStockMaterial", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdMaterial", idMaterial);
                    cmd.Parameters.AddWithValue("@CantidadVendida", cantidadVendida);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return resultado;
        }

        #region MAPEO SEGURO

        private DtoMaterial MapearLectorAMaterialSeguro(SqlDataReader dr)
        {
            try
            {
                var dtoMaterial = new DtoMaterial();

                dtoMaterial.IdMaterial = ObtenerValorSeguro<int>(dr, "Id_Material");
                dtoMaterial.NombreMaterial = ObtenerValorSeguro<string>(dr, "NombreMaterial") ?? string.Empty;
                dtoMaterial.Descripcion = ObtenerValorSeguro<string>(dr, "Descripcion") ?? string.Empty;
                dtoMaterial.Unidad = ObtenerValorSeguro<string>(dr, "Unidad") ?? string.Empty;

                dtoMaterial.PrecioUnitario = ObtenerValorNullableSeguro<decimal>(dr, "PrecioUnitario");
                dtoMaterial.FechaActualizacion = ObtenerValorNullableSeguro<DateTime>(dr, "FechaActualizacion");
                dtoMaterial.StockActual = ObtenerValorNullableSeguro<decimal>(dr, "StockActual");
                dtoMaterial.StockMinimo = ObtenerValorNullableSeguro<decimal>(dr, "StockMinimo");

                var activoValue = ObtenerValorSeguro<object>(dr, "Activo");
                dtoMaterial.Activo = activoValue != null && (
                    (activoValue is bool && (bool)activoValue) ||
                    (activoValue is int && (int)activoValue == 1) ||
                    (activoValue is string && ((string)activoValue).ToLower() == "true")
                );

                dtoMaterial.TipoMaterial = new DtoTipoMaterial
                {
                    IdTipoMaterial = ObtenerValorSeguro<int>(dr, "Id_TipoMaterial"),
                    NombreTipoMaterial = ObtenerValorSeguro<string>(dr, "NombreTipoMaterial") ?? string.Empty,
                    DescripcionTipoMaterial = ObtenerValorSeguro<string>(dr, "DescripcionTipoMaterial") ?? string.Empty,
                    ActivoTipoMaterial = true
                };

                var activoTipoValue = ObtenerValorSeguro<object>(dr, "ActivoTipoMaterial");
                if (activoTipoValue != null)
                {
                    dtoMaterial.TipoMaterial.ActivoTipoMaterial =
                        (activoTipoValue is bool && (bool)activoTipoValue) ||
                        (activoTipoValue is int && (int)activoTipoValue == 1) ||
                        (activoTipoValue is string && ((string)activoTipoValue).ToLower() == "true");
                }

                return dtoMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al mapear material desde DataReader: {ex.Message}", ex);
            }
        }

        private DtoTipoMaterial MapearLectorATipoMaterialSeguro(SqlDataReader dr)
        {
            try
            {
                return new DtoTipoMaterial
                {
                    IdTipoMaterial = ObtenerValorSeguro<int>(dr, "IdTipoMaterial"),
                    NombreTipoMaterial = ObtenerValorSeguro<string>(dr, "NombreTipoMaterial") ?? string.Empty,
                    DescripcionTipoMaterial = ObtenerValorSeguro<string>(dr, "DescripcionTipoMaterial"),
                    ActivoTipoMaterial = ConvertirABoolean(ObtenerValorSeguro<object>(dr, "ActivoTipoMaterial"))
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al mapear tipo de material desde DataReader: {ex.Message}", ex);
            }
        }

        private T ObtenerValorSeguro<T>(SqlDataReader dr, string nombreColumna)
        {
            try
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (dr.GetName(i).Equals(nombreColumna, StringComparison.OrdinalIgnoreCase))
                    {
                        if (dr.IsDBNull(i))
                        {
                            return default(T);
                        }

                        var valor = dr.GetValue(i);

                        if (valor is T)
                        {
                            return (T)valor;
                        }

                        return (T)Convert.ChangeType(valor, typeof(T));
                    }
                }

                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        private T? ObtenerValorNullableSeguro<T>(SqlDataReader dr, string nombreColumna) where T : struct
        {
            try
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (dr.GetName(i).Equals(nombreColumna, StringComparison.OrdinalIgnoreCase))
                    {
                        if (dr.IsDBNull(i))
                        {
                            return null;
                        }

                        var valor = dr.GetValue(i);

                        if (valor is T)
                        {
                            return (T)valor;
                        }

                        return (T)Convert.ChangeType(valor, typeof(T));
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private bool ConvertirABoolean(object valor)
        {
            if (valor == null) return false;

            if (valor is bool) return (bool)valor;
            if (valor is int) return (int)valor != 0;
            if (valor is string)
            {
                return ((string)valor).ToLower() == "true" ||
                       ((string)valor) == "1";
            }

            return false;
        }

        #endregion
    }
}

