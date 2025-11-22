using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmFunctionDetail
{
    public int Id { get; set; }

    public int FunctionId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTests { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual ICollection<BcmResourceDetail> BcmResourceDetails { get; set; } = new List<BcmResourceDetail>();

    public virtual BcmFunction Function { get; set; } = null!;
}
