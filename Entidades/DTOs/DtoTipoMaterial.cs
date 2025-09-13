using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class DtoTipoMaterial
    {
        public int IdTipoMaterial { get; set; }
        public string NombreTipoMaterial { get; set; }
        public string DescripcionTipoMaterial { get; set; }
        public bool ActivoTipoMaterial { get; set; }

        public override string ToString()
        {
            return NombreTipoMaterial;
        }
    }
}
