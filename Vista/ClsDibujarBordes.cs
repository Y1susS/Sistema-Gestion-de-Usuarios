using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    internal class ClsDibujarBordes
    {
        public enum Lado
        {
            Superior,
            Inferior,
            Izquierdo,
            Derecho
        }

        public static void DibujarLinea(Control control, PaintEventArgs e, Lado lado, Color color, float grosor = 1f)
        {
            using (Pen pen = new Pen(color, grosor))
            {
                switch (lado)
                {
                    case Lado.Superior:
                        e.Graphics.DrawLine(pen, 0, 0, control.Width, 0);
                        break;
                    case Lado.Inferior:
                        e.Graphics.DrawLine(pen, 0, control.Height - 1, control.Width, control.Height - 1);
                        break;
                    case Lado.Izquierdo:
                        e.Graphics.DrawLine(pen, 0, 0, 0, control.Height);
                        break;
                    case Lado.Derecho:
                        e.Graphics.DrawLine(pen, control.Width - 1, 0, control.Width - 1, control.Height);
                        break;
                }
            }
        }

        public static void DibujarRectangulo(Control control, PaintEventArgs e, Color color, float grosor = 1f)
        {
            using (Pen pen = new Pen(color, grosor))
            {
                e.Graphics.DrawRectangle(
                    pen,
                    0,
                    0,
                    control.Width - 1,
                    control.Height - 1
                );
            }
        }
    }
}
