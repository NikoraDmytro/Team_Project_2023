using Core.Entities;
using DAL.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClubConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Club>? Clubs { get; set; }
}