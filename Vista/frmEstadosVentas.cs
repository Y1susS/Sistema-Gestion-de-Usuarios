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
    public partial class frmEstadosVentas : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private readonly CL_Ventas _ventas;
        private List<DtoEstadoVenta> _estadosVenta;
        private List<DtoVenta> _todaslasventas;
        public frmEstadosVentas()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
            this.AcceptButton = btnActualizarEstado;
            moverFormulario = new ClsArrastrarFormularios(this);
            _ventas = new CL_Ventas();
        }

        private void frmEstadosVentas_Load(object sender, EventArgs e)
        {
            _estadosVenta = _ventas.ObtenerEstadosVenta();

            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.Columns.Clear();

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID Venta",
                DataPropertyName = "IdVenta",
                Visible = false,
                ReadOnly = true 
            });

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "FechaVenta",
                ReadOnly = true 
            });

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cliente",
                DataPropertyName = "ClienteNombre",
                ReadOnly = true 
            });

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Vendedor",
                DataPropertyName = "VendedorUserName",
                ReadOnly = true 
            });

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Monto Final",
                DataPropertyName = "MontoFinal",
                ReadOnly = true 
            });

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Observaciones",
                DataPropertyName = "Observaciones",
                ReadOnly = true
            });


            DataGridViewComboBoxColumn estadoColumna = new DataGridViewComboBoxColumn
            {
                HeaderText = "Estado",
                Name = "ColEstadoVenta",
                DataPropertyName = "IdEstadoVenta",
                ValueMember = "IdEstadoVenta",
                DisplayMember = "Estado",
                DataSource = _estadosVenta,
            };
            dgvVentas.Columns.Add(estadoColumna);

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estado Actual",
                DataPropertyName = "EstadoVenta",
                ReadOnly = true 
            });


            
            _todaslasventas = _ventas.ObtenerTodasLasVentas();
            dgvVentas.DataSource = _todaslasventas;

        }

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            dgvVentas.EndEdit();

            List<DtoVenta> listaVentas = dgvVentas.DataSource as List<DtoVenta>;

            if (listaVentas == null || listaVentas.Count == 0)
            {
                MessageBox.Show("No hay datos para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                foreach (DtoVenta venta in listaVentas)
                {
                    int idVenta = venta.IdVenta;
                    int? nuevoIdEstado = venta.IdEstadoVenta;

                    if (nuevoIdEstado.HasValue)
                    {
                        _ventas.GuardarEstadoVenta(idVenta, nuevoIdEstado.Value);
                    }
                }

                MessageBox.Show("El estado de las ventas se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RecargarVentas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los estados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecargarVentas()
        {
            try
            {
                _todaslasventas = _ventas.ObtenerTodasLasVentas();
                dgvVentas.DataSource = null;
                dgvVentas.DataSource = _todaslasventas;
            }
            catch (Exception ex)    
            {
                MessageBox.Show("Error al recargar la lista de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEstadosVentas_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.AcceptButton = btnActualizarEstado;
        }

        private void pnlBuscar_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarRectangulo(sender as Control, e, Color.White, 1f);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarPorCliente();
        }

        private void FiltrarPorCliente()
        {
            if (_todaslasventas == null) return;

            string texto = txtBuscar.Text.Trim().ToLower();

            // Si el cuadro está vacío, mostramos todo
            if (string.IsNullOrEmpty(texto))
            {
                dgvVentas.DataSource = _todaslasventas;
                return;
            }

            // Filtramos por coincidencia parcial en el nombre del cliente
            var filtradas = _todaslasventas
                .Where(v => !string.IsNullOrEmpty(v.ClienteNombre) &&
                            v.ClienteNombre.ToLower().Contains(texto))
                .ToList();

            dgvVentas.DataSource = filtradas;
        }

    }
}
