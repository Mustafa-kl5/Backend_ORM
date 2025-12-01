using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmQuestionnaireAnswer
{
    public int Id { get; set; }

    public int QuestionnaireId { get; set; }

    public string Answer { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<OrmRbacontrolQuestAnswer> OrmRbacontrolQuestAnswers { get; set; } = new List<OrmRbacontrolQuestAnswer>();

    public virtual ICollection<OrmRcsaquestioniareAnswer> OrmRcsaquestioniareAnswers { get; set; } = new List<OrmRcsaquestioniareAnswer>();

    public virtual OrmQuestionnnaire Questionnaire { get; set; } = null!;
}
