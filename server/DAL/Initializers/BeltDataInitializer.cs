using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

public class BeltDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<Belt>().HasData
        (
            new Belt()
            {
                Id = 1,
                Rank =  "1"
            },
            new Belt()
            {
                Id = 2,
                Rank =  "2"
            },
            new Belt()
            {
                Id = 3,
                Rank =  "3"
            },
            new Belt()
            {
                Id = 4,
                Rank =  "4"
            },
            new Belt()
            {
                Id = 5,
                Rank =  "5"
            },
            new Belt()
            {
                Id = 6,
                Rank =  "6"
            },
            new Belt()
            {
                Id = 7,
                Rank =  "7"
            },
            new Belt()
            {
                Id = 8,
                Rank =  "8"
            },
            new Belt()
            {
                Id = 9,
                Rank =  "9"
            },
            new Belt()
            {
                Id = 10,
                Rank =  "10"
            },
            new Belt()
            {
                Id = 11,
                Rank =  "I"
            },
            new Belt()
            {
                Id = 12,
                Rank =  "II"
            },
            new Belt()
            {
                Id = 13,
                Rank =  "III"
            },
            new Belt()
            {
                Id = 14,
                Rank =  "IV"
            },
            new Belt()
            {
                Id = 15,
                Rank =  "V"
            },
            new Belt()
            {
                Id = 16,
                Rank =  "VI"
            },
            new Belt()
            {
                Id = 17,
                Rank =  "VII"
            },
            new Belt()
            {
                Id = 18,
                Rank = "VIII"
            },
            new Belt()
            {
                Id = 19,
                Rank =  "IX"
            }
        );
    }
}