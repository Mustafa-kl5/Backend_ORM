using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcSaqanswer
{
    public int Id { get; set; }

    public int QuestionnaireId { get; set; }

    public string? Answers { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<GrcCollectionQuestionnaire> GrcCollectionQuestionnaires { get; set; } = new List<GrcCollectionQuestionnaire>();

    public virtual GrcSelfAssessmentQuestionnaire Questionnaire { get; set; } = null!;
}
