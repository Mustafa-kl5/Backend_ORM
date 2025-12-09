using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ORM.Application.Common.Exceptions;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.DTOs.Common;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Domain.Entities;

namespace ORM.Application.Services;

public class ActivityLogService : IActivityLogService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICurrentUserService _currentUserService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISensitiveDataMaskingService _maskingService;

    public ActivityLogService(
        IServiceProvider serviceProvider,
        ICurrentUserService currentUserService,
        IHttpContextAccessor httpContextAccessor,
        ISensitiveDataMaskingService maskingService)
    {
        _serviceProvider = serviceProvider;
        _currentUserService = currentUserService;
        _httpContextAccessor = httpContextAccessor;
        _maskingService = maskingService;
    }

    public async Task<long> LogActivityAsync(CreateActivityLogDto dto)
    {
        // Use a new scope to get a separate DbContext instance
        using var scope = _serviceProvider.CreateScope();
        var activityLogRepository = scope.ServiceProvider.GetRequiredService<IActivityLogRepository>();
        
        var httpContext = _httpContextAccessor.HttpContext;
        
        var log = new ActivityLog
        {
            TenantId = dto.TenantId ?? _currentUserService.AccountId?.ToString(),
            Environment = dto.Environment ?? GetEnvironment(),
            SourceSystemId = dto.SourceSystemId,
            SourceModuleId = dto.SourceModuleId,
            EventType = dto.EventType.ToString(),
            ActionType = dto.ActionType.ToString(),
            UserId = dto.UserId ?? _currentUserService.UserId?.ToString(),
            UserName = dto.UserName ?? _currentUserService.UserLogin,
            IsSuccess = dto.IsSuccess ?? true,
            FailureReason = dto.FailureReason,
            TargetObject = dto.TargetObject,
            TargetObjectId = dto.TargetObjectId,
            OldValues = MaskIfNeeded(dto.OldValues),
            NewValues = MaskIfNeeded(dto.NewValues),
            SourceIp = httpContext?.Connection.RemoteIpAddress?.ToString(),
            ServerName = Environment.MachineName,
            DeviceInfo = httpContext?.Request.Headers["User-Agent"].ToString(),
            RequestId = httpContext?.TraceIdentifier,
            CorrelationId = dto.CorrelationId ?? GetOrGenerateCorrelationId(httpContext),
            AdditionalData = MaskIfNeeded(dto.AdditionalData)
        };

        return await activityLogRepository.CreateAsync(log);
    }

    public async Task LogActivityAsync(
        EventType eventType,
        ActionType actionType,
        bool isSuccess,
        string? failureReason = null,
        string? targetObject = null,
        string? targetObjectId = null,
        string? oldValues = null,
        string? newValues = null,
        string? additionalData = null,
        int? sourceSystemId = null,
        int? sourceModuleId = null)
    {
        try
        {
            var httpContext = _httpContextAccessor.HttpContext;
            
            var dto = new CreateActivityLogDto
            {
                TenantId = _currentUserService.AccountId?.ToString(),
                Environment = GetEnvironment(),
                SourceSystemId = sourceSystemId,
                SourceModuleId = sourceModuleId,
                EventType = eventType,
                ActionType = actionType,
                UserId = _currentUserService.UserId?.ToString(),
                UserName = _currentUserService.UserLogin,
                IsSuccess = isSuccess,
                FailureReason = failureReason,
                TargetObject = targetObject,
                TargetObjectId = targetObjectId,
                OldValues = oldValues,
                NewValues = newValues,
                AdditionalData = additionalData,
                CorrelationId = GetOrGenerateCorrelationId(httpContext)
            };

            await LogActivityAsync(dto);
        }
        catch
        {
            // Silently fail to prevent breaking business operations
        }
    }

    public async Task LogAuthenticationAsync(EventType eventType, bool isSuccess, string? failureReason = null)
    {
        await LogActivityAsync(
            eventType,
            ActionType.Authentication,
            isSuccess,
            failureReason,
            "Authentication",
            null,
            null,
            null,
            null);
    }

    public async Task LogEntityCreatedAsync<T>(T entity, EventType eventType, int? sourceSystemId = null, int? sourceModuleId = null) where T : class
    {
        var entityName = typeof(T).Name;
        var newValues = SerializeEntityWithoutNavigationProperties(entity);

        await LogActivityAsync(
            eventType,
            ActionType.Write,
            true,
            null,
            entityName,
            GetEntityId(entity),
            null,
            newValues,
            null,
            sourceSystemId,
            sourceModuleId);
    }

    public async Task LogEntityUpdatedAsync<T>(T oldEntity, T newEntity, EventType eventType, int? sourceSystemId = null, int? sourceModuleId = null) where T : class
    {
        var entityName = typeof(T).Name;
        var oldValues = SerializeEntityWithoutNavigationProperties(oldEntity);
        var newValues = SerializeEntityWithoutNavigationProperties(newEntity);

        await LogActivityAsync(
            eventType,
            ActionType.Write,
            true,
            null,
            entityName,
            GetEntityId(newEntity),
            oldValues,
            newValues,
            null,
            sourceSystemId,
            sourceModuleId);
    }

    public async Task LogEntityDeletedAsync<T>(T entity, EventType eventType, int? sourceSystemId = null, int? sourceModuleId = null) where T : class
    {
        var entityName = typeof(T).Name;
        var oldValues = SerializeEntityWithoutNavigationProperties(entity);

        await LogActivityAsync(
            eventType,
            ActionType.Delete,
            true,
            null,
            entityName,
            GetEntityId(entity),
            oldValues,
            null,
            null,
            sourceSystemId,
            sourceModuleId);
    }

    public async Task<long> LogExportAsync(string targetObject, int recordCount, int? sourceModuleId = null)
    {
        var dto = new CreateActivityLogDto
        {
            EventType = Core.DTOs.ActivityLog.EventType.DataExported,
            ActionType = Core.DTOs.ActivityLog.ActionType.Export,
            TargetObject = targetObject,
            SourceModuleId = sourceModuleId,
            AdditionalData = JsonSerializer.Serialize(new { RecordCount = recordCount }),
            IsSuccess = true
        };

        return await LogActivityAsync(dto);
    }

    public async Task<long> LogFailureAsync(Core.DTOs.ActivityLog.EventType eventType, string failureReason, string? targetObject = null, int? sourceModuleId = null)
    {
        var dto = new CreateActivityLogDto
        {
            EventType = eventType,
            ActionType = Core.DTOs.ActivityLog.ActionType.Execute,
            TargetObject = targetObject,
            SourceModuleId = sourceModuleId,
            IsSuccess = false,
            FailureReason = failureReason
        };

        return await LogActivityAsync(dto);
    }

    public async Task<ActivityLogDto?> GetByIdAsync(long id)
    {
        using var scope = _serviceProvider.CreateScope();
        var activityLogRepository = scope.ServiceProvider.GetRequiredService<IActivityLogRepository>();
        
        var log = await activityLogRepository.GetByIdAsync(id);
        return log != null ? MapToDto(log) : null;
    }

    public async Task<PaginatedResponse<ActivityLogDto>> GetFilteredAsync(ActivityLogFilterDto filter)
    {
        using var scope = _serviceProvider.CreateScope();
        var activityLogRepository = scope.ServiceProvider.GetRequiredService<IActivityLogRepository>();
        
        var (logs, totalCount) = await activityLogRepository.GetFilteredAsync(filter);
        
        var logDtos = logs.Select(MapToDto).ToList();
        
        var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);
        
        return new PaginatedResponse<ActivityLogDto>
        {
            Success = true,
            StatusCode = 200,
            Message = "Activity logs retrieved successfully",
            Data = logDtos,
            Pagination = new PaginationMeta
            {
                CurrentPage = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalPages = totalPages,
                TotalCount = totalCount,
                HasNext = filter.PageNumber < totalPages,
                HasPrevious = filter.PageNumber > 1
            },
            Errors = new List<string>(),
            Timestamp = DateTime.UtcNow
        };
    }

    public async Task<IEnumerable<ActivityLogDto>> GetByCorrelationIdAsync(Guid correlationId)
    {
        using var scope = _serviceProvider.CreateScope();
        var activityLogRepository = scope.ServiceProvider.GetRequiredService<IActivityLogRepository>();
        
        var logs = await activityLogRepository.GetByCorrelationIdAsync(correlationId);
        return logs.Select(MapToDto).ToList();
    }

    public async Task<PaginatedResponse<ActivityLogDto>> GetAllAsync(ActivityLogFilterDto filter)
    {
        return await GetFilteredAsync(filter);
    }

    public async Task<ActivityLogStatisticsDto> GetStatisticsAsync(string? tenantId, DateTime? fromDate, DateTime? toDate)
    {
        using var scope = _serviceProvider.CreateScope();
        var activityLogRepository = scope.ServiceProvider.GetRequiredService<IActivityLogRepository>();
        
        return await activityLogRepository.GetStatisticsAsync(tenantId, fromDate, toDate);
    }

    private ActivityLogDto MapToDto(ActivityLog log)
    {
        return new ActivityLogDto
        {
            ActivityLogId = log.ActivityLogId,
            TenantId = log.TenantId,
            Environment = log.Environment,
            SourceSystemId = log.SourceSystemId,
            SourceSystemName = log.SourceSystem?.SystemName,
            SourceModuleId = log.SourceModuleId,
            SourceModuleName = log.SourceModule?.ModuleName,
            EventType = log.EventType,
            ActionType = log.ActionType,
            UserId = log.UserId,
            UserName = log.UserName,
            IsSuccess = log.IsSuccess,
            FailureReason = log.FailureReason,
            TargetObject = log.TargetObject,
            TargetObjectId = log.TargetObjectId,
            OldValues = log.OldValues,
            NewValues = log.NewValues,
            TimestampUtc = log.TimestampUtc,
            ServerName = log.ServerName,
            SourceIp = log.SourceIp,
            DeviceInfo = log.DeviceInfo,
            CorrelationId = log.CorrelationId,
            RequestId = log.RequestId,
            AdditionalData = log.AdditionalData
        };
    }

    private string? SerializeObject(object? obj)
    {
        if (obj == null) return null;
        return JsonSerializer.Serialize(obj);
    }

    private string? MaskIfNeeded(string? json)
    {
        if (string.IsNullOrEmpty(json)) return json;
        return _maskingService.MaskSensitiveData(json);
    }

    private string GetEnvironment()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
    }

    private async Task<CreateActivityLogDto> BuildActivityLogDtoAsync(
        EventType eventType,
        ActionType actionType,
        bool isSuccess,
        string? failureReason = null,
        string? targetObject = null,
        string? targetObjectId = null,
        string? oldValues = null,
        string? newValues = null,
        string? additionalData = null,
        int? sourceSystemId = null,
        int? sourceModuleId = null)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        
        return new CreateActivityLogDto
        {
            TenantId = _currentUserService.AccountId?.ToString(),
            Environment = GetEnvironment(),
            SourceSystemId = sourceSystemId,
            SourceModuleId = sourceModuleId,
            EventType = eventType,
            ActionType = actionType,
            UserId = _currentUserService.UserId?.ToString(),
            UserName = _currentUserService.UserLogin,
            IsSuccess = isSuccess,
            FailureReason = failureReason,
            TargetObject = targetObject,
            TargetObjectId = targetObjectId,
            OldValues = MaskIfNeeded(oldValues),
            NewValues = MaskIfNeeded(newValues),
            AdditionalData = MaskIfNeeded(additionalData),
            CorrelationId = GetOrGenerateCorrelationId(httpContext)
        };
    }

    private string? GetEntityId<T>(T entity) where T : class
    {
        try
        {
            // Use EF Core's metadata to find the primary key directly via reflection
            using var scope = _serviceProvider.CreateScope();
            
            // Get DbContext dynamically without direct reference
            var dbContextType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.Name == "ORMContext");
            
            if (dbContextType != null)
            {
                var context = scope.ServiceProvider.GetService(dbContextType);
                if (context != null)
                {
                    // Get Model property
                    var modelProperty = dbContextType.GetProperty("Model");
                    var model = modelProperty?.GetValue(context);
                    
                    if (model != null)
                    {
                        // Find entity type
                        var findEntityTypeMethod = model.GetType().GetMethod("FindEntityType", new[] { typeof(Type) });
                        var entityType = findEntityTypeMethod?.Invoke(model, new object[] { typeof(T) });
                        
                        if (entityType != null)
                        {
                            // Get primary key
                            var findPrimaryKeyMethod = entityType.GetType().GetMethod("FindPrimaryKey");
                            var primaryKey = findPrimaryKeyMethod?.Invoke(entityType, null);
                            
                            if (primaryKey != null)
                            {
                                // Get properties
                                var propertiesProperty = primaryKey.GetType().GetProperty("Properties");
                                var properties = propertiesProperty?.GetValue(primaryKey) as System.Collections.IEnumerable;
                                
                                if (properties != null)
                                {
                                    var firstProperty = properties.Cast<object>().FirstOrDefault();
                                    if (firstProperty != null)
                                    {
                                        var nameProperty = firstProperty.GetType().GetProperty("Name");
                                        var pkName = nameProperty?.GetValue(firstProperty)?.ToString();
                                        
                                        if (!string.IsNullOrEmpty(pkName))
                                        {
                                            var propertyInfo = typeof(T).GetProperty(pkName);
                                            if (propertyInfo != null)
                                            {
                                                return propertyInfo.GetValue(entity)?.ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            // If EF metadata lookup fails, fall back to convention-based approach
        }
        
        // Fallback: Try multiple property name patterns to find the primary key
        var type = typeof(T);
        
        // 1. Check for [Key] attribute (most reliable for EF entities)
        var idProperty = type.GetProperties()
            .FirstOrDefault(p => p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), true).Any());
        
        // 2. Try exact "Id" property
        if (idProperty == null)
        {
            idProperty = type.GetProperty("Id");
        }
        
        // 3. Try "{TypeName}Id" pattern (e.g., GrcCalendarHolidayId for GrcCalendarHoliday)
        if (idProperty == null)
        {
            idProperty = type.GetProperty($"{type.Name}Id");
        }
        
        // 4. Try removing "Grc" prefix and looking for pattern (e.g., HolidayId for GrcCalendarHoliday)
        if (idProperty == null && type.Name.StartsWith("Grc"))
        {
            var nameWithoutPrefix = type.Name.Substring(3); // Remove "Grc"
            idProperty = type.GetProperty($"{nameWithoutPrefix}Id");
        }
        
        // 5. As last resort, find first non-nullable integer property ending with "Id" 
        // (primary keys are usually non-nullable, foreign keys often nullable)
        if (idProperty == null)
        {
            idProperty = type.GetProperties()
                .FirstOrDefault(p => 
                    p.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase) && 
                    (p.PropertyType == typeof(int) || p.PropertyType == typeof(long)));
        }
        
        return idProperty?.GetValue(entity)?.ToString();
    }

    private Guid GetOrGenerateCorrelationId(HttpContext? httpContext)
    {
        // First priority: Get from HttpContext.Items (set by middleware)
        if (httpContext?.Items?.ContainsKey("CorrelationId") == true)
        {
            return (Guid)httpContext.Items["CorrelationId"];
        }
        
        // Fallback: Generate new if middleware didn't run (background jobs, tests, etc.)
        var newGuid = Guid.NewGuid();
        
        // Store it for subsequent calls in the same request
        if (httpContext?.Items != null)
        {
            httpContext.Items["CorrelationId"] = newGuid;
        }
        
        return newGuid;
    }

    private JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            MaxDepth = 2, // Limit depth to avoid circular references and large payloads
            WriteIndented = false
        };
    }

    private string? SerializeEntityWithoutNavigationProperties<T>(T entity) where T : class
    {
        if (entity == null) return null;

        try
        {
            // Create an anonymous object with only scalar properties
            var entityType = entity.GetType();
            var scalarProperties = entityType.GetProperties()
                .Where(p => p.CanRead &&
                           !p.PropertyType.IsClass || 
                           p.PropertyType == typeof(string) || 
                           p.PropertyType == typeof(DateTime) ||
                           p.PropertyType == typeof(DateTime?) ||
                           p.PropertyType == typeof(Guid) ||
                           p.PropertyType == typeof(Guid?))
                .Where(p => !typeof(System.Collections.IEnumerable).IsAssignableFrom(p.PropertyType) || p.PropertyType == typeof(string))
                .ToDictionary(
                    p => p.Name,
                    p => p.GetValue(entity)
                );

            return JsonSerializer.Serialize(scalarProperties, GetJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            // If serialization fails, return a safe fallback
            return $"{{\"SerializationError\": \"{ex.Message}\"}}";
        }
    }
}
