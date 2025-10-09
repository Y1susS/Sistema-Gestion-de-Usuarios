using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios
{
    public static class ClsSoloNumeros
    {
        // Obtener el separador decimal del sistema (formato español por defecto)
        private static string SeparadorDecimal => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        
        /// <summary>
        /// Método para ingresar solo números enteros en un textbox
        /// Se lo llama desde el evento KeyPress del objeto
        /// </summary>
        public static bool ValidarNro(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | Char.IsControl(e.KeyChar) | char.ToString(e.KeyChar) == SeparadorDecimal)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e.Handled;
        }

        /// <summary>
        /// Valida números decimales usando el separador del sistema (coma para español)
        /// </summary>
        public static bool ValidarNroDecimales(KeyPressEventArgs e, TextBox textBox)
        {
            // Permitir dígitos y teclas de control
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            // Permitir separador decimal solo si no existe uno ya
            else if (e.KeyChar.ToString() == SeparadorDecimal && !textBox.Text.Contains(SeparadorDecimal))
            {
                e.Handled = false;
            }
            // SOPORTE PARA AMBOS SEPARADORES pero sin conversión automática
            else if ((e.KeyChar == '.' || e.KeyChar == ','))
            {
                // Si ya existe un separador decimal, no permitir otro
                if (textBox.Text.Contains(SeparadorDecimal))
                {
                    e.Handled = true;
                }
                // Permitir tanto punto como coma como separadores decimales
                else if ((e.KeyChar == ',' && SeparadorDecimal == ",") || 
                         (e.KeyChar == '.' && SeparadorDecimal == "."))
                {
                    e.Handled = false;
                }
                // Si escriben el separador que no corresponde al sistema actual, no permitirlo
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }

            return e.Handled;
        }

        /// <summary>
        /// Convierte texto a decimal respetando el formato del sistema
        /// </summary>
        public static bool TryParseDecimal(string texto, out decimal resultado)
        {
            resultado = 0;
            
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            try
            {
                // Intentar parsear con la cultura actual
                return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out resultado);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Convierte texto a int
        /// </summary>
        public static bool TryParseInt(string texto, out int resultado)
        {
            resultado = 0;
            
            if (string.IsNullOrWhiteSpace(texto))
                return false;
                
            return int.TryParse(texto, out resultado);
        }

        /// <summary>
        /// Formatea un decimal para mostrar usando el separador del sistema
        /// </summary>
        public static string FormatearDecimal(decimal valor, int decimales = 2)
        {
            return valor.ToString($"N{decimales}", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Configura la cultura del hilo actual para usar formato español
        /// </summary>
        public static void ConfigurarCulturaEspañola()
        {
            var cultura = new CultureInfo("es-ES");
            CultureInfo.CurrentCulture = cultura;
            CultureInfo.CurrentUICulture = cultura;
            System.Threading.Thread.CurrentThread.CurrentCulture = cultura;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultura;
        }
    }
}
