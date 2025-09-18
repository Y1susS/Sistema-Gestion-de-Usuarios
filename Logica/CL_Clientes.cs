using System;
using System.Collections.Generic;
using Datos;
using Entidades.DTOs;

namespace Logica
{
    public class CL_Clientes
    {
        private readonly CD_DaoCliente daoCliente = new CD_DaoCliente();
        private readonly CD_DaoPersona daoPersona = new CD_DaoPersona();
        private readonly CD_DaoLocalidad daoLocalidad = new CD_DaoLocalidad();

        public bool RegistrarCliente(DtoPersona persona, out string mensaje)
        {
            try
            {
                // Validar que no exista un cliente con el mismo documento
                if (daoCliente.ExisteClientePorDocumento(persona.NroDocumento))
                {
                    mensaje = "Ya existe un cliente registrado con ese número de documento";
                    return false;
                }

                // Validaciones básicas
                if (!ValidarDatosPersona(persona, out mensaje))
                {
                    return false;
                }

                // Agregar la persona primero
                int idPersona = daoPersona.AgregarPersona(persona);

                if (idPersona <= 0)
                {
                    mensaje = "Error al registrar los datos personales del cliente";
                    return false;
                }

                // Crear el cliente usando el constructor con DtoPersona
                persona.Id_Persona = idPersona;
                DtoCliente cliente = new DtoCliente(persona);

                // Agregar el cliente
                int idCliente = daoCliente.AgregarCliente(cliente);

                if (idCliente <= 0)
                {
                    mensaje = "Error al registrar el cliente";
                    return false;
                }

                mensaje = "Cliente registrado correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error en el registro: " + ex.Message;
                return false;
            }
        }

        public List<DtoCliente> ListarClientes()
        {
            try
            {
                return daoCliente.ListarClientes();
            }
            catch (Exception)
            {
                return new List<DtoCliente>();
            }
        }

        public DtoCliente ObtenerClientePorId(int idCliente)
        {
            try
            {
                return daoCliente.ObtenerClientePorId(idCliente);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ActualizarCliente(int idCliente, DtoPersona persona, out string mensaje)
        {
            try
            {
                // Obtener el cliente existente para obtener el Id_Persona
                var clienteExistente = daoCliente.ObtenerClientePorId(idCliente);
                if (clienteExistente == null)
                {
                    mensaje = "Cliente no encontrado";
                    return false;
                }

                // Asignar el Id_Persona para la actualización
                persona.Id_Persona = clienteExistente.Id_Persona;

                // Actualizar los datos de la persona
                bool resultadoPersona = daoPersona.ActualizarPersona(persona);
                
                if (!resultadoPersona)
                {
                    mensaje = "Error al actualizar los datos personales del cliente";
                    return false;
                }

                mensaje = "Cliente actualizado correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error en la actualización: " + ex.Message;
                return false;
            }
        }

        public bool EliminarCliente(int idCliente, out string mensaje)
        {
            try
            {
                bool resultado = daoCliente.BajaCliente(idCliente);
                mensaje = resultado ? "Cliente eliminado correctamente" : "Error al eliminar el cliente";
                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = "Error al eliminar: " + ex.Message;
                return false;
            }
        }

        public DtoLocalidad ObtenerLocalidadPorId(int idLocalidad)
        {
            try
            {
                return daoLocalidad.ObtenerLocalidadPorId(idLocalidad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool ValidarDatosPersona(DtoPersona persona, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                mensaje = "El nombre es obligatorio";
                return false;
            }

            if (string.IsNullOrWhiteSpace(persona.Apellido))
            {
                mensaje = "El apellido es obligatorio";
                return false;
            }

            if (string.IsNullOrWhiteSpace(persona.NroDocumento))
            {
                mensaje = "El número de documento es obligatorio";
                return false;
            }

            if (string.IsNullOrWhiteSpace(persona.Email) || !persona.Email.Contains("@"))
            {
                mensaje = "Debe ingresar un email válido";
                return false;
            }

            if (persona.Id_Localidad <= 0)
            {
                mensaje = "Debe seleccionar una localidad";
                return false;
            }

            mensaje = "Datos válidos";
            return true;
        }
    }
}