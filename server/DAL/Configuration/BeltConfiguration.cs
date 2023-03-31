using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class BeltConfiguration: IEntityTypeConfiguration<Belt>
{
    public void Configure(EntityTypeBuilder<Belt> builder)
    {
        builder.ToTable("belts");
        
        builder.HasKey(b => b.Rank);

        builder
            .Property(b => b.Rank)
            .HasColumnName("rank")
            .HasColumnType("varchar(4)");
        
        builder.HasData(
            new Belt()
            {
                Rank =  "1"
            },
            new Belt()
            {
                Rank =  "2"
            },
            new Belt()
            {
                Rank =  "3"
            },
            new Belt()
            {
                Rank =  "4"
            },
            new Belt()
            {
                Rank =  "5"
            },
            new Belt()
            {
                Rank =  "6"
            },
            new Belt()
            {
                Rank =  "7"
            },
            new Belt()
            {
                Rank =  "8"
            },
            new Belt()
            {
                Rank =  "9"
            },
            new Belt()
            {
                Rank =  "10"
            },
            new Belt()
            {
                Rank =  "I"
            },
            new Belt()
            {
                Rank =  "II"
            },
            new Belt()
            {
                Rank =  "III"
            },
            new Belt()
            {
                Rank =  "IV"
            },
            new Belt()
            {
                Rank =  "V"
            },
            new Belt()
            {
                Rank =  "VI"
            },
            new Belt()
            {
                Rank =  "VII"
            },
            new Belt()
            {
                Rank =  "VIII"
            },
            new Belt()
            {
                Rank =  "IX"
            }
        );
    }
}