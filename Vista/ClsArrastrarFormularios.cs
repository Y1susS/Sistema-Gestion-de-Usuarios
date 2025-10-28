using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    internal class ClsArrastrarFormularios
    {
        private Form _formulario;
        private int mouse = 0, mouseX, mouseY;

        public ClsArrastrarFormularios(Form formulario)
        {
            _formulario = formulario;
        }

        public void HabilitarMovimiento(Control control)
        {
            control.MouseDown += Control_MouseDown;
            control.MouseUp += Control_MouseUp;
            control.MouseMove += Control_MouseMove;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse = 1;

                // Convertir a coordenadas de pantalla
                Point puntoPantalla = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                mouseX = puntoPantalla.X - _formulario.Left;
                mouseY = puntoPantalla.Y - _formulario.Top;
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse = 0;
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse == 1)
            {
                int newX = Control.MousePosition.X - mouseX;
                int newY = Control.MousePosition.Y - mouseY;

                Rectangle screenBounds = Screen.FromControl(_formulario).WorkingArea;

                if (newX < screenBounds.Left)
                    newX = screenBounds.Left;
                if (newY < screenBounds.Top)
                    newY = screenBounds.Top;
                if (newX + _formulario.Width > screenBounds.Right)
                    newX = screenBounds.Right - _formulario.Width;
                if (newY + _formulario.Height > screenBounds.Bottom)
                    newY = screenBounds.Bottom - _formulario.Height;

                _formulario.SetDesktopLocation(newX, newY);
            }

        }
    }
}
