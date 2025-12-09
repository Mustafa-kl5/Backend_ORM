namespace ORM.Core.DTOs.ActivityLog;

public class SourceModuleDto
{
    public int SourceModuleId { get; set; }
    public int SourceSystemId { get; set; }
    public string SourceSystemName { get; set; } = null!;
    public string ModuleCode { get; set; } = null!;
    public string ModuleName { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
}

public class CreateSourceModuleDto
{
    public int SourceSystemId { get; set; }
    public string ModuleCode { get; set; } = null!;
    public string ModuleName { get; set; } = null!;
}

public class UpdateSourceModuleDto
{
    public string ModuleName { get; set; } = null!;
    public bool IsActive { get; set; }
}
