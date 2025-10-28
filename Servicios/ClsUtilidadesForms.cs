using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios
{
    public static class ClsUtilidadesForms
    {
        #region MÉTODOS BÁSICOS EXISTENTES

        public static void BloquearControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Enabled = false;
                if (item is ComboBox cmb) cmb.Enabled = false;
                if (item is GroupBox | item is Panel) BloquearControles(item);
            }
        }

        public static void DesbloquearControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Enabled = true;
                if (item is ComboBox cmb) cmb.Enabled = true;
                if (item is GroupBox | item is Panel) DesbloquearControles(item);
            }
        }

        public static void LimpiarControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Text = null;
                if (item is ComboBox cmb) cmb.Text = null;
                if (item is GroupBox | item is Panel) LimpiarControles(item);
            }
        }

        #endregion

        #region MÉTODOS ESPECÍFICOS PARA COTIZADOR

        /// <summary>
        /// Limpia específicamente los controles de maderas del cotizador
        /// </summary>
        public static void LimpiarControlesMaderas(Form formulario)
        {
            // Limpiar TextBoxes de medidas por nombre específico
            var camposMaderas = new[] {
                // Espesores
                "txtespesorm1", "txtespesorm2", "txtespesorm3", "txtespesorm4", "txtespesorm5", "txtespesorm6", "txtespesorm7", "txtespesorm8",
                // Anchos
                "txtanchom1", "txtanchom2", "txtanchom3", "txtanchom4", "txtanchom5", "txtanchom6", "txtanchom7", "txtanchom8",
                // Largos
                "txtlargom1", "txtlargom2", "txtlargom3", "txtlargom4", "txtlargom5", "txtlargom6", "txtlargom7", "txtlargom8",
                // Cantidades
                "txtcantidad1", "txtcantidad2", "txtcantidad3", "txtcantidad4", "txtcantidad5", "txtcantidad6", "txtcantidad7", "txtcantidad8",
                // Descripciones
                "txtdescmad1", "txtdescmad2", "txtdescmad3", "txtdescmad4", "txtdescmad5", "txtdescmad6", "txtdescmad7", "txtdescmad8"
            };

            foreach (var nombreCampo in camposMaderas)
            {
                var textBox = formulario.Controls.Find(nombreCampo, true).FirstOrDefault() as TextBox;
                textBox?.Clear();
            }

            // Desmarcar CheckBoxes de maderas
            var checksboxesMaderas = new[] { "chk1", "chk2", "chk3", "chk4", "chk5", "chk6", "chk7", "chk8" };
            foreach (var nombreCheck in checksboxesMaderas)
            {
                var checkBox = formulario.Controls.Find(nombreCheck, true).FirstOrDefault() as CheckBox;
                if (checkBox != null) checkBox.Checked = false;
            }

            // Resetear ComboBox de maderas
            var cmbMaderas = formulario.Controls.Find("cmbMaderas", true).FirstOrDefault() as ComboBox;
            if (cmbMaderas != null) cmbMaderas.SelectedIndex = -1;
        }

        /// <summary>
        /// Limpia específicamente los controles de vidrios del cotizador
        /// </summary>
        public static void LimpiarControlesVidrios(Form formulario)
        {
            for (int i = 1; i <= 3; i++)
            {
                // Resetear ComboBoxes de vidrios
                var cmbVidrio = formulario.Controls.Find($"cmbVidrio{i}", true).FirstOrDefault() as ComboBox;
                if (cmbVidrio != null) cmbVidrio.SelectedIndex = -1;

                // Limpiar campos de vidrios
                var camposVidrios = new[] { $"txtvidriolargo{i}", $"txtvidrioancho{i}", $"txtvidriocant{i}" };
                foreach (var nombreCampo in camposVidrios)
                {
                    var textBox = formulario.Controls.Find(nombreCampo, true).FirstOrDefault() as TextBox;
                    textBox?.Clear();
                }

                // Desmarcar CheckBoxes de vidrios
                var posiblesNombresCheckbox = new[] { $"chkvidrio{i}", $"chkVidrio{i}", $"checkBoxVidrio{i}" };
                foreach (var nombreCheckbox in posiblesNombresCheckbox)
                {
                    var checkBox = formulario.Controls.Find(nombreCheckbox, true).FirstOrDefault() as CheckBox;
                    if (checkBox != null)
                    {
                        checkBox.Checked = false;
                        break;
                    }
                }

                // Limpiar labels de precios de vidrios
                LimpiarLabelsVidrios(formulario, i);
            }

            // Limpiar total de vidrios
            var lblTotalVidrios = formulario.Controls.Find("lbltotalvidrios", true).FirstOrDefault() as Label;
            if (lblTotalVidrios != null)
            {
                lblTotalVidrios.Text = "$";
                lblTotalVidrios.Visible = false;
            }
        }

        /// <summary>
        /// Limpia específicamente los controles de materiales varios del cotizador
        /// </summary>
        public static void LimpiarControlesMaterialesVarios(Form formulario)
        {
            for (int i = 1; i <= 6; i++)
            {
                // Resetear ComboBoxes de tipos de materiales
                var cmbTipoMaterial = formulario.Controls.Find($"cmbTipoMaterial{i}", true).FirstOrDefault() as ComboBox;
                if (cmbTipoMaterial != null) cmbTipoMaterial.SelectedIndex = -1;

                // Limpiar combo de materiales correspondiente
                LimpiarComboMateriales(formulario, i);

                // Limpiar campos de cantidad
                LimpiarCamposCantidadMaterial(formulario, i);

                // Desmarcar checkbox correspondiente
                DesmarcarCheckboxMaterial(formulario, i);

                // Limpiar labels de precios y totales
                LimpiarLabelsMaterialesVarios(formulario, i);
            }
        }

        /// <summary>
        /// Limpia otros controles generales del cotizador
        /// </summary>
        public static void LimpiarOtrosControlesCotizador(Form formulario)
        {
            // Limpiar controles básicos
            var controlesBasicos = new[] { "txtdesperdicio", "txtganancia" };
            foreach (var nombreControl in controlesBasicos)
            {
                var textBox = formulario.Controls.Find(nombreControl, true).FirstOrDefault() as TextBox;
                textBox?.Clear();
            }

            // Limpiar campo de descripción del mueble
            var txtDescripcion = formulario.Controls.Find("txtDescripcionMueble", true).FirstOrDefault() as TextBox;
            txtDescripcion?.Clear();

            // Limpiar gastos varios
            LimpiarGastosVarios(formulario);

            // Limpiar label de precio de maderas
            var lblPrecio = formulario.Controls.Find("lblPrecioPorPie", true).FirstOrDefault() as Label;
            if (lblPrecio != null)
            {
                lblPrecio.Text = "$";
                lblPrecio.Visible = false;
            }
        }

        /// <summary>
        /// Oculta todos los labels de resultados del cotizador
        /// </summary>
        public static void OcultarLabelsResultados(Form formulario)
        {
            var labelsResultados = new[] {
                "lblpie1", "lblpie2", "lblpie3", "lblpie4", "lblpie5", "lblpie6", "lblpie7", "lblpie8",
                "lblcalculopies", "lblpresupuesto"
            };

            foreach (var nombreLabel in labelsResultados)
            {
                var label = formulario.Controls.Find(nombreLabel, true).FirstOrDefault() as Label;
                if (label != null) label.Visible = false;
            }
        }

        /// <summary>
        /// Actualiza los labels de precios y totales para materiales varios
        /// </summary>
        public static void ActualizarLabelsMaterialesVarios(Form formulario, int numeroCombo, decimal precioUnitario, string nombreMaterial, int cantidad, decimal costoTotal)
        {
            // Actualizar label de unidad con precio
            var posiblesNombresUnidad = new[] {
                $"lblMaterialUnidad{numeroCombo}",
                $"lblUnidadBisagras", // Para bisagras específicamente
                $"lblPrecioUnidad{numeroCombo}",
                $"lblValorUnidad{numeroCombo}"
            };

            foreach (var nombreUnidad in posiblesNombresUnidad)
            {
                var lblUnidad = formulario.Controls.Find(nombreUnidad, true).FirstOrDefault() as Label;
                if (lblUnidad != null)
                {
                    lblUnidad.Text = $"${precioUnitario:N2}";
                    lblUnidad.Visible = true;
                    break;
                }
            }

            // Actualizar label de total
            var posiblesNombresTotal = new[] {
                $"lblMateriaTotal{numeroCombo}",
                $"lblBisagrasTotal",
                $"lbltotalmaterial{numeroCombo}",
                $"lblTotalMaterial{numeroCombo}",
                $"lblTotal{numeroCombo}"
            };

            foreach (var nombreTotal in posiblesNombresTotal)
            {
                var lblTotal = formulario.Controls.Find(nombreTotal, true).FirstOrDefault() as Label;
                if (lblTotal != null)
                {
                    lblTotal.Text = $"${costoTotal:N2}";
                    lblTotal.Visible = true;
                    break;
                }
            }

            System.Diagnostics.Debug.WriteLine($"Material {numeroCombo}: {nombreMaterial} - Cantidad: {cantidad} - Precio unitario: ${precioUnitario:N2} - Total: ${costoTotal:N2}");
        }

        /// <summary>
        /// Limpia los labels de precios y totales para materiales varios específicos
        /// </summary>
        public static void LimpiarLabelsMaterialesVarios(Form formulario, int numeroCombo)
        {
            // Limpiar label de precio unitario
            var posiblesNombresPrecio = new[] {
                $"lblMaterialUnidad{numeroCombo}",
                $"lblUnidadBisagras",
                $"lblPrecioUnidad{numeroCombo}",
                $"lblValorUnidad{numeroCombo}"
            };

            foreach (var nombrePrecio in posiblesNombresPrecio)
            {
                var lblPrecio = formulario.Controls.Find(nombrePrecio, true).FirstOrDefault() as Label;
                if (lblPrecio != null)
                {
                    lblPrecio.Text = "$";
                    lblPrecio.Visible = false;
                    break;
                }
            }

            // Limpiar label de total
            var posiblesNombresTotal = new[] {
                $"lblMateriaTotal{numeroCombo}",
                $"lblBisagrasTotal",
                $"lbltotalmaterial{numeroCombo}",
                $"lblTotalMaterial{numeroCombo}",
                $"lblTotal{numeroCombo}"
            };

            foreach (var nombreTotal in posiblesNombresTotal)
            {
                var lblTotal = formulario.Controls.Find(nombreTotal, true).FirstOrDefault() as Label;
                if (lblTotal != null)
                {
                    lblTotal.Text = "$";
                    lblTotal.Visible = false;
                    break;
                }
            }
        }

        #endregion

        #region MÉTODOS AUXILIARES PRIVADOS

        private static void LimpiarLabelsVidrios(Form formulario, int numeroCombo)
        {
            var labelsVidrios = new[] {
                $"lblvalorxmetro2{numeroCombo}",
                $"lblvidriounidad{numeroCombo}",
                $"lblvidriototal{numeroCombo}"
            };

            foreach (var nombreLabel in labelsVidrios)
            {
                var label = formulario.Controls.Find(nombreLabel, true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Text = "$";
                    label.Visible = false;
                }
            }
        }

        private static void LimpiarComboMateriales(Form formulario, int numeroCombo)
        {
            string nombreComboMaterial = $"cmbMaterial{numeroCombo}";
            var combo = formulario.Controls.Find(nombreComboMaterial, true).FirstOrDefault() as ComboBox;

            if (combo != null)
            {
                combo.DataSource = null;
                combo.Items.Clear();
                combo.Enabled = false;
            }
        }

        private static void LimpiarCamposCantidadMaterial(Form formulario, int numeroCombo)
        {
            var posiblesNombresCantidad = new[] {
                $"txtMaterialCantidad{numeroCombo}",
                $"txtcantidadmaterial{numeroCombo}",
                $"txtCantidadMaterial{numeroCombo}",
                $"txtCantidad{numeroCombo}",
                $"textBoxCantidad{numeroCombo}"
            };

            foreach (var nombreCantidad in posiblesNombresCantidad)
            {
                var txtCantidad = formulario.Controls.Find(nombreCantidad, true).FirstOrDefault() as TextBox;
                if (txtCantidad != null)
                {
                    txtCantidad.Clear();
                    break;
                }
            }
        }

        private static void DesmarcarCheckboxMaterial(Form formulario, int numeroCombo)
        {
            var posiblesNombresCheckbox = new[] {
                $"chkmaterial{numeroCombo}",
                $"chkMaterial{numeroCombo}",
                $"checkBoxMaterial{numeroCombo}",
                $"chkmat{numeroCombo}"
            };

            foreach (var nombreCheckbox in posiblesNombresCheckbox)
            {
                var chkMaterial = formulario.Controls.Find(nombreCheckbox, true).FirstOrDefault() as CheckBox;
                if (chkMaterial != null)
                {
                    chkMaterial.Checked = false;
                    break;
                }
            }
        }

        private static void LimpiarGastosVarios(Form formulario)
        {
            for (int i = 1; i <= 3; i++)
            {
                // Limpiar checkboxes
                var chkGasto = formulario.Controls.Find($"chkotrosmateriales{i}", true).FirstOrDefault() as CheckBox;
                if (chkGasto != null) chkGasto.Checked = false;

                // Limpiar textboxes de precio y descripción
                var txtPrecio = formulario.Controls.Find($"txtMaterialPrecio{i}", true).FirstOrDefault() as TextBox;
                txtPrecio?.Clear();

                var txtDesc = formulario.Controls.Find($"txtDescMateriale{i}", true).FirstOrDefault() as TextBox;
                txtDesc?.Clear();

                // Limpiar labels correspondientes
                var lblGasto = formulario.Controls.Find($"lblotrosmateriales{i}", true).FirstOrDefault() as Label;
                if (lblGasto != null)
                {
                    lblGasto.Text = "$";
                    lblGasto.Visible = false;
                }
            }

            // Limpiar labels especiales
            var labelsEspeciales = new[] {
                "lbltotalgastosvarios",
                "lbltotalgastosadicionales"
            };

            foreach (var nombreLabel in labelsEspeciales)
            {
                var label = formulario.Controls.Find(nombreLabel, true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Text = "$";
                    label.Visible = false;
                }
            }
        }

        #endregion

        #region MÉTODOS PARA VALIDACIONES

        /// <summary>
        /// Configura validaciones numéricas en controles específicos
        /// </summary>
        public static void ConfigurarValidacionesNumericas(Form formulario)
        {
            // Configurar validaciones decimales para campos de dimensiones
            for (int i = 1; i <= 8; i++)
            {
                ConfigurarValidacionDecimal(formulario, $"txtespesorm{i}");
                ConfigurarValidacionDecimal(formulario, $"txtanchom{i}");
                ConfigurarValidacionDecimal(formulario, $"txtlargom{i}");
                ConfigurarValidacionEntero(formulario, $"txtcantidad{i}");
            }

            // Configurar validaciones para vidrios
            for (int i = 1; i <= 3; i++)
            {
                ConfigurarValidacionDecimal(formulario, $"txtvidriolargo{i}");
                ConfigurarValidacionDecimal(formulario, $"txtvidrioancho{i}");
                ConfigurarValidacionEntero(formulario, $"txtvidriocant{i}");
            }

            // Configurar validaciones para materiales varios
            for (int i = 1; i <= 6; i++)
            {
                ConfigurarValidacionEntero(formulario, $"txtMaterialCantidad{i}");
            }

            // Configurar validaciones para gastos varios
            for (int i = 1; i <= 3; i++)
            {
                ConfigurarValidacionDecimal(formulario, $"txtMaterialPrecio{i}");
            }

            // Configurar otros campos
            ConfigurarValidacionDecimal(formulario, "txtdesperdicio");
            ConfigurarValidacionDecimal(formulario, "txtganancia");
        }

        private static void ConfigurarValidacionDecimal(Form formulario, string nombreControl)
        {
            var textBox = formulario.Controls.Find(nombreControl, true).FirstOrDefault() as TextBox;
            if (textBox != null)
            {
                textBox.KeyPress += (sender, e) => {
                    if (sender is TextBox tb)
                        ClsSoloNumeros.ValidarNroDecimales(e, tb);
                };
            }
        }

        private static void ConfigurarValidacionEntero(Form formulario, string nombreControl)
        {
            var textBox = formulario.Controls.Find(nombreControl, true).FirstOrDefault() as TextBox;
            if (textBox != null)
            {
                textBox.KeyPress += (sender, e) => ClsSoloNumeros.ValidarNro(e);
            }
        }

        #endregion

        #region MÉTODOS PARA ENFOQUE Y NAVEGACIÓN

        /// <summary>
        /// Enfoca el primer campo disponible del formulario
        /// </summary>
        public static void EnfocarPrimerCampo(Form formulario)
        {
            var posiblesCampos = new[] {
                "txtespesorm1",
                "txtEspesor1",
                "txtEspesorMadera1"
            };

            foreach (var nombreCampo in posiblesCampos)
            {
                var campo = formulario.Controls.Find(nombreCampo, true).FirstOrDefault() as TextBox;
                if (campo != null)
                {
                    campo.Focus();
                    return;
                }
            }
        }

        #endregion

        #region MÉTODOS PARA OTROS FORMULARIOS

        /// <summary>
        /// Método específico para limpiar formulario de stock como el que tienes
        /// </summary>
        public static void LimpiarFormularioStock(Form formulario)
        {
            var controlesStock = new[] {
                "txtDescripcion", "txtUnidad", "txtPrecioUnitario",
                "txtStockActual", "txtStockMinimo"
            };

            foreach (var nombreControl in controlesStock)
            {
                var textBox = formulario.Controls.Find(nombreControl, true).FirstOrDefault() as TextBox;
                textBox?.Clear();
            }

            var combosStock = new[] { "cmbTipoMaterial", "cmbMaterial" };
            foreach (var nombreCombo in combosStock)
            {
                var combo = formulario.Controls.Find(nombreCombo, true).FirstOrDefault() as ComboBox;
                if (combo != null) combo.SelectedIndex = -1;
            }

            var checkStock = formulario.Controls.Find("cbxActivo", true).FirstOrDefault() as CheckBox;
            if (checkStock != null) checkStock.Checked = false;
        }

        #endregion
    }
}