using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Servicios;
using Sesion;
using Sesion.Entidades;

namespace Logica
{
    public class CL_Usuarios
    {
        private readonly CD_DaoUsuario daoUsuario = new CD_DaoUsuario();
        private readonly CD_DaoPassUsada daoPassUsada = new CD_DaoPassUsada();

        public bool CambiarPrimeraContraseña(string nombreUsuarioStr, string nuevaContraseña, out string mensaje) // Renombrado 'usuario' a 'nombreUsuarioStr' por claridad
        {
            DtoDatosPersonalesPw usuarioCompleto = daoUsuario.ObtenerUsuarioDetallePorNombre(nombreUsuarioStr);

            if (usuarioCompleto == null)
            {
                mensaje = "No se pudieron obtener los datos personales del usuario para validar las políticas de seguridad.";
                return false;
            }
            if (!ValidarNuevaContrasenaSegunPoliticas(nuevaContraseña, usuarioCompleto, out mensaje))
            {
                return false;
            }
            string hashNuevo = ClsSeguridad.SHA256(nombreUsuarioStr + nuevaContraseña); 

            if (daoUsuario.CambiarContraseña(nombreUsuarioStr, hashNuevo))
            {
                daoUsuario.ActualizarPrimeraClave(nombreUsuarioStr, false);

                CL_ConfiguracionContraseña logicaConfig = new CL_ConfiguracionContraseña();
                DtoConfiguracionContraseña config = logicaConfig.ObtenerConfiguracion();
                if (config != null)
                {
                    daoUsuario.ActualizarCambiaCada(nombreUsuarioStr, config.DiasCambioPassword);
                }

                if (ClsSesionActual.EstaLogueado())
                {
                    daoPassUsada.AgregarPassUsada(usuarioCompleto.Id_user, hashNuevo);
                }

                if (ClsSesionActual.EstaLogueado() && ClsSesionActual.Usuario.User == nombreUsuarioStr)
                {
                    ClsSesionActual.Usuario.PrimeraPass = false;
                }

                mensaje = "Contraseña cambiada exitosamente";
                return true;
            }

            mensaje = "Error al cambiar la contraseña";
            return false;
        }


        public bool CambiarContraseña(string usuarioStr, string contraseñaActual, string nuevaContraseña, out string mensaje)
        {
            DtoDatosPersonalesPw usuarioCompleto = daoUsuario.ObtenerUsuarioDetallePorNombre(usuarioStr);
            if (usuarioCompleto == null)
            {
                mensaje = "No se pudieron obtener los datos personales del usuario para validar las políticas de seguridad.";
                return false;
            }

            string hashActual = ClsSeguridad.SHA256(usuarioCompleto.User + contraseñaActual);
            if (!daoUsuario.VerificarContraseñaActual(usuarioStr, hashActual))
            {
                mensaje = "La contraseña actual es incorrecta.";
                return false;
            }

            if (!ValidarNuevaContrasenaSegunPoliticas(nuevaContraseña, usuarioCompleto, out mensaje))
            {
                return false;
            }

            string hashNueva = ClsSeguridad.SHA256(usuarioCompleto.User + nuevaContraseña);

            // Verificar si no está usando una contraseña reciente (siempre relevante para el usuario)
            if (daoPassUsada.VerificarPassUsada(usuarioCompleto.Id_user, hashNueva))
            {
                mensaje = "No puedes reutilizar una contraseña reciente.";
                return false;
            }

            // Actualizar la contraseña en la BD
            if (daoUsuario.CambiarContraseña(usuarioStr, hashNueva))
            {
                // Guardar en historial (siempre que se cambia, se guarda)
                daoPassUsada.AgregarPassUsada(usuarioCompleto.Id_user, hashNueva);

                // Actualizar valor CambiaCada según configuración actual
                DtoConfiguracionContraseña config = objConfigContra.ObtenerConfiguracion();
                if (config != null)
                {
                    daoUsuario.ActualizarCambiaCada(usuarioStr, config.DiasCambioPassword);
                }

                // Si es primera contraseña y es el usuario logueado, actualizar estado en sesión
                if (ClsSesionActual.EstaLogueado() && ClsSesionActual.Usuario.User == usuarioStr)
                {
                    ClsSesionActual.Usuario.PrimeraPass = false;
                }

                mensaje = "Contraseña cambiada exitosamente.";
                return true;
            }

            mensaje = "Error al cambiar la contraseña en la base de datos.";
            return false;
        }        //HAY NUEVO METODO que toma de la base

        //private bool ValidarPoliticasSeguridad(string contraseña, string usuario, out string mensaje)
        //{
        //    // Estas validaciones podrían venir de tabla Restriccion en BD
        //    int minLength = 8;
        //    bool requireUppercase = true;
        //    bool requireNumbers = true;
        //    bool requireSpecialChar = true;

        //    // Validar longitud mínima
        //    if (contraseña.Length < minLength)
        //    {
        //        mensaje = $"La contraseña debe tener al menos {minLength} caracteres";
        //        return false;
        //    }

        //    // Validar mayúsculas
        //    if (requireUppercase && !contraseña.Any(char.IsUpper))
        //    {
        //        mensaje = "La contraseña debe contener al menos una letra mayúscula";
        //        return false;
        //    }

        //    // Validar números
        //    if (requireNumbers && !contraseña.Any(char.IsDigit))
        //    {
        //        mensaje = "La contraseña debe contener al menos un número";
        //        return false;
        //    }

        //    // Validar caracteres especiales
        //    if (requireSpecialChar && contraseña.All(c => char.IsLetterOrDigit(c)))
        //    {
        //        mensaje = "La contraseña debe contener al menos un carácter especial";
        //        return false;
        //    }

        //    // Validar que no contenga datos del usuario
        //    if (contraseña.ToLower().Contains(usuario.ToLower()))
        //    {
        //        mensaje = "La contraseña no puede contener tu nombre de usuario";
        //        return false;
        //    }

        //    mensaje = "Contraseña válida";
        //    return true;
        //}

        public bool RegistrarUsuario(DtoPersona persona, DtoUsuario usuario, string contrasenaPlana, out string mensaje)
        {
            try
            {
                // 1. Validar que no exista un usuario con el mismo nombre
                if (daoUsuario.ExisteUsuario(usuario.User))
                {
                    mensaje = "El nombre de usuario ya está en uso";
                    return false;
                }
                
                // 2. Agregar la persona primero
                CD_DaoPersona daoPersona = new CD_DaoPersona();
                int idPersona = daoPersona.AgregarPersona(persona);
                
                if (idPersona <= 0)
                {
                    mensaje = "Error al registrar los datos personales";
                    return false;
                }
                
                // 3. Asignar valores al usuario
                usuario.Id_Persona = idPersona;
                usuario.Password = ClsSeguridad.SHA256(usuario.User + contrasenaPlana); // Concatenar usuario y contraseña, luego encriptar
                usuario.Activo = true;
                usuario.PrimeraPass = true; // Forzar cambio en primer ingreso
                
                // 4. Agregar el usuario
                int idUsuario = daoUsuario.AgregarUsuario(usuario);
                
                if (idUsuario <= 0)
                {
                    mensaje = "Error al registrar el usuario";
                    return false;
                }
                
                mensaje = "Usuario registrado correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error en el registro: " + ex.Message;
                return false;
            }
        }

        public bool ActualizarUsuario(DtoPersona persona, DtoUsuario usuario, out string mensaje)
        {
            try
            {
                // 1. Actualizar datos de la persona
                CD_DaoPersona daoPersona = new CD_DaoPersona();
                bool resultadoPersona = daoPersona.ActualizarPersona(persona);
                
                if (!resultadoPersona)
                {
                    mensaje = "Error al actualizar los datos personales";
                    return false;
                }
                
                // 2. Actualizar datos del usuario
                bool resultadoUsuario = daoUsuario.ActualizarUsuario(usuario);
                
                if (!resultadoUsuario)
                {
                    mensaje = "Error al actualizar los datos del usuario";
                    return false;
                }
                
                mensaje = "Usuario actualizado correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error en la actualización: " + ex.Message;
                return false;
            }
        }

        public bool EliminarUsuario(int idUsuario, out string mensaje)
        {
            try
            {
                // Aplicamos una baja lógica, no física
                bool resultado = daoUsuario.BajaUsuario(idUsuario);
                
                mensaje = resultado ? "Usuario eliminado correctamente" : "Error al eliminar el usuario";
                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = "Error al eliminar: " + ex.Message;
                return false;
            }
        }

        public List<DtoUsuarioDetalle> ListarUsuarios()
        {
            try
            {
                return daoUsuario.ListarUsuariosDatos();
            }
            catch (Exception)
            {
                return new List<DtoUsuarioDetalle>();
            }
        }

        public DtoUsuarioDetalle ObtenerUsuario(int idUsuario)
        {
            try
            {
                return daoUsuario.ObtenerUsuarioPorId(idUsuario);
            }
            catch (Exception)
            {
                return null;
            }
        }
        //SEGURDAD PW
        private CD_DaoUsuario objDaoUsuario = new CD_DaoUsuario();
        private CL_ConfiguracionContraseña objConfigContra = new CL_ConfiguracionContraseña();

        public bool ValidarNuevaContrasenaSegunPoliticas(string password, DtoDatosPersonalesPw usuario, out string mensaje)
        
        {
            mensaje = "";
            DtoConfiguracionContraseña config = objConfigContra.ObtenerConfiguracion();

            if (config == null)
            {
                mensaje = "No se pudo cargar la configuración de seguridad de la contraseña.";
                return false;
            }

            // Validaciones(MinimoCaracteres, MayusMinus, NumLetra, Especial)
            if (config.MinimoCaracteres > 0 && password.Length < config.MinimoCaracteres)
            {
                mensaje = $"La contraseña debe tener al menos {config.MinimoCaracteres} caracteres.";
                return false;
            }
            if (config.RequiereMayusMinus && !(password.Any(char.IsUpper) && password.Any(char.IsLower)))
            {
                mensaje = "La contraseña debe contener mayúsculas y minúsculas.";
                return false;
            }
            if (config.RequiereNumLetra && !(password.Any(char.IsDigit) && password.Any(char.IsLetter)))
            {
                mensaje = "La contraseña debe contener letras y números.";
                return false;
            }
            if (config.RequiereEspecial && !password.Any(ch => "!@#$%^&*()-_+=[]{}|;:,.<>?".Contains(ch)))
            {
                mensaje = "La contraseña debe contener al menos un carácter especial.";
                return false;
            }


            // Validaciones que requieren datos del usuario o historial
            if (config.EvitarRepetidas)
            {
                List<DtoHistorialContraseña> historial = objDaoUsuario.ObtenerPasswordsUsadas(usuario.Id_user);

                foreach (var item in historial)
                {
                    if (ClsSeguridad.VerificarHash(password, item.Password))
                    {
                        mensaje = "La contraseña ya ha sido utilizada anteriormente. Por favor, elija una nueva.";
                        return false;
                    }
                }
            }

            if (config.EvitarDatosPersonales)
            {
                
                string nombreLimpio = usuario.Nombre?.ToLowerInvariant().Replace(" ", "");
                string apellidoLimpio = usuario.Apellido?.ToLowerInvariant().Replace(" ", "");
                string documentoLimpio = usuario.NroDocumento?.ToLowerInvariant().Replace(" ", "");
                string emailLimpio = usuario.Email?.Split('@')[0].ToLowerInvariant().Replace(" ", ""); // Solo la parte antes del @

                string passwordLower = password.ToLowerInvariant();

                
                if (!string.IsNullOrEmpty(nombreLimpio) && passwordLower.Contains(nombreLimpio))
                {
                    mensaje = "La contraseña no puede contener partes de su nombre.";
                    return false;
                }
                if (!string.IsNullOrEmpty(apellidoLimpio) && passwordLower.Contains(apellidoLimpio))
                {
                    mensaje = "La contraseña no puede contener partes de su apellido.";
                    return false;
                }
                if (!string.IsNullOrEmpty(documentoLimpio) && passwordLower.Contains(documentoLimpio))
                {
                    mensaje = "La contraseña no puede contener partes de su documento.";
                    return false;
                }
                if (!string.IsNullOrEmpty(emailLimpio) && passwordLower.Contains(emailLimpio))
                {
                    mensaje = "La contraseña no puede contener partes de su email.";
                    return false;
                }
            }

            mensaje = "Contraseña válida.";
            return true;
        }

        public bool ActualizarContrasenaUsuario(string usuario, string nuevaContrasenaPlano)
        {
            string nuevaContrasenaHash = ClsSeguridad.SHA256(nuevaContrasenaPlano);
            bool exito = objDaoUsuario.CambiarContraseña(usuario, nuevaContrasenaHash);

            if (exito)
            {
                objDaoUsuario.CambiarContraseña(usuario, nuevaContrasenaHash);
            }
            return exito;
        }
        public DtoDatosPersonalesPw ObtenerDatosPersonalesPwPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                return objDaoUsuario.ObtenerUsuarioDetallePorNombre(nombreUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CL_Usuarios.ObtenerDatosPersonalesPwPorNombreUsuario: {ex.Message}");
                throw;
            }
        }

        public int ObtenerDiasRestantesCambioContrasena(int idUsuario)
        {
            // Obtener la fecha del último cambio 
            DateTime fechaUltimoCambio = daoUsuario.ObtenerFechaUltimoCambio(idUsuario);

            // Obtener la frecuencia de cambio 
            int cambiaCada = daoUsuario.ObtenerCambiaCada(idUsuario);

            if (cambiaCada <= 0)
            {
                return -1; //  No aplica vencimiento
            }

            if (fechaUltimoCambio == DateTime.MinValue)
            {
                return 0; //  No tiene fecha registrada → forzar vencimiento
            }

            // Calcular la diferencia de días transcurridos desde el último cambio
            TimeSpan diferencia = DateTime.Now - fechaUltimoCambio;

            // Calcular los días restantes
            int diasRestantes = cambiaCada - (int)diferencia.TotalDays;

            return diasRestantes;
        }
    }
}
    
