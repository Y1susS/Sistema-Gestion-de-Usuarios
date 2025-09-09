using System;
using System.Collections.Generic;
using Datos;
using Entidades.DTOs;

namespace Logica
{
    public class CL_TipoDoc
    {
        private readonly CD_DaoTipoDoc daoTipoDoc = new CD_DaoTipoDoc();

        public List<DtoTipoDoc> MostrarTiposDocumento()
        {
            try
            {
                return daoTipoDoc.ListarTiposDocumento();
            }
            catch (Exception)
            {
                return new List<DtoTipoDoc>();
            }
        }
    }
}