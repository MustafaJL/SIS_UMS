using System;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    private static readonly byte[] EncryptionKey = KeyGenerator.GenerateRandomKey(16); // Replace with a strong random key

    public static string Encrypt(int value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        byte[] encryptedBytes = new byte[bytes.Length];

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = EncryptionKey;
            aesAlg.Mode = CipherMode.ECB; // Use an appropriate mode
            aesAlg.Padding = PaddingMode.PKCS7; // Use an appropriate padding

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(bytes, 0, bytes.Length);
                    csEncrypt.FlushFinalBlock();
                }
                encryptedBytes = msEncrypt.ToArray();
            }
        }

        return Convert.ToBase64String(encryptedBytes);
    }

    public static int Decrypt(string encryptedValue)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedValue);
        byte[] decryptedBytes = new byte[encryptedBytes.Length];

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = EncryptionKey;
            aesAlg.Mode = CipherMode.ECB; // Use the same mode
            aesAlg.Padding = PaddingMode.PKCS7; // Use the same padding

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    csDecrypt.Read(decryptedBytes, 0, decryptedBytes.Length);
                }
            }
        }

        return BitConverter.ToInt32(decryptedBytes, 0);
    }
}

public static class KeyGenerator
{
    public static byte[] GenerateRandomKey(int keySizeInBytes)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] key = new byte[keySizeInBytes];
            rng.GetBytes(key);
            return key;
        }
    }
}
