using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDataAccessLayer(
        this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromAssemblyOf<IClubRepository>()
                .AddClasses(cl => cl.Where(type => type.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}