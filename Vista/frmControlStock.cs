using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Entidades;
using Entidades.DTOs;

namespace Vista
{
    public partial class frmControlStock : Form
    {
        public CL_Materiales logicaMaterial = new CL_Materiales();
        private DtoMaterial materialSeleccionado;

        public frmControlStock()
        {
            InitializeComponent();
            //CargarGrillaDeMateriales();
            //LlenarComboBoxMaterial(); VER deshabilitado para gestionmaterial
            LlenarComboBoxTipoMaterial();
            EstablecerEstadoInicial();

        }
        private void EstablecerEstadoInicial()
        {
            // Limpiar el contenido de la grilla
            dataGridView1.DataSource = null;

            // Limpiar y deshabilitar todos los controles de edición
            LimpiarControles();
            HabilitarControlesDeEdicion(false);

            // Habilitar solo los botones de acción iniciales
            btnNuevoMaterial.Enabled = true;
            btnGestion.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        private void LimpiarControles()
        {
            // Reinicia los campos a sus valores predeterminados
            cmbTipoMaterial.SelectedIndex = -1;
            cmbMaterial.SelectedIndex = -1; // o cmbMaterial.Text = string.Empty; si es un ComboBox de texto
            txtDescripcion.Clear();
            txtUnidad.Clear();
            txtPrecioUnitario.Clear();
            txtStockActual.Clear();
            txtStockMinimo.Clear();
            cbxActivo.Checked = false;
            dtpFeActualizacion.Format = DateTimePickerFormat.Custom;
            dtpFeActualizacion.CustomFormat = " ";
            materialSeleccionado = null;
        }
        private void HabilitarControlesDeEdicion(bool habilitar)
        {
            // Controla la habilitación de todos los campos de edición
            cmbTipoMaterial.Enabled = habilitar;
            cmbMaterial.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            txtUnidad.Enabled = habilitar;
            txtPrecioUnitario.Enabled = habilitar;
            txtStockActual.Enabled = habilitar;
            txtStockMinimo.Enabled = habilitar;
            cbxActivo.Enabled = habilitar;
            dtpFeActualizacion.Enabled = habilitar;
        }

        private void CargarGrillaDeMateriales()
        {
            // Orden Datagrid
            var columnasConfiguracion = new List<(string Name, string Header)>
            {
                ("Activo", "Activo"),
                ("TipoMaterial", "Tipo de Material"),
                ("NombreMaterial", "Material"),
                ("Descripcion", "Descripción"),
                ("Unidad", "Unidad"),
                ("PrecioUnitario", "Precio Unitario"),
                ("StockActual", "Stock Actual"),
                ("StockMinimo", "Stock Mínimo"),
                ("FechaActualizacion", "Fecha de Actualización")
            };

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Visible = false;
            }

            int displayIndex = 0;
            foreach (var config in columnasConfiguracion)
            {
                if (dataGridView1.Columns.Contains(config.Name))
                {
                    var columna = dataGridView1.Columns[config.Name];
                    columna.Visible = true;
                    columna.HeaderText = config.Header;
                    columna.DisplayIndex = displayIndex;
                    displayIndex++;
                }
            }

            if (dataGridView1.Columns.Contains("IdMaterial"))
            {
                dataGridView1.Columns["IdMaterial"].Visible = false;
            }

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.ReadOnly = true;
        }

        private void btnNuevoMaterial_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene el objeto DTO de la fila
                materialSeleccionado = (DtoMaterial)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Habilitar los controles para la edición y mostrar los datos
                HabilitarControlesDeEdicion(true);
                MostrarDatosEnFormulario(materialSeleccionado);

                // Habilitar botones de acción para la gestión
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void MostrarDatosEnFormulario(DtoMaterial material)
        {
            if (material != null)
            {
                txtDescripcion.Text = material.Descripcion;
                txtUnidad.Text = material.Unidad;
                txtPrecioUnitario.Text = material.PrecioUnitario?.ToString();
                txtStockActual.Text = material.StockActual?.ToString();
                txtStockMinimo.Text = material.StockMinimo?.ToString();
                cbxActivo.Checked = material.Activo;
                dtpFeActualizacion.Value = material.FechaActualizacion ?? DateTime.Now; // Usa DateTime.Now si el valor es nulo

                if (material.TipoMaterial != null && material.TipoMaterial.IdTipoMaterial > 0)
                {
                    cmbTipoMaterial.SelectedValue = material.TipoMaterial.IdTipoMaterial;
                }
                if (material.IdMaterial > 0)
                {
                    cmbMaterial.SelectedValue = material.IdMaterial;
                }
            }
        }
        private void LlenarComboBoxTipoMaterial()
        {
            try
            {
                List<DtoMaterial> listaMateriales = logicaMaterial.ListarMateriales();
                List<DtoTipoMaterial> listaTipos = new List<DtoTipoMaterial>();

                foreach (var material in listaMateriales)
                {
                    if (!listaTipos.Any(t => t.IdTipoMaterial == material.TipoMaterial.IdTipoMaterial))
                    {
                        listaTipos.Add(material.TipoMaterial);
                    }
                }

                cmbTipoMaterial.DataSource = listaTipos;
                cmbTipoMaterial.DisplayMember = "NombreTipoMaterial";
                cmbTipoMaterial.ValueMember = "IdTipoMaterial";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de material: " + ex.Message);
            }
        }
        private void LlenarComboBoxMaterial()
        {
            try
            {
                List<DtoMaterial> listaMateriales = logicaMaterial.ListarMateriales();
                cmbMaterial.DataSource = listaMateriales;
                cmbMaterial.DisplayMember = "NombreMaterial"; 
                cmbMaterial.ValueMember = "IdMaterial";
                cmbMaterial.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los materiales: " + ex.Message);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //GESTIONAR MATERIAL
        private void btnGestion_Click(object sender, EventArgs e)
        {
            {
                EstablecerEstadoInicial();

                // Habilitar solo el ComboBox de tipo de material para el filtro
                cmbTipoMaterial.Enabled = true;

                // Desactivar el botón de Nuevo para que no se superpongan las funcionalidades
                btnNuevoMaterial.Enabled = false;

                // Limpiar el ComboBox de Material, ya que se llenará dinámicamente
                cmbMaterial.DataSource = null;

                // Dejar la grilla vacía hasta que se seleccione un tipo
                dataGridView1.DataSource = null;
            }
        }

        private void cmbTipoMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {// Solo si estamos en el modo de gestión (btnGestion está deshabilitado)
            if (!btnNuevoMaterial.Enabled)
            {
                // Si hay un tipo de material seleccionado
                if (cmbTipoMaterial.SelectedValue != null)
                {
                    try
                    {
                        int idTipoMaterial = Convert.ToInt32(cmbTipoMaterial.SelectedValue);

                        // Llama a la capa de lógica para filtrar los materiales por tipo
                        List<DtoMaterial> materialesFiltrados = logicaMaterial.ListarMaterialesPorTipo(idTipoMaterial);

                        // Llena la grilla con el resultado
                        dataGridView1.DataSource = materialesFiltrados;

                        // Restablecer las configuraciones de la grilla (orden, etc.)
                        CargarGrillaDeMateriales();
                        LlenarComboBoxMaterial();

                        // Habilitar la selección en la grilla
                        dataGridView1.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al filtrar materiales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(materialSeleccionado != null)
            {
                try
                {
                    // 1. Mapear los datos del formulario al DTO
                    materialSeleccionado.Descripcion = txtDescripcion.Text;
                    materialSeleccionado.Unidad = txtUnidad.Text;

                    // Manejo de valores nulos o no numéricos para campos opcionales
                    materialSeleccionado.PrecioUnitario = decimal.TryParse(txtPrecioUnitario.Text, out decimal precio) ? precio : (decimal?)null;
                    materialSeleccionado.StockActual = decimal.TryParse(txtStockActual.Text, out decimal stockActual) ? stockActual : (decimal?)null;
                    materialSeleccionado.StockMinimo = decimal.TryParse(txtStockMinimo.Text, out decimal stockMinimo) ? stockMinimo : (decimal?)null;

                    materialSeleccionado.Activo = cbxActivo.Checked;
                    materialSeleccionado.FechaActualizacion = dtpFeActualizacion.Value;

                    // 2. Llamar a la capa de lógica para guardar los cambios
                    logicaMaterial.ModificarMaterial(materialSeleccionado);

                    // 3. Manejar la respuesta y actualizar la grilla
                    MessageBox.Show("¡Material modificado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (cmbTipoMaterial.SelectedValue != null)
                    {
                        int idTipoMaterial = Convert.ToInt32(cmbTipoMaterial.SelectedValue);
                        List<DtoMaterial> materialesFiltrados = logicaMaterial.ListarMaterialesPorTipo(idTipoMaterial);
                        dataGridView1.DataSource = materialesFiltrados;
                        CargarGrillaDeMateriales();
                    }
                }
                catch (ApplicationException ex)
                {
                    // Captura las excepciones de la capa de lógica y muestra el mensaje al usuario
                    MessageBox.Show("Error en la validación: " + ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un material para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
