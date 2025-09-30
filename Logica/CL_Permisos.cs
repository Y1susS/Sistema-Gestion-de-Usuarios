using System;
using System.Collections.Generic;
using System.Linq;
using Datos;          
using Entidades.DTOs; 
namespace Logica
{
    public class CL_Permisos
    {
        private CD_Permisos _datosPermisos;

        public CL_Permisos()
        {
            _datosPermisos = new CD_Permisos();
        }

        public List<DtoRol> ObtenerRolesDelSistema() 
        {
            try
            {
                return _datosPermisos.ListarRolesDelSistema();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica al obtener roles del sistema: " + ex.Message);
            }
        }

        public List<CD_UsuarioGestion> ObtenerUsuariosParaGestionar() 
        {
            try
            {
                return _datosPermisos.ObtenerUsuariosParaGestionar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica al obtener usuarios para gestionar: " + ex.Message);
            }
        }

        // Este método se usa para cargar la grilla de permisos de usuario.
        // Ya está recibiendo CD_PermisoFuncionalidad, que es lo que devuelve el SP modificado.
        // La lógica de si está habilitado por rol o explícitamente YA ESTÁ EN EL SP.
        // No hay necesidad de procesar los permisos por rol aquí.
        public List<DtoPermisoUsuario> CargarPermisosDeUsuario(int idUsuario) // <-- Cambiamos el tipo de retorno
        {
            try
            {
                // Esto ahora llama al método corregido en la capa de Datos

                return _datosPermisos.ObtenerPermisosExplicitosUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa logica al cargar permisos de usuario para display: " + ex.Message);
            }
        }

        // ***** MÉTODO PARA EL BOTÓN GUARDAR *****
        // Recibe la lista completa de permisos del DataGridView, que ya contiene el estado 'Habilitado' modificado.
        public bool GuardarPermisosDeUsuario(int idUsuario, List<DtoPermisoUsuario> permisosActualesDGV)

        {
            try
            {
                foreach (var permisoFuncionalidad in permisosActualesDGV)
                {
                    // Llamamos al método de la capa de datos.
                    // Si hay un problema en un permiso individual, GuardarPermisoExplicitoUsuario
                    // debería lanzar una excepción, que será capturada por el catch de este método.
                    _datosPermisos.GuardarPermisoExplicitoUsuario(idUsuario, permisoFuncionalidad.IdFuncionalidad, permisoFuncionalidad.Habilitado);

                }
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa logica al guardar los permisos del usuario: " + ex.Message, ex);
            }
        }


        public List<CD_PermisoUsuarioViewModel> ObtenerFuncionalidadesYPermisosDeRol(int idRol)
        {
            // 1. Llama al método corregido, que ahora devuelve List<DtoPermisoUsuario>
            List<DtoPermisoUsuario> todasFuncionalidades = _datosPermisos.ObtenerTodasLasFuncionalidades();

            List<int> permisosDelRol = _datosPermisos.ObtenerPermisosPorRol(idRol);

            // 2. Mantenemos el ViewModel (CD_PermisoUsuarioViewModel) para la lógica de Rol, pero la fuente de datos ahora usa 'Nombre'.
            List<CD_PermisoUsuarioViewModel> permisosViewModel = new List<CD_PermisoUsuarioViewModel>();

            foreach (var funcionalidad in todasFuncionalidades)
            {
                permisosViewModel.Add(new CD_PermisoUsuarioViewModel
                {
                    IdPermiso = funcionalidad.IdFuncionalidad,

                    // CORRECCIÓN: Asignamos funcionalidad.Nombre (el nombre corto) a NombreFuncionalidad del ViewModel
                    NombreFuncionalidad = funcionalidad.Nombre,

                    Descripcion = funcionalidad.Descripcion,
                    Habilitado = permisosDelRol.Contains(funcionalidad.IdFuncionalidad),
                    HabilitadoPorRol = permisosDelRol.Contains(funcionalidad.IdFuncionalidad)
                });
            }
            return permisosViewModel;
        }

        public bool ActualizarPermisosDeRol(int idRol, List<CD_PermisoUsuarioViewModel> permisosActualizados)
        {
            bool exitoGeneral = true;
            try
            {
                List<int> permisosActualesDelRol = _datosPermisos.ObtenerPermisosPorRol(idRol);

                foreach (var permisoVM in permisosActualizados)
                {
                    bool estabaHabilitado = permisosActualesDelRol.Contains(permisoVM.IdPermiso);

                    if (permisoVM.Habilitado && !estabaHabilitado)
                    {
                        if (!_datosPermisos.InsertarRolPermiso(idRol, permisoVM.IdPermiso))
                        {
                            exitoGeneral = false;
                        }
                    }
                    else if (!permisoVM.Habilitado && estabaHabilitado)
                    {
                        if (!_datosPermisos.EliminarRolPermiso(idRol, permisoVM.IdPermiso))
                        {
                            exitoGeneral = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica al actualizar permisos de rol: " + ex.Message);
            }
            return exitoGeneral;
        }

        public bool ActualizarEstadoPermisoUsuario(int idUsuario, int idPermiso, bool habilitado)
        {
            try
            {
                return _datosPermisos.GuardarPermisoExplicitoUsuario(idUsuario, idPermiso, habilitado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica al actualizar el estado explícito del permiso del usuario: " + ex.Message);
            }
        }

        public List<CD_UsuarioGestion> ObtenerTodosLosUsuariosParaGestionComboBox()
        {
            try
            {
                List<CD_UsuarioGestion> usuarios = _datosPermisos.ObtenerUsuariosParaGestionar();
                return usuarios.OrderBy(u => u.NombreUsuario).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica al obtener usuarios para ComboBox: " + ex.Message);
            }
        }
    }
}