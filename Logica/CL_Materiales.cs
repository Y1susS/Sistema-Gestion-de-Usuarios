using Datos;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Materiales
    {
        public readonly CD_DaoMateriales daoMaterial = new CD_DaoMateriales();

        public int AltaMaterial(DtoMaterial material)
        {
            if (material == null)
            {
                throw new ArgumentNullException(nameof(material), "Los datos del material no pueden ser nulos.");
            }
            if (string.IsNullOrWhiteSpace(material.NombreMaterial) && string.IsNullOrWhiteSpace(material.Descripcion))
            {
                throw new ArgumentException("El nombre del material es obligatorio.");
            }
            if (material.TipoMaterial == null || material.TipoMaterial.IdTipoMaterial <= 0)
            {
                throw new ArgumentException("Debe seleccionar un tipo de material válido.");
            }

            try
            {
                return daoMaterial.InsertarMaterial(material);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al agregar el material. " + ex.Message, ex);
            }
        }

        public DtoMaterial ObtenerMaterial(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del material es inválido.");
            }

            try
            {
                var material = daoMaterial.ObtenerMaterial(id);
                if (material == null)
                {
                    throw new ApplicationException("No se encontró el material con el ID especificado.");
                }
                return material;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al obtener el material. " + ex.Message, ex);
            }
        }

        public List<DtoMaterial> ListarMateriales()
        {
            try
            {
                return daoMaterial.ListarMateriales();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al listar los materiales. " + ex.Message, ex);
            }
        }

        public List<DtoMaterial> ListarMaterialesPorTipo(int idTipoMaterial)
        {
            try
            {
                return daoMaterial.ListarMaterialesPorTipo(idTipoMaterial);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al filtrar los materiales por tipo. " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene todas las maderas con sus precios para el cotizador
        /// </summary>
        public List<DtoMaterial> ListarMaderas()
        {
            try
            {
                return daoMaterial.ListarMaderas();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al listar las maderas. " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene todos los vidrios con sus precios para el cotizador
        /// </summary>
        public List<DtoMaterial> ListarVidrios()
        {
            try
            {
                return daoMaterial.ListarVidrios();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al listar los vidrios. " + ex.Message, ex);
            }
        }

        public List<DtoTipoMaterial> ListarTiposMateriales()
        {
            try
            {
                return daoMaterial.ListarTiposMateriales();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al listar los tipos de material.", ex);
            }
        }

        /// <summary>
        /// Obtiene tipos de materiales excluyendo maderas y vidrios para "Materiales Varios"
        /// </summary>
        public List<DtoTipoMaterial> ListarTiposMaterialesVarios()
        {
            try
            {
                return daoMaterial.ListarTiposMaterialesVarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al listar los tipos de materiales varios.", ex);
            }
        }

        private void ValidarMaterial(DtoMaterial material)
        {
            if (material == null)
            {
                throw new ArgumentNullException("El material a modificar no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(material.NombreMaterial))
            {
                throw new ArgumentException("El nombre del material es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(material.Unidad))
            {
                throw new ArgumentException("La unidad del material es obligatoria.");
            }
            if (material.PrecioUnitario <= 0)
            {
                throw new ArgumentException("El precio unitario debe ser un valor positivo.");
            }
            if (material.StockActual < 0)
            {
                throw new ArgumentException("El stock actual no puede ser negativo.");
            }
            if (material.StockMinimo < 0)
            {
                throw new ArgumentException("El stock mínimo no puede ser negativo.");
            }
        }

        public void ModificarMaterial(DtoMaterial material)
        {
            try
            {
                ValidarMaterial(material);

                daoMaterial.ActualizarMaterial(material);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public void ValidarMaterialVista(DtoMaterial material)
        {
            if (material.TipoMaterial == null || material.TipoMaterial.IdTipoMaterial <= 0)
                throw new ApplicationException("Debe seleccionar un tipo de material válido.");

            if (string.IsNullOrWhiteSpace(material.NombreMaterial) && string.IsNullOrWhiteSpace(material.Descripcion))
                throw new ApplicationException("Debe ingresar un nombre de material o una descripción.");

            if (!string.IsNullOrWhiteSpace(material.Unidad) &&
                !Regex.IsMatch(material.Unidad, @"^[a-zA-Z0-9\s]+$"))
                throw new ApplicationException("La unidad solo puede contener letras o números.");

            if (material.PrecioUnitario.HasValue && material.PrecioUnitario <= 0)
                throw new ApplicationException("El precio unitario debe ser mayor a cero.");

            if (material.StockActual.HasValue && material.StockActual < 0)
                throw new ApplicationException("El stock actual no puede ser negativo.");

            if (material.StockMinimo.HasValue && material.StockMinimo < 0)
                throw new ApplicationException("El stock mínimo no puede ser negativo.");
        }
    }
}
