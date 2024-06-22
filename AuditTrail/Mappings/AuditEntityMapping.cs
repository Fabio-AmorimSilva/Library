namespace AuditTrail.Mappings;

public class AuditEntityMapping
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder
            .ToTable("Audits");

        builder
            .Property(a => a.Id)
            .ValueGeneratedNever();

        builder
            .Property(a => a.UserId)
            .IsRequired();

        builder
            .Property(a => a.Type)
            .IsRequired();

        builder
            .Property(a => a.TableName)
            .HasMaxLength(Audit.TableNameMaxLength)
            .IsRequired();

        builder
            .Property(a => a.OldValues)
            .HasMaxLength(Audit.OldValuesMaxLength)
            .IsRequired();

        builder
            .Property(a => a.NewValues)
            .HasMaxLength(Audit.NewValuesMaxLength)
            .IsRequired();

        builder
            .Property(a => a.TableName)
            .HasMaxLength(Audit.UpdatedColumnsMaxLength)
            .IsRequired();

        builder
            .Property(a => a.TableName)
            .HasMaxLength(Audit.PrimaryKeyMaxLength)
            .IsRequired();
    }
}