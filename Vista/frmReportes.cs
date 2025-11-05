using Entidades.DTOs;
using Logica;
using Sistema_Gestion_de_Usuarios.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Vista.Lenguajes;
using static System.Collections.Specialized.BitVector32;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;


namespace Vista
{
    public partial class frmReportes : Form
    {
        private Size _formSizeInicial;
        private ClsArrastrarFormularios moverFormulario;
        private readonly CL_Ventas _ventas;
        public frmReportes()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            _formSizeInicial = this.Size;
            _ventas = new CL_Ventas();
            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(lblreportes);
            moverFormulario.HabilitarMovimiento(pnlBorde);
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
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

            //CheckBoxes
            chkFiltrarxvendedor.Checked = false;
            chkFiltrarxCliente.Checked = false;


            chkFiltrarxvendedor.CheckedChanged += (s, ev) =>
            {
                cboUsuarios.Enabled = chkFiltrarxvendedor.Checked;
                if (!chkFiltrarxvendedor.Checked)
                    cboUsuarios.SelectedIndex = -1;
            };

            chkFiltrarxCliente.CheckedChanged += (s, ev) =>
            {
                cboClientes.Enabled = chkFiltrarxCliente.Checked;
                if (!chkFiltrarxCliente.Checked)
                    cboClientes.SelectedIndex = -1; 
            };



            cboEstados.DataSource = _ventas.ObtenerEstadosVenta();
            cboEstados.DisplayMember = "Estado";
            cboEstados.ValueMember = "IdEstadoVenta";
            cboEstados.SelectedIndex = -1;
            cboEstados.Enabled = false;

  
            chkFiltrarEstado.Checked = false;
            chkFiltrarEstado.CheckedChanged += (s, ev) =>
            {
                cboEstados.Enabled = chkFiltrarEstado.Checked;
                if (!chkFiltrarEstado.Checked)
                    cboEstados.SelectedIndex = -1; 
            };

           
            chkUsarFechas.Checked = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;

          
            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.Columns.Clear();

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "FechaVenta" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Monto Final", DataPropertyName = "MontoFinal" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Observaciones", DataPropertyName = "Observaciones" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "EstadoVenta" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "ClienteNombre" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Vendedor", DataPropertyName = "VendedorUserName" });

            cboTipoGrafico.Items.Add("Ventas por Vendedor");
            cboTipoGrafico.Items.Add("Ventas por Día de Semana");
            cboTipoGrafico.Items.Add("Ventas por Estado");
            cboTipoGrafico.SelectedIndex = 0; 


            // engancho el evento
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;

 
            dtpHasta.MinDate = dtpDesde.Value.Date;

            List<DtoVenta> listaCompleta = _ventas.ObtenerTodasLasVentas();
            dgvVentas.DataSource = listaCompleta;
            ActualizarMetricas(listaCompleta);

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

            int? idUser = (chkFiltrarxvendedor.Checked && cboUsuarios.SelectedIndex >= 0)
                ? (int?)Convert.ToInt32(cboUsuarios.SelectedValue)
                : null;

            int? idCliente = (chkFiltrarxCliente.Checked && cboClientes.SelectedIndex >= 0)
                ? (int?)Convert.ToInt32(cboClientes.SelectedValue)
                : null;

            int? idEstadoVenta = (chkFiltrarEstado.Checked && cboEstados.SelectedIndex >= 0)
                ? (int?)Convert.ToInt32(cboEstados.SelectedValue)
                : null;

            List<DtoVenta> ventas = _ventas.FiltrarVentas(desde, hasta, idUser, idCliente, idEstadoVenta);
            dgvVentas.DataSource = ventas;
            ActualizarMetricas(ventas);


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            chkFiltrarxvendedor.Checked = false;
            chkFiltrarxCliente.Checked = false;
            chkFiltrarEstado.Checked = false;

            chkUsarFechas.Checked = false;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;

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

            dtpHasta.MinDate = dtpDesde.Value.Date;


            if (dtpHasta.Value < dtpDesde.Value)
            {
                dtpHasta.Value = dtpDesde.Value;
            }
        }

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

            //Configurar gráfico
            chartVentas.Series.Clear();
            chartVentas.Titles.Clear();

            if (cboTipoGrafico.SelectedItem.ToString() == "Ventas por Vendedor")
            {
                
                var ventasPorVendedor = ventas
                    .GroupBy(v => v.VendedorUserName)
                    .Select(g => new { Vendedor = g.Key, Cantidad = g.Count() })
                    .OrderByDescending(x => x.Cantidad)
                    .ToList();

                Series serie = new Series("Ventas por Vendedor");
                serie.ChartType = SeriesChartType.Pie;
                serie.IsValueShownAsLabel = true;

                
                serie.Label = "#PERCENT{P0}";
                serie.LegendText = "#VALX";

                foreach (var item in ventasPorVendedor)
                {
                    serie.Points.AddXY(item.Vendedor, item.Cantidad);
                }

                chartVentas.Series.Add(serie);
                chartVentas.Titles.Add("Distribución de Ventas por Vendedor (%)");
            }

            else if (cboTipoGrafico.SelectedItem.ToString() == "Ventas por Estado")
            {
                
                var ventasPorEstado = ventas
                    .GroupBy(v => v.EstadoVenta)
                    .Where(g => g.Key != null) 
                    .Select(g => new { Estado = g.Key, Cantidad = g.Count() })
                    .OrderByDescending(x => x.Cantidad)
                    .ToList();

                Series serie = new Series("Ventas por Estado");
                serie.ChartType = SeriesChartType.Pie;
                serie.IsValueShownAsLabel = true;

            
                serie.Label = "#VALY";
                serie.LegendText = "#VALX";

                foreach (var item in ventasPorEstado)
                {
                    serie.Points.AddXY(item.Estado, item.Cantidad);
                }

                chartVentas.Series.Add(serie);
                chartVentas.Titles.Add("Distribución de Ventas por Estado (Cantidad)");
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



        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.DataSource == null || dgvVentas.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = "Reporte_Ventas.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaPDF = saveFileDialog.FileName;

                try
                {
                  
                    string totalVentas = lblTotal.Text;
                    string cantidadVentas = lblTotalVentas.Text;
                    string ticketPromedio = lblPromedio.Text;


                    string rutaGrafico = Path.Combine(Path.GetTempPath(), "graficoTemp.png");
                    chartVentas.SaveImage(rutaGrafico, ChartImageFormat.Png);

 
                    int filaInicio = 0; 
                    int filasPorPagina = 35; 

                    using (PrintDocument pd = new PrintDocument())
                    {
                        pd.PrinterSettings.PrintToFile = true;
                        pd.PrinterSettings.PrintFileName = rutaPDF;

                        pd.PrintPage += (s, ev) =>
                        {
                            Graphics g = ev.Graphics;
                            g.Clear(Color.White);

                            Font fuenteTitulo = new Font("Arial", 16, FontStyle.Bold);
                            Font fuenteTexto = new Font("Arial", 11);
                            Font fuenteNegrita = new Font("Arial", 12, FontStyle.Bold);
                            Brush brush = Brushes.Black;

                            int y = 40;
                            g.DrawString("Reporte de Ventas", fuenteTitulo, brush, 320, y);
                            y += 40;
                            g.DrawString($"Fecha de exportación: {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteTexto, brush, 20, y);
                            y += 30;
                            g.DrawString($"{totalVentas:N2}", fuenteTexto, brush, 20, y);
                            y += 25;
                            g.DrawString($"{cantidadVentas:N2}", fuenteTexto, brush, 20, y);
                            y += 25;
                            g.DrawString($"{ticketPromedio:N2}", fuenteTexto, brush, 20, y);
                            y += 40;

                            g.DrawString("Detalle de ventas:", fuenteNegrita, brush, 20, y);
                            y += 30;

                            // Encabezados
                            int x = 20;
                            foreach (DataGridViewColumn col in dgvVentas.Columns)
                            {
                                g.DrawString(col.HeaderText, fuenteTexto, brush, x, y);
                                x += 140;
                            }
                            y += 20;
                            g.DrawLine(Pens.Black, 20, y, 880, y);
                            y += 10;


                            int filasDibujadas = 0;
                            for (int i = filaInicio; i < dgvVentas.Rows.Count; i++)
                            {
                                DataGridViewRow row = dgvVentas.Rows[i];
                                if (row.IsNewRow) continue;

                                x = 20;
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    string texto = cell.Value?.ToString();
                                    if (texto?.Length > 18) texto = texto.Substring(0, 18) + "...";
                                    g.DrawString(texto, fuenteTexto, brush, x, y);
                                    x += 140;
                                }

                                y += 20;
                                filasDibujadas++;

                                if (filasDibujadas >= filasPorPagina)
                                {
                                    
                                    filaInicio = i + 1;
                                    ev.HasMorePages = true;
                                    return;
                                }
                            }


                            y += 30;
                            g.DrawString("Gráfico de Ventas:", fuenteNegrita, brush, 20, y);
                            y += 20;

                            if (File.Exists(rutaGrafico))
                            {
                                using (Image grafico = Image.FromFile(rutaGrafico))
                                {
                                    int maxAncho = 760;
                                    int maxAlto = 400;
                                    double ratio = Math.Min((double)maxAncho / grafico.Width, (double)maxAlto / grafico.Height);
                                    int anchoFinal = (int)(grafico.Width * ratio);
                                    int altoFinal = (int)(grafico.Height * ratio);
                                    int xCentrado = (900 - anchoFinal) / 2;
                                    g.DrawImage(grafico, xCentrado, y, anchoFinal, altoFinal);
                                }
                            }

                            ev.HasMorePages = false;
                        };

                        pd.PrintController = new StandardPrintController();
                        pd.Print();
                    }

                    MessageBox.Show("PDF exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (File.Exists(rutaPDF))
                        Process.Start(rutaPDF);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void cboTipoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvVentas.DataSource is List<DtoVenta> ventas)
            {
                ActualizarMetricas(ventas);
            }
        }

        private void pnlFunciones_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, pnlFunciones.Width - 1, pnlFunciones.Height - 1);
            }
        }

        private void frmReportes_Shown(object sender, EventArgs e)
        {
            this.Size = _formSizeInicial;
            this.ActiveControl = null;
        }

        private void pnlGrafico_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, pnlGrafico.Width - 1, pnlGrafico.Height - 1);
            }
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
