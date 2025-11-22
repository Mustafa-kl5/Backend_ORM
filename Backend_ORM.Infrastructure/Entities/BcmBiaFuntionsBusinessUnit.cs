using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmBiaFuntionsBusinessUnit
{
    public int Id { get; set; }

    public int FuntionId { get; set; }

    public int? DepartmentId { get; set; }

    public int? DivisionId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual BcmBiaFuntion Funtion { get; set; } = null!;

    public virtual GrcUser? User { get; set; }
}
