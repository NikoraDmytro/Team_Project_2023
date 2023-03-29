using BLL.Interfaces;
using BLL.MappingProfiles;
using BLL.Models.Settings;
using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public static class DependencyRegistrar
{
    public static IServiceCollection ConfigureBusinessLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IJwtHandler, JwtHandler>();
        services.AddScoped<IAuthService, AuthService>();

        services.ConfigureAutomapper();
        services.ConfigureOptions(configuration);
        
        return services;
    }
    
    private static IServiceCollection ConfigureAutomapper(
        this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));

        return services;
    }
    
    private static IServiceCollection ConfigureOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

        return services;
    }
}