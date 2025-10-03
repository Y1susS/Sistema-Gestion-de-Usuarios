using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Datos
{
    public class CD_Conexion
    {
        private readonly string cadena = "Data Source=.;Initial Catalog=Sistema Integral Remuebla;Integrated Security=True;";
        private SqlConnection oConn;

        public CD_Conexion()
        {
            oConn = new SqlConnection(cadena);
        }

        public SqlConnection AbrirConexion()
        {
            
            if (oConn == null || string.IsNullOrEmpty(oConn.ConnectionString))
            {
                // Reinicializar la conexión si es necesario
                oConn = new SqlConnection(cadena);
            }

            if (oConn.State == ConnectionState.Closed) 
            {
                oConn.Open();
            }

            return oConn;
        }

        public SqlConnection CerrarConexion()
        {
            if (oConn != null && oConn.State == ConnectionState.Open) 
            {
                oConn.Close();
            }
            
            return oConn;
        }

    }
}
