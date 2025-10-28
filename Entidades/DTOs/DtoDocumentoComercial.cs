using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public abstract class DtoDocumentoComercial
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoFinal { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }

        public decimal PorcentajeDescuento
        {
            get
            {
                if (MontoTotal == 0) return 0M; // Evita división por cero

                // Suponiendo que 'Descuento' es el MONTO de dinero
                return Descuento / MontoTotal;
            }
        }
    }
}
