using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcCrimeDetail
{
    public int Id { get; set; }

    public int CrimeId { get; set; }

    public int ReportingDetialsId { get; set; }

    public string? Details { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
