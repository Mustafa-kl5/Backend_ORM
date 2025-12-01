using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcProjectDepartment
{
    public int Id { get; set; }

    public int StrategicProgramProjectId { get; set; }

    public int DepartmentId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual ICollection<GrcSubRegulationDepartmentActivity> GrcSubRegulationDepartmentActivities { get; set; } = new List<GrcSubRegulationDepartmentActivity>();

    public virtual StrategicProgramProject StrategicProgramProject { get; set; } = null!;
}
