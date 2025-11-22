using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcEmail
{
    public int EmailId { get; set; }

    public string EmailAddressFrom { get; set; } = null!;

    public string EmailAddressTo { get; set; } = null!;

    public string? EmailAddressCc { get; set; }

    public string? EmailSubject { get; set; }

    public string? EmailBody { get; set; }

    public bool EmailSent { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
