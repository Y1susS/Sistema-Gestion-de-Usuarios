using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logica
{
    public abstract class CL_ValidacionesBase
    {
        protected List<string> errores = new List<string>();

        // Método abstracto que cada clase hija debe implementar
        public abstract bool ValidarTodo(out string mensaje);

        // Validaciones comunes que heredarán todas las clases
        protected bool ValidarTextoObligatorio(string valor, string nombreCampo, int minimoCaracteres = 2)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                errores.Add($"{nombreCampo} es obligatorio.");
                return false;
            }

            if (valor.Length < minimoCaracteres)
            {
                errores.Add($"{nombreCampo} debe tener al menos {minimoCaracteres} caracteres.");
                return false;
            }

            return true;
        }

        protected bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                errores.Add("El email es obligatorio.");
                return false;
            }

            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, patron))
            {
                errores.Add("El formato del email no es válido.");
                return false;
            }

            return true;
        }

        protected bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
            {
                errores.Add("El teléfono es obligatorio.");
                return false;
            }

            // Permitir solo números, espacios, guiones y paréntesis
            string patron = @"^[\d\s\-\(\)]+$";
            if (!Regex.IsMatch(telefono, patron) || telefono.Length < 8)
            {
                errores.Add("El teléfono debe contener al menos 8 dígitos y solo números, espacios, guiones o paréntesis.");
                return false;
            }

            return true;
        }

        protected bool ValidarDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                errores.Add("El número de documento es obligatorio.");
                return false;
            }

            if (!documento.All(char.IsDigit))
            {
                errores.Add("El documento debe contener solo números.");
                return false;
            }

            if (documento.Length < 7 || documento.Length > 8)
            {
                errores.Add("El documento debe tener entre 7 y 8 dígitos.");
                return false;
            }

            return true;
        }

        protected bool ValidarNumeroPositivo(string numero, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(numero))
            {
                errores.Add($"{nombreCampo} es obligatorio.");
                return false;
            }

            if (!int.TryParse(numero, out int resultado) || resultado <= 0)
            {
                errores.Add($"{nombreCampo} debe ser un número positivo.");
                return false;
            }

            return true;
        }

        protected string ObtenerMensajeErrores()
        {
            return errores.Count > 0 ? string.Join("\n", errores) : string.Empty;
        }

        protected void LimpiarErrores()
        {
            errores.Clear();
        }
    }
}
