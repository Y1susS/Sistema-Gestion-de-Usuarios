using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class Presupuesto : DtoDocumentoComercial
    {
        public int IdPresupuesto { get; set; }
        public string NumeroPresupuesto { get; set; }
        public int? Id_Cliente { get; set; }    
        public int? IdUser { get; set; }      
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaValidez { get; set; }
        public int IdEstadoPresupuesto { get; set; }


        public Presupuesto()
        {
            Activo = true;
            FechaCreacion = DateTime.Now;
            IdEstadoPresupuesto = 1; // Estado inicial
        }

    }
}
