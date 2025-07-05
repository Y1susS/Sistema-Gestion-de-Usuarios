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

        public bool CambiarPrimeraContrase�a(string usuario, string nuevaContrase�a, out string mensaje)
        {
            // Validar pol�ticas de seguridad para la nueva contrase�a
            if (!ValidarPoliticasSeguridad(nuevaContrase�a, usuario, out mensaje))
            {
                return false;
            }

            // Generar el hash de la nueva contrase�a
            string hashNuevo = ClsSeguridad.SHA256(usuario + nuevaContrase�a);

            // Cambiar la contrase�a en la base de datos
            if (daoUsuario.CambiarContrase�a(usuario, hashNuevo))
            {
                // Actualizar el estado de PrimeraPass en la base de datos
                daoUsuario.ActualizarPrimeraClave(usuario, false);
                
                // Guardar en historial de contrase�as usadas
                if (ClsSesionActual.EstaLogueado())
                {
                    daoPassUsada.AgregarPassUsada(ClsSesionActual.Usuario.Id_user, hashNuevo);
                }
                
                // Si el usuario est� en sesi�n, actualizar su estado
                if (ClsSesionActual.EstaLogueado() && ClsSesionActual.Usuario.User == usuario)
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
    }
}