using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcPriority
{
    public int PriorityId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<CompCustomerCall> CompCustomerCalls { get; set; } = new List<CompCustomerCall>();

    public virtual ICollection<GrcEscalationMonitor> GrcEscalationMonitors { get; set; } = new List<GrcEscalationMonitor>();
}
