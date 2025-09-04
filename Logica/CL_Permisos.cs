using System;
using System.Collections.Generic;
using System.Linq;
using Datos;          // Asegúrate de que CD_Permisos, CD_PermisoFuncionalidad, CD_UsuarioGestion estén aquí
using Entidades.DTOs; // Asegúrate de que DtoRol esté aquí
// Si CD_PermisoUsuarioViewModel está en Datos, asegúrate de que 'using Datos;' lo cubra,
// o agrega 'using Vistas.ViewModels;' si tienes una carpeta ViewModels para esto.

namespace Logica
{
    public class CL_Permisos
    {
        private CD_Permisos _datosPermisos;

        public CL_Permisos()
        {
            // Se inicializa en el constructor para asegurar que siempre haya una instancia.
            _datosPermisos = new CD_Permisos();
        }

        public List<DtoRol> ObtenerRolesDelSistema() // Renombrado para mayor claridad
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

        public List<CD_UsuarioGestion> ObtenerUsuariosParaGestionar() // Renombrado para mayor claridad
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
        public List<CD_PermisoFuncionalidad> CargarPermisosDeUsuario(int idUsuario)
        {
            try
            {
                // El SP sp_ObtenerPermisosExplicitosUsuario ahora devuelve directamente
                // todas las funcionalidades con su estado 'Habilitado' ya calculado.
                return _datosPermisos.ObtenerPermisosExplicitosUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa logica al cargar permisos de usuario para display: " + ex.Message);
            }
        }

        // ***** MÉTODO PARA EL BOTÓN GUARDAR *****
        // Recibe la lista completa de permisos del DataGridView, que ya contiene el estado 'Habilitado' modificado.
        public bool GuardarPermisosDeUsuario(int idUsuario, List<CD_PermisoFuncionalidad> permisosActualesDGV)
        {
            // Asumimos que la operación general será exitosa a menos que una excepción ocurra.
            // Esto es coherente con la idea de que el SP de UPSERT maneja el estado deseado.
            try
            {
                foreach (var permisoFuncionalidad in permisosActualesDGV)
                {
                    // Llamamos al método de la capa de datos.
                    // Si hay un problema en un permiso individual, GuardarPermisoExplicitoUsuario
                    // debería lanzar una excepción, que será capturada por el catch de este método.
                    _datosPermisos.GuardarPermisoExplicitoUsuario(idUsuario, permisoFuncionalidad.IdPermiso, permisoFuncionalidad.Habilitado);
                }
                return true; // Si llegamos aquí sin lanzar una excepción, todo fue exitoso.
            }
            catch (Exception ex)
            {
                // Si hay una excepción durante el procesamiento de algún permiso, la relanzamos
                // para que la capa de presentación (UI) la capture y muestre un mensaje de error.
                throw new Exception("Error en la capa logica al guardar los permisos del usuario: " + ex.Message, ex);
                // Si no quieres relanzar la excepción y solo devolver false:
                // return false;
            }
        }

        // Este método ya no es necesario si 'CargarPermisosDeUsuario' hace lo mismo.
        // Lo he eliminado para evitar duplicidades y mantener la consistencia.
        // public List<CD_PermisoFuncionalidad> ObtenerFuncionalidadesYPermisosDeUsuarioParaDisplay(int idUsuario) { ... }

        public List<CD_PermisoUsuarioViewModel> ObtenerFuncionalidadesYPermisosDeRol(int idRol)
        {
            List<CD_PermisoFuncionalidad> todasFuncionalidades = _datosPermisos.ObtenerTodasLasFuncionalidades();
            List<int> permisosDelRol = _datosPermisos.ObtenerPermisosPorRol(idRol);

            List<CD_PermisoUsuarioViewModel> permisosViewModel = new List<CD_PermisoUsuarioViewModel>();

            foreach (var funcionalidad in todasFuncionalidades)
            {
                permisosViewModel.Add(new CD_PermisoUsuarioViewModel
                {
                    IdPermiso = funcionalidad.IdPermiso,
                    NombreFuncionalidad = funcionalidad.NombreFuncionalidad,
                    Descripcion = funcionalidad.Descripcion,
                    Habilitado = permisosDelRol.Contains(funcionalidad.IdPermiso),
                    HabilitadoPorRol = permisosDelRol.Contains(funcionalidad.IdPermiso)
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

        // Este método se mantiene por si se usa en otro lugar, pero la lógica de guardado
        // para un permiso individual es manejada por GuardarPermisosDeUsuario en lote.
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