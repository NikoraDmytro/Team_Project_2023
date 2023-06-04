using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class BeltConfiguration: IEntityTypeConfiguration<Belt>
{
    public void Configure(EntityTypeBuilder<Belt> builder)
    {
        builder.ToTable("belts");
        
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Id)
            .HasColumnName("id");
        
        builder
            .Property(b => b.Rank)
            .HasColumnName("rank")
            .HasColumnType("varchar(6)")
            .IsRequired();

        builder
            .HasIndex(b => b.Rank)
            .IsUnique();
    }
}