using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class DtoMaterial
    {
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public decimal? StockActual { get; set; }
        public decimal? StockMinimo { get; set; }
        public bool Activo { get; set; }

        public DtoTipoMaterial TipoMaterial { get; set; }
    }
}
