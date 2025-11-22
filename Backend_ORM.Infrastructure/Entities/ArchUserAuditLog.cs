using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class ArchUserAuditLog
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? SessionId { get; set; }

    public DateTime? LogInDate { get; set; }
}
