using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class ShuffleConfiguration: IEntityTypeConfiguration<Shuffle>
{
    public void Configure(EntityTypeBuilder<Shuffle> builder)
    {
        builder.ToTable("shuffles", 
            t => 
                t.HasCheckConstraint("CHK_shuffles_competitor_in_blue_id", 
                    "competitor_in_blue_id != competitor_in_red_id"));

        builder.HasKey(s => s.ShuffleId);

        builder
            .Property(s => s.ShuffleId)
            .HasColumnName("shuffle_id");

        builder
            .Property(s => s.LapNum)
            .HasColumnName("lap_num")
            .HasDefaultValue(0);

        builder
            .Property(s => s.PairSerialNum)
            .HasColumnName("pair_serial_num")
            .IsRequired();

        builder
            .Property(s => s.CompetitorInBlueId)
            .HasColumnName("competitor_in_blue_id");

        builder
            .Property(s => s.CompetitorInRedId)
            .HasColumnName("competitor_in_red_id");

        builder
            .HasOne(s => s.CompetitorInBlue)
            .WithMany()
            .HasForeignKey(s => s.CompetitorInBlueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(s => s.CompetitorInRed)
            .WithMany()
            .HasForeignKey(s => s.CompetitorInRedId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(s => new { s.CompetitorInRedId, s.LapNum })
            .IsUnique();

        builder
            .HasIndex(s => new { s.CompetitorInBlueId, s.LapNum })
            .IsUnique();

        builder
            .HasIndex(s => new { s.CompetitorInBlueId, s.CompetitorInRedId })
            .IsUnique();
    }
}