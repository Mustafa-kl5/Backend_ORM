using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcmaPrinciple
{
    public int Id { get; set; }

    public int PrincipleTypeId { get; set; }

    public string Reference { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastIpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual RcmaPrincipleType PrincipleType { get; set; } = null!;

    public virtual ICollection<RcmaElement> RcmaElements { get; set; } = new List<RcmaElement>();
}
