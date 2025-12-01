using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcmaTask
{
    public int Id { get; set; }

    public string Reference { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Description { get; set; }

    public int Recursive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? ComplianceAnalysis { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<RcmaAssessmentElementHeader> RcmaAssessmentElementHeaders { get; set; } = new List<RcmaAssessmentElementHeader>();

    public virtual ICollection<RcmaCalendarTask> RcmaCalendarTasks { get; set; } = new List<RcmaCalendarTask>();

    public virtual ICollection<RcmaDepartmentTaskScore> RcmaDepartmentTaskScores { get; set; } = new List<RcmaDepartmentTaskScore>();

    public virtual ICollection<RcmaTaskUserTemplate> RcmaTaskUserTemplates { get; set; } = new List<RcmaTaskUserTemplate>();
}
