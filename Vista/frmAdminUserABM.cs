using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Vista
{
    public partial class frmAdminUserABM : Form
    {
        CL_Usuarios objCL = new CL_Usuarios();

        public frmAdminUserABM()
        {
            InitializeComponent();
        }

        private void frmAdministrador_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            CL_Usuarios usuario = new CL_Usuarios();
            dataGridView1.DataSource = usuario.MostrarUsuarios();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmAdministrador frm = new frmAdministrador();
            frm.Show();
            this.Close();
        }
    }
}
