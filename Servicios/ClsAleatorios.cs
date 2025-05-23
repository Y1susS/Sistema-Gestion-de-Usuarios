using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class ClsAleatorios
    {
        public static string Armar(bool EsCaracteres, int Cant, int CantCaractEspeciales = 0)
        {
            string caracteres = "0123456789", resultado = "";
            if (!EsCaracteres)
            {
                char[] arrayCaracteres = new char[Cant];
                Random random = new Random();
                for (int i = 0; i < arrayCaracteres.Length; i++)
                {
                    arrayCaracteres[i] = caracteres[random.Next(caracteres.Length)];
                }
                resultado = new String(arrayCaracteres);
            }
            else
            {
                resultado = Membership.GeneratePassword(Cant, CantCaractEspeciales);
            }
            return resultado;
        }
    }
}
