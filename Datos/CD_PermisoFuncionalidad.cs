using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; // Asegúrate de que esto esté presente si usas Task

namespace Datos
    {
        public class CD_PermisoFuncionalidad 
        {
            public int IdPermiso { get; set; }
            public string NombreFuncionalidad { get; set; }
            public string Descripcion { get; set; }
            public bool Habilitado { get; set; }

            
            public override bool Equals(object obj)
            {
                // Si el objeto es nulo o no es del mismo tipo, no son iguales
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                // Castea el objeto a CD_PermisoFuncionalidad
                CD_PermisoFuncionalidad other = (CD_PermisoFuncionalidad)obj;

                // Compara por la propiedad única que define la igualdad
                return IdPermiso == other.IdPermiso;
            }

            public override int GetHashCode()
            {
                return IdPermiso.GetHashCode();
            }
        }
}


