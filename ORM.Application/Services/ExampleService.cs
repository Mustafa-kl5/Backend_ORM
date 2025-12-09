using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Core.Interfaces.Services;

namespace ORM.Application.Services;

/// <summary>
/// EXAMPLE: How to use ICurrentUserService in any service
/// This demonstrates checking user authorities before performing operations
/// </summary>
public class ExampleService
{
    private readonly ICurrentUserService _currentUser;
    private readonly ILocalizationService _localization;

    public ExampleService(
        ICurrentUserService currentUser,
        ILocalizationService localization)
    {
        _currentUser = currentUser;
        _localization = localization;
    }

    /// <summary>
    /// Example: Only Makers can create items
    /// </summary>
    public async Task CreateItemAsync(string itemName)
    {
        // Get full user context
        var userContext = await _currentUser.GetUserContextAsync();

        if (userContext == null)
            throw new UnauthorizedException(_localization.Get(MessageKeys.Unauthorized));

        // Check if user is a Maker
        if (!userContext.Authorities.IsMaker)
            throw new ForbiddenException("Only Makers can create items");

        // Your business logic here...
        // Create the item
    }

    /// <summary>
    /// Example: Only Checkers can approve items
    /// </summary>
    public async Task ApproveItemAsync(int itemId)
    {
        var userContext = await _currentUser.GetUserContextAsync();

        if (userContext == null)
            throw new UnauthorizedException(_localization.Get(MessageKeys.Unauthorized));

        // Check if user is a Checker
        if (!userContext.Authorities.IsChecker)
            throw new ForbiddenException("Only Checkers can approve items");

        // Your business logic here...
    }

    /// <summary>
    /// Example: Only Admins can delete items
    /// </summary>
    public async Task DeleteItemAsync(int itemId)
    {
        var userContext = await _currentUser.GetUserContextAsync();

        if (userContext == null)
            throw new UnauthorizedException(_localization.Get(MessageKeys.Unauthorized));

        // Check if user is Admin
        if (!userContext.Authorities.IsAdmin)
            throw new ForbiddenException("Only Admins can delete items");

        // Your business logic here...
    }

    /// <summary>
    /// Example: Check if user belongs to specific department
    /// </summary>
    public async Task ProcessDepartmentDataAsync(int departmentId)
    {
        var userContext = await _currentUser.GetUserContextAsync();

        if (userContext == null)
            throw new UnauthorizedException(_localization.Get(MessageKeys.Unauthorized));

        // Check if user has access to this department
        bool hasDepartmentAccess = userContext.Department?.DepartmentId == departmentId
            || userContext.Departments.Any(d => d.DepartmentId == departmentId);

        if (!hasDepartmentAccess)
            throw new ForbiddenException("You don't have access to this department");

        // Your business logic here...
    }

    /// <summary>
    /// Example: Check if user belongs to specific branch
    /// </summary>
    public async Task ProcessBranchDataAsync(int branchId)
    {
        var userContext = await _currentUser.GetUserContextAsync();

        if (userContext == null)
            throw new UnauthorizedException(_localization.Get(MessageKeys.Unauthorized));

        // Check if user has access to this branch
        bool hasBranchAccess = userContext.Branch?.BranchId == branchId
            || userContext.Branches.Any(b => b.BranchId == branchId);

        if (!hasBranchAccess)
            throw new ForbiddenException("You don't have access to this branch");

        // Your business logic here...
    }

    /// <summary>
    /// Example: Quick access to user info without database call
    /// </summary>
    public void LogUserAction(string action)
    {
        // These come from JWT claims - no database call needed
        var userId = _currentUser.UserId;
        var userName = _currentUser.UserName;
        var userLogin = _currentUser.UserLogin;

        // Log the action
        Console.WriteLine($"User {userName} (ID: {userId}, Login: {userLogin}) performed: {action}");
    }
}
