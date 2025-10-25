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
                ReadOnly = true // <--- ¡Importante!
            });

            // 2. Columna Fecha (solo lectura)
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "FechaVenta",
                ReadOnly = true // <--- ¡Importante!
            });

            // 3. Columna Cliente (solo lectura)
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cliente",
                DataPropertyName = "ClienteNombre",
                ReadOnly = true // <--- ¡Importante!
            });

            // 4. Columna Vendedor (solo lectura)
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Vendedor",
                DataPropertyName = "VendedorUserName",
                ReadOnly = true // <--- ¡Importante!
            });

            // 5. Columna Monto Final (solo lectura)
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Monto Final",
                DataPropertyName = "MontoFinal",
                ReadOnly = true // <--- ¡Importante!
            });

            // Columna de Observaciones (solo lectura, si la quieres mostrar)
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Observaciones",
                DataPropertyName = "Observaciones",
                ReadOnly = true
            });


            // 6. Columna ComboBox para el Estado (Editable - ReadOnly por defecto es false)
            DataGridViewComboBoxColumn estadoColumna = new DataGridViewComboBoxColumn
            {
                HeaderText = "Estado",
                Name = "ColEstadoVenta",
                DataPropertyName = "IdEstadoVenta",
                ValueMember = "IdEstadoVenta",
                DisplayMember = "Estado",
                DataSource = _estadosVenta,
                // ReadOnly = false (valor por defecto)
            };
            dgvVentas.Columns.Add(estadoColumna);

            // 7. Columna para el nombre del estado (solo lectura)
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estado Actual",
                DataPropertyName = "EstadoVenta",
                ReadOnly = true // <--- ¡Importante!
            });





            List<DtoVenta> listaCompleta = _ventas.ObtenerTodasLasVentas();
            dgvVentas.DataSource = listaCompleta;
            
        }

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            // Asegurarse de que cualquier edición pendiente se comite
            dgvVentas.EndEdit();

            // Obtenemos la lista de ventas enlazada
            List<DtoVenta> listaVentas = dgvVentas.DataSource as List<DtoVenta>;

            if (listaVentas == null || listaVentas.Count == 0)
            {
                MessageBox.Show("No hay datos para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 1. Iterar sobre todos los DTOs enlazados
                foreach (DtoVenta venta in listaVentas)
                {
                    // Usamos el IdVenta y el IdEstadoVenta del DTO, que fue modificado por el ComboBox
                    int idVenta = venta.IdVenta;
                    int? nuevoIdEstado = venta.IdEstadoVenta;

                    // 2. Llamar al SP para guardar si hay un ID de estado válido.
                    // La base de datos se encargará de actualizar solo si hay un cambio.
                    if (nuevoIdEstado.HasValue)
                    {
                        _ventas.GuardarEstadoVenta(idVenta, nuevoIdEstado.Value);

                        // NOTA: Si quieres volver al modelo de 'detección de cambios'
                        // para evitar llamadas innecesarias al SP, usa la lógica de 
                        // IdEstadoVentaOriginal. Pero para simplicidad, llamamos al SP aquí.
                    }
                }

                // 3. Mostrar el mensaje de éxito genérico (ya que se procesaron las filas)
                MessageBox.Show("El estado de las ventas se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Recargar la grilla para refrescar los nombres de estado
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
                List<DtoVenta> listaCompleta = _ventas.ObtenerTodasLasVentas();
                dgvVentas.DataSource = null; // Limpiar antes de reasignar
                dgvVentas.DataSource = listaCompleta;
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
    }
}
