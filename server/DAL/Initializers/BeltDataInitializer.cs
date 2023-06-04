using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers;

internal static class BeltDataInitializer
{
    internal static void SeedData(ModelBuilder builder)
    {
        builder.Entity<Belt>().HasData
        (
            new Belt()
            {
                Id = 1,
                Rank =  "1 куп"
            },
            new Belt()
            {
                Id = 2,
                Rank =  "2 куп"
            },
            new Belt()
            {
                Id = 3,
                Rank =  "3 куп"
            },
            new Belt()
            {
                Id = 4,
                Rank =  "4 куп"
            },
            new Belt()
            {
                Id = 5,
                Rank =  "5 куп"
            },
            new Belt()
            {
                Id = 6,
                Rank =  "6 куп"
            },
            new Belt()
            {
                Id = 7,
                Rank =  "7 куп"
            },
            new Belt()
            {
                Id = 8,
                Rank =  "8 куп"
            },
            new Belt()
            {
                Id = 9,
                Rank =  "9 куп"
            },
            new Belt()
            {
                Id = 10,
                Rank =  "10 куп"
            },
            new Belt()
            {
                Id = 11,
                Rank =  "1 дан"
            },
            new Belt()
            {
                Id = 12,
                Rank =  "2 дан"
            },
            new Belt()
            {
                Id = 13,
                Rank =  "3 дан"
            },
            new Belt()
            {
                Id = 14,
                Rank =  "4 дан"
            },
            new Belt()
            {
                Id = 15,
                Rank =  "5 дан"
            },
            new Belt()
            {
                Id = 16,
                Rank =  "6 дан"
            },
            new Belt()
            {
                Id = 17,
                Rank =  "7 дан"
            },
            new Belt()
            {
                Id = 18,
                Rank = "8 дан"
            },
            new Belt()
            {
                Id = 19,
                Rank =  "9 дан"
            }
        );
    }
}