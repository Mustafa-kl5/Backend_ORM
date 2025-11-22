using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RcmaTaskUserTemplate
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int? UserId { get; set; }

    public int TemplateId { get; set; }

    public string Reference { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? DepartmentId { get; set; }

    public int? ExternalUserId { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual GrcExternalUserAccess? ExternalUser { get; set; }

    public virtual RcmaTask Task { get; set; } = null!;

    public virtual RcmaTemplate Template { get; set; } = null!;

    public virtual GrcUser? User { get; set; }
}
