﻿using Core.Entities;
using DAL.Configuration;
using DAL.Initializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class AppDbContext: IdentityDbContext<User, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClubConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
        JudgeCategoryDataInitializer.SeedData(modelBuilder);
        SportsCategoryDataInitializer.SeedData(modelBuilder);
        InstructorCategoryDataInitializer.SeedData(modelBuilder);
        CompetitionStatusDataInitializer.SeedData(modelBuilder);
        CompetitionLevelDataInitializer.SeedData(modelBuilder);
        BeltDataInitializer.SeedData(modelBuilder);
        JudgeRoleDataInitializer.SeedData(modelBuilder);
        ClubsDataInitializer.SeedData(modelBuilder);
    }

    public DbSet<Club>? Clubs { get; set; }
    public DbSet<Sportsman>? Sportsmen { get; set; }
    public DbSet<Coach>? Coaches { get; set; }
    public DbSet<Judge>? Judges { get; set; }
    public DbSet<Competition>? Competitions { get; set; }
    public DbSet<Competitor>? Competitors { get; set; }
    public DbSet<Shuffle>? Shuffles { get; set; }
    public DbSet<JudgingStaff>? JudgingStaves { get; set; }
    public DbSet<Dayang>? Dayangs { get; set; }
    public DbSet<Division>? Divisions { get; set; }
    public DbSet<Distribution>? Distributions { get; set; }
    public DbSet<JudgeCategory>? JudgeCategories { get; set; }
    public DbSet<SportsCategory>? SportsCategories { get; set; }
    public DbSet<InstructorCategory>? InstructorCategories { get; set; }
    public DbSet<CompetitionLevel>? CompetitionLevels { get; set; }
    public DbSet<CompetitionStatus>? CompetitionStatuses { get; set; }
    public DbSet<Belt>? Belts { get; set; }
    public DbSet<JudgeRole>? JudgeRoles { get; set; }
}