using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Sesion;
using Sesion.Entidades;

namespace Logica
{
    public class CL_Usuarios
    {
        private readonly CD_DaoUsuario daoUsuario = new CD_DaoUsuario();
        private readonly CD_DaoPassUsada daoPassUsada = new CD_DaoPassUsada();

        public bool CambiarPrimeraContraseña(string usuario, string nuevaContraseña, out string mensaje)
        {
            // Validar políticas de seguridad para la nueva contraseña
            if (!ValidarPoliticasSeguridad(nuevaContraseña, usuario, out mensaje))
            {
                return false;
            }

            // Generar el hash de la nueva contraseña
            string hashNuevo = ClsSeguridad.SHA256(usuario + nuevaContraseña);

            // Cambiar la contraseña en la base de datos
            if (daoUsuario.CambiarContraseña(usuario, hashNuevo))
            {
                // Actualizar el estado de PrimeraPass en la base de datos
                daoUsuario.ActualizarPrimeraClave(usuario, false);
                
                // Guardar en historial de contraseñas usadas
                if (ClsSesionActual.EstaLogueado())
                {
                    daoPassUsada.AgregarPassUsada(ClsSesionActual.Usuario.Id_user, hashNuevo);
                }
                
                // Si el usuario está en sesión, actualizar su estado
                if (ClsSesionActual.EstaLogueado() && ClsSesionActual.Usuario.User == usuario)
                {
                    ClsSesionActual.Usuario.PrimeraPass = false;
                }

                mensaje = "Contraseña cambiada exitosamente";
                return true;
            }

            mensaje = "Error al cambiar la contraseña";
            return false;
        }

        public bool CambiarContraseña(string usuario, string contraseñaActual, string nuevaContraseña, out string mensaje)
        {
            // 1. Verificar si la contraseña actual es correcta
            string hashActual = ClsSeguridad.SHA256(usuario + contraseñaActual);
            
            if (!daoUsuario.VerificarContraseñaActual(usuario, hashActual))
            {
                mensaje = "La contraseña actual es incorrecta";
                return false;
            }
            
            // 2. Validar que la nueva contraseña cumpla con políticas
            if (!ValidarPoliticasSeguridad(nuevaContraseña, usuario, out mensaje))
            {
                return false;
            }
            
            // 3. Generar hash de la nueva contraseña
            string hashNueva = ClsSeguridad.SHA256(usuario + nuevaContraseña);
            
            // 4. Verificar que no esté usando una contraseña reciente (si está logueado)
            if (ClsSesionActual.EstaLogueado())
            {
                if (daoPassUsada.VerificarPassUsada(ClsSesionActual.Usuario.Id_user, hashNueva))
                {
                    mensaje = "No puedes reutilizar una contraseña reciente";
                    return false;
                }
                
                // 5. Actualizar la contraseña en la BD
                if (daoUsuario.CambiarContraseña(usuario, hashNueva))
                {
                    // 6. Guardar en historial
                    daoPassUsada.AgregarPassUsada(ClsSesionActual.Usuario.Id_user, hashNueva);
                    
                    // 7. Si es primera contraseña, actualizar estado en sesión
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
                // Si no está logueado (caso recuperación contraseña)
                if (daoUsuario.CambiarContraseña(usuario, hashNueva))
                {
                    mensaje = "Contraseña cambiada exitosamente";
                    return true;
                }
            }
            
            mensaje = "Error al cambiar la contraseña";
            return false;
        }

        private bool ValidarPoliticasSeguridad(string contraseña, string usuario, out string mensaje)
        {
            // Estas validaciones podrían venir de tabla Restriccion en BD
            int minLength = 8;
            bool requireUppercase = true;
            bool requireNumbers = true;
            bool requireSpecialChar = true;
            
            // Validar longitud mínima
            if (contraseña.Length < minLength)
            {
                mensaje = $"La contraseña debe tener al menos {minLength} caracteres";
                return false;
            }
            
            // Validar mayúsculas
            if (requireUppercase && !contraseña.Any(char.IsUpper))
            {
                mensaje = "La contraseña debe contener al menos una letra mayúscula";
                return false;
            }
            
            // Validar números
            if (requireNumbers && !contraseña.Any(char.IsDigit))
            {
                mensaje = "La contraseña debe contener al menos un número";
                return false;
            }
            
            // Validar caracteres especiales
            if (requireSpecialChar && contraseña.All(c => char.IsLetterOrDigit(c)))
            {
                mensaje = "La contraseña debe contener al menos un carácter especial";
                return false;
            }
            
            // Validar que no contenga datos del usuario
            if (contraseña.ToLower().Contains(usuario.ToLower()))
            {
                mensaje = "La contraseña no puede contener tu nombre de usuario";
                return false;
            }
            
            mensaje = "Contraseña válida";
            return true;
        }

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
    }
}