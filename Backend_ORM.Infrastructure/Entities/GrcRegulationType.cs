using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRegulationType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcRegulation> GrcRegulations { get; set; } = new List<GrcRegulation>();

    public virtual ICollection<GrcStagingRegulation> GrcStagingRegulations { get; set; } = new List<GrcStagingRegulation>();

    public virtual ICollection<GrcStagingSubRegulation> GrcStagingSubRegulations { get; set; } = new List<GrcStagingSubRegulation>();

    public virtual ICollection<GrcSubRegulation> GrcSubRegulations { get; set; } = new List<GrcSubRegulation>();
}
