using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcSelfAssessmentQuestionnaire
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int? Type { get; set; }

    public virtual ICollection<GrcCollectionQuestionnaire> GrcCollectionQuestionnaires { get; set; } = new List<GrcCollectionQuestionnaire>();

    public virtual ICollection<GrcSaqanswer> GrcSaqanswers { get; set; } = new List<GrcSaqanswer>();
}
