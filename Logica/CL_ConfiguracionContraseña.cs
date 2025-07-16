using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesion.Entidades;

namespace Logica
{
    public class CL_ConfiguracionContraseña
    {
        CD_DaoConfiguracionSeguridad configContraseñaDao = new CD_DaoConfiguracionSeguridad();

        public DtoConfiguracionContraseña ObtenerConfiguracion()
        {
            List<DtoConfiguracionContraseña> configs = configContraseñaDao.ObtenerConfiguracionesContras();

            // Si la lista es nula o está vacía, no hay configuración en la BD, devolvemos null
            if (configs == null || !configs.Any())
            {
                return null;
            }
            else
            {
                // Hay configuraciones, tomamos la primera
                return configs.FirstOrDefault();
            }
        }


        public bool GuardarConfiguracion(DtoConfiguracionContraseña dto)
        {
            // Validaciones de negocio antes de guardar. Agregar mas
            if (dto.MinimoCaracteres < 0)
            {
                throw new ApplicationException("El mínimo de caracteres no puede ser negativo.");
            }

            if (dto.DiasCambioPassword < 0)
            {
                throw new ApplicationException("La cantidad de días para cambio de contraseña no puede ser negativa.");
            }

            return configContraseñaDao.GuardarConfiguracionContras(dto);
        }
    }
}
