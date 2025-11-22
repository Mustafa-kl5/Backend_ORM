using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class IntegrationApiStatus
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string Status { get; set; } = null!;

    public string? ErrorCode { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<IntegrationApiMonitor> IntegrationApiMonitors { get; set; } = new List<IntegrationApiMonitor>();
}
