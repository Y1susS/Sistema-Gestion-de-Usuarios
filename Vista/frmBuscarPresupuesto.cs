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
        private CL_Presupuesto clPresupuesto = new CL_Presupuesto();
        public DtoPresupuestoFiltro PresupuestoSeleccionado { get; private set; }


        public frmBuscarPresupuesto()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            ConfigurarDataGrid();
        }

        private void ConfigurarDataGrid()
        {
            dgvPresupuestos.AutoGenerateColumns = false;
            dgvPresupuestos.AllowUserToAddRows = false;
            dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPresupuestos.Columns.Clear();

            // 1. Número de presupuesto
            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NumeroPresupuesto",
                HeaderText = "N° Presupuesto",
                Width = 120,
                ReadOnly = true
            });

            // 2. Nombre y apellido de cliente
            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ClienteNombreCompleto",
                HeaderText = "Cliente",
                Width = 200,
                ReadOnly = true
            });

            // 3. Observaciones
            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Observaciones",
                HeaderText = "Observaciones",
                Width = 150,
                ReadOnly = true
            });

            // 4. Fecha de validez
            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaValidez",
                HeaderText = "Vigencia",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            // 5. Monto final
            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MontoFinal",
                HeaderText = "Monto Final",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = { Format = "C2" }
            });

            // 6. Estado de presupuesto
            dgvPresupuestos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "EstadoPresupuesto",
                HeaderText = "Estado",
                Width = 150,
                ReadOnly = true
            });
        }
        private void btnBuscarPresup_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener los parámetros de filtro
                string descripcion = string.IsNullOrEmpty(txtDescripcion.Text.Trim()) ? null : txtDescripcion.Text.Trim();
                string vendedor = string.IsNullOrEmpty(txtVendedor.Text.Trim()) ? null : txtVendedor.Text.Trim();
                string documento = string.IsNullOrEmpty(txtDocumento.Text.Trim()) ? null : txtDocumento.Text.Trim();

                // El control DateTimePicker siempre tiene un valor. 
                // Si quieres que sea opcional, puedes usar un CheckBox asociado 
                // o un valor Sentinel. Aquí lo pasaremos como valor.
                DateTime? fechaValidez = dtpFecha.Value;

                // 2. Llamar a la Lógica de Negocio
                List<DtoPresupuestoFiltro> resultados = clPresupuesto.FiltrarPresupuestos(
                    descripcion,
                    fechaValidez,
                    vendedor,
                    documento
                );

                // 3. Cargar resultados en el DataGrid
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
                // 1. Obtener el objeto DTO de la fila seleccionada
                var filaSeleccionada = dgvPresupuestos.SelectedRows[0];
                this.PresupuestoSeleccionado = filaSeleccionada.DataBoundItem as DtoPresupuestoFiltro;

                if (this.PresupuestoSeleccionado != null)
                {
                    // 2. Establecer el resultado del diálogo en OK
                    this.DialogResult = DialogResult.OK;

                    // 3. Cerrar el formulario de búsqueda
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un presupuesto de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
