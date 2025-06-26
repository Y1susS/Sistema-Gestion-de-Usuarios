using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Logica
{
    public class CL_TipoDoc
    {
        CD_DaoTipoDoc objCD = new CD_DaoTipoDoc();
        public DataTable MostrarTipoDoc()
        {
            DataTable tabla = new DataTable();
            tabla = objCD.MostrarTipoDoc();
            return tabla;
        }
    }
}
