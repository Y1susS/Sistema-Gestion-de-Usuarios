using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DTOs;

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

        // Nuevo método para obtener el usuario de la sesión
        public static DtoUsuario ObtenerUsuario()
        {
            return Usuario;
        }

        //settea para todo el sistema la confid de pw
        public static DtoConfiguracionSeguridad ConfiguracionContraseña { get; private set; }

        public static void SetConfiguracionContrasena(DtoConfiguracionSeguridad dto)
        {
            ConfiguracionContraseña = dto ?? throw new ArgumentNullException(nameof(dto), "El DTO de configuración no puede ser nulo.");
        }
    }
}