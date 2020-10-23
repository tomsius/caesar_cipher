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

                // new ascii code
                int newCode;

                // check if letter is upper case
                if (char.IsUpper(letters[i]))
                {
                    // calculate new ascii code:
                    // if new ascii code is larger than Z's ascii code,
                    // I add given letter's code to secret key to get new ascii code, then
                    // subtract it by Z's ascii code and add the difference to ascii code one lower than A
                    // so I wouldn't ignore letter A
                    // otherwise, new ascii code is new letter
                    newCode = (letterCode + secretKey) > (int)'Z' ? ((int)'A' - 1) + ((letterCode + secretKey) - (int)'Z') : letterCode + secretKey;
                }
                else
                {
                    // similar as above, just with lower case letters
                    newCode = (letterCode + secretKey) > (int)'z' ? ((int)'a' - 1) + ((letterCode + secretKey) - (int)'z') : letterCode + secretKey;
                }
                letters[i] = (char)newCode;
            }

            // return cipher
            return new string(letters);
        }

        public string Decrypt(string cipher)
        {
            // convert cipher to char array
            char[] letters = cipher.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                // take ascii code of letter
                int letterCode = (int)letters[i];

                // new ascii code
                int newCode;

                // check if letter is upper case
                if (char.IsUpper(letters[i]))
                {
                    // calculate new ascii code:
                    // if new ascii code is smaller than A's ascii code,
                    // I subtract from A's ascii code the difference of given letter's code to secret key
                    // and subtract that from ascii code which is one larger than Z's code
                    // so I wouldn't ignore letter Z
                    // otherwise, new ascii code is new letter
                    newCode = (letterCode - secretKey) < (int)'A' ? ((int)'Z' + 1) - ((int)'A' - (letterCode - secretKey)) : letterCode - secretKey;
                }
                else
                {
                    // similar as above, just with lower case letters
                    newCode = (letterCode - secretKey) < (int)'a' ? ((int)'z' + 1) - ((int)'a' - (letterCode - secretKey)) : letterCode - secretKey;
                }
                letters[i] = (char)newCode;
            }

            // return plain text
            return new string(letters);
        }
    }
}
