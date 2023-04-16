using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

internal static class SportsCategoryDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<SportsCategory>().HasData
        (
            new SportsCategory() {
                Id = 1,
                Name = "Майстер спорту України міжнародного класу"
            },
            new SportsCategory() {
                Id = 2,
                Name = "Майстер спорту України"
            },
            new SportsCategory() {
                Id = 3,
                Name = "Кандидат у майстри спорту"
            }
        );
    }
}