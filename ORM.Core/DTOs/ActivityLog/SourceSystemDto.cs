namespace ORM.Core.DTOs.ActivityLog;

public class SourceSystemDto
{
    public int SourceSystemId { get; set; }
    public string SystemCode { get; set; } = null!;
    public string SystemName { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ModuleCount { get; set; }
}

public class CreateSourceSystemDto
{
    public string SystemCode { get; set; } = null!;
    public string SystemName { get; set; } = null!;
}

public class UpdateSourceSystemDto
{
    public string SystemName { get; set; } = null!;
    public bool IsActive { get; set; }
}
