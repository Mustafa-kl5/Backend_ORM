using Microsoft.AspNetCore.Mvc;
using ORM.Application.Common.Responses;

namespace ORM_API.Controllers;

/// <summary>
/// Base controller with common response helper methods
/// </summary>
[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// Returns a success response with data
    /// </summary>
    protected IActionResult Success<T>(T data, string message = "Operation completed successfully", int statusCode = 200)
    {
        var response = ApiResponse<T>.SuccessResponse(data, message, statusCode);
        return StatusCode(statusCode, response);
    }

    /// <summary>
    /// Returns a success response without data
    /// </summary>
    protected IActionResult Success(string message = "Operation completed successfully", int statusCode = 200)
    {
        var response = ApiResponse.SuccessResponse(message, statusCode);
        return StatusCode(statusCode, response);
    }

    /// <summary>
    /// Returns a created response (201)
    /// </summary>
    protected IActionResult Created<T>(T data, string message = "Resource created successfully")
    {
        var response = ApiResponse<T>.SuccessResponse(data, message, 201);
        return StatusCode(201, response);
    }

    /// <summary>
    /// Returns a failure response
    /// </summary>
    protected IActionResult Fail(string message, int statusCode = 400, List<string>? errors = null)
    {
        var response = ApiResponse.FailResponse(message, statusCode, errors);
        return StatusCode(statusCode, response);
    }

    /// <summary>
    /// Returns a not found response
    /// </summary>
    protected IActionResult NotFoundResponse(string message = "Resource not found")
    {
        var response = ApiResponse.FailResponse(message, 404);
        return StatusCode(404, response);
    }

    /// <summary>
    /// Returns an unauthorized response
    /// </summary>
    protected IActionResult UnauthorizedResponse(string message = "Unauthorized access")
    {
        var response = ApiResponse.FailResponse(message, 401);
        return StatusCode(401, response);
    }

    /// <summary>
    /// Returns a paginated response
    /// </summary>
    protected IActionResult Paginated<T>(
        IEnumerable<T> data,
        int currentPage,
        int pageSize,
        int totalCount,
        string message = "Data retrieved successfully")
    {
        var response = PaginatedResponse<T>.SuccessResponse(data, currentPage, pageSize, totalCount, message);
        return Ok(response);
    }

    /// <summary>
    /// Gets the current user ID from the JWT token
    /// </summary>
    protected int GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            throw new UnauthorizedAccessException("User ID not found in token");
        }
        return userId;
    }

    /// <summary>
    /// Gets the current user's account ID from the JWT token
    /// </summary>
    protected int GetCurrentAccountId()
    {
        var accountIdClaim = User.FindFirst("AccountId");
        if (accountIdClaim == null || !int.TryParse(accountIdClaim.Value, out int accountId))
        {
            throw new UnauthorizedAccessException("Account ID not found in token");
        }
        return accountId;
    }

    /// <summary>
    /// Checks if the current user has a specific permission
    /// </summary>
    protected bool HasPermission(string permission)
    {
        return User.Claims.Any(c => c.Type == "Permission" && c.Value == permission);
    }
}
