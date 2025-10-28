using System.Collections.Generic;
using Datos;
using Entidades.DTOs;

namespace Logica
{
    public class CL_Localidad
    {
        private readonly CD_DaoLocalidad daoLocalidad = new CD_DaoLocalidad();

        public List<DtoLocalidad> MostrarLocalidades(int idPartido)
        {
            return daoLocalidad.ListarLocalidadesPorPartido(idPartido);
        }

        // Obtener localidad por ID
        public DtoLocalidad ObtenerLocalidadPorId(int idLocalidad)
        {
            try
            {
                return daoLocalidad.ObtenerLocalidadPorId(idLocalidad);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}