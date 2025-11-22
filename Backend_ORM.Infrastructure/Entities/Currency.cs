using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class Currency
{
    public int Id { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public bool? BaseCurrency { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<AuditLossImpact> AuditLossImpactBaseCurrencies { get; set; } = new List<AuditLossImpact>();

    public virtual ICollection<AuditLossImpact> AuditLossImpactCurrencyLossNavigations { get; set; } = new List<AuditLossImpact>();

    public virtual ICollection<AuditLossImpact> AuditLossImpactRecoveryCurrencyNavigations { get; set; } = new List<AuditLossImpact>();

    public virtual ICollection<CompRootCause> CompRootCauses { get; set; } = new List<CompRootCause>();

    public virtual ICollection<OrmKriEntry> OrmKriEntries { get; set; } = new List<OrmKriEntry>();

    public virtual ICollection<OrmKri> OrmKris { get; set; } = new List<OrmKri>();

    public virtual ICollection<OrmLossEvent> OrmLossEventCurrencyBases { get; set; } = new List<OrmLossEvent>();

    public virtual ICollection<OrmLossEvent> OrmLossEventCurrencyLosses { get; set; } = new List<OrmLossEvent>();

    public virtual ICollection<OrmLossEvent> OrmLossEventCurrencyRecoveries { get; set; } = new List<OrmLossEvent>();
}
