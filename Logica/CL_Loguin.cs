using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades.DTOs;
using Entidades; 

namespace Logica
{
    public class CL_Loguin
    {
        private readonly CD_DaoUsuario daoUsuario = new CD_DaoUsuario();

        public bool Autenticar(string usuario, string passwordPlano, out string mensaje)
        {
            DtoUsuario dto = daoUsuario.ObtenerUsuarioPorNombre(usuario);

            if (dto == null || dto.Password != ClsSeguridad.SHA256(usuario + passwordPlano))
            {
                mensaje = "Usuario o contraseña incorrectos.";
                return false;
            }

            // 2. Si el usuario existe y la contraseña es correcta, verificar su estado
            if (dto.FechaBaja != null)
            {
                mensaje = "Este usuario ha sido dado de baja. Contacte al administrador.";
                return false;
            }

            if (!dto.Activo)
            {
                mensaje = "Este usuario se encuentra inactivo. Contacte al administrador.";
                return false;
            }

            // Cargar permisos del usuario antes de iniciar sesión
            dto.Permisos = daoUsuario.ObtenerPermisosPorUsuario(dto.Id_user) ?? new List<string>();

            ClsSesionActual.Iniciar(dto);
            
            if (dto.PrimeraPass)
            {
                mensaje = "Debe cambiar su contraseña por primera vez";
                return true; // redirige a cambio de contraseña
            }

            DateTime fechaUltimoCambio = daoUsuario.ObtenerFechaUltimoCambio(dto.Id_user);
            int cambiaCada = daoUsuario.ObtenerCambiaCada(dto.Id_user);

            if (fechaUltimoCambio != DateTime.MinValue && cambiaCada > 0)
            {
                TimeSpan diferencia = DateTime.Now - fechaUltimoCambio;
                if (diferencia.TotalDays > cambiaCada)
                {
                    mensaje = "Su contraseña ha expirado. Debe cambiarla.";
                    return true; // redirige a cambio de contraseña
                }
            }

            mensaje = "Login correcto! Bienvenido: " + ClsSesionActual.Usuario.User;
            return true;
        }

        public void EnviarCorreo(string direccionCorreo, string asunto, string nuevaContraseña)
        {
            ClsArmarMail.DireccionCorreo = direccionCorreo;
            ClsArmarMail.Asunto = asunto;
            ClsArmarMail.NuevaContraseña = nuevaContraseña;
            ClsArmarMail.Preparar();
        }
    }
}
