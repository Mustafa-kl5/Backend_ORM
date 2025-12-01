using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmPlanNotificationProc
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanId { get; set; }

    public string Name { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaPlan BiaPlan { get; set; } = null!;
}
