using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Pregunta
    {
        CD_DaoPregunta objCD = new CD_DaoPregunta();
        public DataTable MostrarPreguntas()
        {
            DataTable tabla = new DataTable();
            tabla = objCD.MostrarPreguntas();
            return tabla;
        }
    }

}
