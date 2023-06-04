using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

public class RoleDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 1,
                Name = "Regular",
                NormalizedName = "REGULAR"
            },
            new IdentityRole<int>
            {
                Id = 2,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}