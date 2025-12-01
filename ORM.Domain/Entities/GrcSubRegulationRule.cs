using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcSubRegulationRule
{
    public int RuleId { get; set; }

    public int? SreSubRegulationId { get; set; }

    public int? FreFirstValueId { get; set; }

    public int? FreSecondValueId { get; set; }

    public int? SrrRuleId { get; set; }

    public int? RuleSeq { get; set; }

    public string? FCondition { get; set; }

    public decimal? FPercent { get; set; }

    public string? FVariable1 { get; set; }

    public string? FRelation { get; set; }

    public string? FVariable2 { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcFinancialRef? FreFirstValue { get; set; }

    public virtual GrcFinancialRef? FreSecondValue { get; set; }

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcSubRegulationRule> InverseSrrRule { get; set; } = new List<GrcSubRegulationRule>();

    public virtual GrcSubRegulation? SreSubRegulation { get; set; }

    public virtual GrcSubRegulationRule? SrrRule { get; set; }
}
