using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Logica
{
    public class CL_Usuarios
    {
        CD_DaoUsuarios objCD = new CD_DaoUsuarios();
        public DataTable MostrarUsuarios()
        {
           DataTable tabla = new DataTable();
            tabla = objCD.Mostrar();
            return tabla;
        }
        public bool AgregarUsuario(string id, string usuario, string email, string password, string rol)
        {
            return objCD.AgregarUsuario(id, usuario, email, password, rol);
        }
        public bool ModificarUsuario(int id, string usuario, string email, string password, bool activo, int rol)
        {
            return objCD.ModificarUsuario(id, usuario, email, password, activo, rol);
        }
    }
}
