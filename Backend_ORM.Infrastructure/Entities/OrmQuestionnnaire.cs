using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmQuestionnnaire
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Question { get; set; } = null!;

    public bool Active { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmQuestionnaireAnswer> OrmQuestionnaireAnswers { get; set; } = new List<OrmQuestionnaireAnswer>();

    public virtual ICollection<OrmRbacontrolQuestAnswer> OrmRbacontrolQuestAnswers { get; set; } = new List<OrmRbacontrolQuestAnswer>();

    public virtual ICollection<OrmRcsaquestioniareAnswer> OrmRcsaquestioniareAnswers { get; set; } = new List<OrmRcsaquestioniareAnswer>();
}
