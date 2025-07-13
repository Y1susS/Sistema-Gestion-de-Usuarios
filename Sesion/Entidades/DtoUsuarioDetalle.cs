namespace Sesion.Entidades
{
    public class DtoUsuarioDetalle
    {
        public int Id_user { get; set; }
        public string User { get; set; }
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
        public string Localidad { get; set; }
        public int Id_Partido { get; set; }
        public string Partido { get; set; }
        public int Id_Rol { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
        public string Telefono { get; set; }
        public int Id_Persona { get; set; }
    }
}