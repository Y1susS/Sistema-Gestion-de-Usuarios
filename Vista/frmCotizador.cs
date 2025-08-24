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

            DoubleBuffered = true;

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pctBorde);
            moverFormulario.HabilitarMovimiento(lblCotizador);

            ClsFondoTransparente.Aplicar(
            pctFondo,pctLogo,lbltitulo,lblmadera,lblmadera1,lblmadera2,lblmadera3,lblmadera4,lblmadera5,lblmadera6, chk1, chk2, chk3, chk4, chk5, chk6,
            lbldesperdicio,lblganancia,label20,label1,label2,label3,lblcantidad,lblpie,lblpies1,lblpie1,lblpie2,lblpie3,lblpie4,lblpie5,lblpie6,lblpies,
            lblseleccionmaderas,lblvidrios,lblVidrio1,lblVidrio2,lblVidrio3,chkvidrio1,chkvidrio2,chkvidrio3,lblLargoVidrio,lblUnidadVidrio,lblTotalVidrio,
            lblTotalVidrios2,lbltotalvidrios,lblAnchoVidrio, lblvidriounidad1,lblvidriounidad2,lblvidriounidad3,lblCantidadVidrio,lbltotalvidrios,
            lblvidriototal1, lblvidriototal2,lblvidriototal3,lblmetros2,lblvalorxmetro21,lblvalorxmetro22,lblvalorxmetro23,lblbisagras,lblbisagrasunidad1,
            lblCantBisagras,lblBisagrasTotal,chkbisagras1,lbltotalbisagras,lblUnidadBisagras,lbltitulomateriales,lblCantMateriales,lblLargoMateriales,
            lbltitulovalorguias,lbltitulototal,chkguias1,chkguias2,chkotrosmateriales,chkgastosvarios,lblguias1,lblguias2,lblOtrosMat,lblGastosVariosMat,
            lblTotalGastosMat,lblvalorguias1,lblvalorguias2,lbltotalguias1,lbltotalguias2,lblotrosmateriales,lbltotalgastosvarios,lbltotalgastosadicionales,
            lblPresupuesto);
        }

        private void CalculoPiesMuebles_Load(object sender, EventArgs e)
        {

            this.BeginInvoke(new Action(() => this.ActiveControl = null));
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
