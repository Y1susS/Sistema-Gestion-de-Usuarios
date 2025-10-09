using System;

namespace Entidades.DTOs
{
    public class DtoGastoVario
    {
        public int IdGastoVario { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int? IdCotizacion { get; set; }
        public int? IdPresupuesto { get; set; }
        public string TipoGasto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        
        public DtoGastoVario()
        {
            FechaCreacion = DateTime.Now;
            Activo = true;
        }
    }
}
