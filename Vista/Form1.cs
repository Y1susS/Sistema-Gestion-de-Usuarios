//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.OleDb;
//using System.Diagnostics;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//namespace CalculoPiesMuebles
//{
//    public partial class Form1 : Form
//    {

//        public Form1()
//        {
//            InitializeComponent();
//            lbltitulo.BackColor = Color.White;
//            lbltitulo.Font = new Font("ARIAL", 12, FontStyle.Bold | FontStyle.Italic);
//            lblseleccionmaderas.BackColor = Color.White;
//            lblseleccionmaderas.Font = new Font("ARIAL", 10, FontStyle.Bold | FontStyle.Italic);
//            pcbimagenmaderareciclada.Image = Image.FromFile(Application.StartupPath + @"\logomaderareciclada.jpeg");
//            pcbimagenmaderareciclada.SizeMode = PictureBoxSizeMode.StretchImage;
//            txtespesorm1.Select();
//            dgvmaderas.ForeColor = Color.Blue;
//            dgvmaderas.BackgroundColor = Color.Aqua;
//            lblmaderas.BackColor = Color.White;
//            lblmaderas.Font = new Font("ARIAL", 12, FontStyle.Bold | FontStyle.Italic);  
//            lblvidrios.BackColor = Color.White;
//            lblvidrios.Font = new Font("ARIAL", 12, FontStyle.Bold | FontStyle.Italic);
//            lbltitulomateriales.BackColor = Color.White;
//            lbltitulomateriales.Font = new Font("ARIAL", 12, FontStyle.Bold | FontStyle.Italic);
//            lblbisagras.BackColor = Color.White;
//            lblbisagras.Font = new Font("ARIAL", 12, FontStyle.Bold | FontStyle.Italic);

//        }


//        public double AproximarPulgadas(double valor)
//        { 
//        double entero = Math.Floor(valor);
//        double fraccion = valor - entero;
//            if (fraccion <= 0.01)
//            {
//                return entero;
//            }
//            else
//            {
//                return entero + 1;
//            }

//        }


//        public static double Calcularpies(double espesor, double ancho, double largo, double coeficiente, double cantidad)
//        {
//            double pies = espesor * ancho * largo * coeficiente * cantidad;
//            return pies;

//        }

//        public void btncalcularpies_Click(object sender, EventArgs e)
//        {

//            string textoespesor1 = txtespesorm1.Text;
//            double.TryParse(textoespesor1, out double espesorcm1);
//            double espesorpulgadas1 = espesorcm1 / 2.5;
//            string textoancho1 = txtanchom1.Text;
//            double.TryParse(textoancho1, out double anchocm1);
//            double anchopulgadas1 = anchocm1 / 2.54;
//            double resultadoconversion1 = AproximarPulgadas(anchopulgadas1);
//            string textolargo1 = txtlargom1.Text;
//            double.TryParse(textolargo1, out double largo1);
//            string textocantidad1 = txtcantidad1.Text;
//            double.TryParse(textocantidad1, out double cantidad1);

//            string textoespesor2 = txtespesorm2.Text;
//            double.TryParse(textoespesor2, out double espesorcm2);
//            double espesorpulgadas2 = espesorcm2 / 2.5;
//            string textoancho2 = txtanchom2.Text;
//            double.TryParse(textoancho2, out double anchocm2);
//            double anchopulgadas2 = anchocm2 / 2.54;
//            double resultadoconversion2 = AproximarPulgadas(anchopulgadas2);
//            string textolargo2 = txtlargom2.Text;
//            double.TryParse(textolargo2, out double largo2);
//            string textocantidad2 = txtcantidad2.Text;
//            double.TryParse(textocantidad2, out double cantidad2);

//            string textoespesor3 = txtespesorm3.Text;
//            double.TryParse(textoespesor3, out double espesorcm3);
//            double espesorpulgadas3 = espesorcm3 / 2.5;
//            string textoancho3 = txtanchom3.Text;
//            double.TryParse(textoancho3, out double anchocm3);
//            double anchopulgadas3 = anchocm3 / 2.54;
//            double resultadoconversion3 = AproximarPulgadas(anchopulgadas3);
//            string textolargo3 = txtlargom3.Text;
//            double.TryParse(textolargo3, out double largo3);
//            string textocantidad3 = txtcantidad3.Text;
//            double.TryParse(textocantidad3, out double cantidad3);

//            string textoespesor4 = txtespesorm4.Text;
//            double.TryParse(textoespesor4, out double espesorcm4);
//            double espesorpulgadas4 = espesorcm4 / 2.5;
//            string textoancho4 = txtanchom4.Text;
//            double.TryParse(textoancho4, out double anchocm4);
//            double anchopulgadas4 = anchocm4 / 2.54;
//            double resultadoconversion4 = AproximarPulgadas(anchopulgadas4);
//            string textolargo4 = txtlargom4.Text;
//            double.TryParse(textolargo4, out double largo4);
//            string textocantidad4 = txtcantidad4.Text;
//            double.TryParse(textocantidad4, out double cantidad4);

//            string textoespesor5 = txtespesorm5.Text;
//            double.TryParse(textoespesor5, out double espesorcm5);
//            double espesorpulgadas5 = espesorcm5 / 2.5;
//            string textoancho5 = txtanchom5.Text;
//            double.TryParse(textoancho5, out double anchocm5);
//            double anchopulgadas5 = anchocm5 / 2.54;
//            double resultadoconversion5 = AproximarPulgadas(anchopulgadas5);
//            string textolargo5 = txtlargom5.Text;
//            double.TryParse(textolargo5, out double largo5);
//            string textocantidad5 = txtcantidad5.Text;
//            double.TryParse(textocantidad5, out double cantidad5);

//            string textoespesor6 = txtespesorm6.Text;
//            double.TryParse(textoespesor6, out double espesorcm6);
//            double espesorpulgadas6 = espesorcm6 / 2.5;
//            string textoancho6 = txtanchom6.Text;
//            double.TryParse(textoancho6, out double anchocm6);
//            double anchopulgadas6 = anchocm6 / 2.54;
//            double resultadoconversion6 = AproximarPulgadas(anchopulgadas6);
//            string textolargo6 = txtlargom6.Text;
//            double.TryParse(textolargo6, out double largo6);
//            string textocantidad6 = txtcantidad6.Text;
//            double.TryParse(textocantidad6, out double cantidad6);

//            double coeficiente = 0.2734;
//            double totalpies = 0;

//            if (chk1.Checked)

//            {
//                if (espesorcm1 <= 0)
//                {
//                    MessageBox.Show("el espesor no puede ser cero o negativo, por favor ingrese un numero superior a cero y menor que 10", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                else if (espesorcm1 > 0 && espesorcm1 <= 2.5)
//                {
//                    espesorpulgadas1 = 1;
//                }
//                else if (espesorcm1 > 2.5 && espesorcm1 <= 3.2)
//                {
//                    espesorpulgadas1 = 1.5;
//                }
//                else if (espesorcm1 > 3.2 && espesorcm1 <= 5)
//                {
//                    espesorpulgadas1 = 2;
//                }
//                else if (espesorcm1 > 5 && espesorcm1 <= 7.5)
//                {
//                    espesorpulgadas1 = 3;
//                }
//                else if (espesorcm1 > 7.5 && espesorcm1 <= 10)
//                {
//                    espesorpulgadas1 = 4;
//                }
//                else
//                {
//                    MessageBox.Show("no es posible utilizar espesores superiores a 10 cm", "error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }

//                if (anchocm1 <= 0)
//                {
//                    MessageBox.Show("seleccione un ancho superior a 0 cm", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }

//                if (resultadoconversion1 > 63)
//                {
//                    MessageBox.Show("El ancho maximo de una tabla es 1,60 mts", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }

//                if (largo1 < 0.1)
//                {
//                    MessageBox.Show("seleccione un largo superior a 10 cm", "error",
//                    MessageBoxButtons.OK,
//                    MessageBoxIcon.Error);
//                }

//                double cantidadpies1 = Calcularpies(espesorpulgadas1, resultadoconversion1, largo1, coeficiente, cantidad1);
//                totalpies += cantidadpies1;
//                lblpie1.Text = $"{cantidadpies1:F2}";
//                lblpie1.Visible = true;

//            }

//            if (chk2.Checked)
//            {
//                if (espesorcm2 <= 0)
//                {
//                    MessageBox.Show("el espesor no puede ser cero o negativo, por favor ingrese un numero superior a cero y menor que 10", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                else if (espesorcm2 > 0 && espesorcm2 <= 2.5)
//                {
//                    espesorpulgadas2 = 1;
//                }
//                else if (espesorcm2 > 2.5 && espesorcm2 <= 3.2)
//                {
//                    espesorpulgadas2 = 1.5;
//                }
//                else if (espesorcm2 > 3.2 && espesorcm2 <= 5)
//                {
//                    espesorpulgadas2 = 2;
//                }
//                else if (espesorcm2 > 5 && espesorcm2 <= 7.5)
//                {
//                    espesorpulgadas2 = 3;
//                }
//                else if (espesorcm2 > 7.5 && espesorcm2 <= 10)
//                {
//                    espesorpulgadas2 = 4;
//                }
//                else
//                {
//                    MessageBox.Show("no es posible utilizar espesores superiores a 10 cm", "error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                if (anchocm2 <= 0)
//                { MessageBox.Show("seleccione un ancho superior a 0 cm", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

//                if (resultadoconversion2 > 63)
//                { MessageBox.Show("El ancho maximo de una tabla es 1,60 mts", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

//                if (largo2 < 0.1)
//                {
//                    MessageBox.Show("seleccione un largo superior a 10 cm", "error",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }

//                double cantidadpies2 = Calcularpies(espesorpulgadas2, resultadoconversion2, largo2, coeficiente, cantidad2);
//                totalpies += cantidadpies2;
//                lblpie2.Text = $"{cantidadpies2:F2}";
//                lblpie2.Visible = true;
//            }

//            if (chk3.Checked)
//            {
//                if (espesorcm3 <= 0)
//                {
//                    MessageBox.Show("el espesor no puede ser cero o negativo, por favor ingrese un numero superior a cero y menor que 10", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                else if (espesorcm3 > 0 && espesorcm3 <= 2.5)
//                {
//                    espesorpulgadas3 = 1;
//                }
//                else if (espesorcm3 > 2.5 && espesorcm3 <= 3.2)
//                {
//                    espesorpulgadas3 = 1.5;
//                }
//                else if (espesorcm3 > 3.2 && espesorcm3 <= 5)
//                {
//                    espesorpulgadas3 = 2;
//                }
//                else if (espesorcm3 > 5 && espesorcm3 <= 7.5)
//                {
//                    espesorpulgadas3 = 3;
//                }
//                else if (espesorcm3 > 7.5 && espesorcm3 <= 10)
//                {
//                    espesorpulgadas3 = 4;
//                }
//                else
//                {
//                    MessageBox.Show("no es posible utilizar espesores superiores a 10 cm", "error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                if (anchocm3 <= 0)
//                { MessageBox.Show("seleccione un ancho superior a 0 cm", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

//                if (resultadoconversion3 > 63)
//                { MessageBox.Show("El ancho maximo de una tabla es 1,60 mts", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

//                if (largo3 < 0.1)
//                {
//                    MessageBox.Show("seleccione un largo superior a 10 cm", "error",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }



//                double cantidadpies3 = Calcularpies(espesorpulgadas3, resultadoconversion3, largo3, coeficiente, cantidad3);
//                totalpies += cantidadpies3;
//                lblpie3.Text = $"{cantidadpies3:F2}";
//                lblpie3.Visible = true;
//            }

//            if (chk4.Checked)
//            {
//                if (espesorcm4 <= 0)
//                {
//                    MessageBox.Show("el espesor no puede ser cero o negativo, por favor ingrese un numero superior a cero y menor que 10", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                else if (espesorcm4 > 0 && espesorcm4 <= 2.5)
//                {
//                    espesorpulgadas4 = 1;
//                }
//                else if (espesorcm4 > 2.5 && espesorcm4 <= 3.2)
//                {
//                    espesorpulgadas4 = 1.5;
//                }
//                else if (espesorcm4 > 3.2 && espesorcm4 <= 5)
//                {
//                    espesorpulgadas4 = 2;
//                }
//                else if (espesorcm4 > 5 && espesorcm4 <= 7.5)
//                {
//                    espesorpulgadas4 = 3;
//                }
//                else if (espesorcm4 > 7.5 && espesorcm4 <= 10)
//                {
//                    espesorpulgadas4 = 4;
//                }
//                else
//                {
//                    MessageBox.Show("no es posible utilizar espesores superiores a 10 cm", "error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }

//                if (anchocm4 <= 0)
//                { MessageBox.Show("seleccione un ancho superior a 0 cm", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
//                if (resultadoconversion4 > 63)
//                { MessageBox.Show("El ancho maximo de una tabla es 1,60 mts", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
//                if (largo4 < 0.1)
//                {
//                    MessageBox.Show("seleccione un largo superior a 10 cm", "error",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }





//                double cantidadpies4 = Calcularpies(espesorpulgadas4, resultadoconversion4, largo4, coeficiente, cantidad4);
//                totalpies += cantidadpies4;

//                lblpie4.Text = $"{cantidadpies4:F2}";
//                lblpie4.Visible = true;
//            }

//            if (chk5.Checked)
//            {
//                if (espesorcm5 <= 0)
//                {
//                    MessageBox.Show("el espesor no puede ser cero o negativo, por favor ingrese un numero superior a cero y menor que 10", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                else if (espesorcm5 > 0 && espesorcm5 <= 2.5)
//                {
//                    espesorpulgadas5 = 1;
//                }
//                else if (espesorcm5 > 2.5 && espesorcm5 <= 3.2)
//                {
//                    espesorpulgadas5 = 1.5;
//                }
//                else if (espesorcm5 > 3.2 && espesorcm5 <= 5)
//                {
//                    espesorpulgadas5 = 2;
//                }
//                else if (espesorcm5 > 5 && espesorcm5 <= 7.5)
//                {
//                    espesorpulgadas5 = 3;
//                }
//                else if (espesorcm5 > 7.5 && espesorcm5 <= 10)
//                {
//                    espesorpulgadas5 = 4;
//                }
//                else
//                {
//                    MessageBox.Show("no es posible utilizar espesores superiores a 10 cm", "error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                if (anchocm5 <= 0)
//                { MessageBox.Show("seleccione un ancho superior a 0 cm", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

//                if (resultadoconversion5 > 63)
//                { MessageBox.Show("El ancho maximo de una tabla es 1,60 mts", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }


//                if (largo5 < 0.1)
//                {
//                    MessageBox.Show("seleccione un largo superior a 10 cm", "error",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }



//                double cantidadpies5 = Calcularpies(espesorpulgadas5, resultadoconversion5, largo5, coeficiente, cantidad5);
//                totalpies += cantidadpies5;

//                lblpie5.Text = $"{cantidadpies5:F2}";
//                lblpie5.Visible = true;
//            }

//            if (chk6.Checked)
//            {
//                if (espesorcm6 <= 0)
//                {
//                    MessageBox.Show("el espesor no puede ser cero o negativo, por favor ingrese un numero superior a cero y menor que 10", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                else if (espesorcm6 > 0 && espesorcm6 <= 2.5)
//                {
//                    espesorpulgadas5 = 1;
//                }
//                else if (espesorcm6 > 2.5 && espesorcm6 <= 3.2)
//                {
//                    espesorpulgadas5 = 1.5;
//                }
//                else if (espesorcm6 > 3.2 && espesorcm6 <= 5)
//                {
//                    espesorpulgadas1 = 2;
//                }
//                else if (espesorcm6 > 5 && espesorcm6 <= 7.5)
//                {
//                    espesorpulgadas1 = 3;
//                }
//                else if (espesorcm6 > 7.5 && espesorcm6 <= 10)
//                {
//                    espesorpulgadas6 = 4;
//                }
//                else
//                {
//                    MessageBox.Show("no es posible utilizar espesores superiores a 10 cm", "error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                if (anchocm6 <= 0)
//                { MessageBox.Show("seleccione un ancho superior a 0 cm", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

//                if (resultadoconversion6 > 63)
//                { MessageBox.Show("El ancho maximo de una tabla es 1,60 mts", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

//                if (largo6 < 0.1)
//                {
//                    MessageBox.Show("seleccione un largo superior a 10 cm", "error",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }

//                double cantidadpies6 = Calcularpies(espesorpulgadas6, resultadoconversion6, largo6, coeficiente, cantidad6);
//                totalpies += cantidadpies6;

//                lblpie6.Text = $"{cantidadpies6:F2}";
//                lblpie6.Visible = true;
//            }

//            double desperdicio = 0;
//            double porcentajedesperdicio = 0;
//            string textodesperdicio = txtdesperdicio.Text;
//            double.TryParse(textodesperdicio, out desperdicio);
//            string textoganancia = txtganancia.Text;
//            porcentajedesperdicio = desperdicio / 100 + 1;
//            totalpies = totalpies * porcentajedesperdicio;


//            if (desperdicio < 0)
//            {
//                MessageBox.Show("el desperdicio no puede ser menor que cero, por favor indique un valor igual o superior a cero (0)", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                txtdesperdicio.Select();
//            }
                                             
//            lblcalculopies.Text = $"{totalpies:F2}";
//            lblcalculopies.Visible = true;
        
//        }
//        public void btncalcularpresupuesto_Click(object sender, EventArgs e)
//        {            
//            double totalguias1 = 0;
//            double totalguias2 = 0;
//            double gastosvarios = 0;
//            double otrosmateriales = 0;
//            double totalmateriales = 0;
//            double ganancia = 0;
//            double porcentajeganancia = 0;
//            string textoganancia = txtganancia.Text;
//            double.TryParse(textoganancia, out ganancia);
//            porcentajeganancia = ganancia / 100 + 1;
//            string textopreciomadera = lblvalorpies.Text;
//            double.TryParse(textopreciomadera, out double preciomadera);
//            double presupuesto = 0;
//            string textopies = lblcalculopies.Text;
//            double.TryParse(textopies, out double pies);
//            double totalvidrios = 0;
//            double valortotalvidrios1 = 0;
//            double valortotalvidrios2 = 0;
//            double valortotalvidrios3 = 0;
//            double totalbisagras = 0;

//            if (ganancia <= 0)
//            {
//                MessageBox.Show("la ganancia no puede ser igual o menor que cero (0), por favor indique el porcentaje de ganancia que desea obtener con este mueble", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            if (chkvidrio1.Checked)
//            {
//                double largovidrio1 = 0;
//                double anchovidrio1 = 0;
//                double cantidad1 = 0;
//                double valortipovidrio1 = 0;
//                double valorunitario1 = 0;
//                double valortotal1 = 0;
                
//                if (cmbvidrios1.SelectedIndex == 0)
//                {
//                    MessageBox.Show("Seleccione un modelo de vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textovalorvidrio1 = lblvalorxmetro21.Text;
//                double.TryParse(textovalorvidrio1, out valortipovidrio1);

//                if (txtvidriolargo1 == null)
//                {
//                    MessageBox.Show("ingrese el largo del vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textolargo1 = txtvidriolargo1.Text;
//                double.TryParse(textolargo1, out largovidrio1);

//                if (txtvidrioancho1 == null)
//                {
//                    MessageBox.Show("ingrese el ancho del vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textoancho1 = txtvidrioancho1.Text;
//                double.TryParse(textoancho1, out anchovidrio1);

//                if (txtvidriocant1 == null)
//                {
//                    MessageBox.Show("ingrese la cantidad de vidrios", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textocantidad1 = txtvidriocant1.Text;
//                double.TryParse(textocantidad1, out cantidad1);

//                valorunitario1 = largovidrio1 * anchovidrio1;
//                valortotal1 = valorunitario1 * cantidad1 * valortipovidrio1;
                                
//                lblvidriounidad1.Text = $"{valorunitario1:F2}";
//                lblvidriototal1.Text = $"{valortotal1:F2}";

//            }

//            if (chkvidrio2.Checked)
//            {
//                double largovidrio2 = 0;
//                double anchovidrio2 = 0;
//                double cantidad2 = 0;
//                double valortipovidrio2 = 0;
//                double valorunitario2 = 0;
//                double valortotal2 = 0;

//                if (cmbvidrios2.SelectedIndex == 0)
//                {
//                    MessageBox.Show("Seleccione un modelo de vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textovalorvidrio = lblvalorxmetro22.Text;
//                double.TryParse(textovalorvidrio, out valortipovidrio2);

//                if (txtvidriolargo2 == null)
//                {
//                    MessageBox.Show("ingrese el largo del vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textolargo2 = txtvidriolargo2.Text;
//                double.TryParse(textolargo2, out largovidrio2);

//                if (txtvidrioancho2 == null)
//                {
//                    MessageBox.Show("ingrese el ancho del vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textoancho2 = txtvidrioancho2.Text;
//                double.TryParse(textoancho2, out anchovidrio2);

//                if (txtvidriocant2 == null)
//                {
//                    MessageBox.Show("ingrese la cantidad de vidrios", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textocantidad2 = txtvidriocant2.Text;
//                double.TryParse(textocantidad2, out cantidad2);

//                valorunitario2 = largovidrio2 * anchovidrio2;
//                valortotal2 = valorunitario2 * cantidad2 * valortipovidrio2;

//                lblvidriounidad2.Text = $"{valorunitario2:F2}";
//                lblvidriototal2.Text = $"{valortotal2:F2}";

//            }

//            if (chkvidrio3.Checked)
//            {
//                double largovidrio3 = 0;
//                double anchovidrio3 = 0;
//                double cantidad3 = 0;

//                double valortipovidrio3 = 0;
//                double valorunitario3 = 0;
//                double valortotal3 = 0;

//                if (cmbvidrios3.SelectedIndex == 0)
//                {
//                    MessageBox.Show("Seleccione un modelo de vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textovalorvidrio3 = lblvalorxmetro23.Text;
//                double.TryParse(textovalorvidrio3, out valortipovidrio3);

//                if (txtvidriolargo3 == null)
//                {
//                    MessageBox.Show("ingrese el largo del vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textolargo3 = txtvidriolargo3.Text;
//                double.TryParse(textolargo3, out largovidrio3);

//                if (txtvidrioancho3 == null)
//                {
//                    MessageBox.Show("ingrese el ancho del vidrio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textoancho3 = txtvidrioancho3.Text;
//                double.TryParse(textoancho3, out anchovidrio3);

//                if (txtvidriocant3 == null)
//                {
//                    MessageBox.Show("ingrese la cantidad de vidrios", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textocantidad3 = txtvidriocant3.Text;
//                double.TryParse(textocantidad3, out cantidad3);

//                valorunitario3 = largovidrio3 * anchovidrio3;
//                valortotal3 = valorunitario3 * cantidad3 * valortipovidrio3;

//                lblvidriounidad3.Text = $"{valorunitario3:F2}";
//                lblvidriototal3.Text = $"{valortotal3:F2}";

//            }

//            string vidrio1 = lblvidriototal1.Text;
//            double.TryParse(vidrio1, out valortotalvidrios1 );
//            string vidrio2 = lblvidriototal2.Text;
//            double.TryParse(vidrio2, out valortotalvidrios2);
//            string vidrio3 = lblvidriototal3.Text;
//            double.TryParse(vidrio3, out valortotalvidrios3);

//            totalvidrios = valortotalvidrios1 + valortotalvidrios2 + valortotalvidrios3;
//            lbltotalvidrios.Text = $"{totalvidrios:F2}";

//            if (chkbisagras1.Checked)
//            {
//                double cantidad = 0;
//                double unidad = 0;
                
//                if(cmbbisagras1.SelectedIndex == 0)
//                { MessageBox.Show("Seleccione un modelo de bisagras", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

//                string textocantidadbisagras = txtbisagrascantidad.Text;
//                double.TryParse(textocantidadbisagras, out cantidad);

//                if (cantidad <= 0)
//                {
//                    MessageBox.Show("Seleccione la cantidad de bisagras a utilizar", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
                                
//                string textounidadbisagras = lblbisagrasunidad1.Text;
//                double.TryParse(textounidadbisagras, out unidad);

//                totalbisagras = unidad * cantidad;
//                lbltotalbisagras.Text = $"{totalbisagras:F2}";
                       
//            }

//            if (chkguias1.Checked)
//            {
//                if (txtguias1 == null)
//                {
//                    MessageBox.Show("ingrese la cantidad de guias a utilizar", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textoguias1 = txtguias1.Text;
//                double.TryParse(textoguias1, out double cantidadguias1);
//                string guiasxunidad1 = lblvalorguias1.Text;
//                double.TryParse(guiasxunidad1, out double valorguiasunidad1);
//                totalguias1 = valorguiasunidad1 * cantidadguias1;
//                lbltotalguias1.Text = $"{totalguias1:F2}";
//                lbltotalguias1.Visible = true;
//            }

//            if (chkguias2.Checked)
//            {
//                if (txtguias2 == null)
//                {
//                    MessageBox.Show("ingrese la cantidad de guias a utilizar", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                string textoguias2 = txtguias2.Text;
//                double.TryParse(textoguias2, out double cantidadguias2);
//                string guiasxunidad2 = lblvalorguias2.Text;
//                double.TryParse(guiasxunidad2, out double valorguiasunidad2);
//                totalguias2 = valorguiasunidad2 * cantidadguias2;
//                lbltotalguias2.Text = $"{totalguias2:F2}";
//                lbltotalguias2.Visible = true;
//            }

//            if (chkotrosmateriales.Checked)
//            {
//                string textootrosmateriales = txtmateriales.Text;
//                double.TryParse(textootrosmateriales, out otrosmateriales);
//                lblotrosmateriales.Text = $"{otrosmateriales}";
//            }
          
//            if (chkgastosvarios.Checked)
//            {
//                string textogastosvarios = txtgastosvarios.Text;
//                double.TryParse(textogastosvarios, out gastosvarios);
//                lbltotalgastosvarios.Text = $"{gastosvarios}";
//            }

//            double precioporpie = 0;
//            string maderaseleccionada = cmbmaderas.SelectedItem?.ToString();

//            if (maderaseleccionada == "Pino") { precioporpie = 2000; }
//            else if (maderaseleccionada == "Petiribi") { precioporpie = 3600; }
//            else if (maderaseleccionada == "Guayubira") { precioporpie = 2950; }
//            else if (maderaseleccionada == "Paraiso") { precioporpie = 2300; }
//            else if (maderaseleccionada == "Cancharana") { precioporpie = 3000; }
//            else if (maderaseleccionada == "Alamo") { precioporpie = 2222; }
//            else { MessageBox.Show("Por favor seleccione una madera para calcular el presupuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

//            if (cmbmaderas.Text == "Pino")
//            { lblpresupuesto.Text = $"{presupuesto:F2}"; }
//            else if (cmbmaderas.Text == "Petiribi")
//            { lblpresupuesto.Text = $"{presupuesto:F2}"; }
//            else if (cmbmaderas.Text == "Guayubira")
//            { lblpresupuesto.Text = $"{presupuesto:F2}"; }
//            else if (cmbmaderas.Text == "Paraiso")
//            { lblpresupuesto.Text = $"{presupuesto:F2}"; }
//            else if (cmbmaderas.Text == "cancharana")
//            { lblpresupuesto.Text = $"{presupuesto:F2}"; }

//            lblpresupuesto.Visible = true;

//            double presupuestototal = 0;
//            totalmateriales = totalguias1 + totalguias2 + gastosvarios + otrosmateriales;
//            presupuestototal = (pies * porcentajeganancia * precioporpie) + totalmateriales + totalvidrios + totalbisagras;
//            lbltotalgastosadicionales.Text = $"$ {totalmateriales}";
//            lblpresupuesto.Text = $"{presupuestototal}";

//        }

//        private void btnlimpiarmedidas_Click(object sender, EventArgs e)
//        {
//            txtespesorm1.Clear(); txtespesorm2.Clear(); txtespesorm3.Clear(); txtespesorm4.Clear(); txtespesorm5.Clear(); txtespesorm6.Clear();
//            txtanchom1.Clear(); txtanchom2.Clear(); txtanchom3.Clear(); txtanchom4.Clear(); txtanchom5.Clear(); txtanchom6.Clear(); txtlargom1.Clear(); txtlargom2.Clear(); txtlargom3.Clear(); txtlargom4.Clear(); txtlargom5.Clear(); txtlargom6.Clear(); txtcantidad1.Clear(); txtcantidad2.Clear(); txtcantidad3.Clear(); txtcantidad4.Clear(); txtcantidad5.Clear(); txtcantidad6.Clear(); txtdescmad1.Clear(); txtdescmad2.Clear(); txtdescmad3.Clear(); txtdescmad4.Clear(); txtdescmad5.Clear(); txtdescmad6.Clear(); txtguias1.Clear(); txtguias2.Clear(); txtmateriales.Clear(); txtgastosvarios.Clear(); txtdesperdicio.Clear(); txtganancia.Clear(); txtvidrioancho1.Clear(); txtvidrioancho2.Clear(); txtvidrioancho3.Clear(); txtvidriocant1.Clear(); txtvidriocant2.Clear(); txtvidriocant3.Clear(); txtvidriolargo1.Clear(); txtvidriolargo2.Clear(); txtvidriolargo3.Clear(); txtbisagrascantidad.Clear();

//            lblcalculopies.Text = null; lblcalculopies.Visible = false;
//            lblpresupuesto.Text = null; lblpresupuesto.Visible = false;
//            lblvalorpies.Text = null; lblvalorpies.Visible = false;
//            lblpie1.Text = null; lblpie1.Visible = false;
//            lblpie2.Text = null; lblpie2.Visible = false;
//            lblpie3.Text = null; lblpie3.Visible = false;
//            lblpie4.Text = null; lblpie4.Visible = false;
//            lblpie5.Text = null; lblpie5.Visible = false;
//            lblpie6.Text = null; lblpie6.Visible = false;
            
//            lblvidriounidad1.Text = "$"; lblvidriounidad2.Text = "$"; lblvidriounidad3.Text = "$"; lblvidriototal1.Text = "$"; lblvidriototal2.Text = "$"; lblvidriototal3.Text = "$"; lbltotalvidrios.Text = "$"; lblvalorxmetro21.Text = "$"; lblvalorxmetro22.Text = "$"; lblvalorxmetro23.Text = "$"; lblbisagrasunidad1.Text = "$"; lbltotalbisagras.Text = "$"; lblvalorguias1.Text = "$"; lblvalorguias2.Text = "$"; lbltotalguias1.Text = "$"; lbltotalguias2.Text = "$"; lblotrosmateriales.Text = "$"; lbltotalgastosadicionales.Text = "$";
//            lbltotalgastosvarios.Text = "$"; lbltotalgastosadicionales.Text = "$";
           
//            chk1.Checked = false; chk2.Checked = false; chk3.Checked = false; chk4.Checked = false; chk5.Checked = false; chk6.Checked = false; chkvidrio1.Checked = false;
//            chkvidrio2.Checked = false; chkvidrio3.Checked = false; chkguias1.Checked = false;
//            chkguias2.Checked = false; chkgastosvarios.Checked = false; chkotrosmateriales.Checked = false; chkbisagras1.Checked = false;


//            cmbguias1.SelectedIndex = 0; cmbguias2.SelectedIndex = 0; cmbmaderas.SelectedIndex = 0; cmbvidrios1.SelectedIndex = 0; cmbvidrios2.SelectedIndex = 0; cmbvidrios3.SelectedIndex = 0; cmbbisagras1.SelectedIndex = 0;

//        }

//        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }

//        private void label5_Click(object sender, EventArgs e)
//        {

//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {           
//            cmbmaderas.Items.Add("Seleccione una madera");
//            cmbmaderas.Items.Add("Cancharana");
//            cmbmaderas.Items.Add("Paraiso");
//            cmbmaderas.Items.Add("Guayubira");
//            cmbmaderas.Items.Add("Pino");
//            cmbmaderas.Items.Add("Alamo");
//            cmbmaderas.Items.Add("Petiribi");
//            cmbmaderas.SelectedIndex = 0;
//            txtespesorm1.Select();

//            cmbguias1.Items.Add("Seleccione el lagro de las guias");
//            cmbguias1.Items.Add("25 cm");
//            cmbguias1.Items.Add("30 cm");
//            cmbguias1.Items.Add("35 cm");
//            cmbguias1.Items.Add("40 cm");
//            cmbguias1.Items.Add("45 cm");
//            cmbguias1.Items.Add("50 cm");
//            cmbguias1.Items.Add("55 cm");
//            cmbguias1.Items.Add("60 cm");
//            cmbguias1.SelectedIndex = 0;

//            cmbguias2.Items.Add("Seleccione el lagro de las guias");
//            cmbguias2.Items.Add("25 cm");
//            cmbguias2.Items.Add("30 cm");
//            cmbguias2.Items.Add("35 cm");
//            cmbguias2.Items.Add("40 cm");
//            cmbguias2.Items.Add("45 cm");
//            cmbguias2.Items.Add("50 cm");
//            cmbguias2.Items.Add("55 cm");
//            cmbguias2.Items.Add("60 cm");
//            cmbguias2.SelectedIndex = 0;

//            cmbvidrios1.Items.Add("Seleccione un modelo de vidrio");
//            cmbvidrios1.Items.Add("Float 3 mm");
//            cmbvidrios1.Items.Add("Float 4 mm");
//            cmbvidrios1.Items.Add("Float 5 mm");
//            cmbvidrios1.Items.Add("Float 6 mm");
//            cmbvidrios1.Items.Add("Float laminado 6 mm");
//            cmbvidrios1.Items.Add("Martele incoloro 3 mm");
//            cmbvidrios1.Items.Add("Martele ambar 3 mm");
//            cmbvidrios1.Items.Add("Martele verde 3 mm");
//            cmbvidrios1.Items.Add("Martele azul 3 mm");
//            cmbvidrios1.Items.Add("Esmerilado 3 mm");
//            cmbvidrios1.Items.Add("Opacid 3 mm");
//            cmbvidrios1.Items.Add("Stepolyte 3 mm");
//            cmbvidrios1.Items.Add("Espejo 3 mm");
//            cmbvidrios1.Items.Add("Espejo 4 mm");
//            cmbvidrios1.Items.Add("Espejo 5 mm");
//            cmbvidrios1.SelectedIndex = 0;

//            cmbvidrios2.Items.Add("Seleccione un modelo de vidrio");
//            cmbvidrios2.Items.Add("Float 3 mm");
//            cmbvidrios2.Items.Add("Float 4 mm");
//            cmbvidrios2.Items.Add("Float 5 mm");
//            cmbvidrios2.Items.Add("Float 6 mm");
//            cmbvidrios2.Items.Add("Float laminado 6 mm");
//            cmbvidrios2.Items.Add("Martele incoloro 3 mm");
//            cmbvidrios2.Items.Add("Martele ambar 3 mm");
//            cmbvidrios2.Items.Add("Martele verde 3 mm");
//            cmbvidrios2.Items.Add("Martele azul 3 mm");
//            cmbvidrios2.Items.Add("Esmerilado 3 mm");
//            cmbvidrios2.Items.Add("Opacid 3 mm");
//            cmbvidrios2.Items.Add("Stepolyte 3 mm");
//            cmbvidrios2.Items.Add("Espejo 3 mm");
//            cmbvidrios2.Items.Add("Espejo 4 mm");
//            cmbvidrios2.Items.Add("Espejo 5 mm");
//            cmbvidrios2.SelectedIndex = 0;

//            cmbvidrios3.Items.Add("Seleccione un modelo de vidrio");
//            cmbvidrios3.Items.Add("Float 3 mm");
//            cmbvidrios3.Items.Add("Float 4 mm");
//            cmbvidrios3.Items.Add("Float 5 mm");
//            cmbvidrios3.Items.Add("Float 6 mm");
//            cmbvidrios3.Items.Add("Float laminado 6 mm");
//            cmbvidrios3.Items.Add("Martele incoloro 3 mm");
//            cmbvidrios3.Items.Add("Martele ambar 3 mm");
//            cmbvidrios3.Items.Add("Martele verde 3 mm");
//            cmbvidrios3.Items.Add("Martele azul 3 mm");
//            cmbvidrios3.Items.Add("Esmerilado 3 mm");
//            cmbvidrios3.Items.Add("Opacid 3 mm");
//            cmbvidrios3.Items.Add("Stepolyte 3 mm");
//            cmbvidrios3.Items.Add("Espejo 3 mm");
//            cmbvidrios3.Items.Add("Espejo 4 mm");
//            cmbvidrios3.Items.Add("Espejo 5 mm");
//            cmbvidrios3.SelectedIndex = 0;

//            cmbbisagras1.Items.Add("Seleccione un modelo de bisagra");
//            cmbbisagras1.Items.Add("Bisagra OH");
//            cmbbisagras1.Items.Add("Bisagra T 3 pulgadas");
//            cmbbisagras1.Items.Add("Bisagra T 4 pulgadas");
//            cmbbisagras1.Items.Add("Bisagra Libro 63 mm");
//            cmbbisagras1.Items.Add("Bisagra Libro 75 mm");
//            cmbbisagras1.Items.Add("Bisagra Ficha 50 mm");
//            cmbbisagras1.Items.Add("Bisagra Ficha 63 mm");
//            cmbbisagras1.Items.Add("Bisagra Cazoleta codo 0");
//            cmbbisagras1.Items.Add("Bisagra Cazoleta codo 90°");
//            cmbbisagras1.SelectedIndex = 0;

//            chk1.Select();
//        }

//        private void lblmaderas_Click(object sender, EventArgs e)
//        {

//        }

//        private void btnguardarpresupuesto_Click(object sender, EventArgs e)
//        {

//        }

//        private void cmbmaderas_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (cmbmaderas.Text == "Pino")
//            { lblvalorpies.Text = $"$1.000"; }
//            else if (cmbmaderas.Text == "Petiribi")
//            { lblvalorpies.Text = $"$3.400"; }
//            else if (cmbmaderas.Text == "Guayubira")
//            { lblvalorpies.Text = $"$2.850"; }
//            else if (cmbmaderas.Text == "Paraiso")
//            { lblvalorpies.Text = $"$2.200"; }
//            else if (cmbmaderas.Text == "cancharana")
//            { lblvalorpies.Text = $"$2.850"; }
//            lblvalorpies.Visible = true;
//        }

//        private void cmbguias_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (cmbguias1.Text == "25 cm")
//            { lblvalorguias1.Text = $"3752"; }
//            if (cmbguias1.Text == "30 cm")
//            { lblvalorguias1.Text = $"4417"; }
//            if (cmbguias1.Text == "35 cm")
//            { lblvalorguias1.Text = $"5143"; }
//            if (cmbguias1.Text == "40 cm")
//            { lblvalorguias1.Text = $"5916"; }
//            if (cmbguias1.Text == "45 cm")
//            { lblvalorguias1.Text = $"6837"; }
//            if (cmbguias1.Text == "50 cm")
//            { lblvalorguias1.Text = $"7502"; }
//            if (cmbguias1.Text == "55 cm")
//            { lblvalorguias1.Text = $"8046"; }
//            if (cmbguias1.Text == "60 cm")
//            { lblvalorguias1.Text = $"8773"; }
//        }
//        private void cmbguias2_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (cmbguias2.Text == "25 cm")
//            { lblvalorguias2.Text = $"3752"; }
//            if (cmbguias2.Text == "30 cm")
//            { lblvalorguias2.Text = $"4417"; }
//            if (cmbguias2.Text == "35 cm")
//            { lblvalorguias2.Text = $"5143"; }
//            if (cmbguias2.Text == "40 cm")
//            { lblvalorguias2.Text = $"5916"; }
//            if (cmbguias2.Text == "45 cm")
//            { lblvalorguias2.Text = $"6837"; }
//            if (cmbguias2.Text == "50 cm")
//            { lblvalorguias2.Text = $"7502"; }
//            if (cmbguias2.Text == "55 cm")
//            { lblvalorguias2.Text = $"8046"; }
//            if (cmbguias2.Text == "60 cm")
//            { lblvalorguias2.Text = $"8773"; }
//        }
//        private void cmbvidrios1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (cmbvidrios1.Text == "Float 3 mm") { lblvalorxmetro21.Text = "12200"; }
//            if (cmbvidrios1.Text == "Float 4 mm") { lblvalorxmetro21.Text = "14972"; }
//            if (cmbvidrios1.Text == "Float 5 mm") { lblvalorxmetro21.Text = "19385"; }
//            if (cmbvidrios1.Text == "Float 6 mm") { lblvalorxmetro21.Text = "24898"; }
//            if (cmbvidrios1.Text == "Float laminado 6 mm") { lblvalorxmetro21.Text = "45492"; }
//            if (cmbvidrios1.Text == "Martele incoloro 3 mm") { lblvalorxmetro21.Text = "19580"; }
//            if (cmbvidrios1.Text == "Martele ambar 3 mm") { lblvalorxmetro21.Text = "35544"; }
//            if (cmbvidrios1.Text == "Martele verde 3 mm") { lblvalorxmetro21.Text = "35544"; }
//            if (cmbvidrios1.Text == "Martele azul 3 mm") { lblvalorxmetro21.Text = "35544"; }
//            if (cmbvidrios1.Text == "Esmerilado 3 mm") { lblvalorxmetro21.Text = "25362"; }
//            if (cmbvidrios1.Text == "Opacid 3 mm") { lblvalorxmetro21.Text = "9807"; }
//            if (cmbvidrios1.Text == "Stepolyte 3 mm") { lblvalorxmetro21.Text = "18571"; }
//            if (cmbvidrios1.Text == "Espejo 3 mm") { lblvalorxmetro21.Text = "24560"; }
//            if (cmbvidrios1.Text == "Espejo 4 mm") { lblvalorxmetro21.Text = "30205"; }
//            if (cmbvidrios1.Text == "Espejo 5 mm") { lblvalorxmetro21.Text = "39465"; }

//        }
//        private void cmbvidrios2_SelectedIndexChanged_1(object sender, EventArgs e)
//        {
//            if (cmbvidrios2.Text == "Float 3 mm") { lblvalorxmetro22.Text = "12200"; }
//            if (cmbvidrios2.Text == "Float 4 mm") { lblvalorxmetro22.Text = "14972"; }
//            if (cmbvidrios2.Text == "Float 5 mm") { lblvalorxmetro22.Text = "19385"; }
//            if (cmbvidrios2.Text == "Float 6 mm") { lblvalorxmetro22.Text = "24898"; }
//            if (cmbvidrios2.Text == "Float laminado 6 mm") { lblvalorxmetro22.Text = "45492"; }
//            if (cmbvidrios2.Text == "Martele incoloro 3 mm") { lblvalorxmetro22.Text = "19580"; }
//            if (cmbvidrios2.Text == "Martele ambar 3 mm") { lblvalorxmetro22.Text = "35544"; }
//            if (cmbvidrios2.Text == "Martele verde 3 mm") { lblvalorxmetro22.Text = "35544"; }
//            if (cmbvidrios2.Text == "Martele azul 3 mm") { lblvalorxmetro22.Text = "35544"; }
//            if (cmbvidrios2.Text == "Esmerilado 3 mm") { lblvalorxmetro22.Text = "25362"; }
//            if (cmbvidrios2.Text == "Opacid 3 mm") { lblvalorxmetro22.Text = "9807"; }
//            if (cmbvidrios2.Text == "Stepolyte 3 mm") { lblvalorxmetro22.Text = "18571"; }
//            if (cmbvidrios1.Text == "Espejo 3 mm") { lblvalorxmetro21.Text = "24560"; }
//            if (cmbvidrios1.Text == "Espejo 4 mm") { lblvalorxmetro21.Text = "30205"; }
//            if (cmbvidrios1.Text == "Espejo 5 mm") { lblvalorxmetro21.Text = "39465"; }

//        }
//        private void cmbvidrios3_SelectedIndexChanged(object sender, EventArgs e)
//        {

//            if (cmbvidrios3.Text == "Float 3 mm") { lblvalorxmetro23.Text = "12200"; }
//            if (cmbvidrios3.Text == "Float 4 mm") { lblvalorxmetro23.Text = "14972"; }
//            if (cmbvidrios3.Text == "Float 5 mm") { lblvalorxmetro23.Text = "19385"; }
//            if (cmbvidrios3.Text == "Float 6 mm") { lblvalorxmetro23.Text = "24898"; }
//            if (cmbvidrios3.Text == "Float laminado 6 mm") { lblvalorxmetro23.Text = "45492"; }
//            if (cmbvidrios3.Text == "Martele incoloro 3 mm") { lblvalorxmetro23.Text = "19580"; }
//            if (cmbvidrios3.Text == "Martele ambar 3 mm") { lblvalorxmetro23.Text = "35544"; }
//            if (cmbvidrios3.Text == "Martele verde 3 mm") { lblvalorxmetro23.Text = "35544"; }
//            if (cmbvidrios3.Text == "Martele azul 3 mm") { lblvalorxmetro23.Text = "35544"; }
//            if (cmbvidrios3.Text == "Esmerilado 3 mm") { lblvalorxmetro23.Text = "25362"; }
//            if (cmbvidrios3.Text == "Opacid 3 mm") { lblvalorxmetro23.Text = "9807"; }
//            if (cmbvidrios3.Text == "Stepolyte 3 mm") { lblvalorxmetro23.Text = "18571"; }
//            if (cmbvidrios3.Text == "Espejo 3 mm") { lblvalorxmetro23.Text = "24560"; }
//            if (cmbvidrios3.Text == "Espejo 4 mm") { lblvalorxmetro23.Text = "30205"; }
//            if (cmbvidrios3.Text == "Espejo 5 mm") { lblvalorxmetro23.Text = "39465"; }

//        }

//        private void cmbbisagras1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (cmbbisagras1.Text == "Bisagra T 3 pulgadas")
//            { lblbisagrasunidad1.Text = "765"; }
//            if (cmbbisagras1.Text == "Bisagra T 4 pulgadas")
//            { lblbisagrasunidad1.Text = "873"; }
//            if (cmbbisagras1.Text == "Bisagra Libro 63 mm")
//            { lblbisagrasunidad1.Text = "595"; }
//            if (cmbbisagras1.Text == "Bisagra Libro 75 mm")
//            { lblbisagrasunidad1.Text = "1069"; }
//            if (cmbbisagras1.Text == "Bisagra Ficha 63 mm")
//            { lblbisagrasunidad1.Text = "1426"; }
//            if (cmbbisagras1.Text == "Bisagra Ficha 50 mm")
//            { lblbisagrasunidad1.Text = "1132"; }
//            if (cmbbisagras1.Text == "Bisagra Cazoleta codo 0")
//            { lblbisagrasunidad1.Text = "545"; }
//            if (cmbbisagras1.Text == "Bisagra Cazoleta codo 90°")
//            { lblbisagrasunidad1.Text = "545"; }
//            if (cmbbisagras1.Text == "Bisagra OH")
//            { lblbisagrasunidad1.Text = "666"; }
//        }


//        private void ValoresMaderas()
//        {
//            string cadenaconexion;
//            SqlConnection cnn;
//            SqlDataAdapter da;
//            DataSet ds;

//            try
//            {
//                // Cadena de conexión para SQL Server
//                cadenaconexion = "Data Source=.;Initial Catalog=CalculoPies;Integrated Security=True";

//                cnn = new SqlConnection(cadenaconexion);
//                if (cnn.State == ConnectionState.Open) cnn.Close();
//                cnn.Open();

//                string consultasql = "SELECT Madera, valor FROM Maderas";

//                da = new SqlDataAdapter(consultasql, cnn);
//                ds = new DataSet();
//                da.Fill(ds);

//                cnn.Close();

//                dgvmaderas.DataSource = ds.Tables[0];
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error al conectar con base de datos: " + ex.Message);
//            }
//        }


//        private void dgvmaderas_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {
//            dgvmaderas.AutoGenerateColumns = true;
//            dgvmaderas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
//            ValoresMaderas();
//        }

//        private void btnmostrartodas_Click(object sender, EventArgs e)
//        {
//            ValoresMaderas();
//        }

//        private void btncerrar_Click(object sender, EventArgs e)
//        {
//            Application.Exit();
//        }

//        private void txtespesor_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void textBox16_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void txtlargom1_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void txtespesorm5_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void lblpie5_Click(object sender, EventArgs e)
//        {

//        }

//        private void checkBox1_CheckedChanged(object sender, EventArgs e)
//        {

//        }

//        private void chkguias2_CheckedChanged(object sender, EventArgs e)
//        {

//        }

//        private void txtvidrioancho1_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void txtvidrioancho3_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void txtvidrioancho2_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void txtvidriolargo1_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void txtvidriolargo2_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void txtvidriolargo3_TextChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}
