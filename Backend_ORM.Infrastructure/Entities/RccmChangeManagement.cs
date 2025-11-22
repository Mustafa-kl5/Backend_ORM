using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RccmChangeManagement
{
    public int Id { get; set; }

    public int InitiatedByUserId { get; set; }

    public int? RegulationId { get; set; }

    public int? BusinessUnitId { get; set; }

    public int? ProductId { get; set; }

    public int CmTypeId { get; set; }

    public int CmStatusId { get; set; }

    public int CmPriorityId { get; set; }

    public string? Others { get; set; }

    public string CmReference { get; set; } = null!;

    public string CmDescription { get; set; } = null!;

    public string? CmReason { get; set; }

    public string? Comment { get; set; }

    public string? CmBusinessImpact { get; set; }

    public string? AttachFile { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? DateClosed { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public int? LetterId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcControlBusinessUnit? BusinessUnit { get; set; }

    public virtual RccmCmPriority CmPriority { get; set; } = null!;

    public virtual RccmCmStatus CmStatus { get; set; } = null!;

    public virtual RccmCmType CmType { get; set; } = null!;

    public virtual GrcUser InitiatedByUser { get; set; } = null!;

    public virtual CorresLetter? Letter { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<RccmCmTask> RccmCmTasks { get; set; } = new List<RccmCmTask>();

    public virtual GrcRegulation? Regulation { get; set; }
}
