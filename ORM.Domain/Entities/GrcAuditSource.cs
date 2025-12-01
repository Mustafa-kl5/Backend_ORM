using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcAuditSource
{
    public int AuditSourceId { get; set; }

    public int CouCountryId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCountry CouCountry { get; set; } = null!;

    public virtual ICollection<GrcAuditReport> GrcAuditReports { get; set; } = new List<GrcAuditReport>();
}
