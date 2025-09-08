namespace Entidades.DTOs
{
    public class DtoClienteDetalle : DtoCliente
    {
        // Heredamos todo de DtoCliente y agregamos información relacionada
        public string TipoDocumento { get; set; }
        public string Localidad { get; set; }
        public string Partido { get; set; }
        public int Id_Partido { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string DireccionCompleta => string.IsNullOrEmpty(Piso) && string.IsNullOrEmpty(Depto) 
            ? $"{Calle} {Nro}" 
            : $"{Calle} {Nro}, Piso: {Piso}, Dpto: {Depto}";
    }
}