using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Application.Common.Localization;
using ORM.Core.DTOs.Auth;
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    private readonly IUserContextService _userContextService;
    private readonly ILocalizationService _localization;

    public AuthController(
        IAuthService authService,
        IUserContextService userContextService,
        ILocalizationService localization)
    {
        _authService = authService;
        _userContextService = userContextService;
        _localization = localization;
    }

    /// <summary>
    /// Authenticate user and get JWT token
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var result = await _authService.LoginAsync(request);
        return Success(result, _localization.Get(MessageKeys.LoginSuccess));
    }

    /// <summary>
    /// Refresh JWT token using refresh token
    /// </summary>
    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
    {
        var result = await _authService.RefreshTokenAsync(request);
        return Success(result, _localization.Get(MessageKeys.TokenRefreshed));
    }

    /// <summary>
    /// Get current user context with full details including roles, authorities, branches, departments, and divisions
    /// </summary>
    [HttpGet("context")]
    [Authorize]
    public async Task<IActionResult> GetUserContext()
    {
        var userId = GetCurrentUserId();
        var userContext = await _userContextService.GetUserContextAsync(userId);

        if (userContext == null)
            return NotFoundResponse(_localization.Get(MessageKeys.UserNotFound));

        return Success(userContext);
    }
}
