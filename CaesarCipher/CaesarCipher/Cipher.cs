using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class Cipher
    {
        private readonly int secretKey;
        private const int letterCountInAlphabet = 'z' - 'a' + 1;

        public Cipher(int secretKey)
        {
            if (secretKey >= letterCountInAlphabet)
            {
                secretKey %= letterCountInAlphabet;
            }

            this.secretKey = secretKey;
        }

        public string Encrypt(string plainText)
        {
            if (secretKey == 0)
            {
                return plainText;
            }

            char[] letters = plainText.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                if (IsNotLetter(letters[i]))
                {
                    continue;
                }

                letters[i] = (char)EncryptLetter(letters[i]);
            }

            return new string(letters);
        }

        private bool IsNotLetter(char letter)
        {
            return !char.IsLetter(letter);
        }

        private int EncryptLetter(char letter)
        {
            if (char.IsUpper(letter))
            {
                // calculate new ascii code:
                // if new ascii code is larger than Z's ascii code,
                // I add given letter's code to secret key to get new ascii code, then
                // subtract it by Z's ascii code and add the difference to ascii code one lower than A
                // so I wouldn't ignore letter A
                // otherwise, new ascii code is new letter
                return (letter + secretKey) > 'Z' ? ('A' - 1) + ((letter + secretKey) - 'Z') : letter + secretKey;
            }
            else
            {
                // similar as above, just with lower case letters
                return (letter + secretKey) > 'z' ? ('a' - 1) + ((letter + secretKey) - 'z') : letter + secretKey;
            }
        }

        public string Decrypt(string cipher)
        {
            if (secretKey == 0)
            {
                return cipher;
            }

            char[] letters = cipher.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                if (IsNotLetter(letters[i]))
                {
                    continue;
                }
                
                letters[i] = (char)DecryptLetter(letters[i]);
            }

            return new string(letters);
        }

        private int DecryptLetter(char letter)
        {
            if (char.IsUpper(letter))
            {
                // calculate new ascii code:
                // if new ascii code is smaller than A's ascii code,
                // I subtract from A's ascii code the difference of given letter's code to secret key
                // and subtract that from ascii code which is one larger than Z's code
                // so I wouldn't ignore letter Z
                // otherwise, new ascii code is new letter
                return (letter - secretKey) < (int)'A' ? ((int)'Z' + 1) - ((int)'A' - (letter - secretKey)) : letter - secretKey;
            }
            else
            {
                // similar as above, just with lower case letters
                return (letter - secretKey) < (int)'a' ? ((int)'z' + 1) - ((int)'a' - (letter - secretKey)) : letter - secretKey;
            }
        }
    }
}
