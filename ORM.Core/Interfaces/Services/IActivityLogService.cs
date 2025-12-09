using ORM.Core.DTOs.ActivityLog;
using ORM.Core.DTOs.Common;

namespace ORM.Core.Interfaces.Services;

public interface IActivityLogService
{
    Task LogActivityAsync(
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
        int? sourceModuleId = null);
    
    Task<long> LogActivityAsync(CreateActivityLogDto dto);
    
    Task LogAuthenticationAsync(EventType eventType, bool isSuccess, string? failureReason = null);
    
    Task LogEntityCreatedAsync<T>(T entity, EventType eventType, int? sourceSystemId = null, int? sourceModuleId = null) where T : class;
    
    Task LogEntityUpdatedAsync<T>(T oldEntity, T newEntity, EventType eventType, int? sourceSystemId = null, int? sourceModuleId = null) where T : class;
    
    Task LogEntityDeletedAsync<T>(T entity, EventType eventType, int? sourceSystemId = null, int? sourceModuleId = null) where T : class;
    
    Task<long> LogExportAsync(string targetObject, int recordCount, int? sourceModuleId = null);
    Task<long> LogFailureAsync(EventType eventType, string failureReason, string? targetObject = null, int? sourceModuleId = null);

    // Query methods
    Task<ActivityLogDto?> GetByIdAsync(long id);
    Task<PaginatedResponse<ActivityLogDto>> GetFilteredAsync(ActivityLogFilterDto filter);
    Task<IEnumerable<ActivityLogDto>> GetByCorrelationIdAsync(Guid correlationId);
    Task<PaginatedResponse<ActivityLogDto>> GetAllAsync(ActivityLogFilterDto filter);
    Task<ActivityLogStatisticsDto> GetStatisticsAsync(string? tenantId, DateTime? fromDate, DateTime? toDate);
}
