using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class License
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Comment { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<LicensesDetail> LicensesDetails { get; set; } = new List<LicensesDetail>();
}
