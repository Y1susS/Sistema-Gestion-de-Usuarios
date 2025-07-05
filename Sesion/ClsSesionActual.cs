using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesion.Entidades;

namespace Sesion
{
    public static class ClsSesionActual
    {
        public static DtoUsuario Usuario { get; set; }

        public static void Iniciar(DtoUsuario dto)
        {
            Usuario = dto;
        }

        public static void Cerrar()
        {
            Usuario = null;
        }

        public static bool EstaLogueado()
        {
            return Usuario != null;
        }
    }
}
