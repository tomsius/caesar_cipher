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
        [DataTestMethod]
        public void TestEncrypt(int secretKey, string plainText, string expected)
        {
            Cipher c = new Cipher(secretKey);

            string result = c.Encrypt(plainText);

            Assert.AreEqual(expected, result);
        }


    }
}
