using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Sesion.Entidades;
using Sesion; 

namespace Logica
{
    public class CL_Loguin
    {
        private readonly CD_DaoUsuario daoUsuario = new CD_DaoUsuario();
        public bool Autenticar(string usuario, string passwordPlano, out string mensaje)
        {
            string hash = ClsSeguridad.SHA256(usuario + passwordPlano);   
            DtoUsuario dto = daoUsuario.ValidarUsuario(usuario, hash);

            if (dto == null)
            {
                mensaje = "Usuario o contraseña incorrectos";
                return false;
            }

            // Iniciar la sesión para tener acceso al usuario
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
                else if (fechaUltimoCambio == DateTime.MinValue) // Si la fecha es el valor por defecto, hubo un problema
                {
                    mensaje = "Error al verificar la caducidad de la contraseña. Contacte al administrador.";
                    return false;
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
