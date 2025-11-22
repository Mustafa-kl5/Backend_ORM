using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcWhistleblowerProcess
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int Code { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<WblowerCaseResolution> WblowerCaseResolutions { get; set; } = new List<WblowerCaseResolution>();
}
