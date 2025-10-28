using System;

namespace Entidades.DTOs
{
    public class DtoCotizacionDetalle
    {
        // Información de la pieza de madera
        public int NumeroLinea { get; set; }
        public decimal EspesorCm { get; set; }
        public decimal AnchoCm { get; set; }
        public decimal LargoMts { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        
        // Cálculos
        public decimal EspesorPulgadas { get; set; }
        public decimal AnchoPulgadas { get; set; }
        public decimal Pies { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
    }
}
