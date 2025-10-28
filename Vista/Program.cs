using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Servicios;

namespace Vista
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ClsSoloNumeros.ConfigurarCulturaEspañola();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLoguin());
        }
    }
}
