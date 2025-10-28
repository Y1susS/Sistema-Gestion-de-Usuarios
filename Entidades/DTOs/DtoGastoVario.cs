using System;

namespace Entidades.DTOs
{
    public class DtoGastoVario
    {
        public int IdGastoVario { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int? IdCotizacion { get; set; }
        public bool Activo { get; set; }

        public DtoGastoVario()
        {
            Activo = true;
        }
    }
}
