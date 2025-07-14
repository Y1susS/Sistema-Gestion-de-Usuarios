using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal class CD_UsuarioGestion
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; } // Combinación de Nombre y Apellido
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

    }
}
