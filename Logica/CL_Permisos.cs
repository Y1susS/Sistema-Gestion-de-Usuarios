//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Datos;       

//namespace Logica

//{
//    private CD_Permisos objCapaDatos;

//    public CL_Permisos()
//    {
//        objCapaDatos = new CD_Permisos();
//    }

//    public List<UsuarioGestion> ListarUsuariosGestionables()
//    {
//        try
//        {
//            // La lógica aquí es simplemente pasar la llamada a la capa de datos.
//            return objCapaDatos.ObtenerUsuariosParaGestionar();
//        }
//        catch (Exception ex)
//        {
//            // Manejo de errores: loguear, o relanzar una excepción más amigable para la vista
//            throw new Exception("Error en la capa de lógica al listar usuarios gestionables.", ex);
//        }
//    }

//    public List<PermisoUsuarioViewModel> ObtenerFuncionalidadesYPermisosDeUsuario(int idUsuario, int idRolUsuario)
//    {
//        List<PermisoUsuarioViewModel> permisosCompletos = new List<PermisoUsuarioViewModel>();

//        try
//        {
//            // 1. Obtener todas las funcionalidades/permisos posibles
//            List<PermisoFuncionalidad> todasFuncionalidades = objCapaDatos.ObtenerTodasLasFuncionalidades();

//            // 2. Obtener los permisos que el usuario tiene explícitamente asignados (tabla Usuario_Permiso)
//            List<int> permisosExplicitosUsuario = objCapaDatos.ObtenerPermisosExplicitosUsuario(idUsuario);

//            // 3. Obtener los permisos por defecto del rol del usuario (tabla Rol_Permiso)
//            List<int> permisosPorRol = objCapaDatos.ObtenerPermisosPorRol(idRolUsuario);

//            // 4. Combinar la información para la vista
//            foreach (var funcionalidad in todasFuncionalidades)
//            {
//                bool habilitadoPorRol = permisosPorRol.Contains(funcionalidad.IdPermiso);
//                bool habilitadoExplicitamente = permisosExplicitosUsuario.Contains(funcionalidad.IdPermiso);

//                // La columna 'Habilitado' en el DataGridView debe reflejar si el usuario *tiene* el permiso.
//                // Si está explícitamente asignado, o si lo tiene por su rol.
//                bool habilitadoActual = habilitadoExplicitamente || habilitadoPorRol;

//                permisosCompletos.Add(new PermisoUsuarioViewModel()
//                {
//                    IdPermiso = funcionalidad.IdPermiso,
//                    NombreFuncionalidad = funcionalidad.NombreFuncionalidad,
//                    Descripcion = funcionalidad.Descripcion,
//                    Habilitado = habilitadoActual,
//                    HabilitadoPorRol = habilitadoPorRol // Esto es solo para información, no afecta el Habilitado visible
//                });
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error en la capa de lógica al obtener permisos del usuario.", ex);
//        }
//        return permisosCompletos.OrderBy(p => p.NombreFuncionalidad).ToList();
//    }

//    public bool ActualizarEstadoPermisoUsuario(int idUsuario, int idPermiso, bool habilitar)
//    {
//        try
//        {
//            // Lógica de negocio: Insertar o Eliminar en Usuario_Permiso
//            if (habilitar)
//            {
//                // Si se habilita, insertamos el permiso explícito para el usuario
//                return objCapaDatos.InsertarUsuarioPermiso(idUsuario, idPermiso);
//            }
//            else
//            {
//                // Si se deshabilita, eliminamos el permiso explícito para el usuario
//                // Esto es crucial: si un permiso viene por ROL, y el administrador lo DESMARCA,
//                // significa que quiere REVOCAR ese permiso de forma explícita para ese usuario,
//                // incluso si su rol se lo daría.
//                return objCapaDatos.EliminarUsuarioPermiso(idUsuario, idPermiso);
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error en la capa de lógica al actualizar estado del permiso.", ex);
//        }
//    }
//}   
    





