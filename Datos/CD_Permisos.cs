using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Entidades.DTOs;

namespace Datos
{
    public class CD_Permisos
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

            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
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

        public List<CD_PermisoFuncionalidad> ObtenerTodasLasFuncionalidades()
        {
            List<CD_PermisoFuncionalidad> lista = new List<CD_PermisoFuncionalidad>();

            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerTodasLasFuncionalidades", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CD_PermisoFuncionalidad()
                            {
                                // AQUI: El SP ObtenerTodasLasFuncionalidades devuelve 'IdPermiso' (sin guion bajo)
                                // Asegúrate de que el SP 'sp_ObtenerTodasLasFuncionalidades' también devuelva 'IdPermiso'
                                // o ajusta esta línea si devuelve 'Id_Permiso'.
                                IdPermiso = Convert.ToInt32(dr["IdPermiso"]),
                                NombreFuncionalidad = dr["NombreFuncionalidad"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Habilitado = false
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<CD_PermisoFuncionalidad>();
                    throw new Exception("Error en la capa de datos al obtener todas las funcionalidades: " + ex.Message);
                }
            }
            return lista;
        }

        public List<CD_PermisoFuncionalidad> ObtenerPermisosExplicitosUsuario(int idUsuario)
        {
            List<CD_PermisoFuncionalidad> listaPermisos = new List<CD_PermisoFuncionalidad>();

            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
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
                            listaPermisos.Add(new CD_PermisoFuncionalidad()
                            {
                                // ***** CORRECCIÓN CLAVE AQUÍ *****
                                // El SP devuelve 'IdPermiso' (sin guion bajo) debido al alias 'AS IdPermiso'.
                                // Por lo tanto, el DataReader debe buscar 'IdPermiso'.
                                IdPermiso = Convert.ToInt32(dr["IdPermiso"]),
                                NombreFuncionalidad = dr["NombreFuncionalidad"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Habilitado = Convert.ToBoolean(dr["Habilitado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaPermisos = new List<CD_PermisoFuncionalidad>();
                    throw new Exception("Error en la capa de datos al obtener permisos explicitos de usuario: " + ex.Message);
                }
            }
            return listaPermisos;
        }

        public List<int> ObtenerPermisosPorRol(int idRol)
        {
            List<int> listaIds = new List<int>();

            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
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
            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
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

            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
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

            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
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

            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
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

            CD_Conexion cnx = new CD_Conexion();
            using (SqlConnection oConexion = cnx.AbrirConexion())
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
    }
}