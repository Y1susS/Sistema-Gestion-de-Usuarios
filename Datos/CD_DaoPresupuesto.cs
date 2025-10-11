using Entidades;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_DaoPresupuesto : CD_Conexion
    {

        public List<DtoPresupuestoFiltro> FiltrarPresupuestos(
            string descripcion,
            DateTime? fechaValidez,
            string vendedor,
            string documentoCliente)
        {
            List<DtoPresupuestoFiltro> lista = new List<DtoPresupuestoFiltro>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_FiltrarPresupuestos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 1. Agregar Parámetros de Entrada (usando DBNull.Value para NULL)
                    cmd.Parameters.AddWithValue("@DescripcionPresupuesto", descripcion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaValidez", fechaValidez.HasValue ? fechaValidez.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NombreVendedor", vendedor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NroDocumentoCliente", documentoCliente ?? (object)DBNull.Value);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DtoPresupuestoFiltro dto = new DtoPresupuestoFiltro();

                            // 2. Mapeo al DTO de Filtro (solo 6 campos)
                            dto.IdPresupuesto = Convert.ToInt32(dr["Id_Presupuesto"]);
                            dto.NumeroPresupuesto = dr["NumeroPresupuesto"].ToString();
                            dto.Observaciones = dr["Observaciones"].ToString();

                            // Campos que vienen del JOIN y son calculados
                            dto.ClienteNombreCompleto = dr["ClienteNombreCompleto"].ToString();
                            dto.EstadoPresupuesto = dr["EstadoPresupuesto"].ToString();

                            dto.FechaValidez = Convert.ToDateTime(dr["FechaValidez"]);
                            dto.MontoFinal = Convert.ToDecimal(dr["MontoFinal"]);

                            lista.Add(dto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Lanza una excepción con la original
                    throw new Exception("Error al filtrar presupuestos desde la base de datos.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }
        public Presupuesto ObtenerEncabezado(int idPresupuesto)
        {
            Presupuesto presupuesto = null;

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    // O un SELECT directo con JOINS a Cliente y Persona
                    SqlCommand cmd = new SqlCommand("sp_ObtenerPresupuestoEncabezado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPresupuesto", idPresupuesto);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            presupuesto = new Presupuesto();

                            // Mapeo de DtoDocumentoComercial
                            presupuesto.Id = Convert.ToInt32(dr["Id_Presupuesto"]); 
                            presupuesto.Numero = dr["Numero"].ToString();
                            presupuesto.Fecha = Convert.ToDateTime(dr["FechaCreacion"]);
                            presupuesto.MontoTotal = Convert.ToDecimal(dr["MontoTotal"]);
                            presupuesto.Descuento = Convert.ToDecimal(dr["Descuento"]);
                            presupuesto.MontoFinal = Convert.ToDecimal(dr["MontoFinal"]);
                            presupuesto.Observaciones = dr["Observaciones"].ToString();
                            presupuesto.Activo = Convert.ToBoolean(dr["Activo"]);

                            // Mapeo de Presupuesto
                            presupuesto.IdPresupuesto = presupuesto.Id;
                            presupuesto.IdCliente = Convert.ToInt32(dr["Id_Cliente"]);
                            presupuesto.IdUser = Convert.ToInt32(dr["Id_User"]);
                            presupuesto.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                            presupuesto.FechaValidez = dr.IsDBNull(dr.GetOrdinal("FechaValidez")) ? (DateTime?)null : Convert.ToDateTime(dr["FechaValidez"]);
                            presupuesto.IdEstadoPresupuesto = Convert.ToInt32(dr["Id_EstadoPresupuesto"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el encabezado del presupuesto.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return presupuesto;
        }
        public List<DtoPresupuestoDetalle> ObtenerDetalles(int idPresupuesto)
        {
            List<DtoPresupuestoDetalle> detalles = new List<DtoPresupuestoDetalle>();

            using (SqlConnection conn = AbrirConexion())
            {
                try
                {
                    // Este SP debe hacer JOIN entre PresupuestoCotizacion y Cotizacion
                    SqlCommand cmd = new SqlCommand("sp_ObtenerPresupuestoDetalles", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPresupuesto", idPresupuesto);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DtoPresupuestoDetalle detalle = new DtoPresupuestoDetalle();

                            // Mapeo de la tabla PresupuestoCotizacion (con datos del JOIN a Cotizacion)
                            // Asumo que el SP trae 'Id_Cotizacion', 'Cantidad', 'PrecioUnitario' y 'DescripcionMueble'
                            detalle.IdCotizacion = Convert.ToInt32(dr["Id_Cotizacion"]);
                            detalle.NumeroCotizacion = dr["NumeroCotizacion"].ToString(); // Viene de la tabla Cotizacion
                            detalle.DescripcionMueble = dr["DescripcionMueble"].ToString(); // Viene de la tabla Cotizacion
                            detalle.PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]);
                            detalle.Cantidad = Convert.ToInt32(dr["Cantidad"]);

                            detalles.Add(detalle);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los detalles del presupuesto.", ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return detalles;
        }
    }
}






    //    public int InsertarPresupuesto(Presupuesto presupuesto)
    //    {
    //        using (SqlConnection conn = AbrirConexion())
    //        {
    //            string query = @"
    //                INSERT INTO Presupuesto 
    //                (Id_Cliente, Id_User, FechaCreacion, NumeroPresupuesto, FechaValidez,
    //                 MontoTotal, Descuento, MontoFinal, Id_EstadoPresupuesto, Observaciones, Activo)
    //                VALUES 
    //                (@IdCliente, @IdUser, @FechaCreacion, @NumeroPresupuesto, @FechaValidez,
    //                 @MontoTotal, @Descuento, @MontoFinal, @IdEstado, @Observaciones, @Activo);
    //                SELECT SCOPE_IDENTITY();";

    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            cmd.Parameters.AddWithValue("@IdCliente", (object)presupuesto.Id_Cliente ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@IdUser", (object)presupuesto.Id_User ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@FechaCreacion", presupuesto.FechaCreacion ?? DateTime.Now);
    //            cmd.Parameters.AddWithValue("@NumeroPresupuesto", (object)presupuesto.NumeroPresupuesto ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@FechaValidez", (object)presupuesto.FechaValidez ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@MontoTotal", (object)presupuesto.MontoTotal ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@Descuento", (object)presupuesto.Descuento ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@MontoFinal", (object)presupuesto.MontoFinal ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@IdEstado", presupuesto.Id_EstadoPresupuesto);
    //            cmd.Parameters.AddWithValue("@Observaciones", (object)presupuesto.Observaciones ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@Activo", presupuesto.Activo);

    //            conn.Open();
    //            int idPresupuesto = Convert.ToInt32(cmd.ExecuteScalar());
    //            return idPresupuesto;
    //        }
    //    }

    //    public bool ActualizarPresupuesto(Presupuesto presupuesto)
    //    {
    //        using (SqlConnection conn = AbrirConexion())
    //        {
    //            string query = @"
    //                UPDATE Presupuesto SET
    //                    Id_Cliente = @IdCliente,
    //                    FechaValidez = @FechaValidez,
    //                    MontoTotal = @MontoTotal,
    //                    Descuento = @Descuento,
    //                    MontoFinal = @MontoFinal,
    //                    Id_EstadoPresupuesto = @IdEstado,
    //                    Observaciones = @Observaciones
    //                WHERE Id_Presupuesto = @Id";

    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            cmd.Parameters.AddWithValue("@Id", presupuesto.Id_Presupuesto);
    //            cmd.Parameters.AddWithValue("@IdCliente", (object)presupuesto.Id_Cliente ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@FechaValidez", (object)presupuesto.FechaValidez ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@MontoTotal", (object)presupuesto.MontoTotal ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@Descuento", (object)presupuesto.Descuento ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@MontoFinal", (object)presupuesto.MontoFinal ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@IdEstado", presupuesto.Id_EstadoPresupuesto);
    //            cmd.Parameters.AddWithValue("@Observaciones", (object)presupuesto.Observaciones ?? DBNull.Value);

    //            conn.Open();
    //            int filasAfectadas = cmd.ExecuteNonQuery();
    //            return filasAfectadas > 0;
    //        }
    //    }

    //    public Presupuesto ObtenerPresupuestoPorId(int idPresupuesto)
    //    {
    //        Presupuesto presupuesto = null;

    //        using (SqlConnection conn = AbrirConexion())
    //        {
    //            string query = @"
    //                SELECT p.*, c.Nombre + ' ' + c.Apellido AS NombreCliente,
    //                       e.Estado AS EstadoDescripcion
    //                FROM Presupuesto p
    //                LEFT JOIN Cliente c ON p.Id_Cliente = c.Id_Cliente
    //                LEFT JOIN EstadoPresupuesto e ON p.Id_EstadoPresupuesto = e.Id_EstadoPresupuesto
    //                WHERE p.Id_Presupuesto = @Id";

    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            cmd.Parameters.AddWithValue("@Id", idPresupuesto);
    //            conn.Open();

    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                if (reader.Read())
    //                {
    //                    presupuesto = MapearPresupuesto(reader);
    //                }
    //            }
    //        }

    //        return presupuesto;
    //    }

    //    public string GenerarNumeroPresupuesto()
    //    {
    //        using (SqlConnection conn = AbrirConexion())
    //        {
    //            string query = @"
    //                SELECT ISNULL(MAX(CAST(SUBSTRING(NumeroPresupuesto, 3, LEN(NumeroPresupuesto)) AS INT)), 0) + 1
    //                FROM Presupuesto
    //                WHERE NumeroPresupuesto LIKE 'PR%'";

    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            conn.Open();

    //            int numero = Convert.ToInt32(cmd.ExecuteScalar());
    //            return $"PR{numero:D6}";
    //        }
    //    }

    //    private Presupuesto MapearPresupuesto(SqlDataReader reader)
    //    {
    //        return new Presupuesto
    //        {
    //            Id_Presupuesto = Convert.ToInt32(reader["Id_Presupuesto"]),
    //            Id_Cliente = reader["Id_Cliente"] != DBNull.Value ? Convert.ToInt32(reader["Id_Cliente"]) : (int?)null,
    //            Id_User = reader["Id_User"] != DBNull.Value ? Convert.ToInt32(reader["Id_User"]) : (int?)null,
    //            FechaCreacion = reader["FechaCreacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaCreacion"]) : (DateTime?)null,
    //            NumeroPresupuesto = reader["NumeroPresupuesto"]?.ToString(),
    //            FechaValidez = reader["FechaValidez"] != DBNull.Value ? Convert.ToDateTime(reader["FechaValidez"]) : (DateTime?)null,
    //            MontoTotal = reader["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(reader["MontoTotal"]) : (decimal?)null,
    //            Descuento = reader["Descuento"] != DBNull.Value ? Convert.ToDecimal(reader["Descuento"]) : (decimal?)null,
    //            MontoFinal = reader["MontoFinal"] != DBNull.Value ? Convert.ToDecimal(reader["MontoFinal"]) : (decimal?)null,
    //            Id_EstadoPresupuesto = Convert.ToInt32(reader["Id_EstadoPresupuesto"]),
    //            Observaciones = reader["Observaciones"]?.ToString(),
    //            Activo = Convert.ToBoolean(reader["Activo"]),
    //            NombreCliente = reader["NombreCliente"]?.ToString(),
    //            EstadoPresupuestoDescripcion = reader["EstadoDescripcion"]?.ToString()
    //        };
    //    }
    //}

    //// =====================================================
    //// DAL: PresupuestoCotizacion
    //// =====================================================
    //public class PresupuestoCotizacionDatos : ConexionBD
    //{
    //    public bool InsertarPresupuestoCotizacion(PresupuestoCotizacion pc)
    //    {
    //        using (SqlConnection conn = ObtenerConexion())
    //        {
    //            string query = @"
    //                INSERT INTO PresupuestoCotizacion 
    //                (Id_Presupuesto, Id_Cotizacion, Cantidad, PrecioUnitario, Subtotal, Observaciones, Activo)
    //                VALUES 
    //                (@IdPresupuesto, @IdCotizacion, @Cantidad, @PrecioUnitario, @Subtotal, @Observaciones, @Activo)";

    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            cmd.Parameters.AddWithValue("@IdPresupuesto", pc.Id_Presupuesto);
    //            cmd.Parameters.AddWithValue("@IdCotizacion", pc.Id_Cotizacion);
    //            cmd.Parameters.AddWithValue("@Cantidad", (object)pc.Cantidad ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@PrecioUnitario", (object)pc.PrecioUnitario ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@Subtotal", (object)pc.Subtotal ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@Observaciones", (object)pc.Observaciones ?? DBNull.Value);
    //            cmd.Parameters.AddWithValue("@Activo", pc.Activo);

    //            conn.Open();
    //            int filasAfectadas = cmd.ExecuteNonQuery();
    //            return filasAfectadas > 0;
    //        }
    //    }

    //    public List<PresupuestoCotizacion> ObtenerCotizacionesPorPresupuesto(int idPresupuesto)
    //    {
    //        List<PresupuestoCotizacion> lista = new List<PresupuestoCotizacion>();

    //        using (SqlConnection conn = ObtenerConexion())
    //        {
    //            string query = @"
    //                SELECT pc.*, c.NumeroCotizacion, c.DescripcionMueble, c.MontoTotal
    //                FROM PresupuestoCotizacion pc
    //                INNER JOIN Cotizacion c ON pc.Id_Cotizacion = c.Id_Cotizacion
    //                WHERE pc.Id_Presupuesto = @IdPresupuesto AND pc.Activo = 1";

    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            cmd.Parameters.AddWithValue("@IdPresupuesto", idPresupuesto);
    //            conn.Open();

    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                while (reader.Read())
    //                {
    //                    lista.Add(new PresupuestoCotizacion
    //                    {
    //                        Id_Presupuesto = Convert.ToInt32(reader["Id_Presupuesto"]),
    //                        Id_Cotizacion = Convert.ToInt32(reader["Id_Cotizacion"]),
    //                        Cantidad = reader["Cantidad"] != DBNull.Value ? Convert.ToInt32(reader["Cantidad"]) : (int?)null,
    //                        PrecioUnitario = reader["PrecioUnitario"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioUnitario"]) : (decimal?)null,
    //                        Subtotal = reader["Subtotal"] != DBNull.Value ? Convert.ToDecimal(reader["Subtotal"]) : (decimal?)null,
    //                        Observaciones = reader["Observaciones"]?.ToString(),
    //                        Activo = Convert.ToBoolean(reader["Activo"]),
    //                        NumeroCotizacion = reader["NumeroCotizacion"]?.ToString(),
    //                        DescripcionMueble = reader["DescripcionMueble"]?.ToString(),
    //                        MontoTotal = reader["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(reader["MontoTotal"]) : (decimal?)null
    //                    });
    //                }
    //            }
    //        }

    //        return lista;
    //    }
    //}


