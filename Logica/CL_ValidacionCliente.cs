using Entidades.DTOs;
using System;

namespace Logica
{
    public class CL_ValidacionCliente : CL_ValidacionesBase
    {
        private DtoPersona _cliente;

        public CL_ValidacionCliente(DtoPersona cliente)
        {
            _cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        }

        public override bool ValidarTodo(out string mensaje)
        {
            LimpiarErrores();

            // Validar datos personales
            ValidarTextoObligatorio(_cliente.Nombre, "Nombre");
            ValidarTextoObligatorio(_cliente.Apellido, "Apellido");
            ValidarTextoObligatorio(_cliente.Id_TipoDocumento, "Tipo de documento");
            ValidarDocumento(_cliente.NroDocumento);
            ValidarEmail(_cliente.Email);
            ValidarTelefono(_cliente.Telefono);

            // Validar dirección
            ValidarTextoObligatorio(_cliente.Calle, "Calle");
            ValidarNumeroPositivo(_cliente.Nro.ToString(), "Número de calle");

            // Validaciones opcionales con valores por defecto
            if (!string.IsNullOrWhiteSpace(_cliente.Piso))
            {
                ValidarTextoObligatorio(_cliente.Piso, "Piso", 1);
            }

            if (!string.IsNullOrWhiteSpace(_cliente.Depto))
            {
                ValidarTextoObligatorio(_cliente.Depto, "Departamento", 1);
            }

            // Validar localidad (si tienes un método para validar que existe en BD)
            if (_cliente.Id_Localidad <= 0)
            {
                errores.Add("Debe seleccionar una localidad válida.");
            }

            mensaje = ObtenerMensajeErrores();
            return errores.Count == 0;
        }

        // Método específico para validar si el cliente ya existe
        public bool ValidarClienteNoExiste(string numeroDocumento, out string mensaje)
        {
            // Aquí podrías llamar a tu capa de datos para verificar
            // Por ahora solo un ejemplo básico
            mensaje = string.Empty;
            
            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                mensaje = "El número de documento es requerido para verificar duplicados.";
                return false;
            }

            // Aquí irías a la base de datos a verificar
            // return !_daoPersona.ExistePersonaPorDocumento(numeroDocumento);
            return true; // Por ahora retornamos true
        }
    }
}
