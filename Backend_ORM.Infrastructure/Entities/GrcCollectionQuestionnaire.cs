using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcCollectionQuestionnaire
{
    public int Id { get; set; }

    public int QuestionnaireId { get; set; }

    public int DataCollectionId { get; set; }

    public string? Answer { get; set; }

    public int? AnswerdBy { get; set; }

    public string? Comments { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int? SaqanswerId { get; set; }

    public bool? TfSaqanswer { get; set; }

    public virtual GrcUser? AnswerdByNavigation { get; set; }

    public virtual GrcDataCollectionNonfinancial DataCollection { get; set; } = null!;

    public virtual GrcSelfAssessmentQuestionnaire Questionnaire { get; set; } = null!;

    public virtual GrcSaqanswer? Saqanswer { get; set; }
}
