using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class ExtractRegulation
{
    public int Id { get; set; }

    public string CountryName { get; set; } = null!;

    public string IssuerName { get; set; } = null!;

    public string RegulationType { get; set; } = null!;

    public string RegulationDescription { get; set; } = null!;

    public string RegulationReference { get; set; } = null!;

    public DateTime? RegulationIssueDate { get; set; }

    public DateTime? RegulationEffectiveDate { get; set; }

    public string? RegulationSubjectOtherLang { get; set; }

    public string? RegulationReferenceOtherLang { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
