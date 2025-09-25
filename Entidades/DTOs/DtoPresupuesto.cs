using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class Presupuesto : DocumentoComercial
    {
        public int IdPresupuesto { get; set; } 
        public int? IdCliente { get; set; }    
        public int? IdUser { get; set; }      
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaValidez { get; set; }
        public int IdEstadoPresupuesto { get; set; } 
    }
}
