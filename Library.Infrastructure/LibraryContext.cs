namespace Library.Infrastructure;

public class LibraryContext(DbContextOptions<BaseContext> options) : BaseContext(options)
{
    public DbSet<Author> Authors {  get; set; }
    public DbSet<Book> Books {  get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<LibraryUnit> Libraries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}
