﻿namespace Library.WebApi.Configuration;

public static class ConfigureCors
{
    public static WebApplicationBuilder AddCorsConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Development", policyBuilder => 
                policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyMethod()
                );
        });

        return builder;
    }
}