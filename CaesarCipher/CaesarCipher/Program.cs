using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // assume that secret key > 0
            Cipher c = new Cipher(27);

            string plainText = "AbcxyZ";
            string cipher = c.Encrypt(plainText);
            string decrypted = c.Decrypt(cipher);
            Console.WriteLine(plainText + " >>> " + cipher + " >>> " + decrypted);
        }
    }
}
