using System;
using System.Collections.Generic;
using System.Globalization; // CRÍTICO: Asegúrate de tener este using
using System.Linq;
using System.Resources; // CRÍTICO: Asegúrate de tener este using
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms; // Necesario para aplicar traducciones a Forms

namespace Vista.Lenguajes // Asegúrate de que el namespace sea correcto
{
    public static class Idioma
    {
        // CRÍTICO: ResourceManager estático con la RUTA CORRECTA a tu .resx base
        public static ResourceManager resManager = new ResourceManager(
            //"Sistema_Gestion_de_Usuarios.Vista.Lenguajes.Strings", // <--- RUTA COMPLETA DEL RECURSO BASE
            "Vista.Lenguajes.Strings",
            typeof(Idioma).Assembly);

        // ** LÍNEA CRÍTICA A AGREGAR **
        // Esta propiedad estática es necesaria para que FrmLoguin.cs compile
        public static CultureInfo CulturaActual { get; set; }

        // Ejemplo de ObtenerIdiomasDisponibles (ajusta según tu implementación)
        public static Dictionary<string, string> ObtenerIdiomasDisponibles()
        {
            // Aquí deberías devolver un diccionario con los códigos de idioma y sus nombres
            // Por ejemplo:
            return new Dictionary<string, string>
            {
                {"es-AR", "Español (Argentina)"},
                {"en-US", "English (United States)"}
                // Agrega más idiomas si tienes
            };
        }

        public static void CargarIdiomaGuardado()
        {
            //Properties.Settings.Default.Reset();
            //Properties.Settings.Default.Save();
            string idiomaGuardado = Properties.Settings.Default.Idioma;

            if (!string.IsNullOrEmpty(idiomaGuardado) && idiomaGuardado.Contains(","))
            {
                // El valor guardado está corrupto. Lo reseteamos y usamos el valor seguro.
                Properties.Settings.Default.Idioma = ""; // Limpiar
                Properties.Settings.Default.Save();
                idiomaGuardado = ""; // Usaremos el else
            }

            if (!string.IsNullOrEmpty(idiomaGuardado))
            {
                CambiarIdioma(idiomaGuardado);
            }
            else
            {
                // Si no hay idioma guardado, usa el idioma base seguro: es-AR.
                CambiarIdioma("es-AR");
            }
        }

        // Ejemplo de CambiarIdioma (ajusta según tu implementación)
        public static void CambiarIdioma(string cultura)
        {
            try
            {
                CultureInfo nuevaCultura = new CultureInfo(cultura);
                Thread.CurrentThread.CurrentCulture = nuevaCultura;
                Thread.CurrentThread.CurrentUICulture = nuevaCultura;
                CulturaActual = nuevaCultura; // Actualiza la propiedad estática
                Properties.Settings.Default.Idioma = cultura; // Guarda la preferencia
                Properties.Settings.Default.Save();
            }
            catch (System.Globalization.CultureNotFoundException ex)
            {
                MessageBox.Show($"ERROR CRÍTICO: El valor de cultura es '{cultura}'. Por favor, verifica el código que establece este valor. Mensaje: {ex.Message}");
                CambiarIdioma("es-AR");

            }
        }

        // Ejemplo de AplicarTraduccion (ajusta según tu implementación)
        public static void AplicarTraduccion(Form formulario)
        {
            if (formulario == null) return;

            // Minimiza recalculo de layout y repintados innecesarios
            formulario.SuspendLayout();
            try
            {
                foreach (Control control in formulario.Controls)
                {
                    AplicarTraduccionControl(control);
                }

                // Traducir el texto del formulario mismo
                string nuevoTextoFormulario = resManager.GetString(formulario.Name + ".Text", CulturaActual);
                if (!string.IsNullOrEmpty(nuevoTextoFormulario))
                {
                    if (!string.Equals(formulario.Text, nuevoTextoFormulario, StringComparison.Ordinal))
                    {
                        formulario.Text = nuevoTextoFormulario;
                    }
                }
                else if (string.IsNullOrEmpty(formulario.Text))
                {
                    formulario.Text = formulario.Name; // Valor por defecto
                }
            }
            finally
            {
                formulario.ResumeLayout(performLayout: true);
            }
        }

        private static void AplicarTraduccionControl(Control control)
        {
            if (control == null) return;

            string claveRecurso = control.Name;

            // Solo si el control tiene nombre y no es el ComboBox de idioma
            if (!string.IsNullOrEmpty(claveRecurso) && claveRecurso != "cmbIdioma")
            {
                string textoTraducido = resManager.GetString(claveRecurso, CulturaActual);

                // Evitar trabajo innecesario: solo asignar si realmente cambia
                if (!string.IsNullOrEmpty(textoTraducido) && !string.Equals(control.Text, textoTraducido, StringComparison.Ordinal))
                {
                    control.Text = textoTraducido;
                }
            }

            // Traducir hijos
            if (control.HasChildren)
            {
                foreach (Control subControl in control.Controls)
                {
                    AplicarTraduccionControl(subControl);
                }
            }
        }

    }
}