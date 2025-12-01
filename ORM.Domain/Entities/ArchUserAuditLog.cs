using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class ArchUserAuditLog
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? SessionId { get; set; }

    public DateTime? LogInDate { get; set; }
}
