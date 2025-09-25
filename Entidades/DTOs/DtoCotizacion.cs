using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class Cotizacion : DocumentoComercial
    {
        public int IdCotizacion { get; set; } 
        public int? IdUser { get; set; }      
        public string DescripcionMueble { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public string UnidadMedida { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdEstadoCotizacion { get; set; }
        public decimal MontoMateriales { get; set; }
        public decimal MontoManoObra { get; set; }
    }
}
