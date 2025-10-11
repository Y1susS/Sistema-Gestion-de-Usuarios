using System;
using System.Collections.Generic;

namespace Entidades.DTOs
{
    public class DtoCotizacion : DtoDocumentoComercial
    {
        public int IdCotizacion { get; set; }
        public string NumeroCotizacion { get; set; }
        public int? IdUser { get; set; }
        public string DescripcionMueble { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public string UnidadMedida { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal MontoMateriales { get; set; }
        public decimal MontoManoObra { get; set; }
        
        // Información adicional para el cálculo
        public decimal PorcentajeDesperdicio { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public List<DtoCotizacionDetalle> Detalles { get; set; }
        
        // Información del usuario que cotiza
        public string UsuarioNombre { get; set; }
        
        public DtoCotizacion()
        {
            Detalles = new List<DtoCotizacionDetalle>();
            FechaCreacion = DateTime.Now;
            UnidadMedida = "cm";
            Activo = true;

        }
    }
}
