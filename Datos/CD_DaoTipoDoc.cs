using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class CD_DaoTipoDoc
    {
        CD_Conexion conexion = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarTipoDoc()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_ListarTipoDocumento";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
