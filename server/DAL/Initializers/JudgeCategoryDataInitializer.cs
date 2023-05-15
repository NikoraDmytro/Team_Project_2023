using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

internal static class JudgeCategoryDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<JudgeCategory>().HasData
        (
            new JudgeCategory() {
                Id = 1,
                Name = "Суддя міжнародної категорії А"
            },
            new JudgeCategory() {
                Id = 2,
                Name = "Суддя міжнародної категорії В"
            },
            new JudgeCategory() {
                Id = 3,
                Name = "Суддя національної категорії"
            },
            new JudgeCategory() {
                Id = 4,
                Name = "Суддя 1-ї категорії"
            },
            new JudgeCategory() {
                Id = 5,
                Name = "Суддя 2-ї категорії"
            },
            new JudgeCategory() {
                Id = 6,
                Name = "Суддя 3-ї категорії"
            }
        );
    }
}