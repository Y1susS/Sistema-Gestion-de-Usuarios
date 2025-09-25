using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class EstadoVenta
    {
        public int IdEstadoVenta { get; set; }
        public string Estado { get; set; }
        public bool Activo { get; set; }
    }
}
