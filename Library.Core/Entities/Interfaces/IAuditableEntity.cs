namespace Library.Core.Entities.Interfaces;

public interface IAuditableEntity
{
    public Guid CreatedBy { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}