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
    public partial class frmRegistroClientes : Form
    {
        public frmRegistroClientes()
        {
            InitializeComponent();
        }

        private void btnVolverRegCliente_Click(object sender, EventArgs e)
        {
            frmAdministrador frm = new frmAdministrador();
            frm.Show();
            this.Close();
        }
    }
}
