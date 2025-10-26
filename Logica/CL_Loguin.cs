using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades.DTOs;
using Entidades;
using Sesion;

namespace Logica
{
    public class CL_Loguin
    {
        private readonly CD_DaoUsuario daoUsuario = new CD_DaoUsuario();
        private readonly CL_ConfiguracionContraseña _configSvc = new CL_ConfiguracionContraseña();

        public bool Autenticar(string usuario, string passwordPlano, out string mensaje)
        {
            // Obtener config desde BD (con fallback por si no hay registro)
            var config = _configSvc.ObtenerConfiguracion() ?? new DtoConfiguracionSeguridad
            {
                MaxIntentosLogin = 3,
                MinutosBloqueoLogin = 60
            };

            DtoUsuario dto = daoUsuario.ObtenerUsuarioPorNombre(usuario);

            // Usuario inexistente: no revelar existencia, devolver mensaje genérico
            if (dto == null)
            {
                mensaje = "Usuario o contraseña incorrectos.";
                return false;
            }

            // Verificar bloqueo por intentos
            if (dto.FechaBloqueo.HasValue)
            {
                DateTime finBloqueo = dto.FechaBloqueo.Value.Add(TimeSpan.FromMinutes(config.MinutosBloqueoLogin));
                if (DateTime.Now < finBloqueo)
                {
                    TimeSpan resta = finBloqueo - DateTime.Now;
                    mensaje = $"Cuenta bloqueada. Intente nuevamente en {Math.Ceiling(resta.TotalMinutes)} minutos.";
                    return false;
                }
                else
                {
                    // Expiró el bloqueo, reiniciar contadores
                    daoUsuario.ReiniciarIntentosYDesbloquear(dto.Id_user);
                    dto.Intentos = 0;
                    dto.FechaBloqueo = null;
                }
            }

            // Validar contraseña
            if (dto.Password != ClsSeguridad.SHA256(usuario + passwordPlano))
            {
                // registrar intento fallido
                daoUsuario.RegistrarIntentoFallido(dto.Id_user, config.MaxIntentosLogin);

                // Reconsultar para saber si ya quedó bloqueado
                DtoUsuario after = daoUsuario.ObtenerUsuarioPorNombre(usuario);
                if (after != null && after.FechaBloqueo.HasValue)
                {
                    mensaje = $"Cuenta bloqueada por múltiples intentos fallidos. Intente en {config.MinutosBloqueoLogin} minutos.";
                }
                else
                {
                    int restantes = Math.Max(0, config.MaxIntentosLogin - (after != null ? after.Intentos : dto.Intentos + 1));
                    mensaje = restantes > 0
                        ? $"Usuario o contraseña incorrectos. Intentos restantes: {restantes}."
                        : "Usuario o contraseña incorrectos.";
                }
                return false;
            }

            // Si el usuario existe y la contraseña es correcta, verificar su estado
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

            // Resetear intentos y desbloqueo al éxito
            daoUsuario.ReiniciarIntentosYDesbloquear(dto.Id_user);

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

            mensaje = "";
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
