using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class DtoDatosPersonalesPw
    {
        public int Id_user { get; set; }
        public string User { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string NroDocumento { get; set; }
        public string Email { get; set; }

    }
}
