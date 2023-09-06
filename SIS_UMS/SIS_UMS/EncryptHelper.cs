using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// Provides encryption and decryption functionalities using the AES algorithm.
/// </summary>
public static class EncryptionHelper
{
    // Define a private static byte array to store the encryption key.
    private static readonly byte[] EncryptionKey = KeyGenerator.GenerateRandomKey(16); 
    /// <summary>
    /// Encrypts an integer value using AES encryption with ECB mode and PKCS7 padding.
    /// </summary>
    /// <param name="value">The integer value to be encrypted.</param>
    /// <returns>A Base64-encoded string representing the encrypted value.</returns>
    public static string Encrypt(int value)
    {
        // Convert the integer 'value' into a byte array representation.
        byte[] bytes = BitConverter.GetBytes(value);

        // Initialize a byte array to store the encrypted data.
        byte[] encryptedBytes = new byte[bytes.Length];

        // Create an instance of the AES algorithm for encryption.
        using (Aes aesAlg = Aes.Create())
        {
            // Set the encryption key for the AES algorithm.
            aesAlg.Key = EncryptionKey;

            // Set the encryption mode to ECB (Electronic Codebook mode).
            aesAlg.Mode = CipherMode.ECB; 

            // Set the padding mode to PKCS7.
            aesAlg.Padding = PaddingMode.PKCS7;

            // Create an encryptor object using the AES algorithm's key and initialization vector (IV).
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create a memory stream to store the encrypted data.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                // Create a CryptoStream that links to the memory stream and uses the encryptor for writing.
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    // Write the byte array 'bytes' (the data to be encrypted) into the CryptoStream.
                    csEncrypt.Write(bytes, 0, bytes.Length);

                    // Flush any remaining data from the CryptoStream and finalize the encryption.
                    csEncrypt.FlushFinalBlock();
                }

                // Convert the encrypted data in the memory stream to a byte array.
                encryptedBytes = msEncrypt.ToArray();
            }
        }

        // Convert the encrypted byte array to a Base64-encoded string and return it.
        return Convert.ToBase64String(encryptedBytes);
    }

    /// <summary>
    /// Decrypts an AES-encrypted Base64-encoded string to retrieve the original integer value.
    /// </summary>
    /// <param name="encryptedValue">The Base64-encoded string representing the encrypted value.</param>
    /// <returns>The decrypted integer value.</returns>
    public static int Decrypt(string encryptedValue)
    {
        // Convert the Base64-encoded string back to a byte array.
        byte[] encryptedBytes = Convert.FromBase64String(encryptedValue);

        // Initialize a byte array to store the decrypted data.
        byte[] decryptedBytes = new byte[encryptedBytes.Length];

        // Create an instance of the AES algorithm for decryption.
        using (Aes aesAlg = Aes.Create())
        {
            // Set the encryption key for the AES algorithm.
            aesAlg.Key = EncryptionKey;

            // Set the encryption mode to ECB (Electronic Codebook mode).
            aesAlg.Mode = CipherMode.ECB;

            // Set the padding mode to PKCS7.
            aesAlg.Padding = PaddingMode.PKCS7;

            // Create a decryptor object using the AES algorithm's key and initialization vector (IV).
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create a memory stream initialized with the encrypted byte array.
            using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
            {
                // Create a CryptoStream that links to the memory stream and uses the decryptor for reading.
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    // Read the decrypted data from the CryptoStream into the 'decryptedBytes' array.
                    csDecrypt.Read(decryptedBytes, 0, decryptedBytes.Length);
                }
            }
        }

        // Convert the decrypted byte array back to an integer value and return it.
        return BitConverter.ToInt32(decryptedBytes, 0);
    }
}

/// <summary>
/// Provides a method to generate cryptographically secure random keys of a specified length in bytes.
/// </summary>
public static class KeyGenerator
{
    /// <summary>
    /// Generates a cryptographically secure random key of the specified length in bytes.
    /// </summary>
    /// <param name="keySizeInBytes">The desired length of the random key in bytes.</param>
    /// <returns>A byte array representing the generated random key.</returns>
    public static byte[] GenerateRandomKey(int keySizeInBytes)
    {
        // Create an instance of RNGCryptoServiceProvider for secure random number generation.
        using (var rng = new RNGCryptoServiceProvider())
        {
            // Initialize a byte array to hold the random key.
            byte[] key = new byte[keySizeInBytes];

            // Fill the key array with cryptographically secure random bytes.
            rng.GetBytes(key);

            // Return the generated random key.
            return key;
        }
    }
}
