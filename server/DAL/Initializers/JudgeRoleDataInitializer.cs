using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

internal static class JudgeRoleDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<JudgeRole>().HasData(
            new JudgeRole() 
            {
                Id = 1,
                Name = "боковий суддя"
            },
            new JudgeRole() 
            {
                Id = 2,
                Name = "рефері"
            },
            new JudgeRole() 
            {
                Id = 3,
                Name = "головний суддя"
            },
            new JudgeRole() 
            {
                Id = 4,
                Name = "помічник головного судді"
            },
            new JudgeRole() 
            {
                Id = 5,
                Name = "запасний суддя"
            }
        );
    }
}