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
    public partial class frm1eringreso : Form
    {
        public frm1eringreso()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            frmPreguntas frmpreguntas = new frmPreguntas();
            frmpreguntas.Show();
            this.Hide(); //se oculta el formulario

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
