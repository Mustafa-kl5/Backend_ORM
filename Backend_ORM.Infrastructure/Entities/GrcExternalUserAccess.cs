using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcExternalUserAccess
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual ICollection<RcamAdvisoryRequest> RcamAdvisoryRequests { get; set; } = new List<RcamAdvisoryRequest>();

    public virtual ICollection<RcmaAssessmentElementHeader> RcmaAssessmentElementHeaders { get; set; } = new List<RcmaAssessmentElementHeader>();

    public virtual ICollection<RcmaTaskUserTemplate> RcmaTaskUserTemplates { get; set; } = new List<RcmaTaskUserTemplate>();
}
