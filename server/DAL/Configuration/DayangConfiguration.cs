using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class DayangConfiguration : IEntityTypeConfiguration<Dayang>
{
    public void Configure(EntityTypeBuilder<Dayang> builder)
    {
        builder.ToTable("dayangs");

        builder.HasKey(d => d.DayangId);

        builder
            .Property(d => d.DayangId)
            .HasColumnName("dayang_id");

        builder
            .Property(d => d.CompetitionId)
            .HasColumnName("competition_id");

        builder
            .HasOne(d => d.Competition)
            .WithMany(c => c.Dayangs)
            .HasForeignKey(d => d.CompetitionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}