using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Vista
{
    internal class ClsPlaceHolder
    {
        public static void Leave(string placeholder, TextBox txt, bool isPassword = false)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                // Primero desactivar el sistema de contraseña para que no tape el texto
                if (isPassword)
                    txt.UseSystemPasswordChar = false;

                txt.Text = placeholder;
                txt.ForeColor = Color.Gray;
            }
        }

        public static void Enter(string placeholder, TextBox txt, bool isPassword = false)
        {
            if (txt.Text == placeholder && txt.ForeColor == Color.Gray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;

                // Activar solo después de borrar el texto
                if (isPassword)
                    txt.UseSystemPasswordChar = true;
            }
        }
    }
}
