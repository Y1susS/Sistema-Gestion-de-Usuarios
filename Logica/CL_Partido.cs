using System.Collections.Generic;
using Datos;
using Entidades.DTOs;

namespace Logica
{
    public class CL_Partido
    {
        private readonly CD_DaoPartido daoPartido = new CD_DaoPartido();

        public List<DtoPartido> MostrarPartidos()
        {
            return daoPartido.ListarPartidos();
        }
    }
}