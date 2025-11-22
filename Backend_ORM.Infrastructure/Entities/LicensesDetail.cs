using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class LicensesDetail
{
    public int Id { get; set; }

    public int InstallId { get; set; }

    public DateTime Installationdate { get; set; }

    public string? Version { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual License Install { get; set; } = null!;
}
