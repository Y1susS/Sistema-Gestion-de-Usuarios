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

            // --- PASO CLAVE ---
            // 1. Cargar el idioma guardado antes de abrir cualquier formulario.
            Idioma.CargarIdiomaGuardado();

            // 2. Ejecutar tu formulario de Login.
            Application.Run(new FrmLoguin());
        }
    }
}