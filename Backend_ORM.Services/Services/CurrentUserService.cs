using System.Security.Claims;
using Backend_ORM.Core.DTOs.Auth;
using Backend_ORM.Core.Helpers;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Services.Services;

/// <summary>
/// Service for accessing current authenticated user information from HTTP context
/// </summary>
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ORMContext _context;
    private readonly EncryptionHelper _encryptionHelper;
    private CurrentUserDto? _cachedUser;

    public CurrentUserService(
        IHttpContextAccessor httpContextAccessor,
        ORMContext context,
        EncryptionHelper encryptionHelper)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
        _encryptionHelper = encryptionHelper;
    }

    /// <summary>
    /// Gets the current authenticated user's ID from JWT claims
    /// </summary>
    public int? UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId) ? userId : null;
        }
    }

    /// <summary>
    /// Gets the current authenticated user's account ID from JWT claims
    /// </summary>
    public int? AccountId
    {
        get
        {
            var accountIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("accountId");
            return accountIdClaim != null && int.TryParse(accountIdClaim.Value, out int accountId) ? accountId : null;
        }
    }

    /// <summary>
    /// Gets the current authenticated user's name from JWT claims
    /// </summary>
    public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

    /// <summary>
    /// Gets the current authenticated user's email from JWT claims
    /// </summary>
    public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

    /// <summary>
    /// Indicates if a user is currently authenticated
    /// </summary>
    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    /// <summary>
    /// Gets the full current user information (loaded from database on first access)
    /// </summary>
    public CurrentUserDto? CurrentUser
    {
        get
        {
            if (_cachedUser != null)
                return _cachedUser;

            if (!UserId.HasValue)
                return null;

            var user = _context.GrcUsers
                .Include(u => u.Account)
                .FirstOrDefault(u => u.UserId == UserId.Value);

            if (user == null)
                return null;

            _cachedUser = new CurrentUserDto
            {
                UserId = user.UserId,
                Name = _encryptionHelper.Decrypt(user.Name),
                UserLogin = _encryptionHelper.Decrypt(user.UserLogin),
                EmailAddress = user.EmailAddress != null ? _encryptionHelper.Decrypt(user.EmailAddress) : null,
                AccountId = user.AccountId,
                DepartmentId = user.DepDepartmentId,
                BranchId = user.BranchId,
                DivisionId = user.DivisionId,
                HasAdminAccess = user.AdminAccess == true,
                IsPasswordChangeRequired = user.IsPassMustChange == true,
                IsDefaultActionUser = user.DefaultActionUser == true,
                CanApproveEscalations = user.EscalationActionApproval == true,
                HasRegulatoryAccess = user.AddRegFlag == true,
                HasBreachManagementAccess = user.BreachManagementFlag == true,
                HasWhistleblowerAccess = user.WhistleManagementFlag == true,
                CanApproveStagingRegulations = user.ApproveStagingReg == true,
                HasRcmaAccess = user.RcmaFlag == true,
                HasRccmAccess = user.RccmFlag == true,
                HasAdvisoryAccess = user.AdvisoryFlag == true,
                JobTitleId = user.JobTitleId,
                LanguageCode = user.LanguageCode
            };

            return _cachedUser;
        }
    }
}
