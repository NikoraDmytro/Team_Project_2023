using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class CompetitionConfiguration
    : IEntityTypeConfiguration<Competition>
{
    public void Configure(EntityTypeBuilder<Competition> builder)
    {
        builder.ToTable("competitions");

        builder.HasKey(c => c.CompetitionId);

        builder
            .Property(c => c.CompetitionId)
            .HasColumnName("competition_id");

        builder
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(c => c.WeightingDate)
            .HasColumnName("weighting_date")
            .IsRequired();
        
        builder
            .Property(c => c.StartDate)
            .HasColumnName("start_date")
            .IsRequired();
        
        builder
            .Property(c => c.EndDate)
            .HasColumnName("end_date")
            .IsRequired();

        builder
            .Property(c => c.City)
            .HasColumnType("varchar(60)")
            .HasMaxLength(60)
            .HasColumnName("city")
            .IsRequired();

        builder
            .Property(c => c.CompetitionLevel)
            .HasColumnName("competition_level")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(c => c.CurrentStatus)
            .HasColumnName("current_status")
            .HasDefaultValue("pending");

        builder
            .HasOne(c => c.CompetitionStatus)
            .WithMany()
            .HasForeignKey(c => c.CurrentStatus);

        builder
            .HasIndex(c => new { c.Name, c.StartDate })
            .IsUnique();
    }
}