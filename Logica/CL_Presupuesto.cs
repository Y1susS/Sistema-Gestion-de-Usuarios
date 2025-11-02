using Datos;
using Entidades;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Presupuesto
    {
        private CD_DaoPresupuesto cdPresupuesto = new CD_DaoPresupuesto();

        public List<DtoPresupuestoFiltro> FiltrarPresupuestos(
            string descripcion,
            DateTime? fechaValidez,
            string vendedor,
            string documentoCliente)
        {

            try
            {
                return cdPresupuesto.FiltrarPresupuestos(descripcion, fechaValidez, vendedor, documentoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al intentar filtrar presupuestos.", ex);
            }
        }
        public Presupuesto CargarPresupuestoCompleto(int idPresupuesto)
        {
            Presupuesto presupuesto = cdPresupuesto.ObtenerEncabezado(idPresupuesto);

            if (presupuesto != null)
            {
                List<DtoPresupuestoDetalle> detalles = cdPresupuesto.ObtenerDetalles(idPresupuesto);

                return presupuesto;
            }

            return null;
        }
        public List<DtoPresupuestoDetalle> ObtenerDetalles(int idPresupuesto)
        {
            try
            {
                return cdPresupuesto.ObtenerDetalles(idPresupuesto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al obtener los detalles de cotización.", ex);
            }
        }

        public int GuardarNuevoPresupuesto(Presupuesto presupuesto, List<DtoPresupuestoDetalle> detalles)
        {
            int idPresupuesto = 0;
            try
            {

                idPresupuesto = cdPresupuesto.InsertarPresupuesto(presupuesto, detalles);

                if (idPresupuesto <= 0)
                {
                    throw new Exception("No se pudo obtener el ID de la cabecera del presupuesto.");
                }

                foreach (var detalle in detalles)
                {
                    detalle.IdPresupuesto = idPresupuesto;

                    cdPresupuesto.InsertarDetallePresupuesto(detalle);
                }

                return idPresupuesto;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al guardar el presupuesto (Pudo haber quedado incompleto en DB).", ex);
            }
        }
        public void ActualizarEstadosVencidos()
        {
            try
            {
                cdPresupuesto.ActualizarEstadosVencidos();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar la vigencia de los presupuestos.", ex);
            }
        }

    }
}
