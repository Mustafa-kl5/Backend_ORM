using System.Security.Cryptography;

namespace Backend_ORM.Core.Helpers;

/// <summary>
/// Helper class for password hashing and verification using BCrypt
/// </summary>
public static class PasswordHelper
{
    /// <summary>
    /// Hashes a plain text password using BCrypt
    /// </summary>
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <summary>
    /// Verifies if an entered password matches the stored hash
    /// </summary>
    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
    }

    /// <summary>
    /// Generates a secure password reset token for a user
    /// </summary>
    public static string GeneratePasswordResetToken(int userId)
    {
        byte[] randomBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }
        string token = Convert.ToBase64String(randomBytes);
        string combinedToken = $"{userId}:{token}";
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(combinedToken));
    }

    /// <summary>
    /// Decodes a password reset token to extract user ID and token
    /// </summary>
    public static (int userId, string token) DecodePasswordResetToken(string encodedToken)
    {
        var decodedBytes = Convert.FromBase64String(encodedToken);
        var decodedString = System.Text.Encoding.UTF8.GetString(decodedBytes);
        var parts = decodedString.Split(':');
        if (parts.Length != 2)
            throw new ArgumentException("Invalid token format.");
        int userId = int.Parse(parts[0]);
        string token = parts[1];
        return (userId, token);
    }

    /// <summary>
    /// Default password for initial user setup
    /// </summary>
    public const string DefaultPassword = "M123456789";
}
