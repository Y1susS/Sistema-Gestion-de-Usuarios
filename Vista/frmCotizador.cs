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
    public partial class frmCotizador : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        public frmCotizador()
        {
            InitializeComponent();

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblCotizador);
        }

        private void CalculoPiesMuebles_Load(object sender, EventArgs e)
        {
            int maxWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int maxHeight = Screen.PrimaryScreen.WorkingArea.Height;

            if (this.Width > maxWidth) this.Width = maxWidth;
            if (this.Height > maxHeight) this.Height = maxHeight;

            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void lblpie1_Paint_1(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, lblpie1.Width - 1, lblpie1.Height - 1);
            }
        }

        private void lblpie2_Paint_1(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, lblpie2.Width - 1, lblpie2.Height - 1);
            }
        }

        private void lblpie3_Paint_1(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, lblpie3.Width - 1, lblpie3.Height - 1);
            }
        }

        private void lblpie4_Paint_1(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, lblpie4.Width - 1, lblpie4.Height - 1);
            }
        }

        private void lblpie5_Paint_1(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, lblpie5.Width - 1, lblpie5.Height - 1);
            }
        }

        private void lblpie6_Paint_1(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, lblpie6.Width - 1, lblpie6.Height - 1);
            }
        }


        private void pnlPresupuesto_Paint_1(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, pnlPresupuesto.Width - 1, pnlPresupuesto.Height - 1);
            }
        }

        //private void pnlVarios_Paint_1(object sender, PaintEventArgs e)
        //{
        //    using (Pen p = new Pen(Color.White, 1))
        //    {
        //        e.Graphics.DrawRectangle(p, 0, 0, pnlVarios.Width - 1, pnlVarios.Height - 1);
        //    }
        //}
    }
}
