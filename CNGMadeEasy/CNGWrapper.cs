using System;
using System.Security.Cryptography;
using System.Text;

namespace CNGMadeEasy
{
    public class CNGWrapper
    {
        public string Encrypt(string plainTestPassword, string keyName)
        {
            CngKey key;
            if (CngKey.Exists(keyName))
                key = CngKey.Open(keyName);
            else
                key = CngKey.Create(CngAlgorithm.Rsa, keyName,
                    new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextArchiving });

            var cng = new RSACng(key);
            
            var encryptedData = cng.Encrypt(Encoding.UTF8.GetBytes(plainTestPassword), 
                RSAEncryptionPadding.Pkcs1);

            var encodedData = Convert.ToBase64String(encryptedData);
            return encodedData;
        }

        public string Decrypt(string encryptedData, string keyName)
        {
            var key = CngKey.Open(keyName);
            var decodedData = Convert.FromBase64String(encryptedData);
            var cng = new RSACng(key);

            var decryptedData = cng.Decrypt(decodedData, RSAEncryptionPadding.Pkcs1);
            var decodedString = Encoding.UTF8.GetString(decryptedData);

            return decodedString;
        }
    }
}
