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
            if (fondo == null || controles == null || controles.Length == 0)
                return;

            // Reducir relayout en masa
            fondo.SuspendLayout();
            try
            {
                foreach (var control in controles)
                {
                    if (control == null) continue;
                    control.BackColor = Color.Transparent;
                    // Evitar reprocesar si ya es hijo
                    if (!ReferenceEquals(control.Parent, fondo))
                    {
                        fondo.Controls.Add(control);
                    }
                }
            }
            finally
            {
                fondo.ResumeLayout(performLayout: true);
            }
        }
    }
}
