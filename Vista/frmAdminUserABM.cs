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
        CL_Partido objPartido = new CL_Partido();

        public frmAdminUserABM()
        {
            InitializeComponent();
        }

        private void frmAdministrador_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            CargarCombos();
        }

        private void MostrarUsuarios()
        {
            CL_Usuarios usuario = new CL_Usuarios();
            dataGridView1.DataSource = usuario.MostrarUsuarios();
        }

        private void CargarCombos()
        {
            cmbPartido.DataSource = objPartido.MostrarPartidos();
            cmbPartido.DisplayMember = "Partido";
            cmbPartido.ValueMember = "Id_Partido";
            cmbPartido.SelectedIndex = -1;
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmAdministrador frm = new frmAdministrador();
            frm.Show();
            this.Close();
        }
    }
}
