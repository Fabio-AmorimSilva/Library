namespace Library.WebApi.Configuration;

public static class ConfigureCustomExceptionHandler
{
    public static IServiceCollection AddCustomExceptionHandlerConfiguration(this IServiceCollection services)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }
}