using Microsoft.Extensions.Logging;
using ORM.Application.Common.Helpers;
using ORM.Core.DTOs.Migration;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;

namespace ORM.Application.Services;

/// <summary>
/// Service to migrate user data - re-encrypt and reset passwords
/// </summary>
public class MigrationService : IMigrationService
{
    private readonly IMigrationRepository _migrationRepository;
    private readonly ILogger<MigrationService> _logger;

    // Default password for all users after migration
    private const string DefaultPassword = "M123456789";

    public MigrationService(IMigrationRepository migrationRepository, ILogger<MigrationService> logger)
    {
        _migrationRepository = migrationRepository;
        _logger = logger;
    }

    /// <summary>
    /// Migrate all users:
    /// 1. Decrypt existing encrypted data (Email, UserLogin, Name)
    /// 2. Re-encrypt using our encryption code
    /// 3. Set password to M123456789 (BCrypt hashed)
    /// </summary>
    public async Task<MigrationResponseDto> MigrateUsersAsync()
    {
        var response = new MigrationResponseDto();

        // Get all users
        var users = await _migrationRepository.GetAllUsersAsync();
        response.TotalUsers = users.Count;

        _logger.LogInformation("Starting migration for {Count} users", users.Count);

        // Hash the default password once
        var hashedPassword = PasswordHelper.HashPassword(DefaultPassword);

        foreach (var user in users)
        {
            try
            {
                // 1. Decrypt existing data (if encrypted)
                var decryptedName = DecryptValue(user.Name);
                var decryptedUserLogin = DecryptValue(user.UserLogin);
                var decryptedEmail = DecryptValue(user.EmailAddress);

                // 2. Re-encrypt using our encryption
                user.Name = EncryptionHelper.Encrypt(decryptedName);
                user.UserLogin = EncryptionHelper.Encrypt(decryptedUserLogin);
                user.EmailAddress = !string.IsNullOrEmpty(decryptedEmail)
                    ? EncryptionHelper.Encrypt(decryptedEmail)
                    : null;

                // 3. Set default password (BCrypt hashed)
                user.UserPassword = hashedPassword;

                response.SuccessfullyMigrated++;

                _logger.LogDebug("Migrated user {UserId}: {UserLogin}", user.UserId, decryptedUserLogin);
            }
            catch (Exception ex)
            {
                response.Failed++;
                response.Errors.Add(new MigrationErrorDto
                {
                    UserId = user.UserId,
                    UserLogin = TryGetUserLogin(user.UserLogin),
                    ErrorMessage = ex.Message
                });

                _logger.LogError(ex, "Failed to migrate user {UserId}", user.UserId);
            }
        }

        // Save all changes
        if (response.SuccessfullyMigrated > 0)
        {
            await _migrationRepository.SaveChangesAsync();
            _logger.LogInformation("Migration completed. Success: {Success}, Failed: {Failed}",
                response.SuccessfullyMigrated, response.Failed);
        }

        return response;
    }

    /// <summary>
    /// Decrypt value if it appears to be encrypted, otherwise return as-is
    /// </summary>
    private string DecryptValue(string? value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        try
        {
            // Try to decrypt - if it fails, assume it's plain text
            if (EncryptionHelper.IsEncrypted(value))
            {
                return EncryptionHelper.Decrypt(value);
            }
            return value;
        }
        catch
        {
            // If decryption fails, return original value (might be plain text)
            return value;
        }
    }

    /// <summary>
    /// Try to get readable user login for error reporting
    /// </summary>
    private string? TryGetUserLogin(string? userLogin)
    {
        if (string.IsNullOrEmpty(userLogin))
            return null;

        try
        {
            if (EncryptionHelper.IsEncrypted(userLogin))
                return EncryptionHelper.Decrypt(userLogin);
            return userLogin;
        }
        catch
        {
            return userLogin;
        }
    }
}
