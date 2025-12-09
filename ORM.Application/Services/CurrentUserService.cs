using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ORM.Core.DTOs.User;
using ORM.Core.Interfaces.Services;

namespace ORM.Application.Services;

/// <summary>
/// Service to access current authenticated user information from anywhere in the application.
/// Inject this service into any service or repository to access the current user's data.
/// User context is cached per HTTP request to avoid multiple database calls.
/// </summary>
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserContextService _userContextService;

    // Cache key for storing user context in HttpContext.Items
    private const string UserContextCacheKey = "CurrentUserContext";

    public CurrentUserService(
        IHttpContextAccessor httpContextAccessor,
        IUserContextService userContextService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userContextService = userContextService;
    }

    /// <summary>
    /// Gets the current user's ID from JWT claims
    /// </summary>
    public int? UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out var userId) ? userId : null;
        }
    }

    /// <summary>
    /// Gets the current user's login name from JWT claims
    /// </summary>
    public string? UserLogin => _httpContextAccessor.HttpContext?.User?.FindFirst("UserLogin")?.Value;

    /// <summary>
    /// Gets the current user's name from JWT claims
    /// </summary>
    public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

    /// <summary>
    /// Gets the current user's account ID from JWT claims
    /// </summary>
    public int? AccountId
    {
        get
        {
            var accountIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("AccountId")?.Value;
            return int.TryParse(accountIdClaim, out var accountId) ? accountId : null;
        }
    }

    /// <summary>
    /// Checks if user is authenticated
    /// </summary>
    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    /// <summary>
    /// Gets the full user context with roles, authorities, branches, departments, divisions.
    /// Result is cached per HTTP request - multiple calls won't hit the database again.
    /// </summary>
    public async Task<UserContextDto?> GetUserContextAsync()
    {
        if (!UserId.HasValue)
            return null;

        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
            return null;

        // Check if already cached in this request
        if (httpContext.Items.TryGetValue(UserContextCacheKey, out var cached) && cached is UserContextDto cachedContext)
        {
            return cachedContext;
        }

        // Load from database and cache for this request
        var userContext = await _userContextService.GetUserContextAsync(UserId.Value);

        if (userContext != null)
        {
            httpContext.Items[UserContextCacheKey] = userContext;
        }

        return userContext;
    }
}
