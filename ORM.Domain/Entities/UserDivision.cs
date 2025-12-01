using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class UserDivision
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int UserId { get; set; }

    public int DivisionId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual Division Division { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
