using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion.Entidades
{
    public class DtoPermisoUsuario : DtoFuncionalidad
    {
        // Heredo IdFuncionalidad, Nombre y Descripcion de DtoFuncionalidad
        public bool Habilitado { get; set; } // Me indica si el permiso está activo para el usuario.
    }
}
