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

        private const string PLACEHOLDER_APELLIDO = "Apellido";
        private const string PLACEHOLDER_NOMBRE = "Nombres";
        private const string PLACEHOLDER_TIPO_DOCUMENTO = "Tipo de Documento";
        private const string PLACEHOLDER_NUMERO_DOCUMENTO = "Numero de documento";
        private const string PLACEHOLDER_TELEFONO = "Telefono";
        private const string PLACEHOLDER_EMAIL = "E-mail";
        private const string PLACEHOLDER_CALLE = "Calle";
        private const string PLACEHOLDER_NUMERO_CALLE = "Altura";
        private const string PLACEHOLDER_PISO = "Piso";
        private const string PLACEHOLDER_DEPARTAMENTO = "Dpto";
        private const string PLACEHOLDER_PARTIDO = "Partido";
        private const string PLACEHOLDER_LOCALIDAD = "Localidad";

        public frmRegistroClientes()
        {
            InitializeComponent();

        }

        private void btnVolverRegCliente_Click(object sender, EventArgs e)
        {
            frmPanelUsuarios frm = new frmPanelUsuarios();
            frm.Show();
            this.Close();
        }



        // --- MANEJADOR PARA txtApellidos ---

        private void txtapellido_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_APELLIDO, txtapellido);
        }

        private void txtapellido_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_APELLIDO, txtapellido);
        }

        // Eventos para txtnombre
        private void txtnombre_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_NOMBRE, txtnombre);
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_NOMBRE, txtnombre);
        }

        // Eventos para txttipodocumento
        private void txttipodocumento_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_TIPO_DOCUMENTO, txttipodocumento);
        }

        private void txttipodocumento_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_TIPO_DOCUMENTO, txttipodocumento);
        }

        // Eventos para txtnumerodocumento
        private void txtnumerodocumento_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_NUMERO_DOCUMENTO, txtnumerodocumento);
        }

        private void txtnumerodocumento_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_NUMERO_DOCUMENTO, txtnumerodocumento);
        }

        // Eventos para txttelefono
        private void txttelefono_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_TELEFONO, txttelefono);
        }

        private void txttelefono_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_TELEFONO, txttelefono);
        }

        // Eventos para txtemail
        private void txtemail_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_EMAIL, txtemail);
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_EMAIL, txtemail);
        }

        // Eventos para txtcalle
        private void txtcalle_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_CALLE, txtcalle);
        }

        private void txtcalle_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_CALLE, txtcalle);
        }

        // Eventos para txtnumerocalle
        private void txtnumerocalle_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_NUMERO_CALLE, txtnumerocalle);
        }

        private void txtnumerocalle_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_NUMERO_CALLE, txtnumerocalle);
        }

        // Eventos para txtpiso
        private void txtpiso_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_PISO, txtpiso);
        }

        private void txtpiso_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_PISO, txtpiso);
        }

        // Eventos para txtdepartamento
        private void txtdepartamento_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_DEPARTAMENTO, txtderpatamento);
        }

        private void txtdepartamento_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_DEPARTAMENTO, txtderpatamento);
        }

        // Eventos para txtpartido
        private void txtpartido_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_PARTIDO, txtpartido);
        }

        private void txtpartido_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_PARTIDO, txtpartido);
        }

        // Eventos para txtlocalidad
        private void txtlocalidad_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_LOCALIDAD, txtlocalidad);
        }

        private void txtlocalidad_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_LOCALIDAD, txtlocalidad);
        }

        private void frmRegistroClientes_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => this.ActiveControl = null));
            ClsPlaceHolder.Leave(PLACEHOLDER_APELLIDO, txtapellido);
            ClsPlaceHolder.Leave(PLACEHOLDER_NOMBRE, txtnombre);
            ClsPlaceHolder.Leave(PLACEHOLDER_TIPO_DOCUMENTO, txttipodocumento);
            ClsPlaceHolder.Leave(PLACEHOLDER_NUMERO_DOCUMENTO, txtnumerodocumento);
            ClsPlaceHolder.Leave(PLACEHOLDER_TELEFONO, txttelefono);
            ClsPlaceHolder.Leave(PLACEHOLDER_EMAIL, txtemail);
            ClsPlaceHolder.Leave(PLACEHOLDER_CALLE, txtcalle);
            ClsPlaceHolder.Leave(PLACEHOLDER_NUMERO_CALLE, txtnumerocalle);
            ClsPlaceHolder.Leave(PLACEHOLDER_PISO, txtpiso);
            ClsPlaceHolder.Leave(PLACEHOLDER_DEPARTAMENTO, txtderpatamento);
            ClsPlaceHolder.Leave(PLACEHOLDER_PARTIDO, txtpartido);
            ClsPlaceHolder.Leave(PLACEHOLDER_LOCALIDAD, txtlocalidad);
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPanelUsuarios frmPanelUsuarios = new frmPanelUsuarios();
            frmPanelUsuarios.Show();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
