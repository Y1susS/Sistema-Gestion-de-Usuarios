using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_UsuarioAtributos
    {
        public static int Id_user { get; set; }
        public static string User { get; set; }
        public static string Password { get; set; }
        public static bool Activo { get; set; }
        public static DateTime FechaBloqueo { get; set; }
        public static bool PrimeraPass { get; set; }
        public static int Id_Rol { get; set; }
        public static DateTime FechaBaja { get; set; }
        public static int Id_Persona { get; set; }
        public static int Intentos { get; set; }
        public static int CambiaCada { get; set; }
        public static DateTime FechaUltimoCambio { get; set; }
        public static string Nombre { get; set; }
        public static string APellido { get; set; }
        public static string Id_TipoDocumento { get; set; }
        public static string NroDocumento { get; set; }
        public static string Email { get; set; }
        public static string Calle { get; set; }
        public static string Piso { get; set; }
        public static string Depto { get; set; }
        public static int Id_locacalida { get; set; }

    }
}