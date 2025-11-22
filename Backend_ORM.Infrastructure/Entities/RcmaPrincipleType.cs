using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RcmaPrincipleType
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<RcmaPrinciple> RcmaPrinciples { get; set; } = new List<RcmaPrinciple>();
}
