using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class WblowerCaseResolution
{
    public int Id { get; set; }

    public int WblowerCaseId { get; set; }

    public int? SubRegulationId { get; set; }

    public string? Recommendation { get; set; }

    public bool IsBreach { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ProcessId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcWhistleblowerProcess? Process { get; set; }

    public virtual GrcSubRegulation? SubRegulation { get; set; }

    public virtual WblowerCase WblowerCase { get; set; } = null!;
}
