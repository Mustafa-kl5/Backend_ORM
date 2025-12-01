using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcSubRegulationDepartmentActivity
{
    public int Id { get; set; }

    public int? SubProductDepartmentId { get; set; }

    public int? ProjectDepartmentId { get; set; }

    public int SubRegulationId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdateBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcProjectDepartment? ProjectDepartment { get; set; }

    public virtual GrcSubProductsDepartment? SubProductDepartment { get; set; }

    public virtual GrcSubRegulation SubRegulation { get; set; } = null!;
}
