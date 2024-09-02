namespace Library.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Entity>()
            .HasQueryFilter(e => e.GetType().BaseType == null);
        
        base.OnModelCreating(modelBuilder);
    }
}