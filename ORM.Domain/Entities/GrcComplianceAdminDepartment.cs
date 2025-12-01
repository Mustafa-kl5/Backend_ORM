using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcComplianceAdminDepartment
{
    public int Id { get; set; }

    public int? ComplianceUserId { get; set; }

    public int? DepartmentId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcUser? ComplianceUser { get; set; }

    public virtual GrcDepartment? Department { get; set; }
}
