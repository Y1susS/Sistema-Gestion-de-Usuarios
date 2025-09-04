using System;

namespace Entidades.DTOs
{
    public class DtoRespuesta
    {
        public int Id_User { get; set; }
        public int Id_Pregunta { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
    }
}