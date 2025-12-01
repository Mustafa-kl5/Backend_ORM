using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class AspstateTempApplication
{
    public int AppId { get; set; }

    public string AppName { get; set; } = null!;
}
