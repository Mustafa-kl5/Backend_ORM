namespace ORM.Core.DTOs.Common;

public class ExtensionDto
{
    public int Id { get; set; }

    public string Extention { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? UpdatedDate { get; set; }
}
