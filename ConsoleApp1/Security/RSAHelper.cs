using System;
using System.Security.Cryptography;

namespace ConsoleApp1.Security
{
    public class RSAHelper
    {
        public void CreateKeys()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ExportParameters(false);
            RSA.ToXmlString(true);

        }

        public string EncryptString(string value)
        {
            return String.Empty;
        }


    }
}
