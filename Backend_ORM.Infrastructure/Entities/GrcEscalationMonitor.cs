using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcEscalationMonitor
{
    public int EscalationId { get; set; }

    public int? BreBreachId { get; set; }

    public int? UseCompletedBy { get; set; }

    public int? PriPriorityId { get; set; }

    public string? EscalationRef { get; set; }

    public DateTime? EscalationDate { get; set; }

    public string? Comments { get; set; }

    public DateTime? ResolvedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public bool? CeoEscalationFlag { get; set; }

    public string? BreachDescription { get; set; }

    public int? EstStatusId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBreach? BreBreach { get; set; }

    public virtual GrcEscalationStatus? EstStatus { get; set; }

    public virtual ICollection<GrcEscalationAction> GrcEscalationActions { get; set; } = new List<GrcEscalationAction>();

    public virtual GrcPriority? PriPriority { get; set; }

    public virtual GrcUser? UseCompletedByNavigation { get; set; }
}
