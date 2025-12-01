using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmRcsaquestioniareAnswer
{
    public int Id { get; set; }

    public int? TaskId { get; set; }

    public int QuestionId { get; set; }

    public int? AnswerId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int? DueTaskRiskControlId { get; set; }

    public virtual OrmQuestionnaireAnswer? Answer { get; set; }

    public virtual OrmRcsaDueTaskRiskControl? DueTaskRiskControl { get; set; }

    public virtual OrmQuestionnnaire Question { get; set; } = null!;

    public virtual OrmRcsaTask? Task { get; set; }
}
