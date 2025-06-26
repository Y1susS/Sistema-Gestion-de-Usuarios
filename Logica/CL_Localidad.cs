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
    public class CL_Localidad
    {
        CD_DaoLocalidad objCD = new CD_DaoLocalidad();
        public DataTable MostrarLocalidades(int idPartido)
        {
            DataTable tabla = new DataTable();
            tabla = objCD.MostrarLocalidadesxPartido(idPartido);
            return tabla;
        }

    }
}
