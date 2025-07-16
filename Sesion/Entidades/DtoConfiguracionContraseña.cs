using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion.Entidades
{
    public class DtoConfiguracionContraseña
    {
        public int Id { get; set; }
        public int MinimoCaracteres { get; set; }
        public bool RequiereMayusMinus { get; set; }
        public bool RequiereNumLetra { get; set; }
        public bool RequiereEspecial { get; set; }
        public bool EvitarRepetidas { get; set; }
        public bool EvitarDatosPersonales { get; set; }
        public int DiasCambioPassword { get; set; }
    }
}
