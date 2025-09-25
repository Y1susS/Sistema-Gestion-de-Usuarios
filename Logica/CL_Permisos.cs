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

        public List<CD_PermisoFuncionalidad> CargarPermisosDeUsuario(int idUsuario)
        {
            try
            {
                return _datosPermisos.ObtenerPermisosExplicitosUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa logica al cargar permisos de usuario para display: " + ex.Message);
            }
        }

        public bool GuardarPermisosDeUsuario(int idUsuario, List<CD_PermisoFuncionalidad> permisosActualesDGV)
        {
            try
            {
                foreach (var permisoFuncionalidad in permisosActualesDGV)
                {
                    _datosPermisos.GuardarPermisoExplicitoUsuario(idUsuario, permisoFuncionalidad.IdPermiso, permisoFuncionalidad.Habilitado);
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