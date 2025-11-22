using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcUserActivitiesLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Activity { get; set; } = null!;

    public string BusinessName { get; set; } = null!;

    public string ReferenceName { get; set; } = null!;

    public DateTime ActivityDatetime { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcUserManagementLog> GrcUserManagementLogs { get; set; } = new List<GrcUserManagementLog>();

    public virtual GrcUser User { get; set; } = null!;
}
