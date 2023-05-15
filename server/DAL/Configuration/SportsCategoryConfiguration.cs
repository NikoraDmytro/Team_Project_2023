using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class SportsCategoryConfiguration
    : IEntityTypeConfiguration<SportsCategory>
{
    public void Configure(EntityTypeBuilder<SportsCategory> builder)
    {
        builder.ToTable("sports_categories");
        
        builder.HasKey(sc => sc.Id);

        builder
            .Property(sc => sc.Id)
            .HasColumnName("id");

        builder
            .Property(sc => sc.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .HasIndex(sc => sc.Name)
            .IsUnique();
    }
}
