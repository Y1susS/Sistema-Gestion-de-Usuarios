using System.Collections.Generic;
using Datos;
using Sesion.Entidades;

namespace Logica
{
    public class CL_Localidad
    {
        private readonly CD_DaoLocalidad daoLocalidad = new CD_DaoLocalidad();

        public List<DtoLocalidad> MostrarLocalidades(int idPartido)
        {
            return daoLocalidad.ListarLocalidadesPorPartido(idPartido);
        }
    }
}