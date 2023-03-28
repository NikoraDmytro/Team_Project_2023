using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public static class DependencyRegistrar
{
    public static IServiceCollection ConfigureBusinessLayerServices(
        this IServiceCollection services)
    {
        services.AddScoped<IJwtHandler, JwtHandler>();
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}