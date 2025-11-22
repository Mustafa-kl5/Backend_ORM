using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcIndustry
{
    public int Id { get; set; }

    public string Industry { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<GrcAccount> GrcAccounts { get; set; } = new List<GrcAccount>();
}
