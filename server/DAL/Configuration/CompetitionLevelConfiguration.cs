using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class CompetitionLevelConfiguration : IEntityTypeConfiguration<CompetitionLevel>
{
    public void Configure(EntityTypeBuilder<CompetitionLevel> builder)
    { 
        builder.ToTable("competition_levels");

        builder.HasKey(cs => cs.Id);
        
        builder
            .Property(ic => ic.Id)
            .HasColumnName("id");
        
        builder
            .Property(ic => ic.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30)
            .IsRequired();

        builder
            .HasIndex(ic => ic.Name)
            .IsUnique();
    }
}