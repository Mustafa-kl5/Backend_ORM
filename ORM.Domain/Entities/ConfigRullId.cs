using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class ConfigRullId
{
    public int? Id { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
