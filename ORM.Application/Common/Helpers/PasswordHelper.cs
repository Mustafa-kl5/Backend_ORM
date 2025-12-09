using System.Security.Cryptography;
using System.Text;

namespace ORM.Application.Common.Helpers;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
    }

    public static string GeneratePasswordResetToken(int userId)
    {
        using (var cryptoProvider = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[32];
            cryptoProvider.GetBytes(randomBytes);
            string token = Convert.ToBase64String(randomBytes);
            string combinedToken = $"{userId}:{token}";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(combinedToken));
        }
    }

    public static (int userId, string token) DecodePasswordResetToken(string encodedToken)
    {
        var decodedBytes = Convert.FromBase64String(encodedToken);
        var decodedString = Encoding.UTF8.GetString(decodedBytes);
        var parts = decodedString.Split(':');
        if (parts.Length != 2) throw new Exception("Invalid token format.");
        int userId = int.Parse(parts[0]);
        string token = parts[1];
        return (userId, token);
    }
}
