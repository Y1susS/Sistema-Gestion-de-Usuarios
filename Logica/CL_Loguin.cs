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
            // 1. Buscar al usuario por su nombre
            DtoUsuario dto = daoUsuario.ObtenerUsuarioPorNombre(usuario);

            // Si el usuario no existe, o si la contraseña no coincide
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

            // 3. Si todo está en orden, proceder con el login
            ClsSesionActual.Iniciar(dto);
            
            // Verificar si es primera contraseña
            if (dto.PrimeraPass)
            {
                mensaje = "Debe cambiar su contraseña por primera vez";
                return true; // Devuelve true pero debe dirigir a frmCambioContraseña
            }

            // Verificar si expiró la contraseña
            DateTime fechaUltimoCambio = daoUsuario.ObtenerFechaUltimoCambio(dto.Id_user);
            int cambiaCada = daoUsuario.ObtenerCambiaCada(dto.Id_user);
            
            if (fechaUltimoCambio != DateTime.MinValue && cambiaCada > 0)
            {
                TimeSpan diferencia = DateTime.Now - fechaUltimoCambio;
                if (diferencia.TotalDays > cambiaCada)
                {
                    mensaje = "Su contraseña ha expirado. Debe cambiarla.";
                    return true; // Devuelve true pero debe dirigir a frmCambioContraseña
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
