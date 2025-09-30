using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Entidades.DTOs;

namespace Datos
{
    public class CD_Permisos : CD_Conexion
    {
        // El constructor está vacío porque no hay campos de clase que inicializar
        public CD_Permisos()
        {
            // No hay necesidad de inicializar oCnx aquí, ya que se creará localmente en cada método.
        }

        public List<DtoRol> ListarRolesDelSistema()
        {
            var daoRol = new CD_DaoRol(); // Asumo que CD_DaoRol se encarga de su propia conexión
            return daoRol.ListarRoles();
        }

        public List<CD_UsuarioGestion> ObtenerUsuariosParaGestionar()
        {
            List<CD_UsuarioGestion> lista = new List<CD_UsuarioGestion>();

            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuariosParaGestion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CD_UsuarioGestion()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                NombreUsuario = dr["UserName"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                NombreRol = dr["NombreRol"].ToString(),
                                Activo = Convert.ToBoolean(dr["Activo"]),
                                Usuario = dr["UserName"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<CD_UsuarioGestion>();
                    throw new Exception("Error en la capa de datos al obtener usuarios para gestionar: " + ex.Message);
                }
            }
            return lista;
        }

        public List<DtoPermisoUsuario> ObtenerTodasLasFuncionalidades()
        {
            // 1. Cambiamos el tipo de lista a DtoPermisoUsuario
            List<DtoPermisoUsuario> lista = new List<DtoPermisoUsuario>();


            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerTodasLasFuncionalidades", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // 2. Instanciamos el DtoPermisoUsuario de la capa de Entidades
                            lista.Add(new DtoPermisoUsuario()
                            {
                                // AQUI: Mapeamos al DTO final. 
                                // IdFuncionalidad es la propiedad de la clase base DtoFuncionalidad.
                                IdFuncionalidad = Convert.ToInt32(dr["IdPermiso"]),

                                // CORRECCIÓN CLAVE: Mapeamos el nombre corto a la propiedad 'Nombre' del DTO.
                                Nombre = dr["Nombre"].ToString(),

                                // Mapeamos la descripción larga.
                                Descripcion = dr["Descripcion"].ToString(),

                                // Propiedad específica de DtoPermisoUsuario, inicializada a false.
                                Habilitado = false
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<DtoPermisoUsuario>();
                    throw new Exception("Error en la capa de datos al obtener todas las funcionalidades: " + ex.Message);
                }
            }
            return lista;
        }

        public List<DtoPermisoUsuario> ObtenerPermisosExplicitosUsuario(int idUsuario) // <-- Cambiamos el tipo de retorno
        {
            List<DtoPermisoUsuario> listaPermisos = new List<DtoPermisoUsuario>(); // <-- Cambiamos la lista

            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPermisosExplicitosUsuario", oConexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaPermisos.Add(new DtoPermisoUsuario() // <-- Instanciamos el DTO de Entidades
                            {
                                // Mapeamos a las propiedades del DTO base (DtoFuncionalidad)
                                IdFuncionalidad = Convert.ToInt32(dr["IdPermiso"]),

                                // CORRECCIÓN CLAVE: Mapeamos el nombre corto a la propiedad 'Nombre'.
                                Nombre = dr["Nombre"].ToString(),

                                Descripcion = dr["Descripcion"].ToString(),
                                Habilitado = Convert.ToBoolean(dr["Habilitado"]) // Propiedad específica
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaPermisos = new List<DtoPermisoUsuario>();
                    throw new Exception("Error en la capa de datos al obtener permisos explicitos de usuario: " + ex.Message);
                }
            }
            return listaPermisos;
        }

        public List<int> ObtenerPermisosPorRol(int idRol)
        {
            List<int> listaIds = new List<int>();

            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPermisosPorRolIds", oConexion);
                cmd.Parameters.AddWithValue("@IdRol", idRol);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaIds.Add(Convert.ToInt32(dr["Id_Permiso"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaIds = new List<int>();
                    throw new Exception("Error en la capa de datos al obtener permisos por rol: " + ex.Message);
                }
            }
            return listaIds;
        }

        public bool GuardarPermisoExplicitoUsuario(int idUsuario, int idPermiso, bool habilitado)
        {
            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_UpsertUsuarioPermiso", oConexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@IdPermiso", idPermiso);
                cmd.Parameters.AddWithValue("@Habilitado", habilitado);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    // Ejecutamos el Stored Procedure.
                    // No importa el valor de filasAfectadas para el retorno de este método,
                    // ya que el SP maneja la lógica de UPSERT: si ya está en el estado deseado,
                    // no hace nada, pero la operación lógica es 'exitosa'.
                    cmd.ExecuteNonQuery();

                    // Si llegamos aquí sin excepción, la operación fue lógicamente exitosa.
                    return true;
                }
                catch (Exception ex)
                {
                    // Si hay una excepción de la base de datos, la relanzamos para que la capa superior la maneje.
                    throw new Exception("Error en la capa de datos al guardar/actualizar permiso explícito de usuario: " + ex.Message, ex);
                    // También podrías simplemente retornar false aquí si tu lógica de manejo de errores lo prefiere.
                    // return false;
                }
            }
        }

        public bool InsertarUsuarioPermiso(int idUsuario, int idPermiso)
        {
            bool resultado = false;

            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarUsuarioPermiso", oConexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@IdPermiso", idPermiso);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la capa de datos al insertar permiso de usuario: " + ex.Message);
                }
            }
            return resultado;
        }

        public bool EliminarUsuarioPermiso(int idUsuario, int idPermiso)
        {
            bool resultado = false;

            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarUsuarioPermiso", oConexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@IdPermiso", idPermiso);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la capa de datos al eliminar permiso de usuario: " + ex.Message);
                }
            }
            return resultado;
        }

        public bool InsertarRolPermiso(int idRol, int idPermiso)
        {
            bool resultado = false;

            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarRolPermiso", oConexion);
                cmd.Parameters.AddWithValue("@IdRol", idRol);
                cmd.Parameters.AddWithValue("@IdPermiso", idPermiso);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la capa de datos al insertar permiso de rol: " + ex.Message);
                }
            }
            return resultado;
        }

        public bool EliminarRolPermiso(int idRol, int idPermiso)
        {
            bool resultado = false;

            using (SqlConnection oConexion = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarRolPermiso", oConexion);
                cmd.Parameters.AddWithValue("@IdRol", idRol);
                cmd.Parameters.AddWithValue("@IdPermiso", idPermiso);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la capa de datos al eliminar permiso de rol: " + ex.Message);
                }
            }
            return resultado;
        }
        public bool GuardarPermisosDeUsuarioEnLote(int idUsuario, List<DtoPermisoUsuario> permisosACambiar)
        {
            // Usamos TransactionScope para asegurar que todas las operaciones se completen o ninguna lo haga.
            // Aunque usas un solo SP para el UPSERT, una transacción simple es una buena práctica.
            using (SqlConnection oConexion = AbrirConexion())
            {
                try
                {
                    oConexion.Open(); // Abre la conexión aquí para toda la operación
                    SqlTransaction transaction = oConexion.BeginTransaction();

                    SqlCommand cmd = new SqlCommand("sp_UpsertUsuarioPermiso", oConexion, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Creamos los parámetros fuera del bucle, solo actualizamos sus valores.
                    SqlParameter pIdUsuario = cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    SqlParameter pIdPermiso = cmd.Parameters.Add("@IdPermiso", SqlDbType.Int);
                    SqlParameter pHabilitado = cmd.Parameters.Add("@Habilitado", SqlDbType.Bit);

                    foreach (var permiso in permisosACambiar)
                    {
                        // Actualiza los parámetros para el permiso actual.
                        pIdPermiso.Value = permiso.IdFuncionalidad;
                        pHabilitado.Value = permiso.Habilitado;

                        // Ejecuta la operación para el permiso explícito (UPSERT).
                        cmd.ExecuteNonQuery();
                    }

                    // Si todo fue bien, hacemos Commit de la transacción.
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Si algo falla, la excepción se lanza y la transacción se revierte automáticamente (o debes manejarlo explícitamente con transaction.Rollback()).
                    // Por simplicidad, solo lanzamos la excepción.
                    throw new Exception("Error en la capa de datos al guardar permisos del usuario: " + ex.Message, ex);
                }
                // La conexión se cerrará automáticamente con el 'using' al salir del bloque.
            }
        }
    }
}