using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Application.Common.Localization;
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

/// <summary>
/// Controller for data migration operations
/// WARNING: These endpoints should only be used during initial setup/migration
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MigrationController : BaseController
{
    private readonly IMigrationService _migrationService;
    private readonly ILocalizationService _localization;

    public MigrationController(
        IMigrationService migrationService,
        ILocalizationService localization)
    {
        _migrationService = migrationService;
        _localization = localization;
    }

    /// <summary>
    /// Migrate all users - re-encrypt data and set password to M123456789
    /// WARNING: This will reset ALL user passwords!
    /// </summary>
    /// <remarks>
    /// This endpoint will:
    /// 1. Decrypt existing encrypted data (Email, UserLogin, Name)
    /// 2. Re-encrypt using our encryption code
    /// 3. Set ALL user passwords to "M123456789"
    /// 
    /// USE WITH CAUTION - This operation cannot be undone!
    /// </remarks>
    [HttpPost("migrate-users")]
    [AllowAnonymous] // Remove this after migration is complete!
    public async Task<IActionResult> MigrateUsers()
    {
        var result = await _migrationService.MigrateUsersAsync();

        var message = $"Migration completed. Total: {result.TotalUsers}, Success: {result.SuccessfullyMigrated}, Failed: {result.Failed}";

        if (result.Failed > 0)
        {
            return Success(result, message);
        }

        return Success(result, message);
    }
}
