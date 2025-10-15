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
using Entidades;
using Servicios; // Agregar using para Servicios

namespace Vista
{
    public partial class frmCotizador : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private readonly CL_Cotizacion logicaCotizacion = new CL_Cotizacion();
        private readonly CL_Materiales logicaMateriales = new CL_Materiales();
        private List<DtoCotizacionDetalle> detallesCotizacion = new List<DtoCotizacionDetalle>();
        private List<DtoCotizacionDetalleVidrio> detallesVidrio = new List<DtoCotizacionDetalleVidrio>(); // NUEVO
        private List<DtoCotizacionMaterial> materialesVarios = new List<DtoCotizacionMaterial>(); // NUEVO

        // Clase auxiliar para mantener estado
        private static class ViewState
        {
            public static DtoCotizacion CotizacionActual { get; set; }
        }

        public frmCotizador()
        {
            InitializeComponent();

            // CONFIGURAR FORMATO ESPAÑOL PARA DECIMALES
            ClsSoloNumeros.ConfigurarCulturaEspañola();

            moverFormulario = new ClsArrastrarFormularios(this);
        }

        private void frmCotizador_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                CargarTodosLosCombos();
                OcultarLabelsResultados();
                ConfigurarValidacionesCampos();
                ConfigurarEventosCombos();
            }
            catch
            {
                MessageBox.Show($"Error al cargar el formulario.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarFormulario()
        {
            int maxWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int maxHeight = Screen.PrimaryScreen.WorkingArea.Height;

            if (this.Width > maxWidth) this.Width = maxWidth;
            if (this.Height > maxHeight) this.Height = maxHeight;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Método principal para cargar todos los ComboBoxes del formulario de forma segura
        private void CargarTodosLosCombos()
        {
            try
            {
                // Cargar combos usando métodos específicos
                CargarComboMaderas();
                CargarComboVidrios();
                CargarCombosTiposMateriales();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los combos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga maderas de forma segura con manejo de errores
        private void CargarComboMaderas()
        {
            try
            {
                var maderas = logicaMateriales.ListarMaderas();
                AsignarDatosACombo("cmbMaderas", maderas, "NombreMaterial", "IdMaterial");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar maderas: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Carga vidrios de forma segura with error handling
        private void CargarComboVidrios()
        {
            try
            {
                var vidrios = logicaMateriales.ListarVidrios();

                var nombresComboVidrios = new[] { "cmbVidrio1", "cmbVidrio2", "cmbVidrio3" };

                foreach (var nombreCombo in nombresComboVidrios)
                {
                    AsignarDatosACombo(nombreCombo, new List<DtoMaterial>(vidrios), "NombreMaterial", "IdMaterial");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar vidrios: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga tipos de materiales de forma segura
        private void CargarCombosTiposMateriales()
        {
            try
            {
                var tiposMateriales = logicaMateriales.ListarTiposMaterialesVarios();

                var nombresCombosTypesMateriales = new[]
                {
                    "cmbTipoMaterial1", "cmbTipoMaterial2", "cmbTipoMaterial3",
                    "cmbTipoMaterial4", "cmbTipoMaterial5", "cmbTipoMaterial6"
                };

                foreach (var nombreCombo in nombresCombosTypesMateriales)
                {
                    AsignarDatosACombo(nombreCombo, new List<DtoTipoMaterial>(tiposMateriales), "NombreTipoMaterial", "IdTipoMaterial");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de materiales: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método auxiliar para asignar datos a un ComboBox de forma segura
        private void AsignarDatosACombo(string nombreCombo, object dataSource, string displayMember, string valueMember)
        {
            var combo = this.Controls.Find(nombreCombo, true).FirstOrDefault() as ComboBox;
            if (combo != null)
            {
                combo.DataSource = dataSource;
                combo.DisplayMember = displayMember;
                combo.ValueMember = valueMember;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.SelectedIndex = -1;
            }
        }

      

        #region CARGA DE MATERIALES POR TIPO


        // Carga los materiales específicos en el ComboBox correspondiente según el tipo seleccionado
        private void CargarMaterialesPorTipo(int idTipoMaterial, int numeroCombo)
        {
            try
            {
                var materiales = logicaMateriales.ListarMaterialesPorTipo(idTipoMaterial) ?? new List<DtoMaterial>();

                string nombreComboMaterial = $"cmbMaterial{numeroCombo}";
                var combo = this.Controls.Find(nombreComboMaterial, true).FirstOrDefault() as ComboBox;

                if (combo != null)
                {
                    combo.DataSource = null;
                    combo.DisplayMember = "NombreMaterial";
                    combo.ValueMember = "IdMaterial";
                    combo.DataSource = new List<DtoMaterial>(materiales);
                    combo.DropDownStyle = ComboBoxStyle.DropDownList;
                    combo.SelectedIndex = -1;
                    combo.Enabled = materiales.Count > 0;
                }
            }
            catch (Exception ex)
            {
                // Mantener manejo de error sin traza
            }
        }

        // Limpia el ComboBox de materiales correspondiente
        private void LimpiarComboMateriales(int numeroCombo)
        {
            string nombreComboMaterial = $"cmbMaterial{numeroCombo}";
            var combo = this.Controls.Find(nombreComboMaterial, true).FirstOrDefault() as ComboBox;

            if (combo != null)
            {
                combo.DataSource = null;
                combo.Items.Clear();
                combo.Enabled = false;
            }
        }

        #endregion

        #region EVENTOS DE COMBOS

        // Configura los eventos de los ComboBoxes de forma segura
        private void ConfigurarEventosCombos()
        {
            try
            {
                // Evento para mostrar precio cuando se selecciona una madera
                var cmbMaderas = this.Controls.Find("cmbMaderas", true).FirstOrDefault() as ComboBox;
                if (cmbMaderas != null)
                {
                    cmbMaderas.SelectedIndexChanged += CmbMaderas_SelectedIndexChanged;
                }

                // Eventos para cargar materiales cuando se selecciona un tipo (múltiples combos)
                for (int i = 1; i <= 6; i++)
                {
                    ConfigurarEventoComboTipo(i);
                    ConfigurarEventoComboMaterial(i);
                    ConfigurarEventoCantidadMaterial(i); // NUEVO: Configurar eventos de cantidad
                }

                // FIX: Cambiar ConfigurarEventoComboVidrio por Configurar EventoVidrio
                for (int i = 1; i <= 3; i++)
                {
                    ConfigurarEventoVidrio(i); // CORREGIDO: usar el nombre correcto del método
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar eventos de combos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEventoVidrio(int numeroCombo)
        {
            string nombreComboVidrio = $"cmbVidrio{numeroCombo}";
            var comboVidrio = this.Controls.Find(nombreComboVidrio, true).FirstOrDefault() as ComboBox;

            if (comboVidrio != null)
            {
                // Usar closure para capturar el número de combo correctamente
                comboVidrio.SelectedIndexChanged += (sender, e) => CmbVidrio_SelectedIndexChanged(sender, e, numeroCombo);
            }
        }

        private void CmbVidrio_SelectedIndexChanged(object sender, EventArgs e, int numeroCombo)
        {
            try
            {
                if (sender is ComboBox cmb && cmb.SelectedItem is DtoMaterial vidrioSeleccionado)
                {
                    var lblPrecioM2 = this.Controls.Find($"lblvalorxmetro2{numeroCombo}", true).FirstOrDefault() as Label;
                    if (lblPrecioM2 != null)
                    {
                        lblPrecioM2.Text = $"${vidrioSeleccionado.PrecioUnitario:N2}";
                        lblPrecioM2.Visible = true;
                    }
                }
                else
                {
                    // Si no hay selección, limpiar el label
                    var lblPrecioM2 = this.Controls.Find($"lblvalorxmetro2{numeroCombo}", true).FirstOrDefault() as Label;
                    if (lblPrecioM2 != null)
                    {
                        lblPrecioM2.Text = "$";
                        lblPrecioM2.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar precio del vidrio {numeroCombo}: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbMaderas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is ComboBox cmb && cmb.SelectedItem is DtoMaterial materialSeleccionado)
                {
                    var lblPrecio = this.Controls.Find("lblPrecioPorPie", true).FirstOrDefault() as Label;
                    if (lblPrecio != null)
                    {
                        lblPrecio.Text = $"Precio por pie: ${materialSeleccionado.PrecioUnitario:N2}";
                        lblPrecio.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar precio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbTipoMaterial_SelectedIndexChanged(object sender, EventArgs e, int numeroCombo)
        {

            var cmb = sender as ComboBox;
            if (cmb == null) return;

            int idTipoMaterial = 0;

            if (cmb.SelectedValue != null && int.TryParse(cmb.SelectedValue.ToString(), out idTipoMaterial) && idTipoMaterial > 0)
            {
                CargarMaterialesPorTipo(idTipoMaterial, numeroCombo);
                return;
            }

            var item = cmb.SelectedItem as DtoTipoMaterial;
            if (item != null && item.IdTipoMaterial > 0)
            {
                idTipoMaterial = item.IdTipoMaterial;
                CargarMaterialesPorTipo(idTipoMaterial, numeroCombo);
                return;
            }

            LimpiarComboMateriales(numeroCombo);

        }

        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e, int numeroCombo)
        {
            try
            {
                if (sender is ComboBox cmb && cmb.SelectedItem is DtoMaterial materialSeleccionado)
                {
                    // Mostrar precio unitario en el label correspondiente
                    MostrarPrecioMaterialVarios(numeroCombo, materialSeleccionado);

                    // Recalcular el total si ya hay cantidad ingresada
                    RecalcularTotalMaterialVarios(numeroCombo, materialSeleccionado);
                }
                else
                {
                    // Si no hay selección, limpiar los labels
                    ClsUtilidadesForms.LimpiarLabelsMaterialesVarios(this, numeroCombo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar precio del material {numeroCombo}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPrecioMaterialVarios(int numeroCombo, DtoMaterial material)
        {
            // Mostrar precio unitario en el label de unidad
            var posiblesNombresUnidad = new[] {
                $"lblMaterialUnidad{numeroCombo}",
                $"lblPrecioMaterial{numeroCombo}",
                $"lblpreciomaterial{numeroCombo}",
                $"lblPrecioUnidad{numeroCombo}",
                $"lblValorUnidad{numeroCombo}",
                $"lblUnidadBisagras" // Para el caso específico de bisagras
            };

            foreach (var nombreUnidad in posiblesNombresUnidad)
            {
                var lblUnidad = this.Controls.Find(nombreUnidad, true).FirstOrDefault() as Label;
                if (lblUnidad != null)
                {
                    // Mostrar precio con unidad
                    lblUnidad.Text = $"${material.PrecioUnitario:N2}";
                    lblUnidad.Visible = true;
                    break;
                }
            }

            // También mostrar solo el precio en otro label si existe
            var posiblesNombresPrecio = new[] {
                $"lblPrecioSolo{numeroCombo}",
                $"lblValorSolo{numeroCombo}"
            };

            foreach (var nombrePrecio in posiblesNombresPrecio)
            {
                var lblPrecio = this.Controls.Find(nombrePrecio, true).FirstOrDefault() as Label;
                if (lblPrecio != null)
                {
                    lblPrecio.Text = $"${material.PrecioUnitario:N2}";
                    lblPrecio.Visible = true;
                    break;
                }
            }
        }

        private void RecalcularTotalMaterialVarios(int numeroCombo, DtoMaterial material)
        {
            // Usar los nombres exactos del designer
            var posiblesNombresCantidad = new[] {
                $"txtMaterialCantidad{numeroCombo}",  // Nombre principal del designer
                $"txtcantidadmaterial{numeroCombo}",
                $"txtCantidadMaterial{numeroCombo}",
                $"txtCantidad{numeroCombo}",
                $"textBoxCantidad{numeroCombo}"
            };

            foreach (var nombreCantidad in posiblesNombresCantidad)
            {
                var txtCantidad = this.Controls.Find(nombreCantidad, true).FirstOrDefault() as TextBox;
                if (txtCantidad != null && int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
                {
                    decimal total = (material.PrecioUnitario ?? 0) * cantidad;

                    // LLAMAR DIRECTAMENTE A ClsUtilidadesForms SIN MÉTODO INTERMEDIO
                    ClsUtilidadesForms.ActualizarLabelsMaterialesVarios(
                        this,
                        numeroCombo,
                        material.PrecioUnitario ?? 0,
                        material.NombreMaterial,
                        cantidad,
                        total
                    );
                    break;
                }
            }
        }

        private void ConfigurarEventoComboTipo(int numeroCombo)
        {
            string nombreComboTipo = $"cmbTipoMaterial{numeroCombo}";
            var comboTipo = this.Controls.Find(nombreComboTipo, true).FirstOrDefault() as ComboBox;

            if (comboTipo != null)
            {
                comboTipo.SelectedIndexChanged -= (sender, e) => CmbTipoMaterial_SelectedIndexChanged(sender, e, numeroCombo);
                comboTipo.SelectedIndexChanged += (sender, e) => CmbTipoMaterial_SelectedIndexChanged(sender, e, numeroCombo);
            }
        }

        private void ConfigurarEventoComboMaterial(int numeroCombo)
        {
            string nombreComboMaterial = $"cmbMaterial{numeroCombo}";
            var comboMaterial = this.Controls.Find(nombreComboMaterial, true).FirstOrDefault() as ComboBox;

            if (comboMaterial != null)
            {
                comboMaterial.SelectedIndexChanged += (sender, e) => CmbMaterial_SelectedIndexChanged(sender, e, numeroCombo);
            }
        }

        private void ConfigurarEventoCantidadMaterial(int numeroCombo)
        {
            // Usar los nombres exactos del designer
            var posiblesNombresCantidad = new[] {
                $"txtMaterialCantidad{numeroCombo}",  // Nombre principal del designer
                $"txtcantidadmaterial{numeroCombo}",
                $"txtCantidadMaterial{numeroCombo}",
                $"txtCantidad{numeroCombo}",
                $"textBoxCantidad{numeroCombo}"
            };

            foreach (var nombreCantidad in posiblesNombresCantidad)
            {
                var txtCantidad = this.Controls.Find(nombreCantidad, true).FirstOrDefault() as TextBox;

            }
        }


        private void MostrarTotalGeneralMaterialesVarios(decimal total)
        {
            var posiblesNombresTotalGeneral = new[] {
                "lbltotalgastosadicionales",
                "lblTotalGastosMat",
                "lblTotalMaterialesVarios",
                "lbltotalmaterialesvarios",
                "lblTotalGeneralMateriales"
            };

            foreach (var nombreTotal in posiblesNombresTotalGeneral)
            {
                var lblTotal = this.Controls.Find(nombreTotal, true).FirstOrDefault() as Label;
                if (lblTotal != null)
                {
                    lblTotal.Text = $"${total:N2}";
                    lblTotal.Visible = true;
                    break;
                }
            }
        }
        #endregion

        // Utilidades locales (wrappers)
        private void OcultarLabelsResultados()
        {
            ClsUtilidadesForms.OcultarLabelsResultados(this);
        }

        private void ConfigurarValidacionesCampos()
        {

            ClsUtilidadesForms.ConfigurarValidacionesNumericas(this);

           
        }

        public void CargarCotizacionParaEdicion(DtoCotizacion cotizacion)
        {
            if (cotizacion == null) return;

            try
            {
                // Limpiar si existe el método

                var mi = GetType().GetMethod("LimpiarFormulario", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (mi != null) mi.Invoke(this, null);



                // Asegurar combos cargados
                CargarTodosLosCombos();

                // Datos básicos
                var txtDescripcion = this.Controls.Find("txtDescripcionMueble", true).FirstOrDefault() as TextBox;
                if (txtDescripcion != null) txtDescripcion.Text = cotizacion.DescripcionMueble ?? "";

                var txtDesperdicio = this.Controls.Find("txtdesperdicio", true).FirstOrDefault() as TextBox;
                if (txtDesperdicio != null) txtDesperdicio.Text = cotizacion.PorcentajeDesperdicio.ToString();

                var txtGanancia = this.Controls.Find("txtganancia", true).FirstOrDefault() as TextBox;
                if (txtGanancia != null) txtGanancia.Text = cotizacion.PorcentajeGanancia.ToString();

                // Seleccionar madera sin disparar el evento y forzar el precio guardado
                var cmbMaderas = this.Controls.Find("cmbMaderas", true).FirstOrDefault() as ComboBox;
                var lblPrecio = this.Controls.Find("lblPrecioPorPie", true).FirstOrDefault() as Label;

                if (cmbMaderas != null)
                {
                    cmbMaderas.SelectedIndexChanged -= CmbMaderas_SelectedIndexChanged;

                    if (cotizacion.Id_Madera.HasValue)
                    {
                        // Intento por SelectedValue
                        cmbMaderas.SelectedValue = cotizacion.Id_Madera.Value;

                        // Si no encontró el valor (SelectedValue queda null), buscar manualmente por lista
                        if (cmbMaderas.SelectedValue == null)
                        {
                            if (cmbMaderas.DataSource is IEnumerable<DtoMaterial> ds)
                            {
                                var item = ds.FirstOrDefault(x => x.IdMaterial == cotizacion.Id_Madera.Value);
                                if (item != null) cmbMaderas.SelectedItem = item;
                            }
                        }
                    }

                    // Mostrar SIEMPRE el precio guardado en la cotización (no el actual del material)
                    if (lblPrecio != null)
                    {
                        var precio = cotizacion.PrecioPorPie ?? 0m;
                        lblPrecio.Text = $"Precio por pie: ${precio:N2}";
                        lblPrecio.Visible = true;
                    }

                    cmbMaderas.SelectedIndexChanged += CmbMaderas_SelectedIndexChanged;
                }

                // Rellenar hasta 6 líneas de madera
                if (cotizacion.Detalles != null && cotizacion.Detalles.Count > 0)
                {
                    for (int i = 0; i < Math.Min(cotizacion.Detalles.Count, 6); i++)
                    {
                        var d = cotizacion.Detalles[i];
                        int n = i + 1;

                        var txtEspesor = this.Controls.Find($"txtespesorm{n}", true).FirstOrDefault() as TextBox;
                        var txtAncho = this.Controls.Find($"txtanchom{n}", true).FirstOrDefault() as TextBox;
                        var txtLargo = this.Controls.Find($"txtlargom{n}", true).FirstOrDefault() as TextBox;
                        var txtCant = this.Controls.Find($"txtcantidad{n}", true).FirstOrDefault() as TextBox;
                        var txtDesc = this.Controls.Find($"txtdescmad{n}", true).FirstOrDefault() as TextBox;
                        var chk = this.Controls.Find($"chk{n}", true).FirstOrDefault() as CheckBox;

                        if (txtEspesor != null) txtEspesor.Text = d.EspesorCm.ToString("0.##");
                        if (txtAncho != null) txtAncho.Text = d.AnchoCm.ToString("0.##");
                        if (txtLargo != null) txtLargo.Text = d.LargoCm.ToString("0.##");
                        if (txtCant != null) txtCant.Text = d.Cantidad.ToString();
                        if (txtDesc != null) txtDesc.Text = d.Descripcion ?? $"Pieza {n}";
                        if (chk != null) chk.Checked = true;
                    }
                }

                // Guardar en estado para actualizar/guardar
                var btnGuardar = this.Controls.Find("btnGuardarCotizacion", true).FirstOrDefault() as Button;
                if (btnGuardar != null) btnGuardar.Text = "Actualizar Cotización";


                var field = GetType().GetNestedType("ViewState", System.Reflection.BindingFlags.NonPublic);
                var prop = field?.GetProperty("CotizacionActual", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                prop?.SetValue(null, cotizacion, null);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cotización para edición: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalcularPies_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar cálculos anteriores pero mantener los datos ingresados
                detallesCotizacion.Clear();
                OcultarLabelsResultados();

                // Procesar cada línea de cálculo
                ProcesarLineaCalculo(1, txtespesorm1, txtanchom1, txtlargom1, txtcantidad1, chk1, lblpie1, txtdescmad1);
                ProcesarLineaCalculo(2, txtespesorm2, txtanchom2, txtlargom2, txtcantidad2, chk2, lblpie2, txtdescmad2);
                ProcesarLineaCalculo(3, txtespesorm3, txtanchom3, txtlargom3, txtcantidad3, chk3, lblpie3, txtdescmad3);
                ProcesarLineaCalculo(4, txtespesorm4, txtanchom4, txtlargom4, txtcantidad4, chk4, lblpie4, txtdescmad4);
                ProcesarLineaCalculo(5, txtespesorm5, txtanchom5, txtlargom5, txtcantidad5, chk5, lblpie5, txtdescmad5);
                ProcesarLineaCalculo(6, txtespesorm6, txtanchom6, txtlargom6, txtcantidad6, chk6, lblpie6, txtdescmad6);

                // Total de pies para mostrar (solo informativo)
                decimal totalPies = detallesCotizacion.Sum(d => d.Pies);

                if (ClsSoloNumeros.TryParseDecimal(txtdesperdicio.Text, out decimal desperdicio) && desperdicio > 0)
                {
                    decimal factor = 1 + (desperdicio / 100m);
                    totalPies *= factor;
                }

                lblcalculopies.Text = ClsSoloNumeros.FormatearDecimal(totalPies);
                lblcalculopies.Visible = true;

                MessageBox.Show("Cálculo de pies completado.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular pies: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalcularCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (detallesCotizacion.Count == 0)
                {
                    MessageBox.Show("Primero debe calcular los pies.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarParametrosPresupuesto()) return;

                decimal porcentajeDesperdicio = ClsSoloNumeros.TryParseDecimal(txtdesperdicio.Text, out decimal desp) ? desp : 0;
                if (!ClsSoloNumeros.TryParseDecimal(txtganancia.Text, out decimal porcentajeGanancia))
                {
                    MessageBox.Show("El porcentaje de ganancia no es válido.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal precioPorPie = ObtenerPrecioPorPieSeleccionado();
                string descripcionMueble = ObtenerDescripcionMueble();

                decimal costoVidrios = CalcularCostoVidrios();
                decimal costoMaterialesVarios = CalcularCostoMaterialesVarios();
                decimal otrosCostos = CalcularOtrosCostos();

                var cotizacion = logicaCotizacion.CalcularCotizacion(
                    detallesCotizacion, porcentajeDesperdicio, porcentajeGanancia,
                    precioPorPie, descripcionMueble, ViewState.CotizacionActual?.GastosVarios);

                cotizacion.Id_Madera = ObtenerIdMaderaSeleccionada();
                cotizacion.PrecioPorPie = precioPorPie;
                cotizacion.DetallesVidrio = new List<DtoCotizacionDetalleVidrio>(detallesVidrio);
                cotizacion.MaterialesVarios = new List<DtoCotizacionMaterial>(materialesVarios);

                // Sumar costos adicionales (vidrios + materiales varios)
                cotizacion.SubTotalMateriales += costoVidrios + costoMaterialesVarios;

                decimal totalSinGanancia = cotizacion.SubTotalMateriales;
                decimal factorGanancia = 1 + (porcentajeGanancia / 100m);
                cotizacion.MontoTotal = totalSinGanancia * factorGanancia;
                cotizacion.MontoFinal = cotizacion.MontoTotal;

                lblpresupuesto.Text = $"${ClsSoloNumeros.FormatearDecimal(cotizacion.MontoFinal)}";
                lblpresupuesto.Visible = true;

                ViewState.CotizacionActual = cotizacion;

                MessageBox.Show("Cotización calculada exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular presupuesto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea limpiar todos los campos?",
                    "Confirmar Limpieza", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LimpiarFormulario();
                    MessageBox.Show("Formulario limpiado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPanelUsuarios frmPanelUsuarios = new frmPanelUsuarios();
            frmPanelUsuarios.Show();
        }

        // ========== Métodos de apoyo necesarios para los handlers ==========

        private void ProcesarLineaCalculo(
            int numeroLinea,
            TextBox txtEspesor, TextBox txtAncho, TextBox txtLargo, TextBox txtCantidad,
            CheckBox chk, Label lblResultado, TextBox txtDescripcion)
        {
            if (!chk.Checked) return;

            try
            {
                if (!ClsSoloNumeros.TryParseDecimal(txtEspesor.Text, out decimal espesor) ||
                    !ClsSoloNumeros.TryParseDecimal(txtAncho.Text, out decimal ancho) ||
                    !ClsSoloNumeros.TryParseDecimal(txtLargo.Text, out decimal largo) ||
                    !ClsSoloNumeros.TryParseInt(txtCantidad.Text, out int cantidad))
                {
                    MessageBox.Show($"Línea {numeroLinea}: valores numéricos inválidos.",
                        "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!logicaCotizacion.ValidarDimensiones(espesor, ancho, largo, cantidad, out string msg))
                {
                    MessageBox.Show($"Línea {numeroLinea}: {msg}", "Error de Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = txtDescripcion?.Text ?? $"Pieza {numeroLinea}";
                var detalle = CL_Cotizacion.CalculadorPies.CalcularDetalle(
                    espesor, ancho, largo, cantidad, descripcion);

                detalle.NumeroLinea = numeroLinea;
                detallesCotizacion.Add(detalle);

                lblResultado.Text = ClsSoloNumeros.FormatearDecimal(detalle.Pies);
                lblResultado.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en línea {numeroLinea}: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarParametrosPresupuesto()
        {
            if (!ClsSoloNumeros.TryParseDecimal(txtganancia.Text, out decimal ganancia) || ganancia <= 0)
            {
                MessageBox.Show("Debe ingresar un porcentaje de ganancia válido mayor a cero.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtganancia.Focus();
                return false;
            }

            var cmbMaderas = this.Controls.Find("cmbMaderas", true).FirstOrDefault() as ComboBox;
            if (cmbMaderas != null && cmbMaderas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una madera para calcular el presupuesto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaderas.Focus();
                return false;
            }

            return true;
        }

        private decimal ObtenerPrecioPorPieSeleccionado()
        {
            var cmbMaderas = this.Controls.Find("cmbMaderas", true).FirstOrDefault() as ComboBox;
            if (cmbMaderas?.SelectedItem is DtoMaterial m)
                return m.PrecioUnitario ?? 0m;
            return 0m;
        }

        private string ObtenerDescripcionMueble()
        {
            var txtDesc = this.Controls.Find("txtDescripcionMueble", true).FirstOrDefault() as TextBox;
            if (txtDesc != null && !string.IsNullOrWhiteSpace(txtDesc.Text))
                return txtDesc.Text;
            return "Mueble cotizado";
        }

        private decimal CalcularCostoVidrios()
        {
            detallesVidrio.Clear();
            decimal totalVidrios = 0;

            for (int i = 1; i <= 3; i++)
            {
                var posiblesNombresCheckbox = new[] { $"chkvidrio{i}", $"chkVidrio{i}", $"checkBoxVidrio{i}" };
                CheckBox chkVidrio = null;
                foreach (var nombre in posiblesNombresCheckbox)
                {
                    chkVidrio = this.Controls.Find(nombre, true).FirstOrDefault() as CheckBox;
                    if (chkVidrio != null) break;
                }

                if (chkVidrio?.Checked == true)
                {
                    var cmbVidrio = this.Controls.Find($"cmbVidrio{i}", true).FirstOrDefault() as ComboBox;
                    var txtLargo = this.Controls.Find($"txtvidriolargo{i}", true).FirstOrDefault() as TextBox;
                    var txtAncho = this.Controls.Find($"txtvidrioancho{i}", true).FirstOrDefault() as TextBox;
                    var txtCantidad = this.Controls.Find($"txtvidriocant{i}", true).FirstOrDefault() as TextBox;

                    if (cmbVidrio?.SelectedItem is DtoMaterial vidrio &&
                        ClsSoloNumeros.TryParseDecimal(txtLargo?.Text, out decimal largo) &&
                        ClsSoloNumeros.TryParseDecimal(txtAncho?.Text, out decimal ancho) &&
                        int.TryParse(txtCantidad?.Text, out int cantidad) &&
                        cantidad > 0)
                    {
                        decimal m2PorPieza = (largo / 100m) * (ancho / 100m);
                        decimal precioPorM2 = vidrio.PrecioUnitario ?? 0m;
                        decimal precioPorUnidad = m2PorPieza * precioPorM2;
                        decimal subtotal = precioPorUnidad * cantidad;

                        totalVidrios += subtotal;

                        // Agregar detalle para persistir
                        detallesVidrio.Add(new DtoCotizacionDetalleVidrio
                        {
                            NumeroLinea = i,
                            IdMaterial = vidrio.IdMaterial,
                            Descripcion = vidrio.NombreMaterial,
                            LargoCm = largo,
                            AnchoCm = ancho,
                            Piezas = cantidad,
                            M2PorPieza = Math.Round(m2PorPieza, 4),
                            PrecioPorM2 = precioPorM2,
                            PrecioPorUnidad = Math.Round(precioPorUnidad, 2),
                            Subtotal = Math.Round(subtotal, 2)
                        });
                    }
                }
            }

            var lblTotalVidrios = this.Controls.Find("lbltotalvidrios", true).FirstOrDefault() as Label;
            if (lblTotalVidrios != null)
            {
                lblTotalVidrios.Text = $"${totalVidrios:N2}";
                lblTotalVidrios.Visible = true;
            }

            return totalVidrios;
        }

        private decimal CalcularCostoMaterialesVarios()
        {
            materialesVarios.Clear();
            decimal totalMateriales = 0;

            for (int i = 1; i <= 6; i++)
            {
                // Checkbox
                var posiblesNombresCheckbox = new[] { $"chkmaterial{i}", $"chkMaterial{i}", $"checkBoxMaterial{i}", $"chkmat{i}" };
                CheckBox chkMaterial = null;
                foreach (var nombre in posiblesNombresCheckbox)
                {
                    chkMaterial = this.Controls.Find(nombre, true).FirstOrDefault() as CheckBox;
                    if (chkMaterial != null) break;
                }

                if (chkMaterial?.Checked == true)
                {
                    var cmbMaterial = this.Controls.Find($"cmbMaterial{i}", true).FirstOrDefault() as ComboBox;

                    var posiblesNombresCantidad = new[] {
                        $"txtMaterialCantidad{i}", $"txtcantidadmaterial{i}",
                        $"txtCantidadMaterial{i}", $"txtCantidad{i}", $"textBoxCantidad{i}"
                    };
                    TextBox txtCantidad = null;
                    foreach (var nombreCantidad in posiblesNombresCantidad)
                    {
                        txtCantidad = this.Controls.Find(nombreCantidad, true).FirstOrDefault() as TextBox;
                        if (txtCantidad != null) break;
                    }

                    if (cmbMaterial?.SelectedItem is DtoMaterial material &&
                        txtCantidad != null &&
                        int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
                    {
                        decimal precioUnitario = material.PrecioUnitario ?? 0m;
                        decimal costoTotal = precioUnitario * cantidad;
                        totalMateriales += costoTotal;

                        // Actualizar UI
                        ClsUtilidadesForms.ActualizarLabelsMaterialesVarios(
                            this, i, precioUnitario, material.NombreMaterial, cantidad, costoTotal);

                        // Para persistir
                        materialesVarios.Add(new DtoCotizacionMaterial
                        {
                            IdMaterial = material.IdMaterial,
                            NombreMaterial = material.NombreMaterial,
                            Cantidad = cantidad,
                            Unidad = material.Unidad,
                            PrecioUnitario = material.PrecioUnitario
                        });
                    }
                }
            }

            MostrarTotalGeneralMaterialesVarios(totalMateriales);
            return totalMateriales;
        }

        private decimal CalcularOtrosCostos()
        {
            decimal otrosCostos = 0;

            try
            {
                var chkOtrosMateriales1 = this.Controls.Find("chkotrosmateriales1", true).FirstOrDefault() as CheckBox;
                var txtOtrosMateriales1 = this.Controls.Find("txtMaterialPrecio1", true).FirstOrDefault() as TextBox;
                var txtDescOtrosMateriales1 = this.Controls.Find("txtDescMateriale1", true).FirstOrDefault() as TextBox;

                var chkOtrosMateriales2 = this.Controls.Find("chkotrosmateriales2", true).FirstOrDefault() as CheckBox;
                var txtOtrosMateriales2 = this.Controls.Find("txtMaterialPrecio2", true).FirstOrDefault() as TextBox;
                var txtDescOtrosMateriales2 = this.Controls.Find("txtDescMateriale2", true).FirstOrDefault() as TextBox;

                var chkGastosVarios = this.Controls.Find("chkotrosmateriales3", true).FirstOrDefault() as CheckBox;
                var txtGastosVarios = this.Controls.Find("txtMaterialPrecio3", true).FirstOrDefault() as TextBox;
                var txtDescGastosVarios = this.Controls.Find("txtDescMateriale3", true).FirstOrDefault() as TextBox;

                bool incluyeOtrosMateriales1 = chkOtrosMateriales1?.Checked == true;
                decimal montoOtrosMateriales1 = 0; ClsSoloNumeros.TryParseDecimal(txtOtrosMateriales1?.Text, out montoOtrosMateriales1);
                string descripcionOtrosMateriales1 = txtDescOtrosMateriales1?.Text;

                bool incluyeOtrosMateriales2 = chkOtrosMateriales2?.Checked == true;
                decimal montoOtrosMateriales2 = 0; ClsSoloNumeros.TryParseDecimal(txtOtrosMateriales2?.Text, out montoOtrosMateriales2);
                string descripcionOtrosMateriales2 = txtDescOtrosMateriales2?.Text;

                bool incluyeGastosVarios = chkGastosVarios?.Checked == true;
                decimal montoGastosVarios = 0; ClsSoloNumeros.TryParseDecimal(txtGastosVarios?.Text, out montoGastosVarios);
                string descripcionGastosVarios = txtDescGastosVarios?.Text;

                var gastosVarios = logicaCotizacion.ProcesarMultiplesGastosVariosDesdeFormulario(
                    incluyeOtrosMateriales1, montoOtrosMateriales1, descripcionOtrosMateriales1,
                    incluyeOtrosMateriales2, montoOtrosMateriales2, descripcionOtrosMateriales2,
                    incluyeGastosVarios, montoGastosVarios, descripcionGastosVarios);

                otrosCostos = logicaCotizacion.CalcularTotalGastosVarios(gastosVarios);

                if (ViewState.CotizacionActual == null)
                    ViewState.CotizacionActual = new DtoCotizacion();
                ViewState.CotizacionActual.GastosVarios = gastosVarios;

                // Mostrar total adicional general
                var lblTotalGastos = this.Controls.Find("lbltotalgastosadicionales", true).FirstOrDefault() as Label;
                if (lblTotalGastos != null)
                {
                    lblTotalGastos.Text = $"${ClsSoloNumeros.FormatearDecimal(otrosCostos)}";
                    lblTotalGastos.Visible = otrosCostos > 0;
                }

                return otrosCostos;
            }
            catch
            {
                return 0;
            }
        }

        private int? ObtenerIdMaderaSeleccionada()
        {
            var cmbMaderas = this.Controls.Find("cmbMaderas", true).FirstOrDefault() as ComboBox;
            if (cmbMaderas?.SelectedItem is DtoMaterial materialSeleccionado)
                return materialSeleccionado.IdMaterial;
            return null;
        }

        private void LimpiarFormulario()
        {

            ClsUtilidadesForms.LimpiarControlesMaderas(this);
            ClsUtilidadesForms.LimpiarControlesVidrios(this);
            ClsUtilidadesForms.LimpiarControlesMaterialesVarios(this);
            ClsUtilidadesForms.LimpiarOtrosControlesCotizador(this);
            ClsUtilidadesForms.OcultarLabelsResultados(this);

            detallesCotizacion.Clear();
            detallesVidrio.Clear();
            materialesVarios.Clear();

            ViewState.CotizacionActual = null;

            ClsUtilidadesForms.EnfocarPrimerCampo(this);


        }

        private void btnGuardarCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState.CotizacionActual == null)
                {
                    MessageBox.Show("Debe calcular el presupuesto antes de guardar.", "Advertencia",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var esActualizacion = ViewState.CotizacionActual.Id_Cotizacion > 0;

                var mensaje = esActualizacion
                    ? "¿Desea actualizar esta cotización?"
                    : "¿Desea guardar esta cotización?";

                var result = MessageBox.Show(mensaje, "Confirmar Guardado",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                // Recalcular SIEMPRE antes de guardar para asegurar consistencia
                btnCalcularCotizacion_Click(null, EventArgs.Empty);

                bool exito;
                if (esActualizacion)
                {
                    exito = logicaCotizacion.ActualizarCotizacion(ViewState.CotizacionActual);
                    if (exito)
                        MessageBox.Show("Cotización actualizada exitosamente.", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int idCotizacion = logicaCotizacion.AltaCotizacion(ViewState.CotizacionActual);
                    exito = idCotizacion > 0;
                    if (exito)
                    {
                        ViewState.CotizacionActual.Id_Cotizacion = idCotizacion;
                        MessageBox.Show($"Cotización guardada exitosamente con ID: {idCotizacion}", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (exito)
                {
                    var btnGuardar = sender as Button;
                    if (btnGuardar != null) btnGuardar.Text = "Actualizar Cotización";
                }
                else
                {
                    var accion = esActualizacion ? "actualizar" : "guardar";
                    MessageBox.Show($"Error al {accion} la cotización.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar cotización: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCotizaciones_Click(object sender, EventArgs e)
        {

            this.Close();
            var frmListar = new frmListarCotizaciones();
            frmListar.Show(); // Abre el listado para seleccionar y editar cotizaciones guardadas


        }
    }
}