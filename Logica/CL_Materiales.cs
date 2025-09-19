using Datos;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Materiales
    {
        public readonly CD_DaoMateriales daoMaterial = new CD_DaoMateriales();

    

        // --- Métodos de Gestión ---

        public int AltaMaterial(DtoMaterial material)
        {
            // 1. Validaciones de datos (reglas de negocio).
            if (material == null)
            {
                throw new ArgumentNullException(nameof(material), "Los datos del material no pueden ser nulos.");
            }
            if (string.IsNullOrEmpty(material.NombreMaterial))
            {
                throw new ArgumentException("El nombre del material es obligatorio.");
            }
            if (material.TipoMaterial == null || material.TipoMaterial.IdTipoMaterial <= 0)
            {
                throw new ArgumentException("Debe seleccionar un tipo de material válido.");
            }

            try
            {
                // 2. Coordinación con la capa de datos.
                return daoMaterial.InsertarMaterial(material);
            }
            catch (Exception ex)
            {
                // 3. Manejo de excepciones.
                throw new ApplicationException("Error en la lógica de negocio al agregar el material. " + ex.Message, ex);
            }
        }
               
        public bool EliminarMaterial(int id)
        {
            // 1. Validación simple.
            if (id <= 0)
            {
                throw new ArgumentException("El ID del material es inválido.");
            }

            try
            {
                // 2. Coordinación con la capa de datos.
                return daoMaterial.EliminarMaterial(id);
            }
            catch (Exception ex)
            {
                // 3. Manejo de excepciones.
                throw new ApplicationException("Error en la lógica de negocio al eliminar el material. " + ex.Message, ex);
            }
        }

        public DtoMaterial ObtenerMaterial(int id)
        {
            // 1. Validación simple.
            if (id <= 0)
            {
                throw new ArgumentException("El ID del material es inválido.");
            }

            try
            {
                // 2. Coordinación con la capa de datos.
                var material = daoMaterial.ObtenerMaterial(id);
                if (material == null)
                {
                    throw new ApplicationException("No se encontró el material con el ID especificado.");
                }
                return material;
            }
            catch (Exception ex)
            {
                // 3. Manejo de excepciones.
                throw new ApplicationException("Error en la lógica de negocio al obtener el material. " + ex.Message, ex);
            }
        }

        public List<DtoMaterial> ListarMateriales()
        {
            try
            {
                // 2. Coordinación con la capa de datos.
                return daoMaterial.ListarMateriales();
            }
            catch (Exception ex)
            {
                // 3. Manejo de excepciones.
                throw new ApplicationException("Error en la lógica de negocio al listar los materiales. " + ex.Message, ex);
            }
        }
        public List<DtoMaterial> ListarMaterialesPorTipo(int idTipoMaterial)
        {
            try
            {
                // Pasa el idTipoMaterial a la capa de datos.
                return daoMaterial.ListarMaterialesPorTipo(idTipoMaterial);
            }
            catch (Exception ex)
            {
                // Maneja la excepción y la relanza con un mensaje más claro.
                throw new ApplicationException("Error en la lógica de negocio al filtrar los materiales por tipo. " + ex.Message, ex);
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
                // Realizar las validaciones de negocio antes de llamar a la capa de datos
                ValidarMaterial(material);

                daoMaterial.ActualizarMaterial(material);
            }
            catch (Exception ex)
            {
                // Relanzar la excepción con un mensaje más descriptivo para la capa superior (UI)
                throw new ApplicationException("Error en la lógica de negocio al modificar el material. " + ex.Message, ex);
            }
        }
        public List<DtoTipoMaterial> ListarTiposMateriales()
        {
            try
            {
                // Llama al método de la capa de acceso a datos y devuelve el resultado
                return daoMaterial.ListarTiposMateriales();
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de la capa de lógica
                throw new Exception("Error en la lógica de negocio al listar los tipos de material.", ex);
            }
        }
    }
}
