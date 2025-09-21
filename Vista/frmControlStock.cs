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
using Entidades.DTOs;
using Servicios;

namespace Vista
{
    public partial class frmControlStock : Form
    {
        public CL_Materiales logicaMaterial = new CL_Materiales();
        DtoMaterial nuevoMaterial = new DtoMaterial();
        private DtoMaterial materialSeleccionado;
        private bool modoNuevo = false;
        private bool modoGestion = false;


        public frmControlStock()
        {
            InitializeComponent();
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
            cmbMaterial.Enabled = false;
            cmbTipoMaterial.Enabled = false;
            cmbTipoMaterial.DropDownStyle = ComboBoxStyle.DropDownList;


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
            materialSeleccionado = null;
        }
        private void HabilitarControlesDeEdicion(bool habilitar)
        {
            cmbTipoMaterial.Enabled = habilitar;
            cmbMaterial.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            txtUnidad.Enabled = habilitar;
            txtPrecioUnitario.Enabled = habilitar;
            txtStockActual.Enabled = habilitar;
            txtStockMinimo.Enabled = habilitar;
            cbxActivo.Enabled = habilitar;
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene el objeto DTO de la fila
                materialSeleccionado = (DtoMaterial)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Habilitar los controles para la edición y mostrar los datos
                HabilitarControlesDeEdicion(true);
                MostrarDatosEnFormulario(materialSeleccionado);

                // Habilita botones de acción para la gestión
                btnGuardar.Enabled = true;
                cmbMaterial.Enabled = true;

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
                List<DtoTipoMaterial> listaMateriales = logicaMaterial.ListarTiposMateriales();
                //List<DtoTipoMaterial> listaTipos = new List<DtoTipoMaterial>();


                //foreach (var material in listaMateriales)
                //{
                //    if (!listaTipos.Any(t => t.IdTipoMaterial == material.TipoMaterial.IdTipoMaterial))
                //    {
                //        listaTipos.Add(material.TipoMaterial);
                //    }
                //}

                cmbTipoMaterial.DataSource = listaMateriales;
                cmbTipoMaterial.DisplayMember = "NombreTipoMaterial";
                cmbTipoMaterial.ValueMember = "IdTipoMaterial";
                cmbTipoMaterial.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de material: " + ex.Message);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGestion_Click(object sender, EventArgs e)
        {
            modoGestion = true;
            modoNuevo = false;
            lblMensajeBoton.Text = "Estas en el modo de Gestión de Materiales. Filtrá el Tipo de Material y después editalo seleccionándolo en la tabla";

            // 1. Preguntar si hay datos para limpiar
            if (HayDatosParaLimpiar())
            {
                DialogResult resultado = MessageBox.Show("Estas ingresando al Modo Gestion de Materiales. Se perderán los cambios no guardados.", "Confirmar ingreso al modo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.No)
                {
                    return; // No hace nada si el usuario cancela
                }
            }
            {
                LlenarComboBoxTipoMaterial();
                cmbTipoMaterial.Enabled = true;
                cmbMaterial.DataSource = null;
                dataGridView1.DataSource = null;
            }
        }

        private void cmbTipoMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
               
                if (cmbTipoMaterial.SelectedValue == null || !(cmbTipoMaterial.SelectedValue is int))
                    return;
                {
                    try
                    {
                        int idTipoMaterial = Convert.ToInt32(cmbTipoMaterial.SelectedValue);

                        List<DtoMaterial> materialesFiltrados = logicaMaterial.ListarMaterialesPorTipo(idTipoMaterial);

                        dataGridView1.DataSource = materialesFiltrados;

                        CargarGrillaDeMateriales();
                        LlenarCmbMaterialConFiltro(materialesFiltrados);
                        if (modoNuevo)
                        {
                            dataGridView1.DataSource = null;
                            return;
                        }
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
            // Esta es la validación para saber si el usuario está modificando un material existente.
            if (materialSeleccionado != null)
            {
                // Funcionalidad de MODIFICAR (tu código actual)
                try
                {
                    materialSeleccionado.Descripcion = txtDescripcion.Text;
                    materialSeleccionado.Unidad = txtUnidad.Text;
                    materialSeleccionado.NombreMaterial = cmbMaterial.Text.Trim();


                    // Manejo de valores para campos opcionales
                    materialSeleccionado.PrecioUnitario = decimal.TryParse(txtPrecioUnitario.Text, out decimal precio) ? precio : (decimal?)null;
                    materialSeleccionado.StockActual = decimal.TryParse(txtStockActual.Text, out decimal stockActual) ? stockActual : (decimal?)null;
                    materialSeleccionado.StockMinimo = decimal.TryParse(txtStockMinimo.Text, out decimal stockMinimo) ? stockMinimo : (decimal?)null;
                    materialSeleccionado.FechaActualizacion = DateTime.Now;
                    materialSeleccionado.Activo = cbxActivo.Checked;
                    logicaMaterial.ValidarMaterialVista(materialSeleccionado);

                    logicaMaterial.ModificarMaterial(materialSeleccionado);

                    MessageBox.Show("¡Material modificado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresca la grilla si hay un tipo de material seleccionado
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
                    MessageBox.Show("Error en la validación: " + ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Esta es la nueva sección que maneja la inserción de un nuevo material.
            else if (modoNuevo)
            {
                // Funcionalidad de INSERTAR (el código que necesitas agregar)

                try
                {
                    // Validaciones para el nuevo material
                    //if (string.IsNullOrWhiteSpace(cmbMaterial.Text))
                    //{
                    //    MessageBox.Show("El nombre del material es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    if (cmbTipoMaterial.SelectedValue == null || cmbTipoMaterial.SelectedValue is int idTipoMaterial && idTipoMaterial <= 0)
                    {
                        MessageBox.Show("Debe seleccionar un tipo de material válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Asigna los valores del formulario al nuevo DTO
                    nuevoMaterial.NombreMaterial = cmbMaterial.Text.Trim();
                    nuevoMaterial.Descripcion = txtDescripcion.Text.Trim();
                    nuevoMaterial.Unidad = txtUnidad.Text.Trim();
                    nuevoMaterial.PrecioUnitario = decimal.TryParse(txtPrecioUnitario.Text, out decimal precio) ? precio : (decimal?)0;
                    nuevoMaterial.StockActual = decimal.TryParse(txtStockActual.Text, out decimal stockActual) ? stockActual : (decimal?)0;
                    nuevoMaterial.StockMinimo = decimal.TryParse(txtStockMinimo.Text, out decimal stockMinimo) ? stockMinimo : (decimal?)0;
                    nuevoMaterial.FechaActualizacion = DateTime.Now;
                    nuevoMaterial.Activo = cbxActivo.Checked;
                    nuevoMaterial.TipoMaterial = new DtoTipoMaterial
                    {
                        IdTipoMaterial = Convert.ToInt32(cmbTipoMaterial.SelectedValue)
                    };
                    logicaMaterial.ValidarMaterialVista(nuevoMaterial);
                    // Llama al método de la capa lógica para dar de alta el material
                    int idNuevoMaterial = logicaMaterial.AltaMaterial(nuevoMaterial);

                    // Muestra mensaje de éxito y restablece el formulario.
                    MessageBox.Show($"Acabas de cargar un nuevo material: '{nuevoMaterial.NombreMaterial}.'", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMaterial.DataSource = null;
                    cmbMaterial.Text = string.Empty;
                    EstablecerEstadoInicial();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el nuevo material: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Si no es ni un material seleccionado ni el modo nuevo, se muestra este mensaje.
            else
            {
                MessageBox.Show("Debe estar en modo 'Nuevo' o seleccionar un material para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LlenarCmbMaterialConFiltro(List<DtoMaterial> materiales)
        {
            try
            {
                // Limpia cualquier selección previa
                cmbMaterial.DataSource = null;

                if (materiales != null && materiales.Count > 0)
                {
                    cmbMaterial.DataSource = materiales;
                    cmbMaterial.DisplayMember = "NombreMaterial";
                    cmbMaterial.ValueMember = "IdMaterial";
                    cmbMaterial.Enabled = true;
                    cmbMaterial.SelectedIndex = -1;

                }
                else
                {
                    // Si no hay materiales, deshabilita y limpia el ComboBox
                    cmbMaterial.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los materiales en el ComboBox: " + ex.Message);
            }
        }
         private void btnNuevoMaterial_Click(object sender, EventArgs e)
        {
            modoNuevo = true;
            modoGestion = false;
            lblMensajeBoton.Text = "Podes cargar un Nuevo Material. Seleccioná un Tipo de Material y carga los parametros en los campos";
            cmbMaterial.DropDownStyle = ComboBoxStyle.Simple;

            // 1. Preguntar si hay datos para limpiar
            if (HayDatosParaLimpiar())
            {
                DialogResult resultado = MessageBox.Show("Estas ingresando al Modo de Nuevo Material. Se perderán los cambios no guardados.", "Confirmar limpieza", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.No)
                {
                    return; // No hace nada si el usuario cancela
                }
            }

            // 2. Limpiar el formulario y habilitar los campos de edición
            LimpiarFormularioParaNuevoMaterial();
            LlenarComboBoxTipoMaterial();
            cmbTipoMaterial.Enabled = true;
            dataGridView1.DataSource = null;
        }
        private void LimpiarFormularioParaNuevoMaterial()
        {
            // Resetea todos los controles de entrada de datos a sus valores iniciales
            LimpiarControles();
            HabilitarControlesDeEdicion(true);

            // Deshabilita los controles del modo de gestión
            dataGridView1.Enabled = false;
            cmbTipoMaterial.Enabled = true; // El tipo de material es necesario para un nuevo registro
            btnGestion.Enabled = true;
            cmbMaterial.DataSource = null; // Limpia el contenido del ComboBox de materiales

            // Habilita el botón de guardar
            btnGuardar.Enabled = true;

            // Puedes agregar una bandera para saber en qué modo estás
            // private bool modoNuevo = true;
        }

        private bool HayDatosParaLimpiar()
        {
            // Verifica si algún campo de texto, ComboBox, etc., tiene datos ingresados
            if (!string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                !string.IsNullOrWhiteSpace(txtUnidad.Text) ||
                cmbTipoMaterial.SelectedIndex != -1 ||
                cmbMaterial.SelectedIndex != -1)
            {
                return true;
            }
            return false;
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsSoloNumeros.ValidarNroDecimales(e, txtPrecioUnitario);
        }

        private void txtStockActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsSoloNumeros.ValidarNroDecimales(e, txtStockActual);

        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsSoloNumeros.ValidarNroDecimales(e, txtStockMinimo);

        }
    }
}       

