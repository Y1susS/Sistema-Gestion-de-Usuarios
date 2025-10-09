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
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblCotizador);
        }

        private void frmCotizador_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                ConfigurarControlesExistentes();
                CargarTodosLosCombos();
                OcultarLabelsResultados();
                ConfigurarValidacionesCampos();

                // Asegurar que los eventos estén configurados
                ConfigurarEventosCombos();

                System.Diagnostics.Debug.WriteLine("Formulario cargado correctamente con todos los eventos configurados");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"Error en frmCotizador_Load: {ex}");
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

        private void ConfigurarControlesExistentes()
        {
            // Configurar eventos de botones existentes
            ConfigurarEventosBotones();
        }

        private void ConfigurarEventosBotones()
        {
            // Para usar los botones del diseñador, asigna los nombres correctos en el diseñador
            // y conecta los eventos aquí o directamente en el diseñador
        }

        // Método principal para cargar todos los ComboBoxes del formulario de forma segura
        private void CargarTodosLosCombos()
        {
            try
            {
                // Cargar combos usando métodos específicos
                CargarComboMaderasSeguro();
                CargarComboVidriosSeguro();
                CargarCombosTiposMaterialesSeguro();

                // Configurar eventos de cambio de selección
                ConfigurarEventosCombos();
            }
            catch (Exception)
            {
                // Si falla, intentar método alternativo
                CargarCombosAlternativo();
            }
        }

        #region CARGA SEGURA DE COMBOS


        // Carga maderas de forma segura con manejo de errores
        private void CargarComboMaderasSeguro()
        {
            try
            {
                var maderas = logicaMateriales.ListarMaderas();
                AsignarDatosACombo("cmbMaderas", maderas, "NombreMaterial", "IdMaterial");
            }
            catch (Exception)
            {
                // Si falla, usar método alternativo
                CargarMaderasAlternativo();
            }
        }


        // Carga vidrios de forma segura con manejo de errores
        private void CargarComboVidriosSeguro()
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
            catch (Exception)
            {
                // Si falla, usar método alternativo
                CargarVidriosAlternativo();
            }
        }

        // Carga tipos de materiales de forma segura
        private void CargarCombosTiposMaterialesSeguro()
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
            catch (Exception)
            {
                // Si falla, usar método alternativo
                CargarTiposMaterialesAlternativo();
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

        #endregion

        #region MÉTODOS ALTERNATIVOS


        // Método alternativo para cargar maderas usando todos los materiales
        private void CargarMaderasAlternativo()
        {
            try
            {
                var todosMateriales = logicaMateriales.ListarMateriales();
                // Filtrar maderas por tipo (ID 1 = Maderas)
                var maderas = todosMateriales.Where(m => m.TipoMaterial?.IdTipoMaterial == 1).ToList();

                AsignarDatosACombo("cmbMaderas", maderas, "NombreMaterial", "IdMaterial");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error crítico al cargar maderas: {ex.Message}");
            }
        }


        // Método alternativo para cargar vidrios
        private void CargarVidriosAlternativo()
        {
            try
            {
                var todosMateriales = logicaMateriales.ListarMateriales();
                // Filtrar vidrios por tipo (ID 2 = Vidrios)
                var vidrios = todosMateriales.Where(m => m.TipoMaterial?.IdTipoMaterial == 2).ToList();

                var nombresComboVidrios = new[] { "cmbVidrio1", "cmbVidrio2", "cmbVidrio3" };

                foreach (var nombreCombo in nombresComboVidrios)
                {
                    AsignarDatosACombo(nombreCombo, new List<DtoMaterial>(vidrios), "NombreMaterial", "IdMaterial");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error crítico al cargar vidrios: {ex.Message}");
            }
        }


        // Método alternativo para cargar tipos de materiales
        private void CargarTiposMaterialesAlternativo()
        {
            try
            {
                var todosTipos = logicaMateriales.ListarTiposMateriales();
                // Excluir maderas (ID=1) y vidrios (ID=2)
                var tiposVarios = todosTipos.Where(t => t.IdTipoMaterial != 1 && t.IdTipoMaterial != 2).ToList();

                var nombresCombosTypesMateriales = new[]
                {
                    "cmbTipoMaterial1", "cmbTipoMaterial2", "cmbTipoMaterial3",
                    "cmbTipoMaterial4", "cmbTipoMaterial5", "cmbTipoMaterial6"
                };

                foreach (var nombreCombo in nombresCombosTypesMateriales)
                {
                    AsignarDatosACombo(nombreCombo, new List<DtoTipoMaterial>(tiposVarios), "NombreTipoMaterial", "IdTipoMaterial");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error crítico al cargar tipos de materiales: {ex.Message}");
            }
        }


        // Método de respaldo completo usando solo ListarMateriales básico
        private void CargarCombosAlternativo()
        {
            try
            {
                // Solo usar métodos básicos que sabemos que funcionan
                var todosMateriales = logicaMateriales.ListarMateriales();
                var todosTipos = logicaMateriales.ListarTiposMateriales();

                // Cargar maderas (tipo 1)
                var maderas = todosMateriales.Where(m => m.TipoMaterial?.IdTipoMaterial == 1).ToList();
                AsignarDatosACombo("cmbMaderas", maderas, "NombreMaterial", "IdMaterial");

                // Cargar vidrios (tipo 2)
                var vidrios = todosMateriales.Where(m => m.TipoMaterial?.IdTipoMaterial == 2).ToList();
                var nombresComboVidrios = new[] { "cmbVidrio1", "cmbVidrio2", "cmbVidrio3" };
                foreach (var nombreCombo in nombresComboVidrios)
                {
                    AsignarDatosACombo(nombreCombo, new List<DtoMaterial>(vidrios), "NombreMaterial", "IdMaterial");
                }

                // Cargar tipos varios (excluyendo 1 y 2)
                var tiposVarios = todosTipos.Where(t => t.IdTipoMaterial != 1 && t.IdTipoMaterial != 2).ToList();
                var nombresCombosTypesMateriales = new[]
                {
                    "cmbTipoMaterial1", "cmbTipoMaterial2", "cmbTipoMaterial3",
                    "cmbTipoMaterial4", "cmbTipoMaterial5", "cmbTipoMaterial6"
                };
                foreach (var nombreCombo in nombresCombosTypesMateriales)
                {
                    AsignarDatosACombo(nombreCombo, new List<DtoTipoMaterial>(tiposVarios), "NombreTipoMaterial", "IdTipoMaterial");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error crítico en método alternativo: {ex.Message}");
            }
        }

        #endregion

        #region CARGA DE MATERIALES POR TIPO


        // Carga los materiales específicos en el ComboBox correspondiente según el tipo seleccionado
        private void CargarMaterialesPorTipo(int idTipoMaterial, int numeroCombo)
        {
            try
            {
                var materiales = logicaMateriales.ListarMaterialesPorTipo(idTipoMaterial);

                string nombreComboMaterial = $"cmbMaterial{numeroCombo}";
                AsignarDatosACombo(nombreComboMaterial, new List<DtoMaterial>(materiales), "NombreMaterial", "IdMaterial");

                // Habilitar el combo solo si hay materiales
                var combo = this.Controls.Find(nombreComboMaterial, true).FirstOrDefault() as ComboBox;
                if (combo != null)
                {
                    combo.Enabled = materiales.Count > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar materiales para el combo {numeroCombo}: {ex.Message}");
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

                // FIX: Cambiar ConfigurarEventoComboVidrio por ConfigurarEventoVidrio
                for (int i = 1; i <= 3; i++)
                {
                    ConfigurarEventoVidrio(i); // CORREGIDO: usar el nombre correcto del método
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al configurar eventos de combos: {ex.Message}");
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
                System.Diagnostics.Debug.WriteLine($"Error al mostrar precio del vidrio {numeroCombo}: {ex.Message}");
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
                System.Diagnostics.Debug.WriteLine($"Error al mostrar precio: {ex.Message}");
            }
        }

        private void CmbTipoMaterial_SelectedIndexChanged(object sender, EventArgs e, int numeroCombo)
        {
            try
            {
                if (sender is ComboBox cmb)
                {
                    if (cmb.SelectedValue is int idTipoMaterial && idTipoMaterial > 0)
                    {
                        CargarMaterialesPorTipo(idTipoMaterial, numeroCombo);
                    }
                    else
                    {
                        LimpiarComboMateriales(numeroCombo);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar materiales por tipo en combo {numeroCombo}: {ex.Message}");
            }
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
                System.Diagnostics.Debug.WriteLine($"Error al mostrar precio del material {numeroCombo}: {ex.Message}");
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
                // Usar closure para capturar el número de combo correctamente
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
                if (txtCantidad != null)
                {
                    // Remover eventos anteriores para evitar duplicados
                    txtCantidad.TextChanged -= (sender, e) => TxtCantidadMaterial_TextChanged(sender, e, numeroCombo);

                    // Agregar el evento
                    txtCantidad.TextChanged += (sender, e) => TxtCantidadMaterial_TextChanged(sender, e, numeroCombo);

                    System.Diagnostics.Debug.WriteLine($"Configurado evento TextChanged para {nombreCantidad}");
                    break;
                }
            }
        }

        private void TxtCantidadMaterial_TextChanged(object sender, EventArgs e, int numeroCombo)
        {
            try
            {
                if (sender is TextBox txtCantidad)
                {
                    var cmbMaterial = this.Controls.Find($"cmbMaterial{numeroCombo}", true).FirstOrDefault() as ComboBox;
                    if (cmbMaterial?.SelectedItem is DtoMaterial material)
                    {
                        if (int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
                        {
                            decimal total = (material.PrecioUnitario ?? 0) * cantidad;

                            // Actualizar todos los labels necesarios
                            ClsUtilidadesForms.ActualizarLabelsMaterialesVarios(
                                this,
                                numeroCombo,
                                material.PrecioUnitario ?? 0,
                                material.NombreMaterial,
                                cantidad,
                                total
                            );

                            System.Diagnostics.Debug.WriteLine($"Calculado: {material.NombreMaterial} x {cantidad} = ${total:N2}");
                        }
                        else
                        {
                            // Si no hay cantidad válida, limpiar los labels
                            ClsUtilidadesForms.LimpiarLabelsMaterialesVarios(this, numeroCombo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al calcular total del material {numeroCombo}: {ex.Message}");
            }
        }

        #endregion

        #region LÓGICA DE CÁLCULO

        private void OcultarLabelsResultados()
        {
            lblpie1.Visible = false;
            lblpie2.Visible = false;
            lblpie3.Visible = false;
            lblpie4.Visible = false;
            lblpie5.Visible = false;
            lblpie6.Visible = false;
            lblcalculopies.Visible = false;
            lblpresupuesto.Visible = false;
        }

        private void btnCalcularPies_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar cálculos anteriores pero mantener los datos ingresados
                detallesCotizacion.Clear();
                OcultarLabelsResultados();

                // Procesar cada línea de cálculo
                ProcesarLineaCalculo(1, txtespesorm1, txtanchom1, txtlargom1, txtcantidad1,
                                   chk1, lblpie1, txtdescmad1);
                ProcesarLineaCalculo(2, txtespesorm2, txtanchom2, txtlargom2, txtcantidad2,
                                   chk2, lblpie2, txtdescmad2);
                ProcesarLineaCalculo(3, txtespesorm3, txtanchom3, txtlargom3, txtcantidad3,
                                   chk3, lblpie3, txtdescmad3);
                ProcesarLineaCalculo(4, txtespesorm4, txtanchom4, txtlargom4, txtcantidad4,
                                   chk4, lblpie4, txtdescmad4);
                ProcesarLineaCalculo(5, txtespesorm5, txtanchom5, txtlargom5, txtcantidad5,
                                   chk5, lblpie5, txtdescmad5);
                ProcesarLineaCalculo(6, txtespesorm6, txtanchom6, txtlargom6, txtcantidad6,
                                   chk6, lblpie6, txtdescmad6);

                // Mostrar total de pies SIN desperdicio
                decimal totalPies = detallesCotizacion.Sum(d => d.Pies);

                // MOSTRAR desperdicio aplicado solo para información visual
                // (El desperdicio real se aplica solo en el cálculo final de la cotización)
                if (ClsSoloNumeros.TryParseDecimal(txtdesperdicio.Text, out decimal desperdicio))
                {
                    if (desperdicio < 0)
                    {
                        MessageBox.Show("El desperdicio no puede ser menor que cero.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Solo para mostrar en pantalla - NO afecta otros materiales
                    decimal factorDesperdicio = 1 + (desperdicio / 100);
                    totalPies *= factorDesperdicio;
                }

                lblcalculopies.Text = ClsSoloNumeros.FormatearDecimal(totalPies);
                lblcalculopies.Visible = true;

                // Mensaje aclaratorio
                string mensajeDesperdicio = ClsSoloNumeros.TryParseDecimal(txtdesperdicio.Text, out decimal desp) && desp > 0
                    ? $" (incluye {ClsSoloNumeros.FormatearDecimal(desp)}% de desperdicio solo para maderas)"
                    : "";
                
                MessageBox.Show($"Cálculo completado. Total: {ClsSoloNumeros.FormatearDecimal(totalPies)} pies{mensajeDesperdicio}", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular pies: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcesarLineaCalculo(int numeroLinea, TextBox txtEspesor, TextBox txtAncho,
                                        TextBox txtLargo, TextBox txtCantidad, CheckBox chk,
                                        Label lblResultado, TextBox txtDescripcion)
        {
            if (!chk.Checked) return;

            try
            {
                // Usar los nuevos métodos de parsing
                if (!ClsSoloNumeros.TryParseDecimal(txtEspesor.Text, out decimal espesor) ||
                    !ClsSoloNumeros.TryParseDecimal(txtAncho.Text, out decimal ancho) ||
                    !ClsSoloNumeros.TryParseDecimal(txtLargo.Text, out decimal largo) ||
                    !ClsSoloNumeros.TryParseInt(txtCantidad.Text, out int cantidad))
                {
                    string mensaje = $"Error en los datos de la línea {numeroLinea}. Verifique que todos los campos tengan valores numéricos válidos.";
                    MessageBox.Show(mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar dimensiones usando la lógica de negocio
                if (!logicaCotizacion.ValidarDimensiones(espesor, ancho, largo, cantidad, out string mensajeValidacion))
                {
                    MessageBox.Show($"Línea {numeroLinea}: {mensajeValidacion}", "Error de Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = txtDescripcion?.Text ?? $"Pieza {numeroLinea}";
                var detalle = CL_Cotizacion.CalculadorPiesCubicos.CalcularDetalle(
                    espesor, ancho, largo, cantidad, descripcion);

                detalle.NumeroLinea = numeroLinea;
                detallesCotizacion.Add(detalle);

                // Mostrar resultado usando formato español
                lblResultado.Text = ClsSoloNumeros.FormatearDecimal(detalle.Pies);
                lblResultado.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en línea {numeroLinea}: {ex.Message}", "Error",
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

                // Validar parámetros
                if (!ValidarParametrosPresupuesto()) return;

                // Obtener valores usando parsing con coma
                decimal porcentajeDesperdicio = ClsSoloNumeros.TryParseDecimal(txtdesperdicio.Text, out decimal desp) ? desp : 0;
                
                if (!ClsSoloNumeros.TryParseDecimal(txtganancia.Text, out decimal porcentajeGanancia))
                {
                    MessageBox.Show("El porcentaje de ganancia no es válido.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                decimal precioPorPie = ObtenerPrecioPorPieSeleccionado();
                string descripcionMueble = ObtenerDescripcionMueble();

                // Calcular costos adicionales (SIN aplicar desperdicio)
                decimal costoVidrios = CalcularCostoVidrios();
                decimal costoMaterialesVarios = CalcularCostoMaterialesVarios();
                decimal otrosCostos = CalcularOtrosCostos(); // Gastos varios procesados

                // Crear cotización con gastos varios incluidos
                var cotizacion = logicaCotizacion.CalcularPresupuesto(
                    detallesCotizacion, porcentajeDesperdicio, porcentajeGanancia,
                    precioPorPie, descripcionMueble, ViewState.CotizacionActual?.GastosVarios);

                // Agregar otros costos SIN desperdicio (vidrios y materiales varios)
                cotizacion.MontoMateriales += costoVidrios + costoMaterialesVarios;
                
                // Recalcular total con la ganancia aplicada a TODO
                decimal totalSinGanancia = cotizacion.MontoMateriales;
                decimal factorGanancia = 1 + (porcentajeGanancia / 100);
                cotizacion.MontoTotal = totalSinGanancia * factorGanancia;
                cotizacion.MontoFinal = cotizacion.MontoTotal - cotizacion.Descuento;

                // Mostrar resultado usando formato español
                lblpresupuesto.Text = $"${ClsSoloNumeros.FormatearDecimal(cotizacion.MontoFinal)}";
                lblpresupuesto.Visible = true;

                // Guardar cotización para posible guardado
                ViewState.CotizacionActual = cotizacion;

                // Debug para verificar los cálculos
                decimal totalPiesMaderas = detallesCotizacion.Sum(d => d.Pies);
                decimal totalPiesConDesperdicio = totalPiesMaderas * (1 + porcentajeDesperdicio / 100);
                decimal montoMaderas = totalPiesConDesperdicio * precioPorPie;
                
                System.Diagnostics.Debug.WriteLine("=== DESGLOSE DEL CÁLCULO ===");
                System.Diagnostics.Debug.WriteLine($"Pies de madera (sin desperdicio): {ClsSoloNumeros.FormatearDecimal(totalPiesMaderas)}");
                System.Diagnostics.Debug.WriteLine($"Desperdicio aplicado: {ClsSoloNumeros.FormatearDecimal(porcentajeDesperdicio)}%");
                System.Diagnostics.Debug.WriteLine($"Pies de madera (con desperdicio): {ClsSoloNumeros.FormatearDecimal(totalPiesConDesperdicio)}");
                System.Diagnostics.Debug.WriteLine($"Precio por pie: ${ClsSoloNumeros.FormatearDecimal(precioPorPie)}");
                System.Diagnostics.Debug.WriteLine($"Monto maderas: ${ClsSoloNumeros.FormatearDecimal(montoMaderas)}");
                System.Diagnostics.Debug.WriteLine($"Gastos varios: ${ClsSoloNumeros.FormatearDecimal(otrosCostos)}");
                System.Diagnostics.Debug.WriteLine($"Vidrios: ${ClsSoloNumeros.FormatearDecimal(costoVidrios)}");
                System.Diagnostics.Debug.WriteLine($"Materiales varios: ${ClsSoloNumeros.FormatearDecimal(costoMaterialesVarios)}");
                System.Diagnostics.Debug.WriteLine($"Total sin ganancia: ${ClsSoloNumeros.FormatearDecimal(totalSinGanancia)}");
                System.Diagnostics.Debug.WriteLine($"Ganancia aplicada: {ClsSoloNumeros.FormatearDecimal(porcentajeGanancia)}%");
                System.Diagnostics.Debug.WriteLine($"Total final: ${ClsSoloNumeros.FormatearDecimal(cotizacion.MontoFinal)}");

                MessageBox.Show("Cotización calculada exitosamente.", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular presupuesto: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"Error completo: {ex}");
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
            if (cmbMaderas != null)
            {
                if (cmbMaderas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una madera para calcular el presupuesto.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbMaderas.Focus();
                    return false;
                }
            }

            return true;
        }

        private decimal ObtenerPrecioPorPieSeleccionado()
        {
            var cmbMaderas = this.Controls.Find("cmbMaderas", true).FirstOrDefault() as ComboBox;
            if (cmbMaderas != null)
            {
                if (cmbMaderas.SelectedItem is DtoMaterial materialSeleccionado)
                {
                    return materialSeleccionado.PrecioUnitario ?? 0;
                }
            }
            return 0;
        }

        private string ObtenerDescripcionMueble()
        {
            var txtDesc = this.Controls.Find("txtDescripcionMueble", true).FirstOrDefault() as TextBox;
            if (txtDesc != null)
            {
                return !string.IsNullOrWhiteSpace(txtDesc.Text) ? txtDesc.Text : "Mueble cotizado";
            }

            return "Mueble de madera cotizado";
        }

        private decimal CalcularCostoVidrios()
        {
            decimal totalVidrios = 0;

            for (int i = 1; i <= 3; i++)
            {
                // Buscar nombres posibles de checkboxes de vidrios
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
                        decimal.TryParse(txtLargo?.Text, out decimal largo) &&
                        decimal.TryParse(txtAncho?.Text, out decimal ancho) &&
                        int.TryParse(txtCantidad?.Text, out int cantidad))
                    {
                        decimal metrosCuadrados = (largo / 100) * (ancho / 100); // Convertir cm a metros
                        decimal costoUnitario = metrosCuadrados * (vidrio.PrecioUnitario ?? 0);
                        decimal costoTotal = costoUnitario * cantidad;

                        totalVidrios += costoTotal;

                        // Actualizar labels de resultado
                        var lblUnidad = this.Controls.Find($"lblvidriounidad{i}", true).FirstOrDefault() as Label;
                        if (lblUnidad != null)
                        {
                            lblUnidad.Text = $"${costoUnitario:N2}";
                            lblUnidad.Visible = true;
                        }

                        var lblTotal = this.Controls.Find($"lblvidriototal{i}", true).FirstOrDefault() as Label;
                        if (lblTotal != null)
                        {
                            lblTotal.Text = $"${costoTotal:N2}";
                            lblTotal.Visible = true;
                        }
                    }
                }
            }

            // Actualizar total de vidrios
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
            decimal totalMateriales = 0;

            for (int i = 1; i <= 6; i++)
            {
                // Buscar checkboxes con los nombres exactos del designer
                var posiblesNombresCheckbox = new[] {
                    $"chkmaterial{i}",
                    $"chkMaterial{i}",
                    $"checkBoxMaterial{i}",
                    $"chkmat{i}"
                };
                CheckBox chkMaterial = null;

                foreach (var nombre in posiblesNombresCheckbox)
                {
                    chkMaterial = this.Controls.Find(nombre, true).FirstOrDefault() as CheckBox;
                    if (chkMaterial != null) break;
                }

                if (chkMaterial?.Checked == true)
                {
                    var cmbMaterial = this.Controls.Find($"cmbMaterial{i}", true).FirstOrDefault() as ComboBox;

                    // Buscar TextBox de cantidad con los nombres exactos del designer
                    var posiblesNombresCantidad = new[] {
                        $"txtMaterialCantidad{i}",  // Nombre del designer
                        $"txtcantidadmaterial{i}",
                        $"txtCantidadMaterial{i}",
                        $"txtCantidad{i}",
                        $"textBoxCantidad{i}"
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
                        decimal costoTotal = (material.PrecioUnitario ?? 0) * cantidad;
                        totalMateriales += costoTotal;

                        // Actualizar labels de unidad y total con nombres del designer
                        ClsUtilidadesForms.ActualizarLabelsMaterialesVarios(
                            this,
                            i,
                            material.PrecioUnitario ?? 0,
                            material.NombreMaterial,
                            cantidad,
                            costoTotal
                        );
                    }
                }
            }

            // Mostrar total general de materiales varios
            MostrarTotalGeneralMaterialesVarios(totalMateriales);

            return totalMateriales;
        }

        private void MostrarTotalGeneralMaterialesVarios(decimal total)
        {
            // Buscar el label del total general con nombres del designer
            var posiblesNombresTotalGeneral = new[] {
                "lbltotalgastosadicionales",  // Nombre visible en el designer
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
                    System.Diagnostics.Debug.WriteLine($"Total general de materiales varios mostrado en {nombreTotal}: ${total:N2}");
                    break;
                }
            }
        }

        private decimal CalcularOtrosCostos()
        {
            decimal otrosCostos = 0;

            try
            {
                // PRIMER OTROS MATERIALES
                var chkOtrosMateriales1 = this.Controls.Find("chkotrosmateriales1", true).FirstOrDefault() as CheckBox;
                var txtOtrosMateriales1 = this.Controls.Find("txtMaterialPrecio1", true).FirstOrDefault() as TextBox;
                var txtDescOtrosMateriales1 = this.Controls.Find("txtDescMateriale1", true).FirstOrDefault() as TextBox;

                // SEGUNDO OTROS MATERIALES
                var chkOtrosMateriales2 = this.Controls.Find("chkotrosmateriales2", true).FirstOrDefault() as CheckBox;
                var txtOtrosMateriales2 = this.Controls.Find("txtMaterialPrecio2", true).FirstOrDefault() as TextBox;
                var txtDescOtrosMateriales2 = this.Controls.Find("txtDescMateriale2", true).FirstOrDefault() as TextBox;

                // GASTOS VARIOS
                var chkGastosVarios = this.Controls.Find("chkotrosmateriales3", true).FirstOrDefault() as CheckBox;
                var txtGastosVarios = this.Controls.Find("txtMaterialPrecio3", true).FirstOrDefault() as TextBox;
                var txtDescGastosVarios = this.Controls.Find("txtDescMateriale3", true).FirstOrDefault() as TextBox;

                // Procesar datos usando parsing con coma
                bool incluyeOtrosMateriales1 = chkOtrosMateriales1?.Checked == true;
                decimal montoOtrosMateriales1 = 0;
                ClsSoloNumeros.TryParseDecimal(txtOtrosMateriales1?.Text, out montoOtrosMateriales1);
                string descripcionOtrosMateriales1 = txtDescOtrosMateriales1?.Text;

                bool incluyeOtrosMateriales2 = chkOtrosMateriales2?.Checked == true;
                decimal montoOtrosMateriales2 = 0;
                ClsSoloNumeros.TryParseDecimal(txtOtrosMateriales2?.Text, out montoOtrosMateriales2);
                string descripcionOtrosMateriales2 = txtDescOtrosMateriales2?.Text;

                bool incluyeGastosVarios = chkGastosVarios?.Checked == true;
                decimal montoGastosVarios = 0;
                ClsSoloNumeros.TryParseDecimal(txtGastosVarios?.Text, out montoGastosVarios);
                string descripcionGastosVarios = txtDescGastosVarios?.Text;

                // USAR EL MÉTODO NUEVO DE CL_COTIZACION
                var gastosVarios = logicaCotizacion.ProcesarMultiplesGastosVariosDesdeFormulario(
                    incluyeOtrosMateriales1, montoOtrosMateriales1, descripcionOtrosMateriales1,
                    incluyeOtrosMateriales2, montoOtrosMateriales2, descripcionOtrosMateriales2,
                    incluyeGastosVarios, montoGastosVarios, descripcionGastosVarios);

                // Calcular total usando la lógica de CL_Cotizacion
                otrosCostos = logicaCotizacion.CalcularTotalGastosVarios(gastosVarios);

                // Guardar los gastos en el ViewState para incluirlos al guardar la cotización
                if (ViewState.CotizacionActual == null)
                {
                    ViewState.CotizacionActual = new DtoCotizacion();
                }
                ViewState.CotizacionActual.GastosVarios = gastosVarios;

                // Actualizar labels en el formulario
                ActualizarLabelsGastosVarios(incluyeOtrosMateriales1, montoOtrosMateriales1,
                                            incluyeOtrosMateriales2, montoOtrosMateriales2,
                                            incluyeGastosVarios, montoGastosVarios, otrosCostos);

                // Debug para verificar
                System.Diagnostics.Debug.WriteLine($"Total otros costos calculado: ${ClsSoloNumeros.FormatearDecimal(otrosCostos)}");
                System.Diagnostics.Debug.WriteLine($"Cantidad de gastos varios: {gastosVarios.Count}");

                return otrosCostos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en CalcularOtrosCostos: {ex.Message}");
                return 0;
            }
        }

        private void ActualizarLabelsGastosVarios(bool incluyeOtrosMateriales1, decimal montoOtrosMateriales1,
                                         bool incluyeOtrosMateriales2, decimal montoOtrosMateriales2,
                                         bool incluyeGastosVarios, decimal montoGastosVarios, decimal totalOtrosCostos)
        {
            // Actualizar label del PRIMER otros materiales
            if (incluyeOtrosMateriales1)
            {
                var lblOtrosMateriales1 = this.Controls.Find("lblotrosmateriales1", true).FirstOrDefault() as Label;
                if (lblOtrosMateriales1 != null)
                {
                    lblOtrosMateriales1.Text = $"${ClsSoloNumeros.FormatearDecimal(montoOtrosMateriales1)}";
                    lblOtrosMateriales1.Visible = true;
                }
            }
            else
            {
                // Limpiar si no está seleccionado
                var lblOtrosMateriales1 = this.Controls.Find("lblotrosmateriales1", true).FirstOrDefault() as Label;
                if (lblOtrosMateriales1 != null)
                {
                    lblOtrosMateriales1.Text = "$";
                    lblOtrosMateriales1.Visible = false;
                }
            }

            // Actualizar label del SEGUNDO otros materiales (NUEVO)
            if (incluyeOtrosMateriales2)
            {
                var lblOtrosMateriales2 = this.Controls.Find("lblotrosmateriales2", true).FirstOrDefault() as Label;
                if (lblOtrosMateriales2 != null)
                {
                    lblOtrosMateriales2.Text = $"${ClsSoloNumeros.FormatearDecimal(montoOtrosMateriales2)}";
                    lblOtrosMateriales2.Visible = true;
                }
            }
            else
            {
                // Limpiar si no está seleccionado
                var lblOtrosMateriales2 = this.Controls.Find("lblotrosmateriales2", true).FirstOrDefault() as Label;
                if (lblOtrosMateriales2 != null)
                {
                    lblOtrosMateriales2.Text = "$";
                    lblOtrosMateriales2.Visible = false;
                }
            }

            // Actualizar label de gastos varios
            if (incluyeGastosVarios)
            {
                var lblGastosVarios = this.Controls.Find("lbltotalgastosvarios", true).FirstOrDefault() as Label;
                if (lblGastosVarios != null)
                {
                    lblGastosVarios.Text = $"${ClsSoloNumeros.FormatearDecimal(montoGastosVarios)}";
                    lblGastosVarios.Visible = true;
                }
            }
            else
            {
                // Limpiar si no está seleccionado
                var lblGastosVarios = this.Controls.Find("lbltotalgastosvarios", true).FirstOrDefault() as Label;
                if (lblGastosVarios != null)
                {
                    lblGastosVarios.Text = "$";
                    lblGastosVarios.Visible = false;
                }
            }

            // Mostrar total de gastos adicionales
            var lblTotalGastos = this.Controls.Find("lbltotalgastosadicionales", true).FirstOrDefault() as Label;
            if (lblTotalGastos != null)
            {
                lblTotalGastos.Text = $"${ClsSoloNumeros.FormatearDecimal(totalOtrosCostos)}";
                lblTotalGastos.Visible = totalOtrosCostos > 0;
            }
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                frmPanelUsuarios frmPanelUsuarios = new frmPanelUsuarios();
                frmPanelUsuarios.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al minimizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "¿Está seguro que desea limpiar todos los campos?",
                    "Confirmar Limpieza",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
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

                DialogResult result = MessageBox.Show(
                    "¿Desea guardar esta cotización?",
                    "Confirmar Guardado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idCotizacion = logicaCotizacion.AltaCotizacion(ViewState.CotizacionActual);

                    if (idCotizacion > 0)
                    {
                        MessageBox.Show($"Cotización guardada exitosamente con ID: {idCotizacion}",
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la cotización.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cotización: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí podrías implementar un selector de cotizaciones existentes
                // Por ahora, como ejemplo, cargaremos la última cotización del ViewState
                if (ViewState.CotizacionActual != null)
                {
                    CargarCotizacionEnFormulario(ViewState.CotizacionActual);
                    MessageBox.Show("Cotización cargada correctamente.", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay cotización para cargar.", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cotización: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCotizacionEnFormulario(DtoCotizacion cotizacion)
        {
            try
            {
                // Limpiar formulario primero
                LimpiarFormulario();

                // Cargar datos básicos
                var txtDescripcion = this.Controls.Find("txtDescripcionMueble", true).FirstOrDefault() as TextBox;
                if (txtDescripcion != null) txtDescripcion.Text = cotizacion.DescripcionMueble;

                if (txtdesperdicio != null) txtdesperdicio.Text = cotizacion.PorcentajeDesperdicio.ToString();
                if (txtganancia != null) txtganancia.Text = cotizacion.PorcentajeGanancia.ToString();

                // Cargar detalles si existen
                if (cotizacion.Detalles != null && cotizacion.Detalles.Count > 0)
                {
                    for (int i = 0; i < Math.Min(cotizacion.Detalles.Count, 6); i++)
                    {
                        var detalle = cotizacion.Detalles[i];
                        CargarDetalleEnLinea(i + 1, detalle);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar cotización en formulario: {ex.Message}");
            }
        }

        private void CargarDetalleEnLinea(int numeroLinea, DtoCotizacionDetalle detalle)
        {
            try
            {
                // Buscar controles de la línea específica
                var txtEspesor = this.Controls.Find($"txtespesorm{numeroLinea}", true).FirstOrDefault() as TextBox;
                var txtAncho = this.Controls.Find($"txtanchom{numeroLinea}", true).FirstOrDefault() as TextBox;
                var txtLargo = this.Controls.Find($"txtlargom{numeroLinea}", true).FirstOrDefault() as TextBox;
                var txtCantidad = this.Controls.Find($"txtcantidad{numeroLinea}", true).FirstOrDefault() as TextBox;
                var txtDesc = this.Controls.Find($"txtdescmad{numeroLinea}", true).FirstOrDefault() as TextBox;
                var chk = this.Controls.Find($"chk{numeroLinea}", true).FirstOrDefault() as CheckBox;

                if (txtEspesor != null) txtEspesor.Text = detalle.EspesorCm.ToString();
                if (txtAncho != null) txtAncho.Text = detalle.AnchoCm.ToString();
                if (txtLargo != null) txtLargo.Text = detalle.LargoCm.ToString();
                if (txtCantidad != null) txtCantidad.Text = detalle.Cantidad.ToString();
                if (txtDesc != null) txtDesc.Text = detalle.Descripcion;
                if (chk != null) chk.Checked = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar detalle en línea {numeroLinea}: {ex.Message}");
            }
        }

        private void LimpiarFormulario()
        {
            try
            {
                // Usar métodos de la clase de utilidades
                ClsUtilidadesForms.LimpiarControlesMaderas(this);
                ClsUtilidadesForms.LimpiarControlesVidrios(this);
                ClsUtilidadesForms.LimpiarControlesMaterialesVarios(this);
                ClsUtilidadesForms.LimpiarOtrosControlesCotizador(this);
                ClsUtilidadesForms.OcultarLabelsResultados(this);

                // Limpiar colección de detalles
                detallesCotizacion.Clear();

                // Limpiar ViewState
                ViewState.CotizacionActual = null;

                // Enfocar primer campo
                ClsUtilidadesForms.EnfocarPrimerCampo(this);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al limpiar formulario: {ex.Message}");
                MessageBox.Show("Se produjo un error al limpiar el formulario. Algunos campos pueden no haberse limpiado correctamente.",
                               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigurarValidacionesCampos()
        {
            try
            {
                ClsUtilidadesForms.ConfigurarValidacionesNumericas(this);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al configurar validaciones: {ex.Message}");
            }
        }
        #endregion
    }
}