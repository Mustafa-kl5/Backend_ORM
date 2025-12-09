using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ORM.Application.Common.Helpers;

public static class EncryptionHelper
{
    private static readonly byte[] _key;
    private static readonly byte[] _iv;

    // Static constructor to initialize _key and _iv from configuration
    static EncryptionHelper()
    {
        try
        {
            // Load settings from configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Retrieve key and IV from EncryptionSettings section
            var encryptionSettings = configuration.GetSection("EncryptionSettings");
            var key = encryptionSettings["Key"];
            var iv = encryptionSettings["IV"];

            // Check for null or empty values in Key and IV
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(iv))
                throw new ArgumentException("Key or IV is missing in configuration.");

            _key = Encoding.UTF8.GetBytes(key);
            _iv = Encoding.UTF8.GetBytes(iv);

            // Validate key and IV length
            if (_key.Length != 32)
                throw new ArgumentException("Key must be 32 bytes for AES-256 encryption.");

            if (_iv.Length != 16)
                throw new ArgumentException("IV must be 16 bytes for AES encryption.");
        }
        catch (Exception ex)
        {
            throw new TypeInitializationException(nameof(EncryptionHelper), ex);
        }
    }

    public static string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            throw new ArgumentNullException(nameof(plainText));

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }

    public static string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText))
            throw new ArgumentNullException(nameof(cipherText));

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Helper to check if text appears to be base64 encrypted
    /// </summary>
    public static bool IsEncrypted(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        // Check if it's a valid base64 string (encrypted data is base64 encoded)
        // Base64 strings have length multiple of 4 and contain only valid base64 characters
        if (input.Length % 4 != 0)
            return false;

        try
        {
            // Try to decode as base64 - if it fails, it's not encrypted
            Convert.FromBase64String(input);

            // Additional check: if it contains typical base64 characters and looks like encrypted data
            // Encrypted data usually has mixed case, numbers, and special base64 chars (+, /, =)
            return input.Any(c => c == '+' || c == '/' || c == '=') ||
                   (input.Any(char.IsUpper) && input.Any(char.IsLower) && input.Any(char.IsDigit));
        }
        catch
        {
            return false;
        }
    }
}
