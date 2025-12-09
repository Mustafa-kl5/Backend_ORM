using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class SourceModule
{
    public int SourceModuleId { get; set; }

    public int SourceSystemId { get; set; }

    public string ModuleCode { get; set; } = null!;

    public string ModuleName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual SourceSystem SourceSystem { get; set; } = null!;
}
