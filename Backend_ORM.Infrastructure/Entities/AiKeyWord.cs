using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class AiKeyWord
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<AiCombinationDetail> AiCombinationDetails { get; set; } = new List<AiCombinationDetail>();
}
