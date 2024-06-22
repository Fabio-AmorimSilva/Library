namespace AuditTrail.Entities;

public class Audit
{
    public const int TableNameMaxLength = 256;
    public const int OldValuesMaxLength = 2000;
    public const int NewValuesMaxLength = 2000;
    public const int UpdatedColumnsMaxLength = 2000;
    public const int PrimaryKeyMaxLength = 2000;
    
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

        ArgumentOutOfRangeException.ThrowIfEqual(userId, Guid.Empty);
        
        ArgumentException.ThrowIfNullOrWhiteSpace(tableName);
        ArgumentException.ThrowIfNullOrWhiteSpace(oldValues);
        ArgumentException.ThrowIfNullOrWhiteSpace(newValues);
        ArgumentException.ThrowIfNullOrWhiteSpace(updatedColumns);
        ArgumentException.ThrowIfNullOrWhiteSpace(primaryKey);
        
        ArgumentOutOfRangeException.ThrowIfGreaterThan(tableName.Length, TableNameMaxLength);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(OldValues.Length, OldValuesMaxLength);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(NewValues.Length, NewValuesMaxLength);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(UpdatedColumns.Length, UpdatedColumnsMaxLength);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(PrimaryKey.Length, PrimaryKeyMaxLength);
        
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