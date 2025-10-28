using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    internal class ClsFondoTransparente
    {
        public static void Aplicar(PictureBox fondo, params Control[] controles)
        {
            foreach (var control in controles)
            {
                fondo.Controls.Add(control);
                control.BackColor = Color.Transparent;
            }
        }
    }
}
