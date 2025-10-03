using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades.DTOs;

namespace Logica
{
    public class CL_Ventas
    {
        private readonly CD_DaoVenta _dao;

        public CL_Ventas()
        {
            _dao = new CD_DaoVenta(); // Usa el constructor vacío
        }

        public List<DtoVenta> ObtenerTodasLasVentas()
            => _dao.ListarVentas();

        public List<DtoVenta> FiltrarVentas(DateTime? desde, DateTime? hasta, int? idVendedor, int? idCliente, int? idEstadoVenta)
            => _dao.FiltrarVentas(desde, hasta, idVendedor, idCliente, idEstadoVenta);

        public List<DtoUsuario> ObtenerUsuariosConVentas()
            => _dao.ListarUsuariosConVentas();

        public List<DtoCliente> ObtenerClientes()
            => _dao.ListarClientesVentas();


        public List<DtoEstadoVenta> ObtenerEstadosVenta()
    => _dao.ListarEstadosVenta();

        public void GuardarEstadoVenta(int idVenta, int idEstadoVenta)
    => _dao.ActualizarEstadoVenta(idVenta, idEstadoVenta);
    }


}
