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
        private CD_DaoUsuario daoUsuarios = new CD_DaoUsuario();

        public bool VerificarRecupero(string nroDocumento, int idPregunta, string respuesta)
        {
            if (string.IsNullOrWhiteSpace(nroDocumento) || string.IsNullOrWhiteSpace(respuesta))
            {
                return false;
            }

            return daoUsuarios.VerificarParametrosRecupero(nroDocumento, idPregunta, respuesta);
        }
    }
}
