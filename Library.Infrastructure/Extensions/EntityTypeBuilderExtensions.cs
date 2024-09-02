namespace Microsoft.EntityFrameworkCore;

public static class EntityTypeBuilderExtensions
{
    public static void ConfigureEntityConventions(this EntityTypeBuilder builder)
        => builder.As<EntityTypeBuilder>().TryConfigureEntityBase();

    public static void ConfigureAuditableEntityConventions(this EntityTypeBuilder builder)
        => builder.As<EntityTypeBuilder>().TryConfigureAuditableEntity();    
    
    private static void TryConfigureEntityBase(this EntityTypeBuilder builder)
    {
        if (builder.Metadata.ClrType.IsAssignableTo<Entity>())
            return;

        builder
            .HasKey(nameof(Entity.Id));

        builder
            .Property(nameof(Entity.Id))
            .ValueGeneratedNever();
        
        builder
            .Property(nameof(Entity.Id))
            .IsRequired(false);
    }
    
    private static void TryConfigureAuditableEntity(this EntityTypeBuilder builder)
    {
        if (builder.Metadata.ClrType.IsAssignableTo<Entity>())
            return;

        builder
            .HasKey(nameof(Entity.Id));

        builder
            .Property(nameof(IAuditableEntity.CreatedAt))
            .IsRequired();
        
        builder
            .Property(nameof(IAuditableEntity.CreatedBy))
            .ValueGeneratedNever();
        
        builder
            .Property(nameof(IAuditableEntity.UpdatedAt))
            .IsRequired(false);

        builder
            .Property(nameof(IAuditableEntity.LastModifiedBy))
            .IsRequired(false);
    }

    private static T As<T>(this object obj)
        => (T)obj;
}