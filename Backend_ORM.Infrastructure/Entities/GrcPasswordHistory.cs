using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcPasswordHistory
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string HashedPassword { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public int? CreatedBy { get; set; }
}
