using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRegulationLanguage
{
    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public string Orientation { get; set; } = null!;

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcUser> GrcUsers { get; set; } = new List<GrcUser>();
}
