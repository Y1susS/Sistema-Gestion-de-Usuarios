using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Datos;
using Sesion;
using Entidades.DTOs;

namespace Logica
{
    public class CL_Preguntas
    {
        private readonly CD_DaoPregunta daoPregunta = new CD_DaoPregunta();
        private readonly CD_DaoRespuesta daoRespuesta = new CD_DaoRespuesta();
        
        public List<DtoPregunta> ObtenerPreguntas()
        {
            return daoPregunta.ObtenerPreguntas();
        }
        
        public List<DtoRespuesta> ObtenerRespuestasUsuario()
        {
            if (!ClsSesionActual.EstaLogueado())
            {
                return new List<DtoRespuesta>();
            }
            
            return daoRespuesta.ObtenerRespuestasUsuario(ClsSesionActual.Usuario.Id_user);
        }
        
        public bool RegistrarRespuestas(List<DtoRespuesta> respuestas, out string mensaje)
        {
            if (!ClsSesionActual.EstaLogueado())
            {
                mensaje = "No hay una sesión de usuario activa";
                return false;
            }
            
            // Validar que tenemos 3 preguntas con respuestas
            if (respuestas.Count < 3)
            {
                mensaje = "Debe proporcionar respuestas para las 3 preguntas de seguridad";
                return false;
            }
            
            // Validar que todas las respuestas tienen contenido
            foreach (var respuesta in respuestas)
            {
                if (string.IsNullOrWhiteSpace(respuesta.Respuesta))
                {
                    mensaje = "Todas las preguntas deben tener una respuesta";
                    return false;
                }
            }
            
            bool resultado = true;
            
            // Registrar cada respuesta
            foreach (var respuesta in respuestas)
            {
                resultado = daoRespuesta.RegistrarRespuesta(
                    ClsSesionActual.Usuario.Id_user, 
                    respuesta.Id_Pregunta, 
                    respuesta.Respuesta);
                
                if (!resultado)
                    break;
            }
            
            mensaje = resultado ? 
                "Preguntas de seguridad registradas correctamente" : 
                "Error al registrar las preguntas de seguridad";
            
            return resultado;
        }
        
        public bool VerificarRespuestas(int idUsuario, List<DtoRespuesta> respuestas)
        {
            foreach (var respuesta in respuestas)
            {
                bool esCorrecta = daoRespuesta.VerificarRespuesta(
                    idUsuario, 
                    respuesta.Id_Pregunta, 
                    respuesta.Respuesta);
                
                if (!esCorrecta)
                    return false;
            }
            
            return true;
        }

        public DataTable MostrarPreguntas()
        {
            DataTable tabla = new DataTable();
            tabla = daoPregunta.MostrarPreguntas();
            return tabla;
        }
    }
}