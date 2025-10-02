using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidades.DTOs;
using Entidades;

namespace Logica
{
    public class CL_Cotizacion
    {
        private readonly CD_DaoCotizacion daoCotizacion = new CD_DaoCotizacion();
        private readonly CD_DaoMateriales daoMaterial = new CD_DaoMateriales();

        public List<DtoMaterial> ObtenerMaderas()
        {
            try
            {
                // Obtener todos los materiales y filtrar solo los que son maderas
                var todosMateriales = daoMaterial.ListarMateriales();
                
                // Filtrar por palabras clave en el nombre o tipo
                var maderas = todosMateriales.Where(m => 
                    m.TipoMaterial != null && 
                    (m.TipoMaterial.NombreTipoMaterial.ToLower().Contains("madera") ||
                     m.NombreMaterial.ToLower().Contains("madera") ||
                     EsMaderaConocida(m.NombreMaterial))
                ).ToList();

                return maderas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en lógica al obtener maderas: " + ex.Message);
            }
        }

        // Método auxiliar para identificar maderas conocidas
        private bool EsMaderaConocida(string nombreMaterial)
        {
            var maderasConocidas = new[] { "pino", "petiribi", "guayubira", "paraiso", "cancharana", "álamo", "alamo", "roble", "cedro", "eucalipto" };
            return maderasConocidas.Any(madera => nombreMaterial.ToLower().Contains(madera));
        }

        public List<DtoMaterial> ObtenerTodosLosMateriales()
        {
            try
            {
                return daoMaterial.ListarMateriales();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en lógica al obtener materiales: " + ex.Message);
            }
        }

        public static class CalculadorPiesCubicos
        {
            private const double COEFICIENTE_CONVERSION = 0.2734;

            public static double ConvertirEspesorAPulgadas(double espesorCm)
            {
                if (espesorCm <= 0) return 0;
                if (espesorCm > 0 && espesorCm <= 2.5) return 1;
                if (espesorCm > 2.5 && espesorCm <= 3.2) return 1.5;
                if (espesorCm > 3.2 && espesorCm <= 5) return 2;
                if (espesorCm > 5 && espesorCm <= 7.5) return 3;
                if (espesorCm > 7.5 && espesorCm <= 10) return 4;
                return 0;
            }

            public static double AproximarPulgadas(double valor)
            {
                double entero = Math.Floor(valor);
                double fraccion = valor - entero;
                return fraccion <= 0.01 ? entero : entero + 1;
            }

            public static double CalcularPies(double espesorPulgadas, double anchoPulgadas, 
                                            double largoCm, double cantidad)
            {
                return espesorPulgadas * anchoPulgadas * largoCm * COEFICIENTE_CONVERSION * cantidad;
            }

            public static DtoCotizacionDetalle CalcularDetalle(decimal espesorCm, decimal anchoCm, 
                                                              decimal largoCm, int cantidad, 
                                                              string descripcion = "")
            {
                var detalle = new DtoCotizacionDetalle
                {
                    EspesorCm = espesorCm,
                    AnchoCm = anchoCm,
                    LargoCm = largoCm,
                    Cantidad = cantidad,
                    Descripcion = descripcion
                };

                // Conversiones
                detalle.EspesorPulgadas = (decimal)ConvertirEspesorAPulgadas((double)espesorCm);
                double anchoPulgadasDouble = (double)anchoCm / 2.54;
                detalle.AnchoPulgadas = (decimal)AproximarPulgadas(anchoPulgadasDouble);

                // Cálculo de pies cúbicos
                detalle.PiesCubicos = (decimal)CalcularPies((double)detalle.EspesorPulgadas, 
                                                          (double)detalle.AnchoPulgadas, 
                                                          (double)largoCm, cantidad);

                return detalle;
            }
        }

        public bool ValidarDimensiones(decimal espesor, decimal ancho, decimal largo, 
                                     int cantidad, out string mensaje)
        {
            mensaje = string.Empty;

            if (espesor <= 0)
            {
                mensaje = "El espesor no puede ser cero o negativo. Ingrese un número superior a cero y menor que 10.";
                return false;
            }

            if (espesor > 10)
            {
                mensaje = "No es posible utilizar espesores superiores a 10 cm.";
                return false;
            }

            if (ancho <= 0)
            {
                mensaje = "Seleccione un ancho superior a 0 cm.";
                return false;
            }

            double anchoPulgadas = CalculadorPiesCubicos.AproximarPulgadas((double)ancho / 2.54);
            if (anchoPulgadas > 63)
            {
                mensaje = "El ancho máximo de una tabla es 1,60 mts.";
                return false;
            }

            if (largo < 0.1m)
            {
                mensaje = "Seleccione un largo superior a 10 cm.";
                return false;
            }

            if (cantidad <= 0)
            {
                mensaje = "La cantidad debe ser mayor a cero.";
                return false;
            }

            return true;
        }

        public DtoCotizacion CalcularPresupuesto(List<DtoCotizacionDetalle> detalles, 
                                               decimal porcentajeDesperdicio, 
                                               decimal porcentajeGanancia,
                                               decimal precioPorPie,
                                               string descripcionMueble = "")
        {
            try
            {
                var cotizacion = new DtoCotizacion
                {
                    DescripcionMueble = descripcionMueble,
                    PorcentajeDesperdicio = porcentajeDesperdicio,
                    PorcentajeGanancia = porcentajeGanancia,
                    Detalles = detalles,
                    IdUser = ClsSesionActual.EstaLogueado() ? ClsSesionActual.Usuario.Id_user : (int?)null
                };

                // Calcular total de pies cúbicos
                decimal totalPies = detalles.Sum(d => d.PiesCubicos);
                
                // Aplicar desperdicio
                decimal factorDesperdicio = 1 + (porcentajeDesperdicio / 100);
                totalPies *= factorDesperdicio;

                // Calcular monto de materiales
                cotizacion.MontoMateriales = totalPies * precioPorPie;

                // Aplicar ganancia
                decimal factorGanancia = 1 + (porcentajeGanancia / 100);
                cotizacion.MontoTotal = cotizacion.MontoMateriales * factorGanancia;
                cotizacion.MontoFinal = cotizacion.MontoTotal;

                return cotizacion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular presupuesto: " + ex.Message);
            }
        }

        public int AltaCotizacion(DtoCotizacion cotizacion)
        {
            try
            {
                ValidarCotizacion(cotizacion);
                
                // Generar número de cotización si no existe
                if (string.IsNullOrEmpty(cotizacion.NumeroCotizacion))
                {
                    cotizacion.NumeroCotizacion = GenerarNumeroCotizacion();
                }
                
                cotizacion.FechaCreacion = DateTime.Now;
                cotizacion.Activo = true;

                return daoCotizacion.InsertarCotizacion(cotizacion);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al agregar la cotización: " + ex.Message, ex);
            }
        }

        public bool ModificarCotizacion(DtoCotizacion cotizacion)
        {
            try
            {
                ValidarCotizacion(cotizacion);
                return daoCotizacion.ActualizarCotizacion(cotizacion);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al modificar la cotización: " + ex.Message, ex);
            }
        }

        public DtoCotizacion ObtenerCotizacion(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID de la cotización es inválido.");
            }

            try
            {
                var cotizacion = daoCotizacion.ObtenerCotizacion(id);
                if (cotizacion == null)
                {
                    throw new ApplicationException("No se encontró la cotización con el ID especificado.");
                }
                return cotizacion;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al obtener la cotización: " + ex.Message, ex);
            }
        }

        public List<DtoCotizacion> ListarCotizaciones()
        {
            try
            {
                return daoCotizacion.ListarCotizaciones();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al listar cotizaciones: " + ex.Message, ex);
            }
        }

        public List<DtoCotizacion> ListarCotizacionesPorUsuario(int idUsuario)
        {
            try
            {
                return daoCotizacion.ListarCotizacionesPorUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al listar cotizaciones por usuario: " + ex.Message, ex);
            }
        }

        public bool EliminarCotizacion(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID de la cotización es inválido.");
            }

            try
            {
                return daoCotizacion.EliminarCotizacion(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al eliminar la cotización: " + ex.Message, ex);
            }
        }

        private void ValidarCotizacion(DtoCotizacion cotizacion)
        {
            if (cotizacion == null)
            {
                throw new ArgumentNullException("La cotización no puede ser nula.");
            }

            if (string.IsNullOrWhiteSpace(cotizacion.DescripcionMueble))
            {
                throw new ArgumentException("La descripción del mueble es obligatoria.");
            }

            if (cotizacion.Largo <= 0 || cotizacion.Ancho <= 0 || cotizacion.Alto <= 0)
            {
                throw new ArgumentException("Las dimensiones del mueble deben ser mayores a cero.");
            }

            if (cotizacion.MontoTotal < 0)
            {
                throw new ArgumentException("El monto total no puede ser negativo.");
            }
        }

        private string GenerarNumeroCotizacion()
        {
            return $"COT-{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}
