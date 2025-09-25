using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class DtoVenta : DocumentoComercial
    {
        public int IdVenta { get; set; }
        public string NumeroVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public decimal? MontoTotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? MontoFinal { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }

        public int? IdPresupuesto { get; set; }
        public int? IdCliente { get; set; }
        public string ClienteNombre { get; set; }

        public int? IdVendedor { get; set; }
        public string VendedorUserName { get; set; }
        public string VendedorNombre { get; set; }
        public int? IdRolVendedor { get; set; }

        //public int IdVenta { get; set; } 
        //public int IdPresupuesto { get; set; }
        //public int IdUser { get; set; }        
        //public int IdEstadoVenta { get; set; } 
        //public DateTime FechaVenta { get; set; }
    }
}
