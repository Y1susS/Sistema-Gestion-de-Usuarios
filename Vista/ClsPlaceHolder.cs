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
                txt.Text = placeholder;
                txt.ForeColor = Color.Gray;

                if (isPassword && txt.UseSystemPasswordChar)
                    txt.UseSystemPasswordChar = false;
            }
        }

        public static void Enter(string placeholder, TextBox txt, bool isPassword = false)
        {
            if (txt.Text == placeholder && txt.ForeColor == Color.Gray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;

                if (isPassword && !txt.UseSystemPasswordChar)
                    txt.UseSystemPasswordChar = true;
            }
        }

        //public static bool IsPlaceholder(string placeholder, TextBox txt)
        //{
        //    return txt.Text == placeholder && txt.ForeColor == Color.Gray;
        //}
    }
}
