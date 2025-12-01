using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmPlanRecoveryTeam
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanId { get; set; }

    public int RoleId { get; set; }

    public int ResponsibilityId { get; set; }

    public int TitleId { get; set; }

    public int? DepartmentId { get; set; }

    public int? BranchId { get; set; }

    public int? DivisionId { get; set; }

    public int UserId { get; set; }

    public string Mobile { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaPlan BiaPlan { get; set; } = null!;

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual BcmBusinessResponsibility Responsibility { get; set; } = null!;

    public virtual BcmBusinessRole Role { get; set; } = null!;

    public virtual BcmBusinessTitle Title { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
