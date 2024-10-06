using System.Security.Cryptography;

namespace Encrypt
{
    public static class AesEncryption
    {
        private static readonly byte[] Key;
        private static readonly byte[] IV;

        // Construtor estático para gerar a chave e o IV uma única vez
        static AesEncryption()
        {
            (Key, IV) = GenerateKeyAndIv();
        }

        // Método para criptografar texto
        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));

            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var writer = new StreamWriter(cs))
                {
                    writer.Write(plainText);
                    writer.Flush(); // Certifique-se de que todos os dados sejam escritos
                    cs.FlushFinalBlock(); // Completa a criptografia

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // Método para descriptografar texto
        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText));

            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        // Método para gerar uma chave e um IV
        private static (byte[] key, byte[] iv) GenerateKeyAndIv()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateKey();
                aes.GenerateIV();
                return (aes.Key, aes.IV);
            }
        }
    }
}
