//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;
//using Datos;

//namespace Datos
//{
//    public class CD_Permisos
//    {
//        // Instancia de tu clase de conexión
//        private CD_Conexion objConexion;

//        public CD_Permisos()
//        {
//            objConexion = new CD_Conexion(); // Se inicializa la instancia de CD_Conexion
//        }

//        public List<UsuarioGestion> ObtenerUsuariosParaGestionar()
//        {
//            List<UsuarioGestion> listaUsuarios = new List<UsuarioGestion>();
//            SqlConnection conn = null; // Declarar SqlConnection aquí

//            try
//            {
//                conn = objConexion.AbrirConexion(); // Obtener la conexión abierta
//                SqlCommand cmd = new SqlCommand("sp_ListarUsuariosConRol", conn);
//                cmd.CommandType = CommandType.StoredProcedure;

//                using (SqlDataReader dr = cmd.ExecuteReader())
//                {
//                    while (dr.Read())
//                    {
//                        listaUsuarios.Add(new UsuarioGestion()
//                        {
//                            IdUsuario = Convert.ToInt32(dr["Id_user"]),
//                            NombreUsuario = dr["User"].ToString(),
//                            NombreCompleto = $"{dr["Nombre"]} {dr["Apellido"]}",
//                            IdRol = Convert.ToInt32(dr["Id_Rol"]),
//                            NombreRol = dr["NombreRol"].ToString()
//                        });
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error al obtener usuarios: " + ex.Message);
//                throw new Exception("Error en la capa de datos al obtener usuarios.", ex);
//            }
//            finally
//            {
//                if (conn != null) // Asegurarse de que la conexión fue abierta antes de intentar cerrarla
//                {
//                    objConexion.CerrarConexion(); // Cierra la conexión usando el método de CD_Conexion
//                }
//            }
//            return listaUsuarios;
//        }

//        public List<PermisoFuncionalidad> ObtenerTodasLasFuncionalidades()
//        {
//            List<PermisoFuncionalidad> listaFuncionalidades = new List<PermisoFuncionalidad>();
//            SqlConnection conn = null;

//            try
//            {
//                conn = objConexion.AbrirConexion();
//                SqlCommand cmd = new SqlCommand("sp_ListarTodasLasFuncionalidades", conn);
//                cmd.CommandType = CommandType.StoredProcedure;

//                using (SqlDataReader dr = cmd.ExecuteReader())
//                {
//                    while (dr.Read())
//                    {
//                        listaFuncionalidades.Add(new PermisoFuncionalidad()
//                        {
//                            IdPermiso = Convert.ToInt32(dr["Id_Permiso"]),
//                            NombreFuncionalidad = dr["NombreFuncionalidad"].ToString(),
//                            Descripcion = dr["Descripcion"].ToString()
//                        });
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error al obtener funcionalidades: " + ex.Message);
//                throw new Exception("Error en la capa de datos al obtener funcionalidades.", ex);
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    objConexion.CerrarConexion();
//                }
//            }
//            return listaFuncionalidades;
//        }

//        public List<int> ObtenerPermisosExplicitosUsuario(int idUsuario)
//        {
//            List<int> permisos = new List<int>();
//            SqlConnection conn = null;

//            try
//            {
//                conn = objConexion.AbrirConexion();
//                SqlCommand cmd = new SqlCommand("sp_ObtenerPermisosExplicitosUsuario", conn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@Id_User", idUsuario);

//                using (SqlDataReader dr = cmd.ExecuteReader())
//                {
//                    while (dr.Read())
//                    {
//                        permisos.Add(Convert.ToInt32(dr["Id_Permiso"]));
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al obtener permisos explícitos para el usuario {idUsuario}: {ex.Message}");
//                throw new Exception($"Error en la capa de datos al obtener permisos explícitos para usuario {idUsuario}.", ex);
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    objConexion.CerrarConexion();
//                }
//            }
//            return permisos;
//        }

//        public List<int> ObtenerPermisosPorRol(int idRol)
//        {
//            List<int> permisos = new List<int>();
//            SqlConnection conn = null;

//            try
//            {
//                conn = objConexion.AbrirConexion();
//                SqlCommand cmd = new SqlCommand("sp_ObtenerPermisosPorRol", conn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@Id_Rol", idRol);

//                using (SqlDataReader dr = cmd.ExecuteReader())
//                {
//                    while (dr.Read())
//                    {
//                        permisos.Add(Convert.ToInt32(dr["Id_Permiso"]));
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al obtener permisos por rol {idRol}: {ex.Message}");
//                throw new Exception($"Error en la capa de datos al obtener permisos por rol {idRol}.", ex);
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    objConexion.CerrarConexion();
//                }
//            }
//            return permisos;
//        }

//        public bool InsertarUsuarioPermiso(int idUsuario, int idPermiso)
//        {
//            SqlConnection conn = null;

//            try
//            {
//                conn = objConexion.AbrirConexion();
//                SqlCommand cmd = new SqlCommand("sp_InsertarUsuarioPermiso", conn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@Id_User", idUsuario);
//                cmd.Parameters.AddWithValue("@Id_Permiso", idPermiso);

//                cmd.ExecuteNonQuery();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al insertar permiso {idPermiso} para usuario {idUsuario}: {ex.Message}");
//                throw new Exception($"Error en la capa de datos al insertar permiso {idPermiso} para usuario {idUsuario}.", ex);
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    objConexion.CerrarConexion();
//                }
//            }
//        }

//        public bool EliminarUsuarioPermiso(int idUsuario, int idPermiso)
//        {
//            SqlConnection conn = null;

//            try
//            {
//                conn = objConexion.AbrirConexion();
//                SqlCommand cmd = new SqlCommand("sp_EliminarUsuarioPermiso", conn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@Id_User", idUsuario);
//                cmd.Parameters.AddWithValue("@Id_Permiso", idPermiso);

//                cmd.ExecuteNonQuery();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al eliminar permiso {idPermiso} para usuario {idUsuario}: {ex.Message}");
//                throw new Exception($"Error en la capa de datos al eliminar permiso {idPermiso} para usuario {idUsuario}.", ex);
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    objConexion.CerrarConexion();
//                }
//            }
//        }
//    }

//}


