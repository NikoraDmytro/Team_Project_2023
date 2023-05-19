using Core.Entities;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services)
    {

        var connectionString = 
                          $"Server={Environment.GetEnvironmentVariable("DB_HOST")};" +
                          $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                          $"User Id={Environment.GetEnvironmentVariable("USER_ID")};" +
                          $"Password={Environment.GetEnvironmentVariable("SA_PASSWORD")};" +
                          "Encrypt=False";

        
        
        services.AddDbContext<AppDbContext>(opts =>
            opts
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString));
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentityCore<User>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        });

        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole<int>),
            builder.Services);

        builder.AddSignInManager<SignInManager<User>>();

        builder.AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
}