using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DtoPresupuestoDetalle
    {
        // Propiedades requeridas de la Cotización
        public int IdCotizacion { get; set; }
        public string NumeroCotizacion { get; set; }
        public string DescripcionMueble { get; set; } // Nombre del mueble
        public decimal PrecioUnitario { get; set; }   // Usaremos DtoCotizacion.MontoFinal aquí

        // Propiedad específica del Presupuesto
        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = Math.Max(1, value); } // Aseguramos que la cantidad sea al menos 1
        }

        // Propiedad calculada para el DataGrid (Subtotal de la línea)
        public decimal MontoTotalItem
        {
            get { return Cantidad * PrecioUnitario; }
        }

        public DtoPresupuestoDetalle()
        {

        }


        public DtoPresupuestoDetalle(DtoCotizacion cotizacion)
        {
            if (cotizacion == null) throw new ArgumentNullException(nameof(cotizacion));

            this.IdCotizacion = cotizacion.Id_Cotizacion;
            this.NumeroCotizacion = cotizacion.NumeroCotizacion;
            this.DescripcionMueble = cotizacion.DescripcionMueble;
            this.PrecioUnitario = cotizacion.MontoFinal; // El precio unitario es el MontoFinal de la cotización
            this.Cantidad = 1; // Se inicializa por defecto en 1
        }
    }
}
