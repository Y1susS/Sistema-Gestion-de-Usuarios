using System.Collections.Generic;
using Datos;
using Sesion.Entidades;

namespace Logica
{
    public class CL_TipoDoc
    {
        private readonly CD_DaoTipoDoc daoTipoDoc = new CD_DaoTipoDoc();

        public List<DtoTipoDoc> MostrarTiposDocumento()
        {
            return daoTipoDoc.ListarTiposDocumento();
        }
    }
}