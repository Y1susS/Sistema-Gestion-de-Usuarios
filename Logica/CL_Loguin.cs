using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesion;
using Datos;

namespace Logica
{
    public class CL_Loguin
    {
        CD_Usuarios usuario = new CD_Usuarios();

        public bool LoginUser(string user, string password)
        {
            return usuario.ValidarUsuario(user, password);
        }
    }
}
