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
            // 1. Obtener el encabezado (la parte principal)
            Presupuesto presupuesto = cdPresupuesto.ObtenerEncabezado(idPresupuesto);

            if (presupuesto != null)
            {
                // 2. Obtener los detalles de cotización (las filas del DataGrid)
                List<DtoPresupuestoDetalle> detalles = cdPresupuesto.ObtenerDetalles(idPresupuesto);

                // 3. Crear una propiedad o un método para adjuntar los detalles al presupuesto.
                // Como no tengo tu DTO Presupuesto completo, lo devolveremos separado,
                // pero idealmente deberías tener una propiedad:
                // presupuesto.DetallesCotizacion = detalles;

                // Para fines prácticos, podemos devolver el objeto Presupuesto (encabezado)
                // y gestionar los detalles en la capa de la Vista.

                return presupuesto;
            }

            // Devolver null si no se encontró el encabezado.
            return null;
        }
        public List<DtoPresupuestoDetalle> ObtenerDetalles(int idPresupuesto)
        {
            try
            {
                // Aquí es donde llamas al método implementado en la Capa de Datos (CD)
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
                // 1. Insertar la Cabecera y Obtener el ID Generado
                // cdPresupuesto.InsertarPresupuesto DEBE ser renombrado o modificado
                // para *solo* insertar la cabecera y devolver el ID.
                idPresupuesto = cdPresupuesto.InsertarPresupuesto(presupuesto, detalles);

                if (idPresupuesto <= 0)
                {
                    throw new Exception("No se pudo obtener el ID de la cabecera del presupuesto.");
                }

                // 2. Insertar los Detalles uno por uno (SIN TRANSACCIÓN explícita)
                foreach (var detalle in detalles)
                {
                    // Asignar el ID de la cabecera a cada detalle (Foreign Key)
                    detalle.IdPresupuesto = idPresupuesto;

                    // Llamar al método del DAO que inserta un solo detalle
                    cdPresupuesto.InsertarDetallePresupuesto(detalle);
                }

                return idPresupuesto;
            }
            catch (Exception ex)
            {
                // Si el error ocurre en la cabecera, no se inserta nada.
                // Si el error ocurre en un detalle, la cabecera y los detalles anteriores QUEDARÁN
                // guardados en la base de datos (inconsistencia).
                throw new Exception("Error al guardar el presupuesto (revisar si quedó incompleto en DB).", ex);
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
