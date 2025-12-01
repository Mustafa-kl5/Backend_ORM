using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcUserRole
{
    public int UserRoleId { get; set; }

    public int RolCode { get; set; }

    public int? UseUserId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcRole RolCodeNavigation { get; set; } = null!;

    public virtual GrcUser? UseUser { get; set; }
}
