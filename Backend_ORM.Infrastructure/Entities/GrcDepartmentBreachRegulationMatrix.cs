using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcDepartmentBreachRegulationMatrix
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int? SubRegulationId { get; set; }

    public int? BreachCountWithSubRegulation { get; set; }

    public int? BreachCountNoSubRegulation { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
