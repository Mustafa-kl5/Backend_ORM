using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Application.Common.Responses;

namespace ORM.Infrastructure.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        // Get localization service
        var localizationService = context.RequestServices.GetService<ILocalizationService>();

        var response = new ApiResponse<object>();

        switch (exception)
        {
            case ApiException apiException:
                _logger.LogWarning(exception, "API Exception: {Message}", apiException.Message);
                context.Response.StatusCode = apiException.StatusCode;
                response = new ApiResponse<object>
                {
                    Success = false,
                    StatusCode = apiException.StatusCode,
                    Message = apiException.Message,
                    Errors = apiException.Errors,
                    Data = null
                };
                break;

            case UnauthorizedAccessException:
                _logger.LogWarning(exception, "Unauthorized access attempt");
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                response = new ApiResponse<object>
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Message = localizationService?.Get(MessageKeys.Unauthorized) ?? "Unauthorized access",
                    Errors = new List<string> { localizationService?.Get(MessageKeys.AuthenticationRequired) ?? "You are not authorized to access this resource" },
                    Data = null
                };
                break;

            case KeyNotFoundException:
                _logger.LogWarning(exception, "Resource not found: {Message}", exception.Message);
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                response = new ApiResponse<object>
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = localizationService?.Get(MessageKeys.NotFound) ?? exception.Message,
                    Errors = new List<string>(),
                    Data = null
                };
                break;

            case ArgumentException:
            case InvalidOperationException:
                _logger.LogWarning(exception, "Bad request: {Message}", exception.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response = new ApiResponse<object>
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = localizationService?.Get(MessageKeys.BadRequest) ?? exception.Message,
                    Errors = new List<string>(),
                    Data = null
                };
                break;

            default:
                _logger.LogError(exception, "Unhandled exception occurred: {Message}", exception.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorMessage = _env.IsDevelopment()
                    ? exception.Message
                    : localizationService?.Get(MessageKeys.InternalServerError) ?? "An unexpected error occurred. Please try again later.";

                var errors = _env.IsDevelopment()
                    ? new List<string> { exception.StackTrace ?? string.Empty }
                    : new List<string>();

                response = new ApiResponse<object>
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = errorMessage,
                    Errors = errors,
                    Data = null
                };
                break;
        }

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var result = JsonSerializer.Serialize(response, jsonOptions);
        await context.Response.WriteAsync(result);
    }
}

// Extension method for easy middleware registration
public static class GlobalExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}
