﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class FrmLoguin : Form
    {
        public FrmLoguin()
        {
            InitializeComponent();
            DoubleBuffered = true;
            pctFondo.Controls.Add(lnkRecuperar);
            lnkRecuperar.BackColor = Color.Transparent;
            pctFondo.Controls.Add(pctLogo);
            pctLogo.BackColor = Color.Transparent;
        }

        private void FrmLoguin_Load(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = false;
            ClsPlaceHolder.Leave(USER_PLACEHOLDER, txtUsuario);
            ClsPlaceHolder.Leave(PLACEHOLDER_PASS, txtContrasenia, true);
        }

        private void PctClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            frmRecupero frmRecupero = new frmRecupero();
            frmRecupero.ShowDialog();
        }

        int mouse, mousex, mousey;

        private void pctBorde_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = 1;
            mousex = e.X;
            mousey = e.Y;
        }

        private const string USER_PLACEHOLDER = "Usuario";
        private const string PLACEHOLDER_PASS = "Contraseña";

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(USER_PLACEHOLDER, txtUsuario);
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(USER_PLACEHOLDER, txtUsuario);
        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            ClsPlaceHolder.Enter(PLACEHOLDER_PASS, txtContrasenia, true);
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            ClsPlaceHolder.Leave(PLACEHOLDER_PASS, txtContrasenia, true);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool ambosVacios = string.IsNullOrWhiteSpace(txtUsuario.Text) && string.IsNullOrWhiteSpace(txtContrasenia.Text);

            if (ambosVacios == true)
            {
                MessageBox.Show("Hay campos vacios!");
            }
            else
            {
                MessageBox.Show("Inició sesión correctamente");
            }
        }

        private void pctBorde_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = 0;
        }

        private void pctBorde_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse == 1)
            {
                int newX = MousePosition.X - mousex;
                int newY = MousePosition.Y - mousey;

                // Obtener el área de trabajo de la pantalla (sin la barra de tareas)
                Rectangle screenBounds = Screen.FromControl(this).WorkingArea;

                // Limitar la nueva posición del formulario dentro de la pantalla
                if (newX < screenBounds.Left)
                    newX = screenBounds.Left;
                if (newY < screenBounds.Top)
                    newY = screenBounds.Top;
                if (newX + this.Width > screenBounds.Right)
                    newX = screenBounds.Right - this.Width;
                if (newY + this.Height > screenBounds.Bottom)
                    newY = screenBounds.Bottom - this.Height;

                this.SetDesktopLocation(newX, newY);
            }
        }
    }
}

