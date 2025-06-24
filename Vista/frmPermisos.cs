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
    public partial class frmPermisos : Form
    {
        public frmPermisos()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cmbRoles.Items.Add("Vendedor");
            cmbRoles.Items.Add("Administrador");
            cmbRoles.SelectedIndex = 1; //por defecto el primer rol para asignar siempre es vendedor

            //si tenemos una lista de roles en base de datos, se pueden traer esos roles con la funcion
            
            //List<string> roles = new List<string> { "Administrador", "Usuario General", "Supervisor" };
            //comboBoxRoles.Items.AddRange(roles.ToArray());
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmAdministrador frm = new frmAdministrador();
            frm.Show();
            this.Close();
        }
    }
}
