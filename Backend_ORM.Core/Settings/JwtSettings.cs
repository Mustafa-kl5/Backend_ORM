namespace Backend_ORM.Core.Settings;

/// <summary>
/// Configuration settings for JWT authentication
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Secret key used to sign JWT tokens (minimum 256 bits / 32 characters)
    /// </summary>
    public string SecretKey { get; set; } = null!;

    /// <summary>
    /// JWT token issuer
    /// </summary>
    public string Issuer { get; set; } = null!;

    /// <summary>
    /// JWT token audience
    /// </summary>
    public string Audience { get; set; } = null!;

    /// <summary>
    /// Token expiration time in minutes
    /// </summary>
    public int ExpirationInMinutes { get; set; } = 60;
}
