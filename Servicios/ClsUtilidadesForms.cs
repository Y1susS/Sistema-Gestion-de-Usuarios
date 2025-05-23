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
        public static void BloquearControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Enabled = false;
                if (item is ComboBox cmb) cmb.Enabled = false;
                if (item is GroupBox | item is Panel) BloquearControles(item);
            }
        }

        // Metodo para "desbloquear" los controles de un formulario
        // recibe como parametro el nobre del form
        public static void DesbloquearControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Enabled = true;
                if (item is ComboBox cmb) cmb.Enabled = true;
                if (item is GroupBox | item is Panel) DesbloquearControles(item);
            }
        }

        // Metodo para "limpiar" los controles de un formulario
        // recibe como parametro el nobre del form
        public static void LimpiarControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Text = null;
                if (item is ComboBox cmb) cmb.Text = null;
                if (item is GroupBox | item is Panel) LimpiarControles(item);
            }
        }
    }
}