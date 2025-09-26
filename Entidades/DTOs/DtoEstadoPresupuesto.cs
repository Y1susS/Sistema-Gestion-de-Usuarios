using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class DtoEstadoPresupuesto
    {
        public int IdEstadoPresupuesto { get; set; }
        public string Estado { get; set; }
        public bool Activo { get; set; }
    }
}
