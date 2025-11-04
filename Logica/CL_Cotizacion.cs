using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidades.DTOs;
using Sesion;

namespace Logica
{
    public class CL_Cotizacion
    {
        private readonly CD_DaoCotizacion daoCotizacion = new CD_DaoCotizacion();
        private readonly CD_DaoMateriales daoMaterial = new CD_DaoMateriales();
        private readonly CD_DaoGastosVarios daoGastosVarios = new CD_DaoGastosVarios();
        private readonly CD_DaoCotizacionDetalleMadera daoDetalleMadera = new CD_DaoCotizacionDetalleMadera();
        private readonly CD_DaoCotizacionDetalleVidrio daoDetalleVidrio = new CD_DaoCotizacionDetalleVidrio();
        private readonly CD_DaoCotizacionMaterial daoMaterialesVarios = new CD_DaoCotizacionMaterial(); // NUEVO


        public static class CalculadorPies
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

            public static double CalcularPies(double espesorPulgadas, double anchoPulgadas, double largoCm, double cantidad)
            {
                return espesorPulgadas * anchoPulgadas * largoCm * COEFICIENTE_CONVERSION * cantidad;
            }

            public static DtoCotizacionDetalle CalcularDetalle(decimal espesorCm, decimal anchoCm, decimal largoCm, int cantidad, string descripcion = "")
            {
                var detalle = new DtoCotizacionDetalle
                {
                    EspesorCm = espesorCm,
                    AnchoCm = anchoCm,
                    LargoMts = largoCm,
                    Cantidad = cantidad,
                    Descripcion = descripcion,
                    EspesorPulgadas = (decimal)ConvertirEspesorAPulgadas((double)espesorCm),
                    AnchoPulgadas = (decimal)AproximarPulgadas((double)anchoCm / 2.54),
                    Pies = (decimal)CalcularPies(
                        (double)ConvertirEspesorAPulgadas((double)espesorCm),
                        (double)AproximarPulgadas((double)anchoCm / 2.54),
                        (double)largoCm,
                        cantidad)
                };
                return detalle;
            }
        }

        public bool ValidarDimensiones(decimal espesor, decimal ancho, decimal largo, int cantidad, out string mensaje)
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

            double anchoPulgadas = CalculadorPies.AproximarPulgadas((double)ancho / 2.54);
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

        public virtual decimal CalcularTotalGastosVarios(List<DtoGastoVario> gastosVarios)
        {
            if (gastosVarios == null || !gastosVarios.Any())
                return 0;

            try
            {
                return gastosVarios.Sum(g => g.Monto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al calcular total de gastos varios: " + ex.Message, ex);
            }
        }

        public DtoCotizacion CalcularCotizacion(
            List<DtoCotizacionDetalle> detalles,
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
                    Detalles = detalles ?? new List<DtoCotizacionDetalle>(),
                    GastosVarios = gastosVarios ?? new List<DtoGastoVario>(),
                    IdUser = ClsSesionActual.EstaLogueado() ? ClsSesionActual.Usuario.Id_user : (int?)null,
                    PrecioPorPie = precioPorPie
                };

                decimal totalPiesMaderas = cotizacion.Detalles.Sum(d => d.Pies);
                decimal factorDesperdicio = 1 + (porcentajeDesperdicio / 100m);
                decimal totalPiesConDesperdicio = totalPiesMaderas * factorDesperdicio;

                decimal montoMaderas = totalPiesConDesperdicio * precioPorPie;
                decimal totalGastosVarios = CalcularTotalGastosVarios(cotizacion.GastosVarios);

                cotizacion.SubTotalMateriales = montoMaderas + totalGastosVarios;

                decimal factorGanancia = 1 + (porcentajeGanancia / 100m);
                cotizacion.MontoTotal = cotizacion.SubTotalMateriales * factorGanancia;
                cotizacion.MontoFinal = cotizacion.MontoTotal;

                return cotizacion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular presupuesto: " + ex.Message);
            }
        }

        private void ValidarCotizacion(DtoCotizacion cotizacion)
        {
            if (cotizacion == null)
                throw new ArgumentNullException("La cotización no puede ser nula.");

            if (string.IsNullOrWhiteSpace(cotizacion.DescripcionMueble))
                throw new ArgumentException("La descripción del mueble es obligatoria.");

            if (cotizacion.PorcentajeGanancia < 0)
                throw new ArgumentException("La ganancia no puede ser negativa.");

            if (cotizacion.PorcentajeDesperdicio < 0)
                throw new ArgumentException("El desperdicio no puede ser negativo.");

            if (cotizacion.MontoTotal < 0 || cotizacion.MontoFinal < 0)
                throw new ArgumentException("Los montos no pueden ser negativos.");
        }

        private static string FormatearNumeroCotizacion(int id)
        {
            return "COT-" + id.ToString("D6");
        }

        public int AltaCotizacion(DtoCotizacion cotizacion)
        {
            try
            {
                ValidarCotizacion(cotizacion);

                // Si no viene número, lo generaremos luego basado en el Id
                bool generarNumeroLuego = string.IsNullOrWhiteSpace(cotizacion.NumeroCotizacion);
                if (generarNumeroLuego)
                {
                    cotizacion.NumeroCotizacion = null;
                }

                cotizacion.FechaCreacion = DateTime.Now;
                cotizacion.Activo = true;

                int idCotizacion = daoCotizacion.InsertarCotizacion(cotizacion);
                if (idCotizacion <= 0) return 0;

                // Actualizar con número corto COT-000123
                if (generarNumeroLuego)
                {
                    cotizacion.Id_Cotizacion = idCotizacion;
                    cotizacion.NumeroCotizacion = FormatearNumeroCotizacion(idCotizacion);
                    daoCotizacion.ActualizarCotizacion(cotizacion);
                }

                // Detalles madera
                if (cotizacion.Detalles != null && cotizacion.Detalles.Any())
                {
                    decimal precioPorPie = cotizacion.PrecioPorPie ?? 0m;
                    foreach (var d in cotizacion.Detalles.OrderBy(x => x.NumeroLinea))
                    {
                        d.SubTotal = Math.Round(d.Pies * precioPorPie, 2);
                        daoDetalleMadera.InsertarDetalleMadera(idCotizacion, d);
                    }
                }

                // Detalles vidrio
                if (cotizacion.DetallesVidrio != null && cotizacion.DetallesVidrio.Any())
                {
                    foreach (var v in cotizacion.DetallesVidrio.OrderBy(x => x.NumeroLinea))
                    {
                        daoDetalleVidrio.InsertarDetalleVidrio(idCotizacion, v);
                    }
                }

                // Materiales varios
                if (cotizacion.MaterialesVarios != null && cotizacion.MaterialesVarios.Any())
                {
                    foreach (var mv in cotizacion.MaterialesVarios)
                    {
                        daoMaterialesVarios.InsertarMaterialVario(idCotizacion, mv);
                    }
                }

                // Gastos varios
                if (cotizacion.GastosVarios != null && cotizacion.GastosVarios.Any())
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
                throw new ApplicationException("Error en la lógica al agregar la cotización: " + ex.Message, ex);
            }
        }

        public bool ActualizarCotizacion(DtoCotizacion cotizacion)
        {
            try
            {
                ValidarCotizacion(cotizacion);

                bool ok = daoCotizacion.ActualizarCotizacion(cotizacion);
                if (!ok) return false;

                // Reemplazo detalles madera
                daoDetalleMadera.EliminarDetallesPorCotizacion(cotizacion.Id_Cotizacion);
                if (cotizacion.Detalles != null && cotizacion.Detalles.Any())
                {
                    decimal precioPorPie = cotizacion.PrecioPorPie ?? 0m;
                    foreach (var d in cotizacion.Detalles.OrderBy(x => x.NumeroLinea))
                    {
                        d.SubTotal = Math.Round(d.Pies * precioPorPie, 2);
                        daoDetalleMadera.InsertarDetalleMadera(cotizacion.Id_Cotizacion, d);
                    }
                }

                // Reemplazo vidrio
                daoDetalleVidrio.EliminarDetallesPorCotizacion(cotizacion.Id_Cotizacion);
                if (cotizacion.DetallesVidrio != null && cotizacion.DetallesVidrio.Any())
                {
                    foreach (var v in cotizacion.DetallesVidrio.OrderBy(x => x.NumeroLinea))
                    {
                        daoDetalleVidrio.InsertarDetalleVidrio(cotizacion.Id_Cotizacion, v);
                    }
                }

                // Reemplazo materiales varios
                daoMaterialesVarios.EliminarPorCotizacion(cotizacion.Id_Cotizacion);
                if (cotizacion.MaterialesVarios != null && cotizacion.MaterialesVarios.Any())
                {
                    foreach (var mv in cotizacion.MaterialesVarios)
                    {
                        daoMaterialesVarios.InsertarMaterialVario(cotizacion.Id_Cotizacion, mv);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica al actualizar cotización: " + ex.Message, ex);
            }
        }

        // ====== Métodos agregados para frmListarCotizaciones y frmCotizador ======

        public List<DtoCotizacion> ListarCotizaciones()
        {
            try
            {
                return daoCotizacion.ListarCotizaciones();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica al listar cotizaciones: " + ex.Message, ex);
            }
        }

        public DtoCotizacion ObtenerCotizacion(int idCotizacion)
        {
            if (idCotizacion <= 0)
                throw new ArgumentException("El ID de la cotización debe ser mayor a cero.");

            try
            {
                var cab = daoCotizacion.ObtenerCotizacion(idCotizacion);
                if (cab == null) return null;

                cab.Detalles = daoDetalleMadera.ListarDetallesPorCotizacion(idCotizacion) ?? new List<DtoCotizacionDetalle>();
                cab.DetallesVidrio = daoDetalleVidrio.ListarDetallesPorCotizacion(idCotizacion) ?? new List<DtoCotizacionDetalleVidrio>();
                cab.MaterialesVarios = daoMaterialesVarios.ListarPorCotizacion(idCotizacion) ?? new List<DtoCotizacionMaterial>();

                try
                {
                    cab.GastosVarios = daoGastosVarios.ListarGastosPorCotizacion(idCotizacion) ?? new List<DtoGastoVario>();
                }
                catch
                {
                    cab.GastosVarios = new List<DtoGastoVario>();
                }

                return cab;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica al obtener cotización: " + ex.Message, ex);
            }
        }

        public bool EliminarCotizacion(int idCotizacion)
        {
            if (idCotizacion <= 0)
                throw new ArgumentException("El ID de la cotización debe ser mayor a cero.");

            try
            {
                return daoCotizacion.EliminarCotizacion(idCotizacion);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la lógica al eliminar cotización: " + ex.Message, ex);
            }
        }

        public int AgregarGastoVario(DtoGastoVario gasto)
        {
            try
            {
                if (gasto == null) throw new ArgumentNullException("El gasto no puede ser nulo.");
                if (string.IsNullOrWhiteSpace(gasto.Descripcion)) throw new ArgumentException("La descripción del gasto es obligatoria.");
                if (gasto.Monto <= 0) throw new ArgumentException("El monto debe ser mayor a cero.");

                return daoGastosVarios.InsertarGastoVario(gasto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al agregar gasto vario: " + ex.Message, ex);
            }
        }

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

        public List<DtoGastoVario> ProcesarMultiplesGastosVariosDesdeFormulario(
            bool incluyeOtrosMateriales1, decimal montoOtrosMateriales1, string descripcionOtrosMateriales1,
            bool incluyeOtrosMateriales2, decimal montoOtrosMateriales2, string descripcionOtrosMateriales2,
            bool incluyeGastosVarios, decimal montoGastosVarios, string descripcionGastosVarios,
            int? idCotizacion = null)
        {
            var gastosVarios = new List<DtoGastoVario>();

            try
            {
                if (incluyeOtrosMateriales1 && montoOtrosMateriales1 > 0)
                {
                    gastosVarios.Add(new DtoGastoVario
                    {
                        Descripcion = !string.IsNullOrWhiteSpace(descripcionOtrosMateriales1) ? descripcionOtrosMateriales1 : "Otros materiales 1",
                        Monto = montoOtrosMateriales1,
                        IdCotizacion = idCotizacion,
                        Activo = true
                    });
                }

                if (incluyeOtrosMateriales2 && montoOtrosMateriales2 > 0)
                {
                    gastosVarios.Add(new DtoGastoVario
                    {
                        Descripcion = !string.IsNullOrWhiteSpace(descripcionOtrosMateriales2) ? descripcionOtrosMateriales2 : "Otros materiales 2",
                        Monto = montoOtrosMateriales2,
                        IdCotizacion = idCotizacion,
                        Activo = true
                    });
                }

                if (incluyeGastosVarios && montoGastosVarios > 0)
                {
                    gastosVarios.Add(new DtoGastoVario
                    {
                        Descripcion = !string.IsNullOrWhiteSpace(descripcionGastosVarios) ? descripcionGastosVarios : "Gastos varios",
                        Monto = montoGastosVarios,
                        IdCotizacion = idCotizacion,
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
    }
}
