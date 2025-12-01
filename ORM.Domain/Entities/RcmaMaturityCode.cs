using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcmaMaturityCode
{
    public int Id { get; set; }

    public string? MaturityCode { get; set; }

    public string? Description { get; set; }

    public int? MaturityFrom { get; set; }

    public int? MaturityTo { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Color { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
