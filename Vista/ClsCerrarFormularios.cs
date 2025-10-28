using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    //internal class ClsCerrarFormularios
    //{
    //    public static void CerrarConConfirmacion(Form formularioActual, Form formularioDestino, List<(TextBox, string)> campos)
    //    {
    //        bool todosVacios = campos.All (campo => string.IsNullOrWhiteSpace(campo.Item1.Text) || campo.Item1.Text == campo.Item2);

    //        if (todosVacios)
    //        {
    //            formularioActual.Close();
    //            formularioDestino.Show();
    //        }
    //        else
    //        {
    //            DialogResult opcion = MessageBox.Show(
    //                "Si cierra esta ventana se perderán los datos ingresados \n ¿Seguro que quiere salir?",
    //                "Advertencia",
    //                MessageBoxButtons.YesNo,
    //                MessageBoxIcon.Warning,
    //                MessageBoxDefaultButton.Button2);

    //            if (opcion == DialogResult.Yes)
    //            {
    //                formularioActual.Close();
    //                formularioDestino.Show();
    //            }
    //        }
    //    }
    //}

    internal class ClsCerrarFormularios
    {
        public static void CerrarConConfirmacion(Form formActual, Form formDestino, List<(TextBox, string)> campos)
        {
            bool todosVacios = campos.All(campo =>
                string.IsNullOrWhiteSpace(campo.Item1.Text) || campo.Item1.Text == campo.Item2);

            if (todosVacios)
            {
                formActual.Close();
                formDestino.Show();
            }
            else
            {
                DialogResult opcion = MessageBox.Show(
                    "Si cierra esta ventana se perderán los datos ingresados \n ¿Seguro que quiere salir?",
                    "Advertencia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (opcion == DialogResult.Yes)
                {
                    formActual.Close();
                    formDestino.Show();
                }
            }
        }
        public static bool CamposVacios(List<(TextBox, string)> campos)
        {
            return campos.All(campo =>
                string.IsNullOrWhiteSpace(campo.Item1.Text) || campo.Item1.Text == campo.Item2);
        }

        internal static void CerrarConConfirmacion(FrmLoguin frmLoguin1, FrmLoguin frmLoguin2, List<(TextBox, string)> list)
        {
            throw new NotImplementedException();
        }
    }
}
