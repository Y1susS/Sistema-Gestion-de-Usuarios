using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Entidades.DTOs;
using Logica;
using static System.Collections.Specialized.BitVector32;

namespace Vista
{
    public partial class frmReportes : Form
    {
        private readonly CL_Ventas _ventas;
        public frmReportes()
        {
            InitializeComponent();
            _ventas = new CL_Ventas();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {

            //cboUsuarios.DataSource = _ventas.ObtenerUsuariosConVentas();
            //cboUsuarios.DisplayMember = "User";   // o "NombreCompleto" si lo tenés en el DTO
            //cboUsuarios.ValueMember = "Id_user";
            //cboUsuarios.SelectedIndex = -1;

            //cboClientes.DataSource = _ventas.ObtenerClientes();
            //cboClientes.DisplayMember = "Nombre";
            //cboClientes.ValueMember = "Id_Cliente";
            //cboClientes.SelectedIndex = -1;

            //// Arrancar con los DateTimePicker deshabilitados
            //chkUsarFechas.Checked = false;
            //dtpDesde.Enabled = false;
            //dtpHasta.Enabled = false;


            //// Obtener la lista de ventas completa
            //List<DtoVenta> listaCompleta = _ventas.ObtenerTodasLasVentas();

            //// Asignar esa lista al DataGridView (tu línea de código actual)
            //dgvVentas.DataSource = listaCompleta;

            //// Actualizar el label con el conteo de esa misma lista
            //lblTotalVentas.Text = $"Total de Ventas: {listaCompleta.Count}";

            cboUsuarios.DataSource = _ventas.ObtenerUsuariosConVentas();
            cboUsuarios.DisplayMember = "User";
            cboUsuarios.ValueMember = "Id_user";
            cboUsuarios.SelectedIndex = -1;
            cboUsuarios.Enabled = false;

            cboClientes.DataSource = _ventas.ObtenerClientes();
            cboClientes.DisplayMember = "Nombre";
            cboClientes.ValueMember = "Id_Cliente";
            cboClientes.SelectedIndex = -1;
            cboClientes.Enabled = false;

            // ---- CheckBoxes ----
            chkFiltrarUsuario.Checked = false;
            chkFiltrarCliente.Checked = false;


            chkFiltrarUsuario.CheckedChanged += (s, ev) =>
            {
                cboUsuarios.Enabled = chkFiltrarUsuario.Checked;
                if (!chkFiltrarUsuario.Checked)
                    cboUsuarios.SelectedIndex = -1; // resetea selección
            };

            chkFiltrarCliente.CheckedChanged += (s, ev) =>
            {
                cboClientes.Enabled = chkFiltrarCliente.Checked;
                if (!chkFiltrarCliente.Checked)
                    cboClientes.SelectedIndex = -1; // resetea selección
            };


            // Arrancar con los DateTimePicker deshabilitados
            chkUsarFechas.Checked = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;

            // Configurar DataGridView
            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.Columns.Clear();

            //dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "N° Venta", DataPropertyName = "NumeroVenta" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "FechaVenta" });
            //dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Monto Total", DataPropertyName = "MontoTotal" });
            //dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descuento", DataPropertyName = "Descuento" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Monto Final", DataPropertyName = "MontoFinal" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Observaciones", DataPropertyName = "Observaciones" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "ClienteNombre" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Vendedor", DataPropertyName = "VendedorUserName" });

            //// Obtener lista completa de ventas
            //List<DtoVenta> listaCompleta = _ventas.ObtenerTodasLasVentas();
            //dgvVentas.DataSource = listaCompleta;

            //lblTotalVentas.Text = $"Total de Ventas: {listaCompleta.Count}";
            //decimal totalFinal = listaCompleta.Sum(v => v.MontoFinal ?? 0);
            //lblTotal.Text = $"Total Final: {totalFinal:C}";


            cboTipoGrafico.Items.Add("Ventas por Vendedor");
            cboTipoGrafico.Items.Add("Ventas por Día de Semana");
            cboTipoGrafico.SelectedIndex = 0; // Arranca en "Ventas por Vendedor"


            // engancho el evento
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;

            //////// inicializo MinDate del "hasta"
            dtpHasta.MinDate = dtpDesde.Value.Date;

            List<DtoVenta> listaCompleta = _ventas.ObtenerTodasLasVentas();
            dgvVentas.DataSource = listaCompleta;
            ActualizarMetricas(listaCompleta);

        }

        

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            DateTime? desde = null;
            DateTime? hasta = null;

            if (chkUsarFechas.Checked)
            {
                desde = dtpDesde.Value.Date;
                hasta = dtpHasta.Value.Date;
            }

            int? idUser = (chkFiltrarUsuario.Checked && cboUsuarios.SelectedIndex >= 0)
                ? (int?)Convert.ToInt32(cboUsuarios.SelectedValue)
                : null;

            int? idCliente = (chkFiltrarCliente.Checked && cboClientes.SelectedIndex >= 0)
                ? (int?)Convert.ToInt32(cboClientes.SelectedValue)
                : null;


            //List<DtoVenta> ventas = _ventas.FiltrarVentas(desde, hasta, idUser, idCliente);

            //dgvVentas.DataSource = ventas;

            //lblTotalVentas.Text = $"Total de Ventas: {ventas.Count}";


            //decimal totalFinal = ventas.Sum(v => v.MontoFinal ?? 0);
            //lblTotal.Text = $"Total Final: {totalFinal:C}";

            List<DtoVenta> ventas = _ventas.FiltrarVentas(desde, hasta, idUser, idCliente);
            dgvVentas.DataSource = ventas;
            ActualizarMetricas(ventas);


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar combos
            chkFiltrarUsuario.Checked = false;
            chkFiltrarCliente.Checked = false;

            // Limpiar check y fechas
            chkUsarFechas.Checked = false;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;

            //// Obtener la lista completa de ventas
            //List<DtoVenta> ventasCompletas = _ventas.ObtenerTodasLasVentas();

            //// Asignar la lista al DataGridView
            //dgvVentas.DataSource = ventasCompletas;

            //// ¡Actualizar la etiqueta con el conteo de la lista completa!
            //lblTotalVentas.Text = $"Total de Ventas: {ventasCompletas.Count}";

            //decimal totalFinal = ventasCompletas.Sum(v => v.MontoFinal ?? 0);
            //lblTotal.Text = $"Total Final: {totalFinal:C}";
                
            List<DtoVenta> ventasCompletas = _ventas.ObtenerTodasLasVentas();
            dgvVentas.DataSource = ventasCompletas;
            ActualizarMetricas(ventasCompletas);

        }

        private void chkBuscarPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            bool habilitar = chkUsarFechas.Checked;

            dtpDesde.Enabled = habilitar;
            dtpHasta.Enabled = habilitar;
        }



        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            // Ajusto el mínimo del Hasta al valor del Desde
            dtpHasta.MinDate = dtpDesde.Value.Date;

            // si el Hasta quedó más atrás, lo muevo automáticamente
            if (dtpHasta.Value < dtpDesde.Value)
            {
                dtpHasta.Value = dtpDesde.Value;
            }
        }



        //private void ActualizarMetricas(List<DtoVenta> ventas)
        //{
        //    // Total de ventas
        //    lblTotalVentas.Text = $"Total Ventas {ventas.Count}";

        //    // Suma de montos finales
        //    decimal totalMontosFinales = ventas.Sum(v => v.MontoFinal ?? 0);
        //    lblTotal.Text = $"Total Final: {totalMontosFinales:C}";

        //    // Ticket promedio
        //    decimal ticketPromedio = ventas.Count > 0
        //        ? totalMontosFinales / ventas.Count
        //        : 0;
        //    lblPromedio.Text = $"Ticket Promedio: {ticketPromedio:C}";





        //    // --- Chart (ventas por día) ---
        //    chartVentas.Series.Clear();
        //    chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // Inclina etiquetas
        //    chartVentas.ChartAreas[0].AxisX.Interval = 1;
        //    // Configurar el formato de las etiquetas del eje X
        //    chartVentas.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";

        //    var ventasPorDia = ventas
        //        .Where(v => v.FechaVenta.HasValue) // filtra las que tienen fecha
        //        .GroupBy(v => v.FechaVenta.Value.Date) // usamos .Value.Date
        //        .Select(g => new { Fecha = g.Key, Total = g.Sum(v => v.MontoFinal ?? 0) })
        //        .OrderBy(x => x.Fecha)
        //        .ToList();


        //    Series serie = new Series("Ventas por Día");
        //    serie.ChartType = SeriesChartType.Column; // Columnas verticales
        //    serie.XValueType = ChartValueType.Date;

        //    foreach (var item in ventasPorDia)
        //    {
        //        serie.Points.AddXY(item.Fecha.ToShortDateString(), item.Total);
        //    }

        //    chartVentas.Series.Add(serie);
        //}


        private void ActualizarMetricas(List<DtoVenta> ventas)
        {
            // Total de ventas
            lblTotalVentas.Text = $"Total Ventas {ventas.Count}";

            // Suma de montos finales
            decimal totalMontosFinales = ventas.Sum(v => v.MontoFinal ?? 0);
            lblTotal.Text = $"Total Final: {totalMontosFinales:C}";

            // Ticket promedio
            decimal ticketPromedio = ventas.Count > 0
                ? totalMontosFinales / ventas.Count
                : 0;
            lblPromedio.Text = $"Ticket Promedio: {ticketPromedio:C}";

            // --- Configurar gráfico ---
            chartVentas.Series.Clear();
            chartVentas.Titles.Clear();

            if (cboTipoGrafico.SelectedItem.ToString() == "Ventas por Vendedor")
            {
                // Agrupamos ventas por vendedor
                var ventasPorVendedor = ventas
                    .GroupBy(v => v.VendedorUserName)
                    .Select(g => new { Vendedor = g.Key, Cantidad = g.Count() })
                    .OrderByDescending(x => x.Cantidad)
                    .ToList();

                Series serie = new Series("Ventas por Vendedor");
                serie.ChartType = SeriesChartType.Pie;
                serie.IsValueShownAsLabel = true;

                // Mostrar porcentajes en vez de cantidades
                serie.Label = "#PERCENT{P0}";
                serie.LegendText = "#VALX";

                foreach (var item in ventasPorVendedor)
                {
                    serie.Points.AddXY(item.Vendedor, item.Cantidad);
                }

                chartVentas.Series.Add(serie);
                chartVentas.Titles.Add("Distribución de Ventas por Vendedor (%)");
            }
            else if (cboTipoGrafico.SelectedItem.ToString() == "Ventas por Día de Semana")
            {

                Dictionary<DayOfWeek, string> diasSemanaEs = new Dictionary<DayOfWeek, string>
                {
                    { DayOfWeek.Sunday, "Domingo" },
                    { DayOfWeek.Monday, "Lunes" },
                    { DayOfWeek.Tuesday, "Martes" },
                    { DayOfWeek.Wednesday, "Miércoles" },
                    { DayOfWeek.Thursday, "Jueves" },
                    { DayOfWeek.Friday, "Viernes" },
                    { DayOfWeek.Saturday, "Sábado" }
                };


                // Siempre mostrar los 7 días
                var diasSemana = Enum.GetValues(typeof(DayOfWeek))
                                     .Cast<DayOfWeek>()
                                     .ToList();

                var ventasPorDiaSemana = diasSemana
                    .GroupJoin(
                        ventas.Where(v => v.FechaVenta.HasValue),
                        d => d,
                        v => v.FechaVenta.Value.DayOfWeek,
                        (d, g) => new { Dia = d, Cantidad = g.Count() }
                    )
                    .OrderBy(x => x.Dia)
                    .ToList();

                Series serie = new Series("Ventas por Día");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;

                foreach (var item in ventasPorDiaSemana)
                {
                    serie.Points.AddXY(diasSemanaEs[item.Dia], item.Cantidad);
                }

                chartVentas.Series.Add(serie);
                chartVentas.Titles.Add("Ventas según Día de la Semana");
            }
        }


        private void cboTipoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvVentas.DataSource is List<DtoVenta> ventas)
            {
                ActualizarMetricas(ventas);
            }
        }



    }
}
