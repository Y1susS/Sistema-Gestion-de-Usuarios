using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoLocalidad : CD_Conexion
    {
        public CD_DaoLocalidad() : base()
        {
        }

        public List<DtoLocalidad> ListarLocalidades()
        {
            List<DtoLocalidad> lista = new List<DtoLocalidad>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarLocalidades", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoLocalidad
                            {
                                Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]),
                                Localidad = dr["Localidad"].ToString(),
                                Id_Partido = Convert.ToInt32(dr["Id_Partido"]),
                                Partido = dr["Partido"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar localidades: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        // MÉTODO AGREGADO: Filtrar localidades por partido
        public List<DtoLocalidad> ListarLocalidadesPorPartido(int idPartido)
        {
            List<DtoLocalidad> lista = new List<DtoLocalidad>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_FiltrarLocalidadxPartido", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtroPartido", idPartido);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DtoLocalidad
                            {
                                Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]),
                                Localidad = dr["Localidad"].ToString(),
                                Id_Partido = idPartido, // Ya sabemos el ID del partido
                                Partido = "" // No viene en este SP, pero no es necesario para ComboBox
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar localidades por partido: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public DtoLocalidad ObtenerLocalidadPorId(int idLocalidad)
        {
            DtoLocalidad localidad = null;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerLocalidadPorId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Localidad", idLocalidad);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            localidad = new DtoLocalidad
                            {
                                Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]),
                                Localidad = dr["Localidad"].ToString(),
                                Id_Partido = Convert.ToInt32(dr["Id_Partido"]),
                                Partido = dr["Partido"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener localidad: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return localidad;
        }

        public bool ExisteLocalidad(int idLocalidad)
        {
            bool existe = false;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ExisteLocalidad", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Localidad", idLocalidad);

                    SqlParameter paramExiste = new SqlParameter("@Existe", SqlDbType.Bit);
                    paramExiste.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramExiste);

                    cmd.ExecuteNonQuery();

                    existe = Convert.ToBoolean(paramExiste.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar existencia de localidad: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return existe;
        }
    }
}