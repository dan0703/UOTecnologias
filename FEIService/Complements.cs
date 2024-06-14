using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FEIService
{
    /// <summary>
    /// Proporciona métodos auxiliares y utilidades para diversas funcionalidades.
    /// </summary>
    public class Complements
    {
        /// <summary>
        /// Encripta una contraseña utilizando el algoritmo de hash SHA-256.
        /// </summary>
        /// <param name="password">La contraseña a encriptar.</param>
        /// <returns>La contraseña encriptada como una cadena hexadecimal.</returns>
        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Calcula el hash a partir de la contraseña de entrada
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Construye una representación de cadena del hash
                var hash = new StringBuilder();
                for (int bit = 0; bit < (bytes.Length); bit++)
                {
                    hash.Append(bytes[bit].ToString("x2")); // Convierte byte a cadena hexadecimal
                }
                return hash.ToString();
            }
        }
    }
}
