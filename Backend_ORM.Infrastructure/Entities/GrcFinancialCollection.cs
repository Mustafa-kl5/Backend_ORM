using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcFinancialCollection
{
    public int Id { get; set; }

    public DateTime FinancialDate { get; set; }

    public int FreValueId { get; set; }

    public int CouCountryId { get; set; }

    public long? Value { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCountry CouCountry { get; set; } = null!;

    public virtual GrcFinancialRef FreValue { get; set; } = null!;
}
