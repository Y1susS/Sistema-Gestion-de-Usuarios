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
        // Propiedades requeridas para la Cotización
        public int IdPresupuesto {  get; set; }
        public int IdCotizacion { get; set; }
        public string NumeroCotizacion { get; set; }
        public string Observaciones { get; set; } // Nombre del mueble
        public decimal PrecioUnitario { get; set; }   

        private int _cantidad; // Propiedad específica del Presupuesto

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = Math.Max(1, value); } // PAra que cantidad sea al menos 1
        }

        // Propiedad calculada para DataGrids (Subtotal de la línea)
        public decimal Subtotal
        {
            set { }
            get { return Cantidad * PrecioUnitario; }
        }

        public DtoPresupuestoDetalle()
        {

        }
    }
}
