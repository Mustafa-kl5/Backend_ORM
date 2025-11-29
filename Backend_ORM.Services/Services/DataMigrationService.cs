using Backend_ORM.Core.Helpers;
using Backend_ORM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend_ORM.Services.Services;

/// <summary>
/// Service for migrating existing user data (password reset and encryption)
/// </summary>
public class DataMigrationService
{
    private readonly ORMContext _context;
    private readonly EncryptionHelper _encryptionHelper;
    private readonly ILogger<DataMigrationService> _logger;

    public DataMigrationService(
        ORMContext context,
        EncryptionHelper encryptionHelper,
        ILogger<DataMigrationService> logger)
    {
        _context = context;
        _encryptionHelper = encryptionHelper;
        _logger = logger;
    }

    /// <summary>
    /// Resets all user passwords to the default BCrypt hashed password
    /// and sets the IsPassMustChange flag to true
    /// </summary>
    public async Task<int> ResetAllPasswordsAsync()
    {
        _logger.LogInformation("Starting password reset migration...");

        var hashedPassword = PasswordHelper.HashPassword(PasswordHelper.DefaultPassword);
        var users = await _context.GrcUsers.ToListAsync();
        var updatedCount = 0;

        foreach (var user in users)
        {
            user.UserPassword = hashedPassword;
            user.IsPassMustChange = true;
            user.PasswordChangedDate = DateTime.UtcNow;
            user.LastUpdateDate = DateTime.UtcNow;
            updatedCount++;
        }

        await _context.SaveChangesAsync();
        _logger.LogInformation("Password reset completed for {Count} users", updatedCount);

        return updatedCount;
    }

    /// <summary>
    /// Encrypts Name, UserLogin, and EmailAddress for all users
    /// Skips already encrypted values
    /// </summary>
    public async Task<int> EncryptAllUserDataAsync()
    {
        _logger.LogInformation("Starting user data encryption migration...");

        var users = await _context.GrcUsers.ToListAsync();
        var updatedCount = 0;

        foreach (var user in users)
        {
            var wasUpdated = false;

            // Encrypt Name if not already encrypted
            if (!string.IsNullOrEmpty(user.Name) && !EncryptionHelper.IsEncrypted(user.Name))
            {
                user.Name = _encryptionHelper.Encrypt(user.Name);
                wasUpdated = true;
            }

            // Encrypt UserLogin if not already encrypted
            if (!string.IsNullOrEmpty(user.UserLogin) && !EncryptionHelper.IsEncrypted(user.UserLogin))
            {
                user.UserLogin = _encryptionHelper.Encrypt(user.UserLogin);
                wasUpdated = true;
            }

            // Encrypt EmailAddress if not already encrypted
            if (!string.IsNullOrEmpty(user.EmailAddress) && !EncryptionHelper.IsEncrypted(user.EmailAddress))
            {
                user.EmailAddress = _encryptionHelper.Encrypt(user.EmailAddress);
                wasUpdated = true;
            }

            if (wasUpdated)
            {
                user.LastUpdateDate = DateTime.UtcNow;
                updatedCount++;
            }
        }

        await _context.SaveChangesAsync();
        _logger.LogInformation("User data encryption completed for {Count} users", updatedCount);

        return updatedCount;
    }

    /// <summary>
    /// Runs the complete migration: password reset and data encryption
    /// </summary>
    public async Task<(int passwordsReset, int usersEncrypted)> RunFullMigrationAsync()
    {
        _logger.LogInformation("Starting full user data migration...");

        var passwordsReset = await ResetAllPasswordsAsync();
        var usersEncrypted = await EncryptAllUserDataAsync();

        _logger.LogInformation("Full migration completed. Passwords reset: {Passwords}, Users encrypted: {Encrypted}",
            passwordsReset, usersEncrypted);

        return (passwordsReset, usersEncrypted);
    }

    /// <summary>
    /// Decrypts all user data (for debugging/rollback purposes)
    /// </summary>
    public async Task<int> DecryptAllUserDataAsync()
    {
        _logger.LogWarning("Starting user data decryption (rollback)...");

        var users = await _context.GrcUsers.ToListAsync();
        var updatedCount = 0;

        foreach (var user in users)
        {
            var wasUpdated = false;

            // Decrypt Name if encrypted
            if (!string.IsNullOrEmpty(user.Name) && EncryptionHelper.IsEncrypted(user.Name))
            {
                user.Name = _encryptionHelper.Decrypt(user.Name);
                wasUpdated = true;
            }

            // Decrypt UserLogin if encrypted
            if (!string.IsNullOrEmpty(user.UserLogin) && EncryptionHelper.IsEncrypted(user.UserLogin))
            {
                user.UserLogin = _encryptionHelper.Decrypt(user.UserLogin);
                wasUpdated = true;
            }

            // Decrypt EmailAddress if encrypted
            if (!string.IsNullOrEmpty(user.EmailAddress) && EncryptionHelper.IsEncrypted(user.EmailAddress))
            {
                user.EmailAddress = _encryptionHelper.Decrypt(user.EmailAddress);
                wasUpdated = true;
            }

            if (wasUpdated)
            {
                user.LastUpdateDate = DateTime.UtcNow;
                updatedCount++;
            }
        }

        await _context.SaveChangesAsync();
        _logger.LogInformation("User data decryption completed for {Count} users", updatedCount);

        return updatedCount;
    }
}
