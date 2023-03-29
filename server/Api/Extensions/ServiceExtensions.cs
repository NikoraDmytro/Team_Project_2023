using Core.Entities;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services)
    {

        string connectionString = 
                          $"Server={Environment.GetEnvironmentVariable("DB_HOST")}" +
                          $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                          $"User Id={Environment.GetEnvironmentVariable("USER_ID")};" +
                          $"Password={Environment.GetEnvironmentVariable("SA_PASSWORD")};" +
                           "Encrypt=False";
        
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlServer(connectionString, 
                options => options.MigrationsAssembly("DAL")));
    }
}