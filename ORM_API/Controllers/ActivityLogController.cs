using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

[Authorize]
public class ActivityLogController : BaseController
{
    private readonly IActivityLogService _activityLogService;

    public ActivityLogController(IActivityLogService activityLogService)
    {
        _activityLogService = activityLogService;
    }

    /// <summary>
    /// Get activity log by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var log = await _activityLogService.GetByIdAsync(id);
        if (log == null)
            return NotFoundResponse("Activity log not found");

        return Success(log);
    }

    /// <summary>
    /// Get activity logs with filtering and pagination
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetFiltered([FromQuery] ActivityLogFilterDto filter)
    {
        var result = await _activityLogService.GetFilteredAsync(filter);
        return Ok(result);
    }

    /// <summary>
    /// Get all activity logs by correlation ID
    /// </summary>
    [HttpGet("correlation/{correlationId}")]
    public async Task<IActionResult> GetByCorrelationId(Guid correlationId)
    {
        var logs = await _activityLogService.GetByCorrelationIdAsync(correlationId);
        return Success(logs);
    }

    /// <summary>
    /// Get activity log statistics
    /// </summary>
    [HttpGet("statistics")]
    public async Task<IActionResult> GetStatistics(
        [FromQuery] string? tenantId,
        [FromQuery] DateTime? fromDate,
        [FromQuery] DateTime? toDate)
    {
        var statistics = await _activityLogService.GetStatisticsAsync(tenantId, fromDate, toDate);
        return Success(statistics);
    }

    /// <summary>
    /// Manually log an activity
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateActivityLogDto dto)
    {
        var logId = await _activityLogService.LogActivityAsync(dto);
        return Success(new { ActivityLogId = logId }, "Activity logged successfully");
    }

    /// <summary>
    /// Export activity logs (placeholder for export functionality)
    /// </summary>
    [HttpGet("export")]
    public async Task<IActionResult> Export([FromQuery] ActivityLogFilterDto filter)
    {
        var result = await _activityLogService.GetFilteredAsync(filter);
        
        // Log the export action
        await _activityLogService.LogExportAsync("ActivityLog", result.Pagination?.TotalCount ?? 0);
        
        // Return the data (in real implementation, this would be CSV/Excel)
        return Success(result.Data, "Activity logs exported successfully");
    }
}
