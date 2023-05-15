using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

internal static class InstructorCategoryDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<InstructorCategory>().HasData
        (
            new InstructorCategory()
            {
                Id = 1,
                Name = "Тренер початкової підготовки"
            },
            new InstructorCategory()
            {
                Id = 2,
                Name = "Тренер національного класу"
            },
            new InstructorCategory()
            {
                Id = 3,
                Name = "Інстуктор міжнародного класу"
            },
            new InstructorCategory()
            {
                Id = 4,
                Name = "Майстер-інструктор міжнародного класу"
            }
        );
    }
}