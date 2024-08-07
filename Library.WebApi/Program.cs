var builder = WebApplication.CreateBuilder(args);

builder
    .AddMediatR()
    .AddJwtConfiguration()
    .AddJsonConfiguration()
    .AddDbContextConfiguration()
    .AddCorsConfiguration()
    .AddSerilogCustomConfiguration();

builder.Services
    .AddJwtConfig(builder.Configuration)
    .AddVersioning()
    .AddCustomHealthCheck(builder)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCustomHangFire(builder)
    .ConfigureOptions<ConfigureSwaggerOptions>()
    .AddHttpContextAccessor()
    .AddCustomExceptionHandlerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AddSwagger();
    app.UseCors("Development");
}

app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseHangfireDashboard();

app.AddCustomHealthCheckUrl();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();