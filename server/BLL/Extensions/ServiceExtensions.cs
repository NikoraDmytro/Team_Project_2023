using BLL.Interfaces;
using BLL.MappingProfiles;
using BLL.Models.Settings;
using BLL.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions;

public static class DependencyRegistrar
{
    public static IServiceCollection ConfigureBusinessLayerServices(
        this IServiceCollection services)
    {
        services.AddScoped<IJwtHandler, JwtHandler>();
        services.AddScoped<IAuthService, AuthService>();

        services.ConfigureAutomapper();
        services.ConfigureOptions();
        
        return services;
    }
    
    private static IServiceCollection ConfigureAutomapper(
        this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));

        return services;
    }
    
    private static IServiceCollection ConfigureOptions(
        this IServiceCollection services)
    {
        services.Configure<JwtSettings>(options =>
        {
            options.Key = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? "JwtSecretKey";
            options.Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "JwtIssuer";
            options.Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "JwtAudience";
        });
        
        return services;
    }
}