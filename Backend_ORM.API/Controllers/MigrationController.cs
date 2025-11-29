using Backend_ORM.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

/// <summary>
/// Controller for running data migrations (Admin only)
/// </summary>
[ApiController]
[Route("api/migration")]
public class MigrationController : ControllerBase
{
    private readonly DataMigrationService _migrationService;
    private readonly ILogger<MigrationController> _logger;

    public MigrationController(
        DataMigrationService migrationService,
        ILogger<MigrationController> logger)
    {
        _migrationService = migrationService;
        _logger = logger;
    }

    /// <summary>
    /// Reset all user passwords to default (M123456789) with BCrypt hashing
    /// WARNING: This will reset ALL user passwords!
    /// </summary>
    [HttpPost("reset-passwords")]
    public async Task<IActionResult> ResetAllPasswords()
    {
        try
        {
            _logger.LogWarning("Password reset migration initiated");
            var count = await _migrationService.ResetAllPasswordsAsync();
            return Ok(new { Message = $"Successfully reset passwords for {count} users", UsersAffected = count });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during password reset migration");
            return StatusCode(500, "An error occurred during password reset migration");
        }
    }

    /// <summary>
    /// Encrypt all user sensitive data (Name, UserLogin, EmailAddress)
    /// </summary>
    [HttpPost("encrypt-user-data")]
    public async Task<IActionResult> EncryptAllUserData()
    {
        try
        {
            _logger.LogWarning("User data encryption migration initiated");
            var count = await _migrationService.EncryptAllUserDataAsync();
            return Ok(new { Message = $"Successfully encrypted data for {count} users", UsersAffected = count });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during user data encryption migration");
            return StatusCode(500, "An error occurred during user data encryption migration");
        }
    }

    /// <summary>
    /// Run full migration: reset passwords and encrypt user data
    /// WARNING: This will reset ALL user passwords!
    /// </summary>
    [HttpPost("run-full-migration")]
    public async Task<IActionResult> RunFullMigration()
    {
        try
        {
            _logger.LogWarning("Full migration initiated");
            var (passwordsReset, usersEncrypted) = await _migrationService.RunFullMigrationAsync();
            return Ok(new
            {
                Message = "Full migration completed successfully",
                PasswordsReset = passwordsReset,
                UsersEncrypted = usersEncrypted
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during full migration");
            return StatusCode(500, "An error occurred during full migration");
        }
    }

    /// <summary>
    /// Decrypt all user data (for rollback purposes)
    /// WARNING: This will remove encryption from user data!
    /// </summary>
    [HttpPost("decrypt-user-data")]
    public async Task<IActionResult> DecryptAllUserData()
    {
        try
        {
            _logger.LogWarning("User data decryption (rollback) initiated");
            var count = await _migrationService.DecryptAllUserDataAsync();
            return Ok(new { Message = $"Successfully decrypted data for {count} users", UsersAffected = count });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during user data decryption");
            return StatusCode(500, "An error occurred during user data decryption");
        }
    }
}
