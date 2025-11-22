using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class CorresOrgPerson
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int OrgId { get; set; }

    public string? Name { get; set; }

    public string EmailAddress { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<CorresLetterToPerson> CorresLetterToPeople { get; set; } = new List<CorresLetterToPerson>();

    public virtual ICollection<CorresLetter> CorresLetters { get; set; } = new List<CorresLetter>();

    public virtual CorresOrganization Org { get; set; } = null!;
}
