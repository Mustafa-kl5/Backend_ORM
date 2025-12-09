namespace ORM.Core.DTOs.ActivityLog;

public class ActivityLogStatisticsDto
{
    public int TotalActivities { get; set; }
    public int SuccessfulActivities { get; set; }
    public int FailedActivities { get; set; }
    public double SuccessRate { get; set; }
    public Dictionary<string, int> ActivitiesByEventType { get; set; } = new();
    public Dictionary<string, int> ActivitiesByModule { get; set; } = new();
    public Dictionary<string, int> ActivitiesByUser { get; set; } = new();
    public List<TopUserActivityDto> TopActiveUsers { get; set; } = new();
    public List<RecentFailureDto> RecentFailures { get; set; } = new();
}

public class TopUserActivityDto
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public int ActivityCount { get; set; }
}

public class RecentFailureDto
{
    public long ActivityLogId { get; set; }
    public string EventType { get; set; } = null!;
    public string? UserName { get; set; }
    public string? FailureReason { get; set; }
    public DateTime TimestampUtc { get; set; }
}
