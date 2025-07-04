﻿using System;
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
                    SqlCommand cmd = new SqlCommand("UPDATE Usuario SET PrimeraPass = @PrimeraPass WHERE [User] = @User", conn);
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
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT FechaUltimoCambio FROM Usuario WHERE Id_user = @Id_user", conn);
                    cmd.Parameters.AddWithValue("@Id_user", idUsuario);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        fechaUltimoCambio = Convert.ToDateTime(result);
                    }
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
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT CambiaCada FROM Usuario WHERE Id_user = @Id_user", conn);
                    cmd.Parameters.AddWithValue("@Id_user", idUsuario);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        diasCambiaCada = Convert.ToInt32(result);
                    }
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Usuario WHERE [User] = @User", conn);
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
                    SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Activo = 0, FechaBaja = GETDATE() WHERE Id_user = @Id_user", conn);
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
                                Apellido = dr.GetString(5),
                                Nombre = dr.GetString(6),
                                Id_TipoDocumento = dr.GetString(7),
                                NroDocumento = dr.GetString(8),
                                Email = dr.GetString(9),
                                Calle = dr.IsDBNull(10) ? string.Empty : dr.GetString(10),
                                Nro = dr.IsDBNull(11) ? 0 : dr.GetInt32(11),
                                Piso = dr.IsDBNull(12) ? string.Empty : dr.GetString(12),
                                Depto = dr.IsDBNull(13) ? string.Empty : dr.GetString(13),
                                Id_Localidad = dr.GetInt32(14),
                                Localidad = dr.GetString(15),
                                Id_Partido = dr.GetInt32(16),
                                Partido = dr.GetString(17),
                                Telefono = dr.IsDBNull(18) ? string.Empty : dr.GetString(18)
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

    }
}
