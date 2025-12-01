using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OldgrcFinancialCollection
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
}
