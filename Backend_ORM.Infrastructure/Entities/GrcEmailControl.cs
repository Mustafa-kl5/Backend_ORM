using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcEmailControl
{
    public int Id { get; set; }

    public int EmailCode { get; set; }

    public string EmailDescription { get; set; } = null!;

    public bool Enabled { get; set; }

    public int CreatedBy { get; set; }

    public DateTime Creationdate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? EmailMsgSec1 { get; set; }

    public string? EmailMsgSec2 { get; set; }

    public string? EmailMsgSec3 { get; set; }

    public string? EmailMsgSec4 { get; set; }

    public string Subject { get; set; } = null!;

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
