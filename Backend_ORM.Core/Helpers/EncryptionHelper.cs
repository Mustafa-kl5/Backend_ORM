using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Backend_ORM.Core.Helpers;

/// <summary>
/// Helper class for AES-256 encryption and decryption of sensitive data
/// </summary>
public class EncryptionHelper
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    /// <summary>
    /// Creates a new EncryptionHelper using configuration settings
    /// </summary>
    public EncryptionHelper(IConfiguration configuration)
    {
        var encryptionSettings = configuration.GetSection("EncryptionSettings");
        var key = encryptionSettings["Key"];
        var iv = encryptionSettings["IV"];

        if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(iv))
            throw new ArgumentException("Key or IV is missing in configuration.");

        _key = Encoding.UTF8.GetBytes(key);
        _iv = Encoding.UTF8.GetBytes(iv);

        if (_key.Length != 32)
            throw new ArgumentException("Key must be 32 bytes for AES-256 encryption.");

        if (_iv.Length != 16)
            throw new ArgumentException("IV must be 16 bytes for AES encryption.");
    }

    /// <summary>
    /// Encrypts plain text using AES-256 CBC mode
    /// </summary>
    public string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            return plainText;

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

    /// <summary>
    /// Decrypts cipher text using AES-256 CBC mode
    /// </summary>
    public string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText))
            return cipherText;

        try
        {
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
        catch
        {
            // If decryption fails, return original value (might already be plain text)
            return cipherText;
        }
    }

    /// <summary>
    /// Checks if a string appears to be encrypted (base64 encoded)
    /// </summary>
    public static bool IsEncrypted(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        try
        {
            // Check if it's valid base64 and has typical AES output characteristics
            var bytes = Convert.FromBase64String(input);
            return bytes.Length >= 16 && bytes.Length % 16 == 0;
        }
        catch
        {
            return false;
        }
    }
}
