using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

internal static class ClubsDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<Club>().HasData
        (
            new Club()
            {
                Id = 1,
                Name = "СК \"Білий Ведмідь\"",
                City = "Харків",
                Address = "Дитячий садок, проспект Перемоги, 76А, Харків, Харківська область, 61000"
            },
            new Club()
            {
                Id = 2,
                Name = "СК \"Кобра-Кван\"",
                City = "Дніпро",
                Address = "вулиця Шолохова, 17, Дніпро, Дніпропетровська область, 49000"
            },
            new Club()
            {
                Id = 3,
                Name = "КДЮСШ \"ТАЙФУН\"",
                City = "Київ",
                Address = "Артилерійський провулок, 7Б, Київ, 03113"
            },
            new Club()
            {
                Id = 4,
                Name = "СК \"МАКСИМУМ\"",
                City = "Вінниця",
                Address = "вулиця Миколи Оводова, 22, Вінниця, Вінницька область, 21000"
            },
            new Club()
            {
                Id = 5,
                Name = "СК \"Спарта\"",
                City = "Київ",
                Address = "вулиця Садова, 94, Ірпінь, Київська область, 08200"
            }
        );
    }
}