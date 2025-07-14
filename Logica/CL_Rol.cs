using System.Collections.Generic;
using Datos;
using Sesion.Entidades;

namespace Logica
{
    public class CL_Rol
    {
        private readonly CD_DaoRol daoRol = new CD_DaoRol();

        public List<DtoRol> MostrarRoles()
        {
            return daoRol.ListarRoles();
        }
    }
}