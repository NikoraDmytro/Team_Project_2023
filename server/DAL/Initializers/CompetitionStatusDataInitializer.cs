using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

internal static class CompetitionStatusDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<CompetitionStatus>().HasData
        (
            new CompetitionStatus 
            {
                Id = 1,
                Name = "Очікується"
            },
            new CompetitionStatus 
            {
                Id = 2,
                Name = "Прийом заявок"
            },
            new CompetitionStatus 
            {
                Id = 3,
                Name = "Прийом заявок закінченно"
            },
            new CompetitionStatus 
            {
                Id = 4,
                Name = "Проходить"
            },
            new CompetitionStatus 
            {
                Id = 5,
                Name = "Завершено"
            },
            new CompetitionStatus 
            {
                Id = 6,
                Name = "Скасовано"
            }
        );
    }
}