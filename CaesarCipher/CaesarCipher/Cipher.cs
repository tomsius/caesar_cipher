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

            // if secret key is larger than number of letters in alphabet,
            // we take the remainder
            if (secretKey >= letterCountInAlphabet)
            {
                secretKey = secretKey % letterCountInAlphabet;
            }

            this.secretKey = secretKey;
        }

        public string Encrypt(string plainText)
        {
            // convert plainText to char array
            char[] letters = plainText.ToCharArray();

            // shift every letter
            for (int i = 0; i < letters.Length; i++)
            {
                // take ascii code of letter
                int letterCode = (int)letters[i];

                // calculate new ascii code:
                // if new ascii code is larger than z's ascii code,
                // I subtract new ascii code by z's ascii value to know how much I
                // need to shift from a, and add that value to (a's code - 1) because
                // I don't want to ignore letter a
                // otherwise, new ascii code is new letter
                int newCode = (letterCode + secretKey) > (int)'z' ? ((int)'a' - 1) + ((letterCode + secretKey) - (int)'z') : letterCode + secretKey;
                letters[i] = (char)newCode;
            }

            // return cipher
            return new string(letters);
        }

        public string Decrypt(string cipher)
        {
        }
    }
}
