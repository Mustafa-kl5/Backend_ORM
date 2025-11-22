using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRegulationLink
{
    public int Id { get; set; }

    public int RegulationId { get; set; }

    public int LinkRegulationId { get; set; }

    public string Comments { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcRegulation LinkRegulation { get; set; } = null!;

    public virtual GrcRegulation Regulation { get; set; } = null!;
}
