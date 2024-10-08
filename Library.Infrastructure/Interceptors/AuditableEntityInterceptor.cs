﻿namespace Library.Infrastructure.Interceptors;

public class AuditableEntityInterceptor(string? userId = null) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new()
    )
    {
        SetCreateInfo(eventData.Context);
        SetUpdateInfo(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void SetCreateInfo(DbContext? context)
    {
        if (context is null)
            return;
        
        if (context.ChangeTracker.Entries().All(e => e.State != EntityState.Added))
            return;

        var createdEntities = context.ChangeTracker
            .Entries<Entity>()
            .Where(e => e.State == EntityState.Added);
        
        foreach (var entity in createdEntities)
        {
            entity.Entity.CreatedAt = DateTime.Now;
            entity.Entity.CreatedBy = Guid.Parse(userId);
        }
    }

    private void SetUpdateInfo(DbContext? context)
    {
        if (context is null)
            return;

        if (context.ChangeTracker.Entries().All(e => e.State != EntityState.Modified))
            return;

        var modifiedEntities = context.ChangeTracker
            .Entries<Entity>()
            .Where(e => e.State == EntityState.Modified);

        foreach (var entity in modifiedEntities)
            entity.Entity.UpdatedAt = DateTime.Now;
    }
}