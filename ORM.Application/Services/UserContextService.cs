using ORM.Application.Common.Helpers;
using ORM.Core.DTOs.User;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;

namespace ORM.Application.Services;

public class UserContextService : IUserContextService
{
    private readonly IUserContextRepository _userContextRepository;

    // Role codes (1, 2, 3, 99)
    private static readonly int[] RoleCodes = { 1, 2, 3, 99 };

    // Authority codes
    private const int MakerCode = 50;
    private const int CheckerCode = 51;
    private const int AdminCode = 55;
    private const int ManagerCode = 56;

    public UserContextService(IUserContextRepository userContextRepository)
    {
        _userContextRepository = userContextRepository;
    }

    public async Task<UserContextDto?> GetUserContextAsync(int userId)
    {
        // Get user with primary details
        var user = await _userContextRepository.GetUserWithDetailsAsync(userId);
        if (user == null)
            return null;

        // Get additional user data sequentially (DbContext is not thread-safe)
        var userBranches = await _userContextRepository.GetUserBranchesAsync(userId);
        var userDepartments = await _userContextRepository.GetUserDepartmentsAsync(userId);
        var userDivisions = await _userContextRepository.GetUserDivisionsAsync(userId);
        var userRoles = await _userContextRepository.GetUserRolesAsync(userId);

        // Build user context
        var userContext = new UserContextDto
        {
            UserId = user.UserId,
            Name = DecryptIfEncrypted(user.Name) ?? string.Empty,
            UserLogin = DecryptIfEncrypted(user.UserLogin) ?? string.Empty,
            EmailAddress = DecryptIfEncrypted(user.EmailAddress),
            CountryId = user.CouCountryId,
            AccountId = user.AccountId,
            LanguageCode = user.LanguageCode,

            // Primary Department
            Department = user.DepDepartment != null ? new DepartmentDto
            {
                DepartmentId = user.DepDepartment.DepartmentId,
                DepartmentName = user.DepDepartment.DepartmentName
            } : null,

            // Primary Branch
            Branch = user.Branch != null ? new BranchDto
            {
                BranchId = user.Branch.BranchId,
                BranchName = user.Branch.BranchName
            } : null,

            // Primary Division
            Division = user.Division != null ? new DivisionDto
            {
                DivisionId = user.Division.Id,
                DivisionName = user.Division.Description
            } : null,

            // Job Title
            JobTitle = user.JobTitle != null ? new JobTitleDto
            {
                JobTitleId = user.JobTitle.Id,
                JobTitleName = user.JobTitle.Title
            } : null,

            // Multiple Branches
            Branches = userBranches
                .Where(ub => ub.Branch != null)
                .Select(ub => new BranchDto
                {
                    BranchId = ub.Branch.BranchId,
                    BranchName = ub.Branch.BranchName
                }).ToList(),

            // Multiple Departments
            Departments = userDepartments
                .Where(ud => ud.Department != null)
                .Select(ud => new DepartmentDto
                {
                    DepartmentId = ud.Department.DepartmentId,
                    DepartmentName = ud.Department.DepartmentName
                }).ToList(),

            // Multiple Divisions
            Divisions = userDivisions
                .Where(ud => ud.Division != null)
                .Select(ud => new DivisionDto
                {
                    DivisionId = ud.Division.Id,
                    DivisionName = ud.Division.Description
                }).ToList(),

            // Role and Authorities
            Role = GetUserRole(userRoles),
            Authorities = GetUserAuthorities(userRoles)
        };

        return userContext;
    }

    /// <summary>
    /// Get user role (code 1, 2, 3, 99)
    /// </summary>
    private RoleDto? GetUserRole(List<Domain.Entities.OrmRoleUser> userRoles)
    {
        var role = userRoles
            .Where(ru => ru.Role != null && RoleCodes.Contains(ru.Role.Code))
            .Select(ru => ru.Role)
            .FirstOrDefault();

        if (role == null)
            return null;

        return new RoleDto
        {
            RoleId = role.Id,
            RoleName = role.Description,
            Code = role.Code
        };
    }

    /// <summary>
    /// Get user authorities (code 50, 51, 55, 56)
    /// </summary>
    private UserAuthoritiesDto GetUserAuthorities(List<Domain.Entities.OrmRoleUser> userRoles)
    {
        var authorityCodes = userRoles
            .Where(ru => ru.Role != null)
            .Select(ru => ru.Role.Code)
            .ToHashSet();

        return new UserAuthoritiesDto
        {
            IsMaker = authorityCodes.Contains(MakerCode),
            IsChecker = authorityCodes.Contains(CheckerCode),
            IsAdmin = authorityCodes.Contains(AdminCode),
            IsManager = authorityCodes.Contains(ManagerCode)
        };
    }

    /// <summary>
    /// Decrypts a value if it appears to be encrypted
    /// </summary>
    private string? DecryptIfEncrypted(string? value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        try
        {
            if (EncryptionHelper.IsEncrypted(value))
                return EncryptionHelper.Decrypt(value);
            return value;
        }
        catch
        {
            return value;
        }
    }
}
