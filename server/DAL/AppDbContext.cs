using Core.Entities;
using DAL.Configuration;
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
}