using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Vista
{
    internal class PlaceHolder
    {
        public static void Leave(string pHolder, TextBox pText)
        {
            if (pText.Text == string.Empty)
            {
                pText.Text = pHolder;
                pText.ForeColor = Color.Gray;
            }
        }

        public static void Enter(string pHolder, TextBox pText)
        {
            if (pText.Text == pHolder)
            {
                pText.Text = string.Empty;
                pText.ForeColor = Color.Black;
            }
        }
    }
}
