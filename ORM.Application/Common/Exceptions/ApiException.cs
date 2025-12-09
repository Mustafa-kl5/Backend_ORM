namespace ORM.Application.Common.Exceptions;

/// <summary>
/// Base API exception class
/// </summary>
public class ApiException : Exception
{
    public int StatusCode { get; }
    public List<string> Errors { get; }

    public ApiException(string message, int statusCode = 500, List<string>? errors = null)
        : base(message)
    {
        StatusCode = statusCode;
        Errors = errors ?? new List<string>();
    }
}

/// <summary>
/// Exception for resource not found (404)
/// </summary>
public class NotFoundException : ApiException
{
    public NotFoundException(string message = "Resource not found")
        : base(message, 404)
    {
    }

    public NotFoundException(string resourceName, object key)
        : base($"{resourceName} with key '{key}' was not found", 404)
    {
    }
}

/// <summary>
/// Exception for validation errors (400)
/// </summary>
public class ValidationException : ApiException
{
    public ValidationException(string message = "Validation failed")
        : base(message, 400)
    {
    }

    public ValidationException(List<string> errors)
        : base("One or more validation errors occurred", 400, errors)
    {
    }

    public ValidationException(string field, string error)
        : base($"Validation failed for '{field}': {error}", 400, new List<string> { $"{field}: {error}" })
    {
    }
}

/// <summary>
/// Exception for unauthorized access (401)
/// </summary>
public class UnauthorizedException : ApiException
{
    public UnauthorizedException(string message = "Unauthorized access")
        : base(message, 401)
    {
    }
}

/// <summary>
/// Exception for forbidden access (403)
/// </summary>
public class ForbiddenException : ApiException
{
    public ForbiddenException(string message = "Access forbidden")
        : base(message, 403)
    {
    }
}

/// <summary>
/// Exception for conflict errors (409)
/// </summary>
public class ConflictException : ApiException
{
    public ConflictException(string message = "Resource conflict")
        : base(message, 409)
    {
    }
}

/// <summary>
/// Exception for bad request (400)
/// </summary>
public class BadRequestException : ApiException
{
    public BadRequestException(string message = "Bad request")
        : base(message, 400)
    {
    }
}
