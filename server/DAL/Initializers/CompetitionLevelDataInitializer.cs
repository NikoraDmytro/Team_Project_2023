using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

internal static class CompetitionLevelDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<CompetitionLevel>().HasData
        (
            new CompetitionLevel 
            {
                Id = 1,
                Name = "Чемпіонат області"
            },
            new CompetitionLevel 
            {
                Id = 2,
                Name = "Кубок області"
            },
            new CompetitionLevel 
            {
                Id = 3,
                Name = "Чемпіонат України"
            },
            new CompetitionLevel 
            {
                Id = 4,
                Name = "Кубок України"
            },
            new CompetitionLevel 
            {
                Id = 5,
                Name = "Інші всеукраїнські турніри"
            },
            new CompetitionLevel 
            {
                Id = 6,
                Name = "Інші турніри"
            }
        );
    }
}