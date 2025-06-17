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
        CD_Usuario usuario = new CD_Usuario();
        CD_AccionUsuarios acciones = new CD_AccionUsuarios();

        public bool LoginUser(string user, string password)
        {
            return acciones.ValidarUsuario(user, password);
        }
        public string ObtenerUsuarioActual()
        {
            return usuario.User;
        }
    }
}
