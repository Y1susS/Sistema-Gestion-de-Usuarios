using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class CL_VerificaIngreso
    {
        public bool EsUsuarioActivo(CD_Usuario usuario)
        {
            return usuario != null && usuario.Activo;
        }
        ////hacer messagebox y pasarle esto
        ///
        //CD_UsuarioAtributos usuario = usuarioDAL.ObtenerUsuarioPorId(idUsuario);

        //if (!usuarioLogica.EsUsuarioActivo(usuario))
        //{
        //    MessageBox.Show("El usuario se encuentra inactivo. Por favor, contacte al administrador.","Usuario inactivo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //return; // corta el flujo
        //}
    }
}
