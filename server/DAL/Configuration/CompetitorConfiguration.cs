using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class CompetitorConfiguration
    : IEntityTypeConfiguration<Competitor>
{
    public void Configure(EntityTypeBuilder<Competitor> builder)
    {
        builder.ToTable("competitors");

        builder.HasKey(c => c.ApplicationNum);

        builder
            .Property(c => c.ApplicationNum)
            .HasColumnName("application_num");

        builder
            .Property(c => c.WeightingResult)
            .HasColumnName("weighting_result");

        builder
            .Property(c => c.Rank)
            .HasColumnName("belt_rank")
            .HasMaxLength(4)
            .IsRequired();
        
        builder
            .HasOne(c => c.Belt)
            .WithMany()
            .HasForeignKey(c => c.Rank)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(c => c.MembershipCardNum)
            .HasColumnName("membership_card_num");

        builder
            .HasOne(c => c.Sportsman)
            .WithMany()
            .HasForeignKey(c => c.MembershipCardNum)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(c => c.CompetitionId)
            .HasColumnName("competition_id");

        builder
            .HasOne(c => c.Competition)
            .WithMany(c => c.Competitors)
            .HasForeignKey(c => c.CompetitionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}