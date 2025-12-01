using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcFinancialRef
{
    public int ValueId { get; set; }

    public string Name { get; set; } = null!;

    public bool? Level2Flag { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Code { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcFinancialCollection> GrcFinancialCollections { get; set; } = new List<GrcFinancialCollection>();

    public virtual ICollection<GrcFinancialRefLevelLink> GrcFinancialRefLevelLinks { get; set; } = new List<GrcFinancialRefLevelLink>();

    public virtual ICollection<GrcFinancialRefReg> GrcFinancialRefRegs { get; set; } = new List<GrcFinancialRefReg>();

    public virtual ICollection<GrcSubRegulationRule> GrcSubRegulationRuleFreFirstValues { get; set; } = new List<GrcSubRegulationRule>();

    public virtual ICollection<GrcSubRegulationRule> GrcSubRegulationRuleFreSecondValues { get; set; } = new List<GrcSubRegulationRule>();
}
