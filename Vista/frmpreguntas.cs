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
    public partial class frmpreguntas : Form
    {
        public frmpreguntas()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            FrmLoguin loggin = new FrmLoguin();
            loggin.Show();
            this.Hide();

        }
    }
}
