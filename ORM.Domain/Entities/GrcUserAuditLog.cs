using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcUserAuditLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string SessionId { get; set; } = null!;

    public DateTime LogDateTime { get; set; }

    public bool? IsActive { get; set; }

    public string? LogInId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
