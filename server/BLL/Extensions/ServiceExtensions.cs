using System.Reflection;
using BLL.Mappings;
using BLL.Models.Settings;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions;

public static class DependencyRegistrar
{
    public static IServiceCollection ConfigureBusinessLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Scan(scan =>
            scan.FromAssemblyOf<IClubService>()
                .AddClasses(cl => cl.Where(type => type.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        services.ConfigureAutomapper();
        services.ConfigureOptions(configuration);
        
        return services;
    }
    
    private static IServiceCollection ConfigureAutomapper(
        this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

        return services;
    }
    
    private static IServiceCollection ConfigureOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(options =>
        {
            options.Key = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? "JwtSecretKey";
            options.Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "JwtIssuer";
            options.Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "JwtAudience";
        });

        services.Configure<GoogleSettings>(options =>
        {
            options.ClientId = configuration["Authentication:Google:ClientId"];
            options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
        });
        
        return services;
    }
}