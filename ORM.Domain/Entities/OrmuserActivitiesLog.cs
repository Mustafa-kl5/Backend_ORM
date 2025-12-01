using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmuserActivitiesLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Activity { get; set; } = null!;

    public string BusinessName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime ActivityDatetime { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmuserManagementLog> OrmuserManagementLogs { get; set; } = new List<OrmuserManagementLog>();

    public virtual GrcUser User { get; set; } = null!;
}
