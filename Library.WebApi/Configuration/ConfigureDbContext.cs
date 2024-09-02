using Library.Infrastructure.Context;

namespace Library.WebApi.Configuration;

public static class ConfigureDbContext
{
    public static WebApplicationBuilder AddDbContextConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        builder.Services.AddScoped<ISaveChangesInterceptor, AuditEntityInterceptor>();
        builder.Services.AddScoped<RequestUserService>();
        
        builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var requestUserService = sp.GetRequiredService<RequestUserService>();
            var userId = requestUserService.GetUserId();
            
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
            options.AddInterceptors(new AuditableEntityInterceptor(userId));
        });
        
        builder.Services.AddDbContext<LibraryContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });
        
        return builder;
    }
}