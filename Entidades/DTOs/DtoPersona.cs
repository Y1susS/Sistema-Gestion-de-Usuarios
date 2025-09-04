namespace Entidades.DTOs
{
    public class DtoPersona
    {
        public int Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Id_TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public string Piso { get; set; }
        public string Depto { get; set; }
        public int Id_Localidad { get; set; }
        public string Telefono { get; set; } 
    }
}