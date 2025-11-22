using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class ArchGrcUserManagementLog
{
    public int Id { get; set; }

    public string? ActivityUserName { get; set; }

    public string? ActivityBusiness { get; set; }

    public string? UserNameOld { get; set; }

    public string? UserNameNew { get; set; }

    public string? BranchNameOld { get; set; }

    public string? BranchNameNew { get; set; }

    public string? JobTitleOld { get; set; }

    public string? JobTitleNew { get; set; }

    public string? DepartmentNameOld { get; set; }

    public string? DepartmentNameNew { get; set; }

    public bool? AddRegFlagOld { get; set; }

    public bool? AddRegFlagNew { get; set; }

    public bool? BreachManagementFlagOld { get; set; }

    public bool? BreachManagementFlagNew { get; set; }

    public bool? DefaultActionUserOld { get; set; }

    public bool? DefaultActionUserNew { get; set; }

    public bool? EscalationActionApprovalOld { get; set; }

    public bool? EscalationActionApprovalNew { get; set; }

    public bool? WhistleManagementFlagOld { get; set; }

    public bool? WhistleManagementFlagNew { get; set; }

    public bool? WhistleManagementActionFlagOld { get; set; }

    public bool? WhistleManagementActionFlagNew { get; set; }

    public bool? ApproveStagingRegOld { get; set; }

    public bool? ApproveStagingRegNew { get; set; }

    public string? RoleNameOld { get; set; }

    public string? RoleNameNew { get; set; }

    public bool? MaturityAssessmentFlagOld { get; set; }

    public bool? MaturityAssessmentFlagNew { get; set; }

    public bool? CbChangeRequestAdminFlagOld { get; set; }

    public bool? CbChangeRequestAdminFlagnew { get; set; }

    public bool? AdminAccessOld { get; set; }

    public bool? AdminAccessNew { get; set; }

    public bool? AdvisoryFlagOld { get; set; }

    public bool? AdvisoryFlagNew { get; set; }
}
