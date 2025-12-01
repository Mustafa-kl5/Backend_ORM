using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcTestHeader> GrcTestHeaders { get; set; } = new List<GrcTestHeader>();

    public virtual ICollection<ProductAssessmentHeader> ProductAssessmentHeaders { get; set; } = new List<ProductAssessmentHeader>();

    public virtual ICollection<ProductIndicatorLink> ProductIndicatorLinks { get; set; } = new List<ProductIndicatorLink>();

    public virtual ICollection<RccmChangeManagement> RccmChangeManagements { get; set; } = new List<RccmChangeManagement>();

    public virtual ICollection<SubProduct> SubProducts { get; set; } = new List<SubProduct>();
}
