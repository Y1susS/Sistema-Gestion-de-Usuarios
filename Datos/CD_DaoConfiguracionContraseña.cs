using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoConfiguracionSeguridad
    {
        public List<DtoConfiguracionContraseña> ObtenerConfiguracionesContras()
        {
            List<DtoConfiguracionContraseña> listaConfiguraciones = new List<DtoConfiguracionContraseña>();
            CD_Conexion conexion = new CD_Conexion();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ListarConfiguracionesSeguridad", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                DtoConfiguracionContraseña config = new DtoConfiguracionContraseña();
                                config.Id = Convert.ToInt32(dr["Id"]);
                                config.MinimoCaracteres = Convert.ToInt32(dr["MinimoCaracteres"]);
                                config.RequiereMayusMinus = Convert.ToBoolean(dr["RequiereMayusMinus"]);
                                config.RequiereNumLetra = Convert.ToBoolean(dr["RequiereNumLetra"]);
                                config.RequiereEspecial = Convert.ToBoolean(dr["RequiereEspecial"]);
                                config.EvitarRepetidas = Convert.ToBoolean(dr["EvitarRepetidas"]);
                                config.EvitarDatosPersonales = Convert.ToBoolean(dr["EvitarDatosPersonales"]);
                                config.DiasCambioPassword = dr["DiasCambioPassword"] != DBNull.Value ? Convert.ToInt32(dr["DiasCambioPassword"]) : 0;

                                listaConfiguraciones.Add(config);
                            }
                        }
                    }
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }

            return listaConfiguraciones;
        }
        public bool GuardarConfiguracionContras(DtoConfiguracionContraseña dto)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlConnection conn = null;
            try
            {
                conn = conexion.AbrirConexion();

                using (SqlCommand cmd = new SqlCommand("sp_GuardarConfiguracionSeguridad", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", dto.Id);
                    cmd.Parameters.AddWithValue("@MinimoCaracteres", dto.MinimoCaracteres);
                    cmd.Parameters.AddWithValue("@RequiereMayusMinus", dto.RequiereMayusMinus);
                    cmd.Parameters.AddWithValue("@RequiereNumLetra", dto.RequiereNumLetra);
                    cmd.Parameters.AddWithValue("@RequiereEspecial", dto.RequiereEspecial);
                    cmd.Parameters.AddWithValue("@EvitarRepetidas", dto.EvitarRepetidas);
                    cmd.Parameters.AddWithValue("@EvitarDatosPersonales", dto.EvitarDatosPersonales);
                    cmd.Parameters.AddWithValue("@DiasCambioPassword", dto.DiasCambioPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {

                            int result = reader.GetInt32(reader.GetOrdinal("Result"));

                            return result == 1;
                        }
                    }
                    return false;
                }
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conexion.CerrarConexion();
                }
            }
        }
    }
}

