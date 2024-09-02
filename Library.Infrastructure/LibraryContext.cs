using Library.Infrastructure.Context;

namespace Library.Infrastructure;

public class LibraryContext(DbContextOptions<ApplicationDbContext> options) : ApplicationDbContext(options)
{
    public DbSet<Author> Authors {  get; set; }
    public DbSet<Book> Books {  get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<LibraryUnit> Libraries { get; set; }
    public DbSet<Audit> Audits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
