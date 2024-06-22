using Library.Core.Entities;

namespace AuditTrail.Interceptors;

public class AuditEntityInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = new CancellationToken()
    )
    {
        await SetAuditableEntity(eventData.Context);

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task SetAuditableEntity(DbContext? context)
    {
        if (context is null)
            return;

        var entries = context.ChangeTracker
            .Entries<BaseEntity>()
            .ToList();

        if (entries.Count != 0)
        {
            foreach (var entry in entries)
            {
                var audit = new Audit(
                    userId: entry.Entity.CreatedBy,
                    type: entry.Entity.GetType().ToString(),
                    tableName: entry.Entity.GetType() + "s",
                    timeStamp: DateTime.Now,
                    oldValues: entry.OriginalValues.Properties.ToString()!,
                    newValues: entry.CurrentValues.Properties.ToString()!,
                    updatedColumns: entry.CurrentValues.Properties.Select(p => p.Name).ToString()!,
                    primaryKey: entry.Entity.Id.ToString()
                );

                await context.AddAsync(audit);
            }
        }
    }
}