using System;

namespace Entidades.DTOs
{
    public class DtoConfiguracionSeguridad
    {
        public int Id { get; set; }
        public int MinimoCaracteres { get; set; }
        public bool RequiereMayusMinus { get; set; }
        public bool RequiereNumLetra { get; set; }
        public bool RequiereEspecial { get; set; }
        public bool EvitarRepetidas { get; set; }
        public bool EvitarDatosPersonales { get; set; }
        public int DiasCambioPassword { get; set; }

        // Nuevos parámetros de seguridad para login
        public int MaxIntentosLogin { get; set; }
        public int MinutosBloqueoLogin { get; set; }
    }
}
