using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class WblowerCaseAction
{
    public int Id { get; set; }

    public int WblowerCaseId { get; set; }

    public int LoggedUserId { get; set; }

    public int? DepartmentId { get; set; }

    public int? AssignUserId { get; set; }

    public int? EscalatedUserId { get; set; }

    public int? BranchId { get; set; }

    public int SequenceNumber { get; set; }

    public DateTime ActionDate { get; set; }

    public string ActionTaken { get; set; } = null!;

    public DateTime ExpectedResolvedDate { get; set; }

    public string? AttschedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcUser? AssignUser { get; set; }

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual GrcUser? EscalatedUser { get; set; }

    public virtual GrcUser LoggedUser { get; set; } = null!;

    public virtual WblowerCase WblowerCase { get; set; } = null!;
}
