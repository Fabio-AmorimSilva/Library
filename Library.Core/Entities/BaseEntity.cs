namespace Library.Core.Entities;

public abstract class BaseEntity : IAuditableEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CreatedBy { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
