using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class SourceSystem
{
    public int SourceSystemId { get; set; }

    public string SystemCode { get; set; } = null!;

    public string SystemName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<SourceModule> SourceModules { get; set; } = new List<SourceModule>();
}
