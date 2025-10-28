using Datos;
using Entidades;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Presupuesto
    {
        private CD_DaoPresupuesto cdPresupuesto = new CD_DaoPresupuesto();

        public List<DtoPresupuestoFiltro> FiltrarPresupuestos(
            string descripcion,
            DateTime? fechaValidez,
            string vendedor,
            string documentoCliente)
        {

            try
            {
                return cdPresupuesto.FiltrarPresupuestos(descripcion, fechaValidez, vendedor, documentoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al intentar filtrar presupuestos.", ex);
            }
        }
        public Presupuesto CargarPresupuestoCompleto(int idPresupuesto)
        {
            // 1. Obtener el encabezado (la parte principal)
            Presupuesto presupuesto = cdPresupuesto.ObtenerEncabezado(idPresupuesto);

            if (presupuesto != null)
            {
                // 2. Obtener los detalles de cotización (las filas del DataGrid)
                List<DtoPresupuestoDetalle> detalles = cdPresupuesto.ObtenerDetalles(idPresupuesto);

                // 3. Crear una propiedad o un método para adjuntar los detalles al presupuesto.
                // Como no tengo tu DTO Presupuesto completo, lo devolveremos separado,
                // pero idealmente deberías tener una propiedad:
                // presupuesto.DetallesCotizacion = detalles;

                // Para fines prácticos, podemos devolver el objeto Presupuesto (encabezado)
                // y gestionar los detalles en la capa de la Vista.

                return presupuesto;
            }

            // Devolver null si no se encontró el encabezado.
            return null;
        }
        public List<DtoPresupuestoDetalle> ObtenerDetalles(int idPresupuesto)
        {
            try
            {
                // Aquí es donde llamas al método implementado en la Capa de Datos (CD)
                return cdPresupuesto.ObtenerDetalles(idPresupuesto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al obtener los detalles de cotización.", ex);
            }
        }

        public int GuardarNuevoPresupuesto(Presupuesto presupuesto, List<DtoPresupuestoDetalle> detalles)
        {
            int idPresupuesto = 0;
            try
            {
                // 1. Insertar la Cabecera y Obtener el ID Generado
                // cdPresupuesto.InsertarPresupuesto DEBE ser renombrado o modificado
                // para *solo* insertar la cabecera y devolver el ID.
                idPresupuesto = cdPresupuesto.InsertarPresupuesto(presupuesto, detalles);

                if (idPresupuesto <= 0)
                {
                    throw new Exception("No se pudo obtener el ID de la cabecera del presupuesto.");
                }

                // 2. Insertar los Detalles uno por uno (SIN TRANSACCIÓN explícita)
                foreach (var detalle in detalles)
                {
                    // Asignar el ID de la cabecera a cada detalle (Foreign Key)
                    detalle.IdPresupuesto = idPresupuesto;

                    // Llamar al método del DAO que inserta un solo detalle
                    cdPresupuesto.InsertarDetallePresupuesto(detalle);
                }

                return idPresupuesto;
            }
            catch (Exception ex)
            {
                // Si el error ocurre en la cabecera, no se inserta nada.
                // Si el error ocurre en un detalle, la cabecera y los detalles anteriores QUEDARÁN
                // guardados en la base de datos (inconsistencia).
                throw new Exception("Error al guardar el presupuesto (revisar si quedó incompleto en DB).", ex);
            }
        }        //CLAUDIOOIO
    }
    //    private PresupuestoDatos presupuestoDatos = new PresupuestoDatos();
    //    private PresupuestoCotizacionDatos pcDatos = new PresupuestoCotizacionDatos();

    //    public int CrearPresupuesto(Presupuesto presupuesto, List<Cotizacion> cotizaciones)
    //    {
    //        try
    //        {
    //            // Validaciones
    //            ValidarPresupuesto(presupuesto);
    //            ValidarCotizacionesPresupuesto(cotizaciones);

    //            // Calcular montos
    //            decimal montoTotal = cotizaciones.Sum(c => c.MontoTotal ?? 0);
    //            decimal descuento = presupuesto.Descuento ?? 0;
    //            decimal montoFinal = montoTotal - (montoTotal * descuento / 100);

    //            presupuesto.MontoTotal = montoTotal;
    //            presupuesto.MontoFinal = montoFinal;

    //            // Generar número de presupuesto si no existe
    //            if (string.IsNullOrWhiteSpace(presupuesto.NumeroPresupuesto))
    //            {
    //                presupuesto.NumeroPresupuesto = presupuestoDatos.GenerarNumeroPresupuesto();
    //            }

    //            // Insertar presupuesto
    //            int idPresupuesto = presupuestoDatos.InsertarPresupuesto(presupuesto);

    //            // Insertar cotizaciones del presupuesto
    //            foreach (var cotizacion in cotizaciones)
    //            {
    //                PresupuestoCotizacion pc = new PresupuestoCotizacion
    //                {
    //                    Id_Presupuesto = idPresupuesto,
    //                    Id_Cotizacion = cotizacion.Id_Cotizacion,
    //                    Cantidad = 1,
    //                    PrecioUnitario = cotizacion.MontoTotal,
    //                    Subtotal = cotizacion.MontoTotal,
    //                    Activo = true
    //                };

    //                pcDatos.InsertarPresupuestoCotizacion(pc);
    //            }

    //            return idPresupuesto;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al crear el presupuesto: " + ex.Message, ex);
    //        }
    //    }

    //    public bool ActualizarPresupuesto(Presupuesto presupuesto, List<Cotizacion> cotizaciones)
    //    {
    //        try
    //        {
    //            // Validaciones
    //            ValidarPresupuesto(presupuesto);
    //            ValidarCotizacionesPresupuesto(cotizaciones);

    //            // Calcular montos
    //            decimal montoTotal = cotizaciones.Sum(c => c.MontoTotal ?? 0);
    //            decimal descuento = presupuesto.Descuento ?? 0;
    //            decimal montoFinal = montoTotal - (montoTotal * descuento / 100);

    //            presupuesto.MontoTotal = montoTotal;
    //            presupuesto.MontoFinal = montoFinal;

    //            // Actualizar presupuesto
    //            bool resultado = presupuestoDatos.ActualizarPresupuesto(presupuesto);

    //            if (resultado)
    //            {
    //                // Eliminar cotizaciones anteriores
    //                pcDatos.EliminarCotizacionesDePresupuesto(presupuesto.Id_Presupuesto);

    //                // Insertar nuevas cotizaciones
    //                foreach (var cotizacion in cotizaciones)
    //                {
    //                    PresupuestoCotizacion pc = new PresupuestoCotizacion
    //                    {
    //                        Id_Presupuesto = presupuesto.Id_Presupuesto,
    //                        Id_Cotizacion = cotizacion.Id_Cotizacion,
    //                        Cantidad = 1,
    //                        PrecioUnitario = cotizacion.MontoTotal,
    //                        Subtotal = cotizacion.MontoTotal,
    //                        Activo = true
    //                    };

    //                    pcDatos.InsertarPresupuestoCotizacion(pc);
    //                }
    //            }

    //            return resultado;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al actualizar el presupuesto: " + ex.Message, ex);
    //        }
    //    }

    //    public Presupuesto ObtenerPresupuestoPorId(int idPresupuesto)
    //    {
    //        try
    //        {
    //            if (idPresupuesto <= 0)
    //                throw new ArgumentException("El ID de presupuesto debe ser mayor a 0");

    //            return presupuestoDatos.ObtenerPresupuestoPorId(idPresupuesto);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al obtener el presupuesto: " + ex.Message, ex);
    //        }
    //    }

    //    public List<PresupuestoCotizacion> ObtenerCotizacionesDePresupuesto(int idPresupuesto)
    //    {
    //        try
    //        {
    //            if (idPresupuesto <= 0)
    //                throw new ArgumentException("El ID de presupuesto debe ser mayor a 0");

    //            return pcDatos.ObtenerCotizacionesPorPresupuesto(idPresupuesto);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al obtener las cotizaciones del presupuesto: " + ex.Message, ex);
    //        }
    //    }

    //    public string GenerarNumeroPresupuesto()
    //    {
    //        try
    //        {
    //            return presupuestoDatos.GenerarNumeroPresupuesto();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al generar el número de presupuesto: " + ex.Message, ex);
    //        }
    //    }

    //    public decimal CalcularMontoTotal(List<Cotizacion> cotizaciones)
    //    {
    //        if (cotizaciones == null || !cotizaciones.Any())
    //            return 0;

    //        return cotizaciones.Sum(c => c.MontoTotal ?? 0);
    //    }

    //    public decimal CalcularMontoConDescuento(decimal montoTotal, decimal porcentajeDescuento)
    //    {
    //        if (montoTotal < 0)
    //            throw new ArgumentException("El monto total no puede ser negativo");

    //        if (porcentajeDescuento < 0 || porcentajeDescuento > 100)
    //            throw new ArgumentException("El descuento debe estar entre 0 y 100");

    //        decimal montoDescuento = montoTotal * (porcentajeDescuento / 100);
    //        return montoTotal - montoDescuento;
    //    }

    //    private void ValidarPresupuesto(Presupuesto presupuesto)
    //    {
    //        if (presupuesto == null)
    //            throw new ArgumentException("El presupuesto no puede ser nulo");

    //        if (presupuesto.Id_Cliente == null || presupuesto.Id_Cliente <= 0)
    //            throw new Exception("Debe seleccionar un cliente");

    //        if (presupuesto.FechaValidez == null)
    //            throw new Exception("Debe establecer una fecha de validez");

    //        if (presupuesto.FechaValidez < DateTime.Now.Date)
    //            throw new Exception("La fecha de validez no puede ser anterior a hoy");

    //        if (presupuesto.Descuento != null && (presupuesto.Descuento < 0 || presupuesto.Descuento > 100))
    //            throw new Exception("El descuento debe estar entre 0 y 100");
    //    }

    //    private void ValidarCotizacionesPresupuesto(List<Cotizacion> cotizaciones)
    //    {
    //        if (cotizaciones == null || !cotizaciones.Any())
    //            throw new Exception("Debe agregar al menos una cotización al presupuesto");

    //        foreach (var cotizacion in cotizaciones)
    //        {
    //            if (cotizacion.MontoTotal == null || cotizacion.MontoTotal <= 0)
    //                throw new Exception($"La cotización '{cotizacion.DescripcionMueble}' tiene un monto inválido");
    //        }
    //    }


    //    //


    //    private PresupuestoCotizacionDatos pcDatos = new PresupuestoCotizacionDatos();

    //    public bool AgregarCotizacionAPresupuesto(int idPresupuesto, int idCotizacion, decimal precioUnitario)
    //    {
    //        try
    //        {
    //            if (idPresupuesto <= 0)
    //                throw new ArgumentException("ID de presupuesto inválido");

    //            if (idCotizacion <= 0)
    //                throw new ArgumentException("ID de cotización inválido");

    //            if (precioUnitario <= 0)
    //                throw new ArgumentException("El precio unitario debe ser mayor a 0");

    //            PresupuestoCotizacion pc = new PresupuestoCotizacion
    //            {
    //                Id_Presupuesto = idPresupuesto,
    //                Id_Cotizacion = idCotizacion,
    //                Cantidad = 1,
    //                PrecioUnitario = precioUnitario,
    //                Subtotal = precioUnitario,
    //                Activo = true
    //            };

    //            return pcDatos.InsertarPresupuestoCotizacion(pc);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al agregar cotización al presupuesto: " + ex.Message, ex);
    //        }
    //    }

    //    public List<PresupuestoCotizacion> ObtenerCotizacionesPorPresupuesto(int idPresupuesto)
    //    {
    //        try
    //        {
    //            if (idPresupuesto <= 0)
    //                throw new ArgumentException("ID de presupuesto inválido");

    //            return pcDatos.ObtenerCotizacionesPorPresupuesto(idPresupuesto);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al obtener cotizaciones del presupuesto: " + ex.Message, ex);
    //        }
    //    }

    //    public decimal CalcularSubtotalPresupuesto(int idPresupuesto)
    //    {
    //        try
    //        {
    //            var cotizaciones = pcDatos.ObtenerCotizacionesPorPresupuesto(idPresupuesto);
    //            return cotizaciones.Sum(c => c.Subtotal ?? 0);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al calcular subtotal: " + ex.Message, ex);
    //        }
    //    }
    //}
}
