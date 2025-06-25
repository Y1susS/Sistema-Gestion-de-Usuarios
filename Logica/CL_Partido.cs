using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class CL_Partido
    {
        CD_DaoPartido objCD = new CD_DaoPartido();
        public DataTable MostrarPartidos()
        {
            DataTable tabla = new DataTable();
            tabla = objCD.MostrarPartidos(); 
            return tabla;
        }   
    }
}
