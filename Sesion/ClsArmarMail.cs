using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion
{
    public static class ClsArmarMail
    {
        public static string DireccionCorreo { get; set; }
        public static string Asunto { get; set; }
        public static string NuevaContraseña { get; set; }

        public static void Preparar()
        {
            string body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1> Contraseña de ingreso: </h1></br>
                            <h2> " + NuevaContraseña + "</h2>";
            ClsEnviarMail.sendMail(DireccionCorreo, Asunto, body);
        }
    }
}
