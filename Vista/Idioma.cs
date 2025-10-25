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
            "Sistema_Gestion_de_Usuarios.Vista.Lenguajes.Strings", // <--- RUTA COMPLETA DEL RECURSO BASE
            typeof(Idioma).Assembly);

        // ** LÍNEA CRÍTICA A AGREGAR **
        // Esta propiedad estática es necesaria para que FrmLoguin.cs compile
        public static CultureInfo CulturaActual { get; set; }

        // ... (Aquí van tus otros métodos: CargarIdiomaGuardado, CambiarIdioma, AplicarTraduccion, ObtenerIdiomasDisponibles) ...

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
            CultureInfo nuevaCultura = new CultureInfo(cultura);
            Thread.CurrentThread.CurrentCulture = nuevaCultura;
            Thread.CurrentThread.CurrentUICulture = nuevaCultura;
            CulturaActual = nuevaCultura; // Actualiza la propiedad estática
            Properties.Settings.Default.Idioma = cultura; // Guarda la preferencia
            Properties.Settings.Default.Save();
        }

        // Ejemplo de AplicarTraduccion (ajusta según tu implementación)
        public static void AplicarTraduccion(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                AplicarTraduccionControl(control);
            }
            // También traduce el texto del formulario mismo
            formulario.Text = resManager.GetString(formulario.Name + ".Text", CulturaActual);
            if (string.IsNullOrEmpty(formulario.Text))
            {
                // Si no hay traducción específica para el formulario, usa el texto original
                formulario.Text = formulario.Name; // O el valor que desees
            }
        }

        private static void AplicarTraduccionControl(Control control)
        {
            // Traduce el texto del control si tiene una clave en el .resx
            string textoTraducido = resManager.GetString(control.Name + ".Text", CulturaActual);
            if (!string.IsNullOrEmpty(textoTraducido))
            {
                control.Text = textoTraducido;
            }

            // Si es un ComboBox y tiene el nombre "cboIdioma", no lo traducimos, 
            // ya que sus items ya están siendo gestionados con el DataSource
            if (control is ComboBox comboBox && control.Name == "cboIdioma")
            {
                // No hacer nada, ya se carga en el constructor del FrmLoguin
            }

            // Traduce controles hijos
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