using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica
{
    public class CL_VerificarRecupero
    {
        private CD_DaoUsuarios daoUsuarios = new CD_DaoUsuarios();

        public bool VerificarRecupero(string nroDocumento, int idPregunta, string respuestaHasheada)
        {
            if (string.IsNullOrWhiteSpace(nroDocumento) || string.IsNullOrWhiteSpace(respuestaHasheada))
            {
                return false;
            }

            return daoUsuarios.VerificarParametrosRecupero(nroDocumento, idPregunta, respuestaHasheada);
        }
    }
}
