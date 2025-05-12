using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmLoguin : Form
    {
        public FrmLoguin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        private void FrmLoguin_Load(object sender, EventArgs e)
        {

        }

        private void MskUser_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void MskPassword_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void MskUser_Click(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PctClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
