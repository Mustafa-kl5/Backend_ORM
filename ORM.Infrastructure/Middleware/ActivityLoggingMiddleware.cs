using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.Interfaces.Services;

namespace ORM.Infrastructure.Middleware;

public class ActivityLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly HashSet<string> _excludedEndpoints;

    public ActivityLoggingMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
        
        var excludedConfig = configuration.GetSection("ActivityLogging:ExcludedEndpoints").GetChildren();
        var excludedPaths = excludedConfig.Select(x => x.Value).Where(v => !string.IsNullOrEmpty(v)).Select(v => v!).ToList();
        
        if (!excludedPaths.Any())
        {
            excludedPaths = new List<string> { "/health", "/swagger", "/api/activitylog" };
        }
        
        _excludedEndpoints = new HashSet<string>(excludedPaths, StringComparer.OrdinalIgnoreCase);
    }

    public async Task InvokeAsync(HttpContext context, IActivityLogService activityLogService)
    {
        var enableMiddleware = _configuration.GetSection("ActivityLogging:EnableMiddleware").Value;
        var isEnabled = string.IsNullOrEmpty(enableMiddleware) || bool.Parse(enableMiddleware);
        
        if (!isEnabled || ShouldExclude(context.Request.Path))
        {
            await _next(context);
            return;
        }

        // Generate CorrelationId once at the start of request
        var correlationId = Guid.NewGuid();
        
        // Store in HttpContext.Items so ALL services can access it
        context.Items["CorrelationId"] = correlationId;
        
        // Add to response headers for debugging purposes
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Append("X-Correlation-ID", correlationId.ToString());
            return Task.CompletedTask;
        });

        var requestPath = context.Request.Path.Value ?? string.Empty;
        var method = context.Request.Method;

        try
        {
            await _next(context);

            // Log successful request
            if (context.Response.StatusCode < 400)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await activityLogService.LogActivityAsync(new CreateActivityLogDto
                        {
                            EventType = MapHttpMethodToEventType(method),
                            ActionType = MapHttpMethodToActionType(method),
                            TargetObject = $"API Request: {requestPath}",
                            IsSuccess = true,
                            AdditionalData = System.Text.Json.JsonSerializer.Serialize(new
                            {
                                Method = method,
                                Path = requestPath,
                                QueryString = context.Request.QueryString.Value,
                                StatusCode = context.Response.StatusCode
                            })
                        });
                    }
                    catch
                    {
                        // Silently fail to avoid breaking the request
                    }
                });
            }
        }
        catch (Exception ex)
        {
            // Log failure
            _ = Task.Run(async () =>
            {
                try
                {
                    await activityLogService.LogFailureAsync(
                        MapHttpMethodToEventType(method),
                        ex.Message,
                        $"API Request: {requestPath}"
                    );
                }
                catch
                {
                    // Silently fail
                }
            });

            throw;
        }
    }

    private bool ShouldExclude(PathString path)
    {
        return _excludedEndpoints.Any(excluded => 
            path.StartsWithSegments(excluded, StringComparison.OrdinalIgnoreCase));
    }

    private EventType MapHttpMethodToEventType(string method)
    {
        return method.ToUpper() switch
        {
            "GET" => EventType.DataViewed,
            "POST" => EventType.DataCreated,
            "PUT" => EventType.DataUpdated,
            "PATCH" => EventType.DataUpdated,
            "DELETE" => EventType.DataDeleted,
            _ => EventType.CustomEvent
        };
    }

    private ActionType MapHttpMethodToActionType(string method)
    {
        return method.ToUpper() switch
        {
            "GET" => ActionType.Read,
            "POST" => ActionType.Write,
            "PUT" => ActionType.Write,
            "PATCH" => ActionType.Write,
            "DELETE" => ActionType.Delete,
            _ => ActionType.Execute
        };
    }
}
