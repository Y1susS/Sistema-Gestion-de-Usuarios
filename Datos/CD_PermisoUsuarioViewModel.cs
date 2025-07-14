using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal class CD_PermisoUsuarioViewModel
    {
        public int IdPermiso { get; set; }
        public string NombreFuncionalidad { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; } // Indica si el usuario tiene este permiso (ya sea explícito o por rol)
        public bool HabilitadoPorRol { get; set; } // Solo para referencia: ¿viene por defecto del rol?
    }
}
