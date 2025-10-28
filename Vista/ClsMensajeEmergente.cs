using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    internal class ClsMensajeEmergente
    {
        private ToolTip mensajeEmergente;

        public ClsMensajeEmergente()
        {
            mensajeEmergente = new ToolTip();

            mensajeEmergente.AutoPopDelay = 5000;   // cuánto dura visible
            mensajeEmergente.InitialDelay = 200;    // retraso inicial
            mensajeEmergente.ReshowDelay = 100;     // tiempo entre reapariciones
            mensajeEmergente.ShowAlways = true;     // siempre visible
        }

        public void AsignarMensaje(Control control, string texto)
        {
            mensajeEmergente.SetToolTip(control, texto);
        }
    }
}
