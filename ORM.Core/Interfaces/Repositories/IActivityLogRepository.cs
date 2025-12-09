using ORM.Core.DTOs.ActivityLog;
using ORM.Core.DTOs.Common;

namespace ORM.Core.Interfaces.Repositories;

public interface IActivityLogRepository
{
    Task<long> CreateAsync(Domain.Entities.ActivityLog log);
    Task<Domain.Entities.ActivityLog?> GetByIdAsync(long id);
    Task<(List<Domain.Entities.ActivityLog> logs, int totalCount)> GetFilteredAsync(ActivityLogFilterDto filter);
    Task<List<Domain.Entities.ActivityLog>> GetByCorrelationIdAsync(Guid correlationId);
    Task<List<Domain.Entities.ActivityLog>> GetByTenantIdAsync(string tenantId, int pageNumber, int pageSize);
    Task<List<Domain.Entities.ActivityLog>> GetRecentFailuresAsync(string? tenantId, int count);
    Task<ActivityLogStatisticsDto> GetStatisticsAsync(string? tenantId, DateTime? fromDate, DateTime? toDate);
    Task<int> BulkCreateAsync(List<Domain.Entities.ActivityLog> logs);
}
