using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class AiCombinationDetail
{
    public int Id { get; set; }

    public int? CombinationId { get; set; }

    public int KeyWordId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual AiCombination? Combination { get; set; }

    public virtual AiKeyWord KeyWord { get; set; } = null!;
}
