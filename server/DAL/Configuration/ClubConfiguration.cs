using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class ClubConfiguration: IEntityTypeConfiguration<Club>
{
    public void Configure(EntityTypeBuilder<Club> builder)
    {
        builder.ToTable("clubs");
        
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("club_id");

        builder
            .HasIndex(c => c.Name)
            .IsUnique();
        
        builder
            .Property(c => c.Name)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)")
            .HasColumnName("name")
            .IsRequired();

        builder
            .Property(c => c.City)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .HasColumnName("city")
            .IsRequired();
        
        builder
            .Property(c => c.Address)
            .HasMaxLength(200)
            .HasColumnType("varchar(200)")
            .HasColumnName("address")
            .IsRequired();
    }
}