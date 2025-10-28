using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    internal class ClsMostrarOcultarClave
    {
        public static void Configurar(TextBox txtPassword, PictureBox pctMostrar, PictureBox pctOcultar, string placeholder)
        {
            pctMostrar.Click += (s, e) =>
            {
                if (txtPassword.ForeColor == Color.Gray)
                    return;

                pctOcultar.BringToFront();
                txtPassword.UseSystemPasswordChar = false;
            };

            pctOcultar.Click += (s, e) =>
            {
                if (txtPassword.ForeColor == Color.Gray)
                    return;

                pctMostrar.BringToFront();
                txtPassword.UseSystemPasswordChar = true;
            };

            txtPassword.Leave += (s, e) =>
            {
                if (txtPassword.Text == placeholder && txtPassword.ForeColor == Color.Gray)
                {
                    pctMostrar.BringToFront();
                }
            };
        }
    }
}
