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

        public bool CambiarPrimeraContrase�a(string nombreUsuarioStr, string nuevaContrase�a, out string mensaje) // Renombrado 'usuario' a 'nombreUsuarioStr' por claridad
        {
            DtoDatosPersonalesPw usuarioCompleto = daoUsuario.ObtenerUsuarioDetallePorNombre(nombreUsuarioStr);

            if (usuarioCompleto == null)
            {
                mensaje = "No se pudieron obtener los datos personales del usuario para validar las pol�ticas de seguridad.";
                return false;
            }
            if (!ValidarNuevaContrasenaSegunPoliticas(nuevaContrase�a, usuarioCompleto, out mensaje))
            {
                return false;
            }
            string hashNuevo = ClsSeguridad.SHA256(nombreUsuarioStr + nuevaContrase�a); 

            if (daoUsuario.CambiarContrase�a(nombreUsuarioStr, hashNuevo))
            {
                daoUsuario.ActualizarPrimeraClave(nombreUsuarioStr, false); 

                if (ClsSesionActual.EstaLogueado())
                {
                    daoPassUsada.AgregarPassUsada(usuarioCompleto.Id_user, hashNuevo);
                }

                if (ClsSesionActual.EstaLogueado() && ClsSesionActual.Usuario.User == nombreUsuarioStr)
                {
                    ClsSesionActual.Usuario.PrimeraPass = false;
                }

                mensaje = "Contrase�a cambiada exitosamente";
                return true;
            }

            mensaje = "Error al cambiar la contrase�a";
            return false;
        }


        public bool CambiarContrase�a(string usuario, string contrase�aActual, string nuevaContrase�a, out string mensaje)
        {
            // 1. Verificar si la contrase�a actual es correcta
            string hashActual = ClsSeguridad.SHA256(usuario + contrase�aActual);

            if (!daoUsuario.VerificarContrase�aActual(usuario, hashActual))
            {
                mensaje = "La contrase�a actual es incorrecta";
                return false;
            }

            // 2. Validar que la nueva contrase�a cumpla con pol�ticas
            if (!ValidarPoliticasSeguridad(nuevaContrase�a, usuario, out mensaje))
            {
                return false;
            }

            // 3. Generar hash de la nueva contrase�a
            string hashNueva = ClsSeguridad.SHA256(usuario + nuevaContrase�a);

            // 4. Verificar que no est� usando una contrase�a reciente (si est� logueado)
            if (ClsSesionActual.EstaLogueado())
            {
                if (daoPassUsada.VerificarPassUsada(ClsSesionActual.Usuario.Id_user, hashNueva))
                {
                    mensaje = "No puedes reutilizar una contrase�a reciente";
                    return false;
                }

                // 5. Actualizar la contrase�a en la BD
                if (daoUsuario.CambiarContrase�a(usuario, hashNueva))
                {
                    // 6. Guardar en historial
                    daoPassUsada.AgregarPassUsada(ClsSesionActual.Usuario.Id_user, hashNueva);

                    // 7. Si es primera contrase�a, actualizar estado en sesi�n
                    if (ClsSesionActual.Usuario.PrimeraPass)
                    {
                        ClsSesionActual.Usuario.PrimeraPass = false;
                    }

                    mensaje = "Contrase�a cambiada exitosamente";
                    return true;
                }
            }
            else
            {
                // Si no est� logueado (caso recuperaci�n contrase�a)
                if (daoUsuario.CambiarContrase�a(usuario, hashNueva))
                {
                    mensaje = "Contrase�a cambiada exitosamente";
                    return true;
                }
            }

            mensaje = "Error al cambiar la contrase�a";
            return false;
        }

        private bool ValidarPoliticasSeguridad(string contrase�a, string usuario, out string mensaje)
        {
            // Estas validaciones podr�an venir de tabla Restriccion en BD
            int minLength = 8;
            bool requireUppercase = true;
            bool requireNumbers = true;
            bool requireSpecialChar = true;

            // Validar longitud m�nima
            if (contrase�a.Length < minLength)
            {
                mensaje = $"La contrase�a debe tener al menos {minLength} caracteres";
                return false;
            }

            // Validar may�sculas
            if (requireUppercase && !contrase�a.Any(char.IsUpper))
            {
                mensaje = "La contrase�a debe contener al menos una letra may�scula";
                return false;
            }

            // Validar n�meros
            if (requireNumbers && !contrase�a.Any(char.IsDigit))
            {
                mensaje = "La contrase�a debe contener al menos un n�mero";
                return false;
            }

            // Validar caracteres especiales
            if (requireSpecialChar && contrase�a.All(c => char.IsLetterOrDigit(c)))
            {
                mensaje = "La contrase�a debe contener al menos un car�cter especial";
                return false;
            }

            // Validar que no contenga datos del usuario
            if (contrase�a.ToLower().Contains(usuario.ToLower()))
            {
                mensaje = "La contrase�a no puede contener tu nombre de usuario";
                return false;
            }

            mensaje = "Contrase�a v�lida";
            return true;
        }

        public bool RegistrarUsuario(DtoPersona persona, DtoUsuario usuario, string contrasenaPlana, out string mensaje)
        {
            try
            {
                // 1. Validar que no exista un usuario con el mismo nombre
                if (daoUsuario.ExisteUsuario(usuario.User))
                {
                    mensaje = "El nombre de usuario ya est� en uso";
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
                usuario.Password = ClsSeguridad.SHA256(usuario.User + contrasenaPlana); // Concatenar usuario y contrase�a, luego encriptar
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
                mensaje = "Error en la actualizaci�n: " + ex.Message;
                return false;
            }
        }

        public bool EliminarUsuario(int idUsuario, out string mensaje)
        {
            try
            {
                // Aplicamos una baja l�gica, no f�sica
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
        private CL_ConfiguracionContrase�a objConfigContra = new CL_ConfiguracionContrase�a();

        public bool ValidarNuevaContrasenaSegunPoliticas(string password, DtoDatosPersonalesPw usuario, out string mensaje)
        {
            mensaje = "";
            DtoConfiguracionContrase�a config = objConfigContra.ObtenerConfiguracion();

            if (config == null)
            {
                mensaje = "No se pudo cargar la configuraci�n de seguridad de la contrase�a.";
                return false;
            }

            // Validaciones(MinimoCaracteres, MayusMinus, NumLetra, Especial)
            if (config.MinimoCaracteres > 0 && password.Length < config.MinimoCaracteres)
            {
                mensaje = $"La contrase�a debe tener al menos {config.MinimoCaracteres} caracteres.";
                return false;
            }
            if (config.RequiereMayusMinus && !(password.Any(char.IsUpper) && password.Any(char.IsLower)))
            {
                mensaje = "La contrase�a debe contener may�sculas y min�sculas.";
                return false;
            }
            if (config.RequiereNumLetra && !(password.Any(char.IsDigit) && password.Any(char.IsLetter)))
            {
                mensaje = "La contrase�a debe contener letras y n�meros.";
                return false;
            }
            if (config.RequiereEspecial && !password.Any(ch => "!@#$%^&*()-_+=[]{}|;:,.<>?".Contains(ch)))
            {
                mensaje = "La contrase�a debe contener al menos un car�cter especial.";
                return false;
            }


            // Validaciones que requieren datos del usuario o historial
            if (config.EvitarRepetidas)
            {
                List<DtoHistorialContrase�a> historial = objDaoUsuario.ObtenerPasswordsUsadas(usuario.Id_user);

                foreach (var item in historial)
                {
                    if (ClsSeguridad.VerificarHash(password, item.Password))
                    {
                        mensaje = "La contrase�a ya ha sido utilizada anteriormente. Por favor, elija una nueva.";
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
                    mensaje = "La contrase�a no puede contener partes de su nombre.";
                    return false;
                }
                if (!string.IsNullOrEmpty(apellidoLimpio) && passwordLower.Contains(apellidoLimpio))
                {
                    mensaje = "La contrase�a no puede contener partes de su apellido.";
                    return false;
                }
                if (!string.IsNullOrEmpty(documentoLimpio) && passwordLower.Contains(documentoLimpio))
                {
                    mensaje = "La contrase�a no puede contener partes de su documento.";
                    return false;
                }
                if (!string.IsNullOrEmpty(emailLimpio) && passwordLower.Contains(emailLimpio))
                {
                    mensaje = "La contrase�a no puede contener partes de su email.";
                    return false;
                }
            }

            mensaje = "Contrase�a v�lida.";
            return true;
        }

        public bool ActualizarContrasenaUsuario(string usuario, string nuevaContrasenaPlano)
        {
            string nuevaContrasenaHash = ClsSeguridad.SHA256(nuevaContrasenaPlano);
            bool exito = objDaoUsuario.CambiarContrase�a(usuario, nuevaContrasenaHash);

            if (exito)
            {
                objDaoUsuario.CambiarContrase�a(usuario, nuevaContrasenaHash);
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
    }
}
    
