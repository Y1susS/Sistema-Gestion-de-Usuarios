﻿using System;
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
    public partial class frmAdministrador : Form
    {
        public frmAdministrador()
        {
            InitializeComponent();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            frmAdminUserABM frmalta = new frmAdminUserABM();
            frmalta.Show();
            this.Hide();
        }

        private void btnGestionPermisos_Click(object sender, EventArgs e)
        {
            frmPermisos frmPermisos = new frmPermisos();
            frmPermisos.Show();
            this.Hide();
        }

        private void btnGestionContraseñas_Click(object sender, EventArgs e)
        {
            frmSegContraseña frmSegContraseña = new frmSegContraseña();
            frmSegContraseña.Show();
            this.Hide();
        }

        private void btnRegistroClientes_Click(object sender, EventArgs e)
        {
            frmRegistroClientes frmRegistro = new frmRegistroClientes();
            frmRegistro.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
