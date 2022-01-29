using System.Security.Cryptography;
using System;
using System.Text;

namespace Biblioteca.Models
{
    public static class Criptografo
    {
        public static string CriptografarTexto(string texto)
        {
            MD5 MD5Hasher = MD5.Create();

            byte[] By = Encoding.Default.GetBytes(texto);
            byte[] bytesCriptografado = MD5Hasher.ComputeHash(By);

            StringBuilder SB = new StringBuilder();

            foreach (byte b in bytesCriptografado)
            {
                string DebugB = b.ToString("X2");
                SB.Append(DebugB);
            }

            return SB.ToString();
        }

    }
}