using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmBiaFuntionProcess
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ProcessDetailId { get; set; }

    public int? BiaFunctionId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaFuntion? BiaFunction { get; set; }

    public virtual OrmProcessDetail ProcessDetail { get; set; } = null!;
}
