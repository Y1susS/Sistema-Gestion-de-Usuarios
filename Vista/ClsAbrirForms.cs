using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    internal class ClsAbrirForms
    {
        public static void Abrir<T>(Form formularioPadre) where T : Form, new()
        {
            // Buscar si ya existe una instancia del formulario hijo
            foreach (Form form in formularioPadre.MdiChildren)
            {
                if (form is T) //Si la encuentra
                {
                    form.BringToFront(); // Trae al frente el formulario hijo
                    // Si el formulario está minimizado, lo restaura
                    if (form.WindowState == FormWindowState.Minimized) form.WindowState = FormWindowState.Normal;
                    CentrarEnMdi(formularioPadre, form); // Centrar el formulario hijo
                    return; // Salir del método para no abrir otro
                }
            }
            // Crear una nueva instancia si no está abierta
            T FormularioHijo = new T
            {
                MdiParent = formularioPadre // Establece la relacion con el formulario padre
            };
            CentrarEnMdi(formularioPadre, FormularioHijo); // Centrar el formulario hijo
            FormularioHijo.Show(); // Mostrar el formulario hijo
        }

        //Método privado para que el formulario hijo se centre en el formulario padre
        private static void CentrarEnMdi(Form padre, Form hijo)
        {
            hijo.StartPosition = FormStartPosition.Manual; // Establece la posición de inicio manualmente
            // Calcula la posición centrada
            hijo.Location = new Point(
                (padre.ClientSize.Width - hijo.Width) / 2,
                (padre.ClientSize.Height - hijo.Height) / 2
            );
        }
    }
}
