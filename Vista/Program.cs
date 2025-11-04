using Sistema_Gestion_de_Usuarios.Vista; // Tu namespace principal
using System;
using System.Windows.Forms;
using Vista;
using Vista.Lenguajes;

namespace Sistema_Gestion_de_Usuarios.Vista
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Idioma.CargarIdiomaGuardado();

            Application.Run(new FrmLoguin());
        }
    }
}