using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcCrimeSituation
{
    public int Id { get; set; }

    public string Reference { get; set; } = null!;

    public int InitiatedBy { get; set; }

    public int CrimeNatureId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime DiscoveryDate { get; set; }

    public string? SubjectMaterPersone { get; set; }

    public bool? Reported { get; set; }

    public string? ResonForNotReporting { get; set; }

    public int? EmployeeInChargeId { get; set; }

    public string? CompAssessmentReview { get; set; }

    public string? CorrectiveAction { get; set; }

    public string? CommissionDetails { get; set; }

    public string? Conclusions { get; set; }

    public int CreationBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Obligation { get; set; }

    public DateTime? DatetheCrimeOccurred { get; set; }

    public string? DetectiveName { get; set; }

    public int? CrimeStatusId { get; set; }

    public string? CommitteeSummary { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCrimeNature CrimeNature { get; set; } = null!;

    public virtual GrcCrimeStatus? CrimeStatus { get; set; }

    public virtual GrcUser? EmployeeInCharge { get; set; }

    public virtual ICollection<GrcCrimeBusinessunit> GrcCrimeBusinessunits { get; set; } = new List<GrcCrimeBusinessunit>();

    public virtual GrcUser InitiatedByNavigation { get; set; } = null!;
}
