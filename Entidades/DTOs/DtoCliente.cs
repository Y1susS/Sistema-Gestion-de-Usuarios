using System;

namespace Entidades.DTOs
{
    public class DtoCliente : DtoPersona
    {
        // Propiedades específicas del cliente
        public int Id_Cliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int TotalCompras { get; set; }
        public int CantidadCompras { get; set; }
        public bool Activo { get; set; }
        public string Observaciones { get; set; }
        
        // Constructor por defecto
        public DtoCliente()
        {
            FechaRegistro = DateTime.Now;
            Activo = true;
            Observaciones = string.Empty;
            TotalCompras = 0;
            CantidadCompras = 0;
        }
        
        // Constructor que acepta una DtoPersona (facilita la herencia)
        public DtoCliente(DtoPersona persona) : this()
        {
            if (persona != null)
            {
                Id_Persona = persona.Id_Persona;
                Nombre = persona.Nombre;
                Apellido = persona.Apellido;
                Id_TipoDocumento = persona.Id_TipoDocumento;
                NroDocumento = persona.NroDocumento;
                Email = persona.Email;
                Calle = persona.Calle;
                Nro = persona.Nro;
                Piso = persona.Piso;
                Depto = persona.Depto;
                Id_Localidad = persona.Id_Localidad;
                Telefono = persona.Telefono;
            }
        }
    }
}
