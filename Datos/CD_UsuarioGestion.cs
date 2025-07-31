using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_UsuarioGestion
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get { return $"{Nombre} {Apellido} ({NombreUsuario})"; } } 
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public string Usuario { get; set; } 

       
    }
}
