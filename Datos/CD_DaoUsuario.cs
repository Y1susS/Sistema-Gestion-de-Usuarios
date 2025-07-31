using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesion.Entidades;

namespace Datos
{
    public class CD_DaoUsuario
    {
        public DtoUsuario ValidarUsuario(string usuario, string password)
        {
            CD_Conexion conexion = new CD_Conexion();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", usuario);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return new DtoUsuario
                        {
                            Id_user = dr.GetInt32(0),
                            User = dr.GetString(1),
                            Activo = dr.GetBoolean(2),
                            Id_Rol = dr.GetInt32(3),
                            PrimeraPass = dr.GetBoolean(4)
                        };
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            return null;
        }

        public bool VerificarContraseñaActual(string usuario, string password)
        {
            CD_Conexion conexion = new CD_Conexion();
            bool resultado = false;

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VerificaPassActual", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", usuario);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();
                    resultado = (result != null && result != DBNull.Value);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return resultado;
        }

        public bool CambiarContraseña(string usuario, string nuevaPassword)
        {
            CD_Conexion conexion = new CD_Conexion();
            bool resultado = false;

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_CambiarPassword", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", usuario);
                    cmd.Parameters.AddWithValue("@NuevaPassword", nuevaPassword);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return resultado;
        }

        public bool ActualizarPrimeraClave(string usuario, bool primeraPass)
        {
            CD_Conexion conexion = new CD_Conexion();
            bool resultado = false;

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarPrimeraClave", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", usuario);
                    cmd.Parameters.AddWithValue("@PrimeraPass", primeraPass);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return resultado;
        }

        public DateTime ObtenerFechaUltimoCambio(int idUsuario)
        {
            CD_Conexion conexion = new CD_Conexion();
            DateTime fechaUltimoCambio = DateTime.MinValue;

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerFechaUltimoCambio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_user", idUsuario);

                try
                {

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        fechaUltimoCambio = Convert.ToDateTime(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener la fecha del último cambio de contraseña " + ex.Message);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return fechaUltimoCambio;
        }

        public int ObtenerCambiaCada(int idUsuario)
        {
            CD_Conexion conexion = new CD_Conexion();
            int diasCambiaCada = 0;

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerCambiaCada", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_user", idUsuario);

                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        diasCambiaCada = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener 'CambiaCada' desde SP: " + ex.Message);

                }

                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return diasCambiaCada;
        }

        public int AgregarUsuario(DtoUsuario usuario)
        {
            int idUsuario = 0;
            CD_Conexion conexion = new CD_Conexion();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@User", usuario.User);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@Activo", usuario.Activo);
                    cmd.Parameters.AddWithValue("@PrimeraPass", usuario.PrimeraPass);
                    cmd.Parameters.AddWithValue("@Id_Rol", usuario.Id_Rol);
                    cmd.Parameters.AddWithValue("@Id_Persona", usuario.Id_Persona);
                    cmd.Parameters.AddWithValue("@Intentos", 0);
                    cmd.Parameters.AddWithValue("@CambiaCada", 90); // Por defecto, cambiar cada 90 días
                    cmd.Parameters.AddWithValue("@FechaUltimoCambio", DateTime.Now);

                    SqlParameter paramId = new SqlParameter("@Id_user", SqlDbType.Int);
                    paramId.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramId);

                    cmd.ExecuteNonQuery();

                    if (paramId.Value != DBNull.Value)
                    {
                        idUsuario = Convert.ToInt32(paramId.Value);
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return idUsuario;
        }

        public bool ActualizarUsuario(DtoUsuario usuario)
        {
            bool resultado = false;
            CD_Conexion conexion = new CD_Conexion();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_user", usuario.Id_user);
                    cmd.Parameters.AddWithValue("@User", usuario.User);
                    cmd.Parameters.AddWithValue("@Activo", usuario.Activo);
                    cmd.Parameters.AddWithValue("@Id_Rol", usuario.Id_Rol);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return resultado;
        }

        public bool ExisteUsuario(string usuario)
        {
            bool resultado = false;
            CD_Conexion conexion = new CD_Conexion();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ExisteUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@User", usuario);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    resultado = count > 0;
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return resultado;
        }

        public bool BajaUsuario(int idUsuario)
        {
            bool resultado = false;
            CD_Conexion conexion = new CD_Conexion();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BajaUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_user", idUsuario);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return resultado;
        }

        public List<DtoUsuarioDetalle> ListarUsuariosDatos()
        {
            List<DtoUsuarioDetalle> usuarios = new List<DtoUsuarioDetalle>();
            CD_Conexion conexion = new CD_Conexion();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarUsuariosDatos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DtoUsuarioDetalle usuario = new DtoUsuarioDetalle
                            {
                                Id_user = dr.GetInt32(0),
                                User = dr.GetString(1),
                                Activo = dr.GetBoolean(2),
                                Rol = dr.GetString(3),
                                Apellido = dr.GetString(4),
                                Nombre = dr.GetString(5),
                                Id_TipoDocumento = dr.GetString(6),
                                NroDocumento = dr.GetString(7),
                                Email = dr.GetString(8),
                                Calle = dr.IsDBNull(9) ? string.Empty : dr.GetString(9),
                                Nro = dr.IsDBNull(10) ? 0 : dr.GetInt32(10),
                                Piso = dr.IsDBNull(11) ? string.Empty : dr.GetString(11),
                                Depto = dr.IsDBNull(12) ? string.Empty : dr.GetString(12),
                                Localidad = dr.GetString(13),
                                Partido = dr.GetString(14),
                                Telefono = dr.IsDBNull(15) ? string.Empty : dr.GetString(15)
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return usuarios;
        }

        public DtoUsuarioDetalle ObtenerUsuarioPorId(int idUsuario)
        {
            DtoUsuarioDetalle usuario = null;
            CD_Conexion conexion = new CD_Conexion();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioPorId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_user", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new DtoUsuarioDetalle
                            {
                                Id_user = dr.GetInt32(0),
                                User = dr.GetString(1),
                                Activo = dr.GetBoolean(2),
                                Id_Rol = dr.GetInt32(3),
                                Rol = dr.GetString(4),
                                Id_Persona = dr.GetInt32(5),
                                Apellido = dr.GetString(6),
                                Nombre = dr.GetString(7),
                                Id_TipoDocumento = dr.GetString(8),
                                NroDocumento = dr.GetString(9),
                                Email = dr.GetString(10),
                                Calle = dr.IsDBNull(11) ? string.Empty : dr.GetString(11),
                                Nro = dr.IsDBNull(12) ? 0 : dr.GetInt32(12),
                                Piso = dr.IsDBNull(13) ? string.Empty : dr.GetString(13),
                                Depto = dr.IsDBNull(14) ? string.Empty : dr.GetString(14),
                                Id_Localidad = dr.GetInt32(15),
                                Localidad = dr.GetString(16),
                                Id_Partido = dr.GetInt32(17),
                                Partido = dr.GetString(18),
                                Telefono = dr.IsDBNull(19) ? string.Empty : dr.GetString(19)
                            };
                        }
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return usuario;
        }
        public DtoDatosPersonalesPw ObtenerUsuarioDetallePorNombre(string nombreUsuario)
        {
            DtoDatosPersonalesPw usuario = null;
            CD_Conexion conexion = new CD_Conexion();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioDetallePorNombre", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new DtoDatosPersonalesPw
                            {
                                Id_user = dr.GetInt32(dr.GetOrdinal("Id_user")),
                                User = dr.GetString(dr.GetOrdinal("User")),
                                Apellido = dr.GetString(dr.GetOrdinal("Apellido")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                NroDocumento = dr.GetString(dr.GetOrdinal("NroDocumento")),
                                Email = dr.GetString(dr.GetOrdinal("Email")),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en CD_DaoUsuarios.ObtenerUsuarioDetallePorNombre: {ex.Message}");
                    throw;
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            return usuario;
        }

        public DtoUsuario ObtenerUsuarioPorNombre(string usuario)
        {
            CD_Conexion conexion = new CD_Conexion();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioPorNombre", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", usuario);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return new DtoUsuario
                        {
                            Id_user = dr.GetInt32(dr.GetOrdinal("Id_user")),
                            User = dr.GetString(dr.GetOrdinal("User")),
                            Password = dr.GetString(dr.GetOrdinal("Password")),
                            Activo = dr.GetBoolean(dr.GetOrdinal("Activo")),
                            Id_Rol = dr.GetInt32(dr.GetOrdinal("Id_Rol")),
                            PrimeraPass = dr.GetBoolean(dr.GetOrdinal("PrimeraPass")),
                            FechaBaja = dr.IsDBNull(dr.GetOrdinal("FechaBaja")) ? (DateTime?)null : dr.GetDateTime(dr.GetOrdinal("FechaBaja"))
                        };
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            return null;
        }

        public bool VerificarParametrosRecupero(string NroDocumento, int Id_Pregunta, string Respuesta)
        {
            CD_Conexion conexion = new CD_Conexion();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_VerificarRecuperoRespuesta";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NroDocumento", NroDocumento);
            comando.Parameters.AddWithValue("@IdPregunta", Id_Pregunta);
            comando.Parameters.AddWithValue("@Respuesta", Respuesta);

            int resultado = Convert.ToInt32(comando.ExecuteScalar());

            conexion.CerrarConexion();

            if (resultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DtoHistorialContraseña> ObtenerPasswordsUsadas(int idUsuario)
        {
            List<DtoHistorialContraseña> lista = new List<DtoHistorialContraseña>();
            CD_Conexion conexion = new CD_Conexion();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerPasswordsUsadas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_User", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoHistorialContraseña
                            {
                                Password = dr["Password"].ToString(),
                                FechaCambio = Convert.ToDateTime(dr["FechaCambio"])
                            });
                        }
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return lista;
        }

        public void ActualizarCambiaCada(string nombreUsuario, int dias)
        {
            CD_Conexion conexion = new CD_Conexion();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarCambiaCada", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Dias", dias);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DtoDatosPersonalesPw ObtenerUsuarioPorDni(string dni)
        {
            DtoDatosPersonalesPw usuarioEncontrado = null;


            CD_Conexion conexion = new CD_Conexion();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ObtenerUsuarioPorDni", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NroDocumento", dni);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuarioEncontrado = new DtoDatosPersonalesPw
                            {
                                Id_user = dr.GetInt32(dr.GetOrdinal("Id_user")),
                                User = dr.GetString(dr.GetOrdinal("User")),
                                Apellido = dr.GetString(dr.GetOrdinal("Apellido")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                NroDocumento = dr.GetString(dr.GetOrdinal("NroDocumento")),
                                Email = dr.GetString(dr.GetOrdinal("Email"))
                            };
                        }

                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error SQL en ObtenerUsuarioPorDni: {ex.Message}");
                    throw new Exception("Error de base de datos al obtener información del usuario por DNI.", ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error general en ObtenerUsuarioPorDni: {ex.Message}");
                    throw new Exception("Error inesperado al obtener información del usuario por DNI.", ex);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
          return usuarioEncontrado;
        }

        
    }
}

