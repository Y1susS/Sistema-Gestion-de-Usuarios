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

        private const string PLACEHOLDER_APELLIDO = "Ingrese su apellido";
        private const string PLACEHOLDER_NOMBRE = "Ingrese su nombre";
        private const string PLACEHOLDER_TIPO_DOCUMENTO = "Ingrese su tipo documento";
        private const string PLACEHOLDER_NUMERO_DOCUMENTO = "Ingrese su numero de documento";
        private const string PLACEHOLDER_TELEFONO = "Ingrese su numero de telefono";
        private const string PLACEHOLDER_EMAIL = "Ingrese su e-mail";
        private const string PLACEHOLDER_CALLE = "Ingrese el nombre de su calle";
        private const string PLACEHOLDER_NUMERO_CALLE = "Ingrese el numero de su domicilio";
        private const string PLACEHOLDER_PISO = "Ingrese el piso de su departamento";
        private const string PLACEHOLDER_DEPARTAMENTO = "Ingrese la letra o numero de departamento";
        private const string PLACEHOLDER_PARTIDO = "Ingrese el partido";
        private const string PLACEHOLDER_LOCALIDAD = "Ingrese la localidad";

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
    }
}
