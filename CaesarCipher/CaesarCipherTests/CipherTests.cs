using System;
using CaesarCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaesarCipherTests
{
    [TestClass]
    public class CipherTests
    {
        [DataRow(2, "ABC", "CDE")]
        [DataRow(2, "abc", "cde")]
        [DataRow(28, "ABC", "CDE")]
        [DataRow(28, "abc", "cde")]
        [DataRow(2, "xYz", "zAb")]
        [DataRow(2, "XyZ", "ZaB")]
        [DataRow(5, "abcdefghijklmnopqrstuvwxyz", "fghijklmnopqrstuvwxyzabcde")]
        [DataRow(5, "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "FGHIJKLMNOPQRSTUVWXYZABCDE")]
        [DataRow(5, "aB9c", "fG9h")]
        [DataRow(5, "-=-*/", "-=-*/")]
        [DataRow(5, "", "")]
        [DataRow(26, "test", "test")]
        [DataTestMethod]
        public void TestEncrypt(int secretKey, string plainText, string expected)
        {
            Cipher c = new Cipher(secretKey);

            string result = c.Encrypt(plainText);

            Assert.AreEqual(expected, result);
        }

        [DataRow(2, "CDE", "ABC")]
        [DataRow(2, "cde", "abc")]
        [DataRow(28, "CDE", "ABC")]
        [DataRow(28, "cde", "abc")]
        [DataRow(2, "zAb", "xYz")]
        [DataRow(2, "ZaB", "XyZ")]
        [DataRow(5, "fghijklmnopqrstuvwxyzabcde", "abcdefghijklmnopqrstuvwxyz")]
        [DataRow(5, "FGHIJKLMNOPQRSTUVWXYZABCDE", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [DataRow(5, "fG9h", "aB9c")]
        [DataRow(5, "-=-*/", "-=-*/")]
        [DataRow(5, "", "")]
        [DataRow(26, "test", "test")]
        [DataTestMethod]
        public void TestDecrypt(int secretKey, string cipher, string expected)
        {
            Cipher c = new Cipher(secretKey);

            string result = c.Decrypt(cipher);

            Assert.AreEqual(expected, result);
        }
    }
}
