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
        CL_Rol objRol = new CL_Rol();
        CL_TipoDoc objTipoDoc = new CL_TipoDoc();
        CL_Localidad objLocalidad = new CL_Localidad();

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
            //CL_Usuarios usuario = new CL_Usuarios();
            dataGridView1.DataSource = objCL.MostrarUsuarios();
        }

        private void CargarCombos()
        {
            cmbPartido.DataSource = objPartido.MostrarPartidos();
            cmbPartido.DisplayMember = "Partido";
            cmbPartido.ValueMember = "Id_Partido";
            cmbPartido.SelectedIndex = -1;

            cmbRol.DataSource = objRol.MostrarRoles();
            cmbRol.DisplayMember = "Rol";
            cmbRol.ValueMember = "Id_Rol";
            cmbRol.SelectedIndex = -1;

            cmbTipoDoc.DataSource = objTipoDoc.MostrarTipoDoc();
            cmbTipoDoc.DisplayMember = "Id_TipoDocumento";
            cmbTipoDoc.ValueMember = "Id_TipoDocumento";
            cmbTipoDoc.SelectedIndex = -1;

            cmbLocalidad.DataSource = null;
        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbPartido.SelectedValue != null && int.TryParse(cmbPartido.SelectedValue.ToString(), out int idPartido))
            {
                
                //int idPartido = Convert.ToInt32(cmbPartido.SelectedValue);
                cmbLocalidad.DataSource = objLocalidad.MostrarLocalidades(idPartido);
                cmbLocalidad.DisplayMember = "Localidad";
                cmbLocalidad.ValueMember = "Id_Localidad";
                cmbLocalidad.SelectedIndex = -1;
            }
            else
            {
                cmbLocalidad.DataSource = null;
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmAdministrador frm = new frmAdministrador();
            frm.Show();
            this.Close();
        }
    }
}
