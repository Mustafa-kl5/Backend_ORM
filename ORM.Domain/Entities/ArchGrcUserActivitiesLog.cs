using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class ArchGrcUserActivitiesLog
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Activity { get; set; }

    public string? Businessname { get; set; }

    public DateTime? ActivityDate { get; set; }
}
