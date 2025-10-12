using System;

namespace Entidades.DTOs
{
    public class DtoCotizacionDetalleVidrio
    {
        public int IdDetalleVidrio { get; set; }
        public int IdCotizacion { get; set; }
        public int NumeroLinea { get; set; }
        public int IdMaterial { get; set; }
        public string Descripcion { get; set; }
        public decimal LargoCm { get; set; }
        public decimal AnchoCm { get; set; }
        public int Piezas { get; set; }
        public decimal M2PorPieza { get; set; }
        public decimal PrecioPorM2 { get; set; }
        public decimal PrecioPorUnidad { get; set; }
        public decimal Subtotal { get; set; }
        public string Observaciones { get; set; }
    }
}