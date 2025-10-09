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
        private readonly CD_DaoGastosVarios daoGastosVarios = new CD_DaoGastosVarios(); // NUEVO

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
                if (espesorCm > 2.5 && espesorCm <= 3.8) return 1.5;
                if (espesorCm > 3.8 && espesorCm <= 5) return 2;
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
                detalle.Pies = (decimal)CalcularPies((double)detalle.EspesorPulgadas, 
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

        /// <summary>
        /// Calcula el total de gastos varios para una cotización
        /// </summary>
        public virtual decimal CalcularTotalGastosVarios(List<DtoGastoVario> gastosVarios)
        {
            if (gastosVarios == null || !gastosVarios.Any())
                return 0;

            try
            {
                return gastosVarios.Where(g => g.Activo).Sum(g => g.Monto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al calcular total de gastos varios: " + ex.Message, ex);
            }
        }

        public DtoCotizacion CalcularPresupuesto(List<DtoCotizacionDetalle> detalles, 
                                               decimal porcentajeDesperdicio, 
                                               decimal porcentajeGanancia,
                                               decimal precioPorPie,
                                               string descripcionMueble = "",
                                               List<DtoGastoVario> gastosVarios = null)
        {
            try
            {
                var cotizacion = new DtoCotizacion
                {
                    DescripcionMueble = descripcionMueble,
                    PorcentajeDesperdicio = porcentajeDesperdicio,
                    PorcentajeGanancia = porcentajeGanancia,
                    Detalles = detalles,
                    GastosVarios = gastosVarios ?? new List<DtoGastoVario>(),
                    IdUser = ClsSesionActual.EstaLogueado() ? ClsSesionActual.Usuario.Id_user : (int?)null
                };

                // Calcular total de pies cúbicos de maderas (SIN desperdicio aún)
                decimal totalPiesMaderas = detalles.Sum(d => d.Pies);
                
                // APLICAR DESPERDICIO SOLO A LAS MADERAS
                decimal factorDesperdicio = 1 + (porcentajeDesperdicio / 100);
                decimal totalPiesConDesperdicio = totalPiesMaderas * factorDesperdicio;

                // Calcular monto de maderas (con desperdicio aplicado)
                decimal montoMaderas = totalPiesConDesperdicio * precioPorPie;

                // Calcular total de gastos varios (SIN desperdicio)
                decimal totalGastosVarios = CalcularTotalGastosVarios(cotizacion.GastosVarios);

                // SUMAR: Maderas (con desperdicio) + Gastos varios (sin desperdicio)
                cotizacion.MontoMateriales = montoMaderas + totalGastosVarios;

                // Aplicar ganancia al total
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

                // Insertar la cotización primero
                int idCotizacion = daoCotizacion.InsertarCotizacion(cotizacion);

                // Si se insertó correctamente y hay gastos varios, insertarlos
                if (idCotizacion > 0 && cotizacion.GastosVarios != null && cotizacion.GastosVarios.Any())
                {
                    foreach (var gasto in cotizacion.GastosVarios)
                    {
                        gasto.IdCotizacion = idCotizacion;
                        AgregarGastoVario(gasto);
                    }
                }

                return idCotizacion;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica de negocio al agregar la cotización: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Agrega un gasto vario a una cotización
        /// </summary>
        public int AgregarGastoVario(DtoGastoVario gasto)
        {
            try
            {
                ValidarGastoVario(gasto);
                return daoGastosVarios.InsertarGastoVario(gasto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al agregar gasto vario: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lista todos los gastos varios de una cotización específica
        /// </summary>
        public List<DtoGastoVario> ListarGastosPorCotizacion(int idCotizacion)
        {
            if (idCotizacion <= 0)
            {
                throw new ArgumentException("El ID de la cotización es inválido.");
            }

            try
            {
                return daoGastosVarios.ListarGastosPorCotizacion(idCotizacion);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al listar gastos varios: " + ex.Message, ex);
            }
        }

        ///// <summary>
        ///// Actualiza un gasto vario existente
        ///// </summary>
        //public bool ActualizarGastoVario(DtoGastoVario gasto)
        //{
        //    try
        //    {
        //        ValidarGastoVario(gasto);
        //        return daoGastosVarios.ActualizarGastoVario(gasto);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error al actualizar gasto vario: " + ex.Message, ex);
        //    }
        //}

        ///// <summary>
        ///// Elimina un gasto vario (eliminación lógica)
        ///// </summary>
        //public bool EliminarGastoVario(int idGastoVario)
        //{
        //    if (idGastoVario <= 0)
        //    {
        //        throw new ArgumentException("El ID del gasto vario es inválido.");
        //    }

        //    try
        //    {
        //        return daoGastosVarios.EliminarGastoVario(idGastoVario);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error al eliminar gasto vario: " + ex.Message, ex);
        //    }
        //}

        /// <summary>
        /// Procesa y calcula gastos varios desde datos del formulario
        /// </summary>
        public List<DtoGastoVario> ProcesarGastosVariosDesdeFormulario(
            bool incluyeOtrosMateriales, decimal montoOtrosMateriales, string descripcionOtrosMateriales,
            bool incluyeGastosVarios, decimal montoGastosVarios, string descripcionGastosVarios,
            int? idCotizacion = null)
        {
            var gastosVarios = new List<DtoGastoVario>();

            try
            {
                // Procesar "Otros Materiales"
                if (incluyeOtrosMateriales && montoOtrosMateriales > 0)
                {
                    gastosVarios.Add(new DtoGastoVario
                    {
                        Descripcion = !string.IsNullOrWhiteSpace(descripcionOtrosMateriales) 
                            ? descripcionOtrosMateriales 
                            : "Otros materiales",
                        Monto = montoOtrosMateriales,
                        TipoGasto = "OtrosMateriales",
                        IdCotizacion = idCotizacion,
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    });
                }

                // Procesar "Gastos Varios"
                if (incluyeGastosVarios && montoGastosVarios > 0)
                {
                    gastosVarios.Add(new DtoGastoVario
                    {
                        Descripcion = !string.IsNullOrWhiteSpace(descripcionGastosVarios) 
                            ? descripcionGastosVarios 
                            : "Gastos varios",
                        Monto = montoGastosVarios,
                        TipoGasto = "GastosVarios",
                        IdCotizacion = idCotizacion,
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    });
                }

                return gastosVarios;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al procesar gastos varios: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Procesa múltiples gastos varios desde datos del formulario
        /// </summary>
        public List<DtoGastoVario> ProcesarMultiplesGastosVariosDesdeFormulario(
            bool incluyeOtrosMateriales1, decimal montoOtrosMateriales1, string descripcionOtrosMateriales1,
            bool incluyeOtrosMateriales2, decimal montoOtrosMateriales2, string descripcionOtrosMateriales2,
            bool incluyeGastosVarios, decimal montoGastosVarios, string descripcionGastosVarios,
            int? idCotizacion = null)
        {
            var gastosVarios = new List<DtoGastoVario>();

            try
            {
                // Procesar PRIMER "Otros Materiales"
                if (incluyeOtrosMateriales1 && montoOtrosMateriales1 > 0)
                {
                    gastosVarios.Add(new DtoGastoVario
                    {
                        Descripcion = !string.IsNullOrWhiteSpace(descripcionOtrosMateriales1) 
                            ? descripcionOtrosMateriales1 
                            : "Otros materiales 1",
                        Monto = montoOtrosMateriales1,
                        TipoGasto = "OtrosMateriales1",
                        IdCotizacion = idCotizacion,
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    });
                }

                // Procesar SEGUNDO "Otros Materiales"
                if (incluyeOtrosMateriales2 && montoOtrosMateriales2 > 0)
                {
                    gastosVarios.Add(new DtoGastoVario
                    {
                        Descripcion = !string.IsNullOrWhiteSpace(descripcionOtrosMateriales2) 
                            ? descripcionOtrosMateriales2 
                            : "Otros materiales 2",
                        Monto = montoOtrosMateriales2,
                        TipoGasto = "OtrosMateriales2",
                        IdCotizacion = idCotizacion,
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    });
                }

                // Procesar "Gastos Varios"
                if (incluyeGastosVarios && montoGastosVarios > 0)
                {
                    gastosVarios.Add(new DtoGastoVario
                    {
                        Descripcion = !string.IsNullOrWhiteSpace(descripcionGastosVarios) 
                            ? descripcionGastosVarios 
                            : "Gastos varios",
                        Monto = montoGastosVarios,
                        TipoGasto = "GastosVarios",
                        IdCotizacion = idCotizacion,
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    });
                }

                return gastosVarios;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al procesar múltiples gastos varios: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Valida un gasto vario
        /// </summary>
        private void ValidarGastoVario(DtoGastoVario gasto)
        {
            if (gasto == null)
                throw new ArgumentNullException("El gasto no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(gasto.Descripcion))
                throw new ArgumentException("La descripción del gasto es obligatoria.");

            if (gasto.Monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");

            if (gasto.Descripcion.Length > 100)
                throw new ArgumentException("La descripción no puede exceder los 100 caracteres.");
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
