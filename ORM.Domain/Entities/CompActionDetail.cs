using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class CompActionDetail
{
    public int Id { get; set; }

    public int CustomerCallId { get; set; }

    public int StatusId { get; set; }

    public int LoggedByUserId { get; set; }

    public int? EscalatedUserId { get; set; }

    public int SequenceNumber { get; set; }

    public DateTime ActionDate { get; set; }

    public string ActionTaken { get; set; } = null!;

    public DateTime ExpectedResolvedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? AttachedFile { get; set; }

    public int? AssignUserId { get; set; }

    public int? DepartmentId { get; set; }

    public int? BranchId { get; set; }

    public DateTime? ExpectedRespondDate { get; set; }

    public virtual GrcUser? AssignUser { get; set; }

    public virtual GrcBranch? Branch { get; set; }

    public virtual CompCustomerCall CustomerCall { get; set; } = null!;

    public virtual GrcDepartment? Department { get; set; }

    public virtual GrcUser? EscalatedUser { get; set; }

    public virtual GrcUser LoggedByUser { get; set; } = null!;

    public virtual CompStatus Status { get; set; } = null!;
}
