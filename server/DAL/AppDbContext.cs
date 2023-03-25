using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
    {
    }

    public DbSet<Club>? Clubs { get; set; }
}