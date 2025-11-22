using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmBiaResource
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ResourceDetailId { get; set; }

    public int? BiaFunctionId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTests { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual BcmBiaFuntion? BiaFunction { get; set; }

    public virtual BcmResourceDetail ResourceDetail { get; set; } = null!;
}
