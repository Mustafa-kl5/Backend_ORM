using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmuserManagementLog
{
    public int Id { get; set; }

    public int ActivityLogId { get; set; }

    public string? UserNameOld { get; set; }

    public string? UserNameNew { get; set; }

    public string? DeparmentNameOld { get; set; }

    public string? DeparmentNameNew { get; set; }

    public string? BranchNameOld { get; set; }

    public string? BranchNameNew { get; set; }

    public string? JobTitleOld { get; set; }

    public string? JobTitleNew { get; set; }

    public bool? DefaultActionUserOld { get; set; }

    public bool? DefaultActionUserNew { get; set; }

    public bool? EscalationActionApprovalOld { get; set; }

    public bool? EscalationActionApprovalNew { get; set; }

    public string? RoleNameOld { get; set; }

    public string? RoleNameNew { get; set; }

    public string? AuthorityOld { get; set; }

    public string? AuthorityNew { get; set; }

    public int AccountId { get; set; }

    public string? DivisionNameOld { get; set; }

    public string? DivisionNameNew { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmuserActivitiesLog ActivityLog { get; set; } = null!;
}
