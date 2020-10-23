using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class Cipher
    {
        private readonly int secretKey; // cannot change secret key after creating object
        private const int letterCountInAlphabet = (int)'z' - (int)'a' + 1;

        public Cipher(int secretKey)
        {
            this.secretKey = secretKey;
        }

        public string Encrypt(string plainText)
        {
            return "";
        }

        public string Decrypt(string cipher)
        {
            return "";
        }
    }
}
