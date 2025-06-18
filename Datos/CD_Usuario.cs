using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Usuario : CD_Persona
    {
        public int Id_user { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaBloqueo { get; set; }
        public bool PrimeraPass { get; set; }
        public int Id_Rol { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int Intentos { get; set; }
        public int CambiaCada { get; set; }
        public DateTime? FechaUltimoCambio { get; set; }

    }
}