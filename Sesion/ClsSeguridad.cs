﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sesion
{
    public static class ClsSeguridad
    {
        public static string SHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public static bool VerificarHash(string textoPlano, string hashAlmacenado)
        {
            string hashTextoPlano = SHA256(textoPlano);
            return string.Equals(hashTextoPlano, hashAlmacenado, StringComparison.OrdinalIgnoreCase);
        }
    }
}
