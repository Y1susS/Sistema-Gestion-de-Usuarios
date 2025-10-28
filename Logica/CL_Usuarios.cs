using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Servicios; 
using Entidades; 
using Entidades.DTOs;
using Sesion;


namespace Logica
{
    public class CL_Usuarios
    {
        private readonly CD_DaoUsuario daoUsuario = new CD_DaoUsuario();
        private readonly CD_DaoPassUsada daoPassUsada = new CD_DaoPassUsada();
        
        //agregados por lucas
        private CD_DaoUsuario objDaoUsuario = new CD_DaoUsuario();
        private CL_ConfiguracionContraseña objConfigContra = new CL_ConfiguracionContraseña();

        //método para cambiar la primera contraseña del usuario.
        public bool CambiarPrimeraContraseña(string nombreUsuarioStr, string nuevaContraseña, out string mensaje)
        {
            DtoDatosPersonalesPw usuarioCompleto = daoUsuario.ObtenerUsuarioDetallePorNombre(nombreUsuarioStr);

            if (usuarioCompleto == null)
            {
                mensaje = "No pude obtener los datos personales del usuario para validar las políticas de seguridad.";
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
                DtoConfiguracionSeguridad config = logicaConfig.ObtenerConfiguracion();
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
                DtoConfiguracionSeguridad config = objConfigContra.ObtenerConfiguracion();
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



        // método para registrar un nuevo usuario en el sistema.

        public bool RegistrarUsuario(DtoPersona persona, DtoUsuario usuario, string contrasenaPlana, out string mensaje)
        {
            try
            {
                // Valido que no exista un usuario con el mismo nombre
                if (daoUsuario.ExisteUsuario(usuario.User))
                {
                    mensaje = "El nombre de usuario ya está en uso";
                    return false;
                }

                // Agrego la persona primero
                CD_DaoPersona daoPersona = new CD_DaoPersona();
                int idPersona = daoPersona.AgregarPersona(persona);

                if (idPersona <= 0)
                {
                    mensaje = "Error al registrar los datos personales";
                    return false;
                }

                // Asigno valores al usuario
                usuario.Id_Persona = idPersona;
                usuario.Password = ClsSeguridad.SHA256(usuario.User + contrasenaPlana); // Concateno usuario y contraseña, luego encripto
                usuario.Activo = true;
                usuario.PrimeraPass = true; // Fuerzo el cambio en el primer ingreso

                // Agrego el usuario
                int idUsuario = daoUsuario.AgregarUsuario(usuario);

                if (idUsuario <= 0)
                {
                    mensaje = "Error al registrar el usuario";
                    return false;
                }

       // ASIGNAR PERMISOS POR ROL ---
                daoUsuario.AsignarPermisosPorRol(idUsuario, usuario.Id_Rol);
             

                mensaje = "Usuario registrado correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error en el registro: " + ex.Message;
                return false;
            }
        }

        // Mi método para actualizar un usuario existente.
        public bool ActualizarUsuario(DtoPersona persona, DtoUsuario usuario, out string mensaje)
        {
            try
            {
                // Actualizo los datos de la persona
                CD_DaoPersona daoPersona = new CD_DaoPersona();
                bool resultadoPersona = daoPersona.ActualizarPersona(persona);

                if (!resultadoPersona)
                {
                    mensaje = "Error al actualizar los datos personales";
                    return false;
                }

                // Actualizo los datos del usuario
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

        // método para eliminar un usuario (realizando una baja lógica).
        public bool EliminarUsuario(int idUsuario, out string mensaje)
        {
            try
            {
                // Aplico una baja lógica, no física
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

        // método para listar usuarios con sus detalles (probablemente para una vista específica).
        public List<DtoUsuarioDetalle> ListarUsuarios()
        {
            try
            {
                return daoUsuario.ListarUsuariosDatos();
            }
            catch (Exception)
            {
                // En caso de error, devuelvo una lista vacía para evitar nulos
                return new List<DtoUsuarioDetalle>();
            }
        }

        //método para obtener un usuario por su ID.
        public DtoUsuarioDetalle ObtenerUsuario(int idUsuario)
        {
            try
            {
                return daoUsuario.ObtenerUsuarioPorId(idUsuario);
            }
            catch (Exception)
            {
                // En caso de error, devuelvo nulo
                return null;
            }
        }

        // método para validar si una nueva contraseña cumple con las políticas de seguridad.
        public bool ValidarNuevaContrasenaSegunPoliticas(string password, DtoDatosPersonalesPw usuario, out string mensaje)
        
        {
            mensaje = "";
            DtoConfiguracionSeguridad config = objConfigContra.ObtenerConfiguracion();

            if (config == null)
            {
                mensaje = "No pude cargar la configuración de seguridad de la contraseña.";
                return false;
            }

            // Valido las características mínimas (MinimoCaracteres, MayusMinus, NumLetra, Especial)
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


            // Valido que no se repitan contraseñas si la configuración lo indica
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

            // Valido que no contenga datos personales si la configuración lo indica
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

        //método para actualizar la contraseña de un usuario directamente (sin verificación de actual).
        public bool ActualizarContrasenaUsuario(string usuario, string nuevaContrasenaPlano)
        {
            string cadenaParaHash = usuario + nuevaContrasenaPlano;
            string nuevaContrasenaHash = ClsSeguridad.SHA256(cadenaParaHash);

            return objDaoUsuario.CambiarContraseña(usuario, nuevaContrasenaHash);
        }

        // método para obtener los datos personales y de contraseña de un usuario por su nombre.
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

        // método para obtener los días restantes para el cambio de contraseña de un usuario.
        public int ObtenerDiasRestantesCambioContrasena(int idUsuario)
        {
            // Obtengo la fecha del último cambio
            DateTime fechaUltimoCambio = daoUsuario.ObtenerFechaUltimoCambio(idUsuario);

            // Obtengo la frecuencia de cambio
            int cambiaCada = daoUsuario.ObtenerCambiaCada(idUsuario);

            if (cambiaCada <= 0)
            {
                return -1; // No aplica vencimiento (cambiaCada 0 o negativo significa ilimitado)
            }

            if (fechaUltimoCambio == DateTime.MinValue)
            {
                return 0; // No tiene fecha registrada → fuerzo el vencimiento
            }

            // Calculo la diferencia de días transcurridos desde el último cambio
            TimeSpan diferencia = DateTime.Now - fechaUltimoCambio;

            // Calculo los días restantes
            int diasRestantes = cambiaCada - (int)diferencia.TotalDays;

            return diasRestantes;
        }

        public DtoDatosPersonalesPw ObtenerUsuarioDetallePorDni(string dni)
        {
            try
            {
                return objDaoUsuario.ObtenerUsuarioPorDni(dni); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CL_Usuarios.ObtenerUsuarioDetallePorDni: {ex.Message}");
                throw;
            }
        }
        public bool ActualizarPrimeraClave(string usuario, bool primeraPass)
        {
            // Llama al método existente en la capa de datos
            // y le pasa el valor 'true' para marcar la contraseña como temporal.
            return daoUsuario.ActualizarPrimeraClave(usuario, primeraPass);
        }
       

        private readonly CD_DaoPregunta daoPregunta = new CD_DaoPregunta();

        public bool UsuarioTienePreguntasDeSeguridad(string nombreUsuario)
        {
            // Llama al método de la capa de datos para verificar si el usuario tiene preguntas configuradas.
            // Implementar este método en la clase de datos (CD_DaoPregunta).
            return daoPregunta.VerificarExistencia(nombreUsuario);
        }

        public int ObtenerIdRolUsuario()
        {
            // Obtenemos el objeto del usuario de la sesión actual
            DtoUsuario usuarioActual = ClsSesionActual.ObtenerUsuario();

            // Verificamos si el usuario no es nulo
            if (usuarioActual != null)
            {
                return usuarioActual.Id_Rol;
            }
            else
            {
                // Si el usuario es nulo, devolvemos un valor por defecto que indique un error o un rol desconocido
                return -1; // Por ejemplo, -1 para indicar que no se pudo obtener el rol
            }
        }



    }
}