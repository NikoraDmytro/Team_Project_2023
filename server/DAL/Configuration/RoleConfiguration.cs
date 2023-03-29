using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
    {
        builder.HasData(
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