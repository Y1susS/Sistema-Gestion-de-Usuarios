using Entidades.DTOs;
using Logica;
using Sistema_Gestion_de_Usuarios.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmBuscarPresupuesto : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private CL_Presupuesto clPresupuesto = new CL_Presupuesto();
        public DtoPresupuestoFiltro PresupuestoSeleccionado { get; private set; }
        private CL_TipoDoc _logicaTipoDoc = new CL_TipoDoc();


        public frmBuscarPresupuesto()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            ConfigurarDataGrid();
            ConfigurarControles();
            clPresupuesto.ActualizarEstadosVencidos();

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblTitulo);
        }

        private void ConfigurarControles()
        {
            var tiposDocumento = _logicaTipoDoc.MostrarTiposDocumento();
            if (cmbTipoDni != null) 
            {
                cmbTipoDni.DataSource = tiposDocumento;
                cmbTipoDni.DisplayMember = "Id_TipoDocumento";
                cmbTipoDni.ValueMember = "Id_TipoDocumento";
                cmbTipoDni.SelectedIndex = -1;
            }
        }


        private void ConfigurarDataGrid()
        {
            dgvPresupuestos.AutoGenerateColumns = false;
            dgvPresupuestos.AllowUserToAddRows = false;
            dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPresupuestos.MultiSelect = false;
            dgvPresupuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvPresupuestos.Columns.Clear();

            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NumeroPresupuesto",
                HeaderText = "N° Presupuesto",
                ReadOnly = true
            });

            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ClienteNombreCompleto",
                HeaderText = "Cliente",
                ReadOnly = true
            });

            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Observaciones",
                HeaderText = "Observaciones",
                ReadOnly = true
            });

            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaValidez",
                HeaderText = "Vigencia",
                ReadOnly = true,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MontoFinal",
                HeaderText = "Monto Final",
                ReadOnly = true,
                DefaultCellStyle = { Format = "N2" }
            });

            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "EstadoPresupuesto",
                HeaderText = "Estado",
                ReadOnly = true
            });
        }
        private void btnBuscarPresup_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = string.IsNullOrEmpty(txtDescripcion.Text.Trim()) ? null : txtDescripcion.Text.Trim();
                string vendedor = string.IsNullOrEmpty(txtVendedor.Text.Trim()) ? null : txtVendedor.Text.Trim();
                string documento = string.IsNullOrEmpty(txtDocumento.Text.Trim()) ? null : txtDocumento.Text.Trim();

                DateTime? fechaValidez = dtpFecha.Value;

                List<DtoPresupuestoFiltro> resultados = clPresupuesto.FiltrarPresupuestos(
                    descripcion,
                    fechaValidez,
                    vendedor,
                    documento
                );

                dgvPresupuestos.DataSource = resultados;

                if (resultados == null || resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron presupuestos que coincidan con los filtros.", "Búsqueda Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar presupuestos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionPresup_Click(object sender, EventArgs e)
        {
            if (dgvPresupuestos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvPresupuestos.SelectedRows[0];
                this.PresupuestoSeleccionado = filaSeleccionada.DataBoundItem as DtoPresupuestoFiltro;

                if (this.PresupuestoSeleccionado != null)
                {
                    this.DialogResult = DialogResult.OK;

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un presupuesto de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscarPresup.PerformClick();
            }
        }

        private void txtVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscarPresup.PerformClick();
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscarPresup.PerformClick();
            }
        }

        private void pnlOpciones_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarRectangulo(sender as Control, e, Color.White, 1f);
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
