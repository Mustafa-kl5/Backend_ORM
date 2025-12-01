using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class ExtractSubRegulation
{
    public int Id { get; set; }

    public string RegReference { get; set; } = null!;

    public string? SubRegulationDescription { get; set; }

    public string? SubRegulationReference { get; set; }

    public int? Formula { get; set; }

    public string? Occure { get; set; }

    public int? Day { get; set; }

    public int? Month { get; set; }

    public DateTime? IssueDate { get; set; }

    public string? RegulationType { get; set; }

    public string? SubOtherLang { get; set; }

    public string? ReferenceOtherLang { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
