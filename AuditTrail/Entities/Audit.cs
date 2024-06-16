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

    public Audit(
        Guid userId, 
        string type, 
        string tableName, 
        DateTime timeStamp, 
        string oldValues, 
        string newValues, 
        string updatedColumns, 
        string primaryKey
    )
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Type = type;
        TableName = tableName;
        TimeStamp = timeStamp;
        OldValues = oldValues;
        NewValues = newValues;
        UpdatedColumns = updatedColumns;
        PrimaryKey = primaryKey;
    }
}