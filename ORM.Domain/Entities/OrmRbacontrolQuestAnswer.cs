using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmRbacontrolQuestAnswer
{
    public int Id { get; set; }

    public int? AccountId { get; set; }

    public int RiskControlId { get; set; }

    public int QuestionniareId { get; set; }

    public int AnswerId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual GrcAccount? Account { get; set; }

    public virtual OrmQuestionnaireAnswer Answer { get; set; } = null!;

    public virtual OrmQuestionnnaire Questionniare { get; set; } = null!;

    public virtual OrmProcessControlLink RiskControl { get; set; } = null!;
}
