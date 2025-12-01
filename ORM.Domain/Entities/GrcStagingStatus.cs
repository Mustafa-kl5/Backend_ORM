using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcStagingStatus
{
    public int Id { get; set; }

    public int StatusCode { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcStagingRegulation> GrcStagingRegulations { get; set; } = new List<GrcStagingRegulation>();

    public virtual ICollection<GrcStagingSubRegulation> GrcStagingSubRegulations { get; set; } = new List<GrcStagingSubRegulation>();
}
