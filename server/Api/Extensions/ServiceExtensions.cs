﻿using Core.Entities;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using Api.Validators.Club;
using Api.Validators.Coach;
using Api.Validators.Judge;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services)
    {

        /*var connectionString = 
                          $"Server={Environment.GetEnvironmentVariable("DB_HOST")};" +
                          $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                          $"User Id={Environment.GetEnvironmentVariable("USER_ID")};" +
                          $"Password={Environment.GetEnvironmentVariable("SA_PASSWORD")};" +
                          "Encrypt=False";*/

        var anotherString =
            "Server=LEGION5\\SQLEXPRESS;Database=taekwondo;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
        
        services.AddDbContext<AppDbContext>(opts =>
            opts
                .UseLazyLoadingProxies()
                .UseSqlServer(anotherString));
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentityCore<User>(o =>
        {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 4;
            o.User.RequireUniqueEmail = true;
        });

        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole<int>),
            builder.Services);

        builder.AddSignInManager<SignInManager<User>>();

        builder.AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureFluentValidation(
        this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateClubModelValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateClubModelValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateCoachModelValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateCoachModelValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateJudgeModelValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateJudgeModelValidator>();
    }
}