using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class DtoPresupuestoFiltro
    {
        public int IdPresupuesto { get; set; }
        public string NumeroPresupuesto { get; set; } 
        public string ClienteNombreCompleto { get; set; } 
        public string Observaciones { get; set; }
        public DateTime FechaValidez { get; set; } 
        public decimal MontoFinal { get; set; } 
        public string EstadoPresupuesto { get; set; } 
    }
}
