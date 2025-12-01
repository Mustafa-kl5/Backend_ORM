using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcExtention
{
    public int Id { get; set; }

    public string Extention { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? UpdatedDate { get; set; }
}
