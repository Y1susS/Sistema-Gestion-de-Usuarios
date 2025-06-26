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
    public class CL_Rol
    {
        CD_DaoRol objCD = new CD_DaoRol();
        public DataTable MostrarRoles()
        {
            DataTable tabla = new DataTable();
            tabla = objCD.MostrarRoles();
            return tabla;
        }

       
    }
}
