using System;
using System.Collections.Generic;

namespace Entidades.DTOs
{
    public class DtoCotizacion : DtoDocumentoComercial
    {
        public int Id_Cotizacion { get; set; }
        public string NumeroCotizacion { get; set; }
        public int? IdUser { get; set; }
        public string DescripcionMueble { get; set; }

        // Compatibilidad
        public string UnidadMedida { get; set; }

        public DateTime FechaCreacion { get; set; }
        public decimal SubTotalMateriales { get; set; }

        // BD: PorcentajeDeperdicio / ProcentajeGanancia
        public decimal PorcentajeDesperdicio { get; set; }
        public decimal PorcentajeGanancia { get; set; }

        // Mueble base
        public int? Id_Madera { get; set; }
        public decimal? PrecioPorPie { get; set; }
        public string NombreMadera { get; set; }  

        public List<DtoCotizacionDetalle> Detalles { get; set; }
        public List<DtoCotizacionDetalleVidrio> DetallesVidrio { get; set; }

        // NUEVO: Materiales Varios
        public List<DtoCotizacionMaterial> MaterialesVarios { get; set; }

        public string UsuarioNombre { get; set; }
        public List<DtoGastoVario> GastosVarios { get; set; }

        public DtoCotizacion()
        {
            Detalles = new List<DtoCotizacionDetalle>();
            DetallesVidrio = new List<DtoCotizacionDetalleVidrio>();
            MaterialesVarios = new List<DtoCotizacionMaterial>();
            GastosVarios = new List<DtoGastoVario>();
            FechaCreacion = DateTime.Now;
            UnidadMedida = "cm";
            Activo = true;

        }
    }
}
