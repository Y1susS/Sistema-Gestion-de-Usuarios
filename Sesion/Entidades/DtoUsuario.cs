using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion.Entidades
{
    public class DtoUsuario
    {
        public int Id_user { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public bool PrimeraPass { get; set; }
        public int Id_Rol { get; set; }
        public int Id_Persona { get; set; }
        public DateTime FechaUltimoCambio { get; set; }
        public int CambiaCada { get; set; }
        public DateTime? FechaBaja { get; set; } 
        public bool RequiereCambioContraseña => CambiaCada > 0 && 
            (DateTime.Now - FechaUltimoCambio).TotalDays > CambiaCada;
    }
}
