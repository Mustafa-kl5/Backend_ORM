using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcIntegrationEntity
{
    public int Id { get; set; }

    public int EntityId { get; set; }

    public int IntegrationTypeId { get; set; }

    public int IntegrationServiceId { get; set; }

    public string? Smsmessage { get; set; }

    public string? IntegrationEntityServiceId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcEntity Entity { get; set; } = null!;

    public virtual ICollection<GrcIntegrationMonitor> GrcIntegrationMonitors { get; set; } = new List<GrcIntegrationMonitor>();

    public virtual GrcIntegrationService IntegrationService { get; set; } = null!;

    public virtual GrcIntegrationType IntegrationType { get; set; } = null!;
}
