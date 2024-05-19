namespace AuditTrail.Entities;

public class Audit
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Type { get; private set; }
    public string TableName { get; private set; }
    public DateTime TimeStamp { get; private set; }
    public string OldValues { get; private set; }
    public string NewValues { get; private set; }
    public string UpdatedColumns { get; private set; }
    public string PrimaryKey { get; private set; }
}