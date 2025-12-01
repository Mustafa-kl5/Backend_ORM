using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcBreach
{
    public int BreachId { get; set; }

    public DateTime? BreachDate { get; set; }

    public int? CouCountryId { get; set; }

    public int? RegRegulationId { get; set; }

    public int? SreSubRegulationId { get; set; }

    public int? UseResolvedByUserId { get; set; }

    public int? SrrRuleId { get; set; }

    public int? RiskLevel { get; set; }

    public bool? Formula { get; set; }

    public string? FCondition { get; set; }

    public decimal? FPrecent { get; set; }

    public string? FVariable1 { get; set; }

    public string? FRelation { get; set; }

    public string? FVariable2 { get; set; }

    public decimal? FirstValueCode { get; set; }

    public decimal? FirstValue { get; set; }

    public decimal? SecondValueCode { get; set; }

    public decimal? SecondValue { get; set; }

    public DateTime? ResolutionDate { get; set; }

    public int? RegRepId { get; set; }

    public int? NonFinId { get; set; }

    public int? AfiIssueId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? CustomerCallId { get; set; }

    public int? WblowerId { get; set; }

    public bool Lvl3Escl { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcAuditFinding? AfiIssue { get; set; }

    public virtual GrcCountry? CouCountry { get; set; }

    public virtual CompCustomerCall? CustomerCall { get; set; }

    public virtual ICollection<GrcEscalationMonitor> GrcEscalationMonitors { get; set; } = new List<GrcEscalationMonitor>();

    public virtual GrcDataCollectionNonfinancial? NonFin { get; set; }

    public virtual GrcRegulation? RegRegulation { get; set; }

    public virtual GrcRegulatoryReportingTrack? RegRep { get; set; }

    public virtual GrcSubRegulation? SreSubRegulation { get; set; }

    public virtual GrcSubRegulationRule? SrrRule { get; set; }

    public virtual GrcUser? UseResolvedByUser { get; set; }

    public virtual WblowerCase? Wblower { get; set; }
}
