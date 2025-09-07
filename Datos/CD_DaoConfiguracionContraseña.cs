﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entidades.DTOs;

namespace Datos
{
    public class CD_DaoConfiguracionSeguridad : CD_Conexion
    {
        public List<DtoConfiguracionContraseña> ObtenerConfiguracionesContras()
        {
            List<DtoConfiguracionContraseña> listaConfiguraciones = new List<DtoConfiguracionContraseña>();
            using (SqlConnection conn = AbrirConexion())
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
                    CerrarConexion();
                }
            }

            return listaConfiguraciones;
        }
        public bool GuardarConfiguracionContras(DtoConfiguracionContraseña dto)
        {
            SqlConnection conn = null;
            try
            {
                conn = AbrirConexion();

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
                    CerrarConexion();
                }
            }
        }
    }
}

