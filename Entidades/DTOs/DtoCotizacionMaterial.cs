using System;

namespace Entidades.DTOs
{
    public class DtoCotizacionMaterial
    {
        public int IdCotizacionMaterial { get; set; }
        public int IdCotizacion { get; set; }
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public decimal? PrecioUnitario { get; set; }

        // No se persiste, útil para UI
        public decimal Subtotal => (PrecioUnitario ?? 0m) * Cantidad;
    }
}