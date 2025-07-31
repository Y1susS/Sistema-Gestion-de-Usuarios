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

        //método para cambiar la contraseña de un usuario existente.
        public bool CambiarContraseña(string usuario, string contraseñaActual, string nuevaContraseña, out string mensaje)
        {
            // Verifico si la contraseña actual es correcta
            string hashActual = ClsSeguridad.SHA256(usuario + contraseñaActual);

            if (!daoUsuario.VerificarContraseñaActual(usuario, hashActual))
            {
                mensaje = "La contraseña actual es incorrecta";
                return false;
            }

            // Valido que la nueva contraseña cumpla con políticas
            if (!ValidarPoliticasSeguridad(nuevaContraseña, usuario, out mensaje))
            {
                return false;
            }

            // Genero hash de la nueva contraseña
            string hashNueva = ClsSeguridad.SHA256(usuario + nuevaContraseña);

            // Verifico que no esté usando una contraseña reciente (si estoy logueado)
            if (ClsSesionActual.EstaLogueado())
            {
                if (daoPassUsada.VerificarPassUsada(ClsSesionActual.Usuario.Id_user, hashNueva))
                {
                    mensaje = "No puedo reutilizar una contraseña reciente";
                    return false;
                }

                // Actualizo la contraseña en la BD
                if (daoUsuario.CambiarContraseña(usuario, hashNueva))
                {
                    // Guardo en historial
                    daoPassUsada.AgregarPassUsada(ClsSesionActual.Usuario.Id_user, hashNueva);

                    // Actualizo el valor CambiaCada según la configuración actual
                    CL_ConfiguracionContraseña logicaConfig = new CL_ConfiguracionContraseña();
                    DtoConfiguracionContraseña config = logicaConfig.ObtenerConfiguracion();
                    if (config != null)
                    {
                        daoUsuario.ActualizarCambiaCada(usuario, config.DiasCambioPassword);
                    }

                    // Si es primera contraseña, actualizo el estado en sesión
                    if (ClsSesionActual.Usuario.PrimeraPass)
                    {
                        ClsSesionActual.Usuario.PrimeraPass = false;
                    }

                    mensaje = "Contraseña cambiada exitosamente";
                    return true;
                }
            }
            else
            {
                // Si no estoy logueado (caso recuperación de contraseña)
                if (daoUsuario.CambiarContraseña(usuario, hashNueva))
                {
                    CL_ConfiguracionContraseña logicaConfig = new CL_ConfiguracionContraseña();
                    DtoConfiguracionContraseña config = logicaConfig.ObtenerConfiguracion();
                    if (config != null)
                    {
                        daoUsuario.ActualizarCambiaCada(usuario, config.DiasCambioPassword);
                    }

                    mensaje = "Contraseña cambiada exitosamente";
                    return true;
                }
            }

            mensaje = "Error al cambiar la contraseña";
            return false;
        }

       

        // método privado para validar las políticas de seguridad de la contraseña.
        private bool ValidarPoliticasSeguridad(string contraseña, string usuario, out string mensaje)
        {
            int minLength = 8;
            bool requireUppercase = true;
            bool requireNumbers = true;
            bool requireSpecialChar = true;

            // Valido la longitud mínima
            if (contraseña.Length < minLength)
            {
                mensaje = $"La contraseña debe tener al menos {minLength} caracteres";
                return false;
            }

            // Valido mayúsculas
            if (requireUppercase && !contraseña.Any(char.IsUpper))
            {
                mensaje = "La contraseña debe contener al menos una letra mayúscula";
                return false;
            }

            // Valido números
            if (requireNumbers && !contraseña.Any(char.IsDigit))
            {
                mensaje = "La contraseña debe contener al menos un número";
                return false;
            }

            // Valido caracteres especiales
            if (requireSpecialChar && contraseña.All(c => char.IsLetterOrDigit(c)))
            {
                mensaje = "La contraseña debe contener al menos un carácter especial";
                return false;
            }

            // Valido que no contenga datos del usuario
            if (contraseña.ToLower().Contains(usuario.ToLower()))
            {
                mensaje = "La contraseña no puede contener tu nombre de usuario";
                return false;
            }

            mensaje = "Contraseña válida";
            return true;
        }

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
            DtoConfiguracionContraseña config = objConfigContra.ObtenerConfiguracion();

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
            string nuevaContrasenaHash = ClsSeguridad.SHA256(nuevaContrasenaPlano);
            bool exito = objDaoUsuario.CambiarContraseña(usuario, nuevaContrasenaHash);

            if (exito)
            {
                // Si la actualización es exitosa, la guardo en el historial si es necesario
                // y actualizo la fecha de cambio en la base de datos.
            }
            return exito;
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

        // NUEVO MÉTODO PARA LA GESTIÓN DE USUARIOS
        // método para obtener la lista de usuarios optimizada para la pantalla de gestión.
        public List<CD_UsuarioGestion> ListarUsuariosParaGestion()
        {
            try
            {
                // Aquí puedo añadir lógica de negocio adicional si la necesito antes de devolver la lista
                return daoUsuario.ListarUsuariosParaGestion(); // Llamo al método de mi capa de datos
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar usuarios para gestión desde la capa de negocio: " + ex.Message, ex);
            }
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
    }
}