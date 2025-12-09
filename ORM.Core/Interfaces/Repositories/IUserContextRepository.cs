using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

/// <summary>
/// Repository for user context related data
/// </summary>
public interface IUserContextRepository
{
    /// <summary>
    /// Get user by ID with related data (Department, Branch, Division, JobTitle)
    /// </summary>
    Task<GrcUser?> GetUserWithDetailsAsync(int userId);

    /// <summary>
    /// Get user branches from User_Branch table
    /// </summary>
    Task<List<UserBranch>> GetUserBranchesAsync(int userId);

    /// <summary>
    /// Get user departments from GRC_User_Department table
    /// </summary>
    Task<List<GrcUserDepartment>> GetUserDepartmentsAsync(int userId);

    /// <summary>
    /// Get user divisions from User_Division table
    /// </summary>
    Task<List<UserDivision>> GetUserDivisionsAsync(int userId);

    /// <summary>
    /// Get user roles from OrmRoleUsers and OrmRoles tables
    /// </summary>
    Task<List<OrmRoleUser>> GetUserRolesAsync(int userId);
}
