using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class CorresLetter
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int OrgId { get; set; }

    public int? OrgPersonId { get; set; }

    public int AccountId { get; set; }

    public int? RegulationId { get; set; }

    public int? SubRegulationId { get; set; }

    public int StatusId { get; set; }

    public string Reference { get; set; } = null!;

    public string? LetterSubject { get; set; }

    public string? LetterTo { get; set; }

    public DateTime? RespnseByDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public DateTime? LetterDate { get; set; }

    public int? DepartmentId { get; set; }

    public int? CategoryId { get; set; }

    public bool? Dispatch { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual CorresCategory? Category { get; set; }

    public virtual ICollection<CorresAttachFile> CorresAttachFiles { get; set; } = new List<CorresAttachFile>();

    public virtual ICollection<CorresLetterLink> CorresLetterLinkLetters { get; set; } = new List<CorresLetterLink>();

    public virtual ICollection<CorresLetterLink> CorresLetterLinkLinkedLetters { get; set; } = new List<CorresLetterLink>();

    public virtual ICollection<CorresLetterToPerson> CorresLetterToPeople { get; set; } = new List<CorresLetterToPerson>();

    public virtual ICollection<CorresLettersDep> CorresLettersDeps { get; set; } = new List<CorresLettersDep>();

    public virtual GrcDepartment? Department { get; set; }

    public virtual CorresOrganization Org { get; set; } = null!;

    public virtual CorresOrgPerson? OrgPerson { get; set; }

    public virtual ICollection<RccmChangeManagement> RccmChangeManagements { get; set; } = new List<RccmChangeManagement>();

    public virtual GrcRegulation? Regulation { get; set; }

    public virtual CorresStatus Status { get; set; } = null!;

    public virtual GrcSubRegulation? SubRegulation { get; set; }

    public virtual CorresType Type { get; set; } = null!;
}
