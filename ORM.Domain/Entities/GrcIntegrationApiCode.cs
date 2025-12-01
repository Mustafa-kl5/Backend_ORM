using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcIntegrationApiCode
{
    public int Id { get; set; }

    public int IntegrationTypeId { get; set; }

    public int StatusId { get; set; }

    public string? MsgCode { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcIntegrationMonitor> GrcIntegrationMonitors { get; set; } = new List<GrcIntegrationMonitor>();

    public virtual GrcIntegrationType IntegrationType { get; set; } = null!;

    public virtual GrcIntegrationStatus Status { get; set; } = null!;
}
