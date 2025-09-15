using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            cboUsuarios.DataSource = _ventas.ObtenerUsuariosConVentas();
            cboUsuarios.DisplayMember = "User";   // o "NombreCompleto" si lo tenés en el DTO
            cboUsuarios.ValueMember = "Id_user";
            cboUsuarios.SelectedIndex = -1;

            cboClientes.DataSource = _ventas.ObtenerClientes();
            cboClientes.DisplayMember = "Nombre";
            cboClientes.ValueMember = "Id_Cliente";
            cboClientes.SelectedIndex = -1;

            // Arrancar con los DateTimePicker deshabilitados
            chkUsarFechas.Checked = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;


            // Obtener la lista de ventas completa
            List<DtoVenta> listaCompleta = _ventas.ObtenerTodasLasVentas();

            // Asignar esa lista al DataGridView (tu línea de código actual)
            dgvVentas.DataSource = listaCompleta;

            // Actualizar la etiqueta con el conteo de esa misma lista
            lblTotalVentas.Text = $"Total de Ventas: {listaCompleta.Count}";


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
                hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);
            }

            int? idUser = cboUsuarios.SelectedIndex >= 0 ? (int?)Convert.ToInt32(cboUsuarios.SelectedValue) : null;
            int? idCliente = cboClientes.SelectedIndex >= 0 ? (int?)Convert.ToInt32(cboClientes.SelectedValue) : null;

            List<DtoVenta> ventas = _ventas.FiltrarVentas(desde, hasta, idUser, idCliente);

            dgvVentas.DataSource = ventas;

            lblTotalVentas.Text = $"Total de Ventas: {ventas.Count}";

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar combos
            cboUsuarios.SelectedIndex = -1;
            cboClientes.SelectedIndex = -1;

            // Limpiar check y fechas
            chkUsarFechas.Checked = false;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;

            // Obtener la lista completa de ventas
            List<DtoVenta> ventasCompletas = _ventas.ObtenerTodasLasVentas();

            // Asignar la lista al DataGridView
            dgvVentas.DataSource = ventasCompletas;

            // ¡Actualizar la etiqueta con el conteo de la lista completa!
            lblTotalVentas.Text = $"Total de Ventas: {ventasCompletas.Count}";
        }

        private void chkBuscarPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            bool habilitar = chkUsarFechas.Checked;

            dtpDesde.Enabled = habilitar;
            dtpHasta.Enabled = habilitar;
        }
    }
}
