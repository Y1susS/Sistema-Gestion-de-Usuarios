using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class CD_DaoLocalidad
    {
        CD_Conexion conexion = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        
        public DataTable MostrarLocalidadesxPartido(int idPartido)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Clear();
            comando.CommandText = "sp_FiltrarLocalidadxPartido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@filtroPartido", idPartido);
            DataTable tabla = new DataTable();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
