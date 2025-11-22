using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class AspstateTempApplication
{
    public int AppId { get; set; }

    public string AppName { get; set; } = null!;
}
