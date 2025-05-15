using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    internal class PlaceHolderPass
    {
        private const char passwordChar = '●';
        public static void Leave(string pHolder, TextBox TextPass)
        {
            if (string.IsNullOrWhiteSpace(TextPass.Text))
                {
                    TextPass.Text = pHolder;
                TextPass.ForeColor = Color.Gray;
                TextPass.UseSystemPasswordChar = false;
            }

        }

        public static void Enter(string pHolder, TextBox TextPass)
        {
            if (TextPass.Text == pHolder)
            {
                TextPass.Text = string.Empty;
                TextPass.ForeColor = Color.Black;
                TextPass.UseSystemPasswordChar = true;
            }
        }
    }
}
