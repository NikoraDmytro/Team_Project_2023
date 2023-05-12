using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDataAccessLayer(
        this IServiceCollection services)
    {
        services.AddScoped<IClubRepository, ClubRepository>();

        return services;
    }
}