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

        /// <summary>
        /// Obtiene tipos de materiales excluyendo maderas y vidrios para la sección "Materiales Varios"
        /// </summary>
        public List<DtoTipoMaterial> ListarTiposMaterialesVarios()
        {
            List<DtoTipoMaterial> listaTipos = new List<DtoTipoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ListarTiposMaterialesVarios", conn);
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
                throw new Exception("Error al listar tipos de materiales varios: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return listaTipos;
        }

        /// <summary>
        /// Obtiene todas las maderas (TipoMaterial ID = 1) con sus precios
        /// </summary>
        public List<DtoMaterial> ListarMaderas()
        {
            List<DtoMaterial> maderas = new List<DtoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                
                // Intentar primero con SP específico, si falla usar método alternativo
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarMaderas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            maderas.Add(MapearLectorAMaterialSeguro(dr));
                        }
                    }
                }
                catch (SqlException)
                {
                    // Si el SP no existe, usar método alternativo
                    CerrarConexion();
                    return ListarMaderasAlternativo();
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

        /// <summary>
        /// Obtiene todos los vidrios (TipoMaterial ID = 2) con sus precios
        /// </summary>
        public List<DtoMaterial> ListarVidrios()
        {
            List<DtoMaterial> vidrios = new List<DtoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                
                // Intentar primero con SP específico, si falla usar método alternativo
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarVidrios", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            vidrios.Add(MapearLectorAMaterialSeguro(dr));
                        }
                    }
                }
                catch (SqlException)
                {
                    // Si el SP no existe, usar método alternativo
                    CerrarConexion();
                    return ListarVidriosAlternativo();
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

        #region MÉTODOS ALTERNATIVOS

        /// <summary>
        /// Método alternativo para obtener maderas usando el SP general
        /// </summary>
        private List<DtoMaterial> ListarMaderasAlternativo()
        {
            List<DtoMaterial> maderas = new List<DtoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ListarMaterialesPorTipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoMaterial", 1); // 1 = Maderas

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        maderas.Add(MapearLectorAMaterialSeguro(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar maderas (método alternativo): " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return maderas;
        }

        /// <summary>
        /// Método alternativo para obtener vidrios usando el SP general
        /// </summary>
        private List<DtoMaterial> ListarVidriosAlternativo()
        {
            List<DtoMaterial> vidrios = new List<DtoMaterial>();
            SqlConnection conn = null;

            try
            {
                conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ListarMaterialesPorTipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoMaterial", 2); // 2 = Vidrios

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vidrios.Add(MapearLectorAMaterialSeguro(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar vidrios (método alternativo): " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return vidrios;
        }

        #endregion

        #region MAPEO SEGURO

        /// <summary>
        /// Método de mapeo mejorado con manejo de errores y verificación de columnas
        /// </summary>
        private DtoMaterial MapearLectorAMaterialSeguro(SqlDataReader dr)
        {
            try
            {
                var dtoMaterial = new DtoMaterial();

                // Mapear campos básicos con verificación de existencia
                dtoMaterial.IdMaterial = ObtenerValorSeguro<int>(dr, "Id_Material");
                dtoMaterial.NombreMaterial = ObtenerValorSeguro<string>(dr, "NombreMaterial") ?? string.Empty;
                dtoMaterial.Descripcion = ObtenerValorSeguro<string>(dr, "Descripcion") ?? string.Empty;
                dtoMaterial.Unidad = ObtenerValorSeguro<string>(dr, "Unidad") ?? string.Empty;
                
                // Mapear campos nullable
                dtoMaterial.PrecioUnitario = ObtenerValorNullableSeguro<decimal>(dr, "PrecioUnitario");
                dtoMaterial.FechaActualizacion = ObtenerValorNullableSeguro<DateTime>(dr, "FechaActualizacion");
                dtoMaterial.StockActual = ObtenerValorNullableSeguro<decimal>(dr, "StockActual");
                dtoMaterial.StockMinimo = ObtenerValorNullableSeguro<decimal>(dr, "StockMinimo");
                
                // Mapear campo booleano
                var activoValue = ObtenerValorSeguro<object>(dr, "Activo");
                dtoMaterial.Activo = activoValue != null && (
                    (activoValue is bool && (bool)activoValue) ||
                    (activoValue is int && (int)activoValue == 1) ||
                    (activoValue is string && ((string)activoValue).ToLower() == "true")
                );

                // Mapear TipoMaterial
                dtoMaterial.TipoMaterial = new DtoTipoMaterial
                {
                    IdTipoMaterial = ObtenerValorSeguro<int>(dr, "Id_TipoMaterial"),
                    NombreTipoMaterial = ObtenerValorSeguro<string>(dr, "NombreTipoMaterial") ?? string.Empty,
                    DescripcionTipoMaterial = ObtenerValorSeguro<string>(dr, "DescripcionTipoMaterial") ?? string.Empty,
                    ActivoTipoMaterial = true // Por defecto activo si no se puede determinar
                };

                // Intentar obtener ActivoTipoMaterial si existe
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

        /// <summary>
        /// Método de mapeo seguro para TipoMaterial
        /// </summary>
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

        /// <summary>
        /// Obtiene un valor de forma segura del DataReader
        /// </summary>
        private T ObtenerValorSeguro<T>(SqlDataReader dr, string nombreColumna)
        {
            try
            {
                // Verificar si la columna existe
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
                        
                        // Intentar conversión
                        return (T)Convert.ChangeType(valor, typeof(T));
                    }
                }
                
                // Columna no encontrada
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Obtiene un valor nullable de forma segura del DataReader
        /// </summary>
        private T? ObtenerValorNullableSeguro<T>(SqlDataReader dr, string nombreColumna) where T : struct
        {
            try
            {
                // Verificar si la columna existe
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
                        
                        // Intentar conversión
                        return (T)Convert.ChangeType(valor, typeof(T));
                    }
                }
                
                // Columna no encontrada
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte un objeto a boolean de forma segura
        /// </summary>
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

        #region MÉTODOS ORIGINALES (MANTENER COMPATIBILIDAD)
        
        private DtoMaterial MapearLectorAMaterial(SqlDataReader dr)
        {
            // Usar el método seguro
            return MapearLectorAMaterialSeguro(dr);
        }

        private DtoTipoMaterial MapearLectorATipoMaterial(SqlDataReader dr)
        {
            // Usar el método seguro
            return MapearLectorATipoMaterialSeguro(dr);
        }

        #endregion
    }
}

