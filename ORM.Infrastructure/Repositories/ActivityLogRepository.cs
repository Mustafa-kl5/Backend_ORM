using Microsoft.EntityFrameworkCore;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class ActivityLogRepository : IActivityLogRepository
{
    private readonly ORMContext _context;

    public ActivityLogRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<long> CreateAsync(ActivityLog log)
    {
        _context.ActivityLogs.Add(log);
        await _context.SaveChangesAsync();
        return log.ActivityLogId;
    }

    public async Task<ActivityLog?> GetByIdAsync(long id)
    {
        return await _context.ActivityLogs
            .AsNoTracking()
            .Include(a => a.SourceSystem)
            .Include(a => a.SourceModule)
            .FirstOrDefaultAsync(a => a.ActivityLogId == id);
    }

    public async Task<(List<ActivityLog> logs, int totalCount)> GetFilteredAsync(ActivityLogFilterDto filter)
    {
        var query = _context.ActivityLogs
            .AsNoTracking()
            .Include(a => a.SourceSystem)
            .Include(a => a.SourceModule)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(filter.TenantId))
            query = query.Where(a => a.TenantId == filter.TenantId);

        if (filter.SourceSystemId.HasValue)
            query = query.Where(a => a.SourceSystemId == filter.SourceSystemId.Value);

        if (filter.SourceModuleId.HasValue)
            query = query.Where(a => a.SourceModuleId == filter.SourceModuleId.Value);

        if (filter.EventType.HasValue)
            query = query.Where(a => a.EventType == filter.EventType.Value.ToString());

        if (filter.ActionType.HasValue)
            query = query.Where(a => a.ActionType == filter.ActionType.Value.ToString());

        if (!string.IsNullOrEmpty(filter.UserId))
            query = query.Where(a => a.UserId == filter.UserId);

        if (filter.IsSuccess.HasValue)
            query = query.Where(a => a.IsSuccess == filter.IsSuccess.Value);

        if (!string.IsNullOrEmpty(filter.TargetObject))
            query = query.Where(a => a.TargetObject == filter.TargetObject);

        if (!string.IsNullOrEmpty(filter.TargetObjectId))
            query = query.Where(a => a.TargetObjectId == filter.TargetObjectId);

        if (filter.FromDate.HasValue)
            query = query.Where(a => a.TimestampUtc >= filter.FromDate.Value);

        if (filter.ToDate.HasValue)
            query = query.Where(a => a.TimestampUtc <= filter.ToDate.Value);

        if (filter.CorrelationId.HasValue)
            query = query.Where(a => a.CorrelationId == filter.CorrelationId.Value);

        var totalCount = await query.CountAsync();

        var logs = await query
            .OrderByDescending(a => a.TimestampUtc)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return (logs, totalCount);
    }

    public async Task<List<ActivityLog>> GetByCorrelationIdAsync(Guid correlationId)
    {
        return await _context.ActivityLogs
            .AsNoTracking()
            .Include(a => a.SourceSystem)
            .Include(a => a.SourceModule)
            .Where(a => a.CorrelationId == correlationId)
            .OrderBy(a => a.TimestampUtc)
            .ToListAsync();
    }

    public async Task<List<ActivityLog>> GetByTenantIdAsync(string tenantId, int pageNumber, int pageSize)
    {
        return await _context.ActivityLogs
            .AsNoTracking()
            .Where(a => a.TenantId == tenantId)
            .OrderByDescending(a => a.TimestampUtc)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<ActivityLog>> GetRecentFailuresAsync(string? tenantId, int count)
    {
        var query = _context.ActivityLogs
            .AsNoTracking()
            .Where(a => a.IsSuccess == false);

        if (!string.IsNullOrEmpty(tenantId))
            query = query.Where(a => a.TenantId == tenantId);

        return await query
            .OrderByDescending(a => a.TimestampUtc)
            .Take(count)
            .ToListAsync();
    }

    public async Task<ActivityLogStatisticsDto> GetStatisticsAsync(string? tenantId, DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.ActivityLogs.AsNoTracking();

        if (!string.IsNullOrEmpty(tenantId))
            query = query.Where(a => a.TenantId == tenantId);

        if (fromDate.HasValue)
            query = query.Where(a => a.TimestampUtc >= fromDate.Value);

        if (toDate.HasValue)
            query = query.Where(a => a.TimestampUtc <= toDate.Value);

        var totalActivities = await query.CountAsync();
        var successfulActivities = await query.CountAsync(a => a.IsSuccess == true);
        var failedActivities = await query.CountAsync(a => a.IsSuccess == false);

        var activitiesByEventType = await query
            .GroupBy(a => a.EventType)
            .Select(g => new { EventType = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.EventType, x => x.Count);

        var activitiesByModule = await query
            .Where(a => a.SourceModule != null)
            .GroupBy(a => a.SourceModule!.ModuleName)
            .Select(g => new { ModuleName = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.ModuleName, x => x.Count);

        var activitiesByUser = await query
            .Where(a => a.UserName != null)
            .GroupBy(a => a.UserName!)
            .Select(g => new { UserName = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.UserName, x => x.Count);

        var topActiveUsers = await query
            .Where(a => a.UserId != null && a.UserName != null)
            .GroupBy(a => new { a.UserId, a.UserName })
            .Select(g => new TopUserActivityDto
            {
                UserId = g.Key.UserId,
                UserName = g.Key.UserName,
                ActivityCount = g.Count()
            })
            .OrderByDescending(x => x.ActivityCount)
            .Take(10)
            .ToListAsync();

        var recentFailures = await query
            .Where(a => a.IsSuccess == false)
            .OrderByDescending(a => a.TimestampUtc)
            .Take(10)
            .Select(a => new RecentFailureDto
            {
                ActivityLogId = a.ActivityLogId,
                EventType = a.EventType,
                UserName = a.UserName,
                FailureReason = a.FailureReason,
                TimestampUtc = a.TimestampUtc
            })
            .ToListAsync();

        return new ActivityLogStatisticsDto
        {
            TotalActivities = totalActivities,
            SuccessfulActivities = successfulActivities,
            FailedActivities = failedActivities,
            SuccessRate = totalActivities > 0 ? (double)successfulActivities / totalActivities * 100 : 0,
            ActivitiesByEventType = activitiesByEventType,
            ActivitiesByModule = activitiesByModule,
            ActivitiesByUser = activitiesByUser,
            TopActiveUsers = topActiveUsers,
            RecentFailures = recentFailures
        };
    }

    public async Task<int> BulkCreateAsync(List<ActivityLog> logs)
    {
        _context.ActivityLogs.AddRange(logs);
        return await _context.SaveChangesAsync();
    }
}
