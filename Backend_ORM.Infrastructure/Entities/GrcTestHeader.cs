using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcTestHeader
{
    public int TestHeaderId { get; set; }

    public int CouCountryId { get; set; }

    public int DepDepartmentId { get; set; }

    public string TestReference { get; set; } = null!;

    public DateTime? TestDate { get; set; }

    public string? OfficerName { get; set; }

    public DateTime? IssueDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public bool AdhocSelfAssessment { get; set; }

    public int? RegulationId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCountry CouCountry { get; set; } = null!;

    public virtual GrcDepartment DepDepartment { get; set; } = null!;

    public virtual ICollection<GrcAuditReport> GrcAuditReports { get; set; } = new List<GrcAuditReport>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancials { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcTestDetail> GrcTestDetails { get; set; } = new List<GrcTestDetail>();

    public virtual Product? Product { get; set; }

    public virtual GrcRegulation? Regulation { get; set; }

    public virtual GrcUser? User { get; set; }
}
