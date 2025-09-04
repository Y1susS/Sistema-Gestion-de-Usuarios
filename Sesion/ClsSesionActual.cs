using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DTOs;

namespace Entidades
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

        //settea para todo el sistema la confid de pw
        public static DtoConfiguracionContraseña ConfiguracionContraseña { get; private set; }

        public static void SetConfiguracionContrasena(DtoConfiguracionContraseña dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "El DTO de configuración no puede ser nulo.");
            }
            ConfiguracionContraseña = dto;
        }
               
    }
}
