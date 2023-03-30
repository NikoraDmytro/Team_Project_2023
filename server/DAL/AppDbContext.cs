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
}