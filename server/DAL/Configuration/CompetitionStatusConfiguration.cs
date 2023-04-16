using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class CompetitionStatusConfiguration
    : IEntityTypeConfiguration<CompetitionStatus>
{
    public void Configure(EntityTypeBuilder<CompetitionStatus> builder)
    {
        builder.ToTable("competition_statuses");

        builder.HasKey(cs => cs.StatusName);

        builder
            .Property(cs => cs.StatusName)
            .HasColumnName("status_name")
            .HasMaxLength(30)
            .HasColumnType("char(30)");
        
        builder.HasData(
            new CompetitionStatus 
            {
                StatusName = "pending"
            },
            new CompetitionStatus 
            {
                StatusName = "accepting_applications"
            },
            new CompetitionStatus 
            {
                StatusName = "accepting_applications_closed"
            },
            new CompetitionStatus 
            {
                StatusName = "started"
            },
            new CompetitionStatus 
            {
                StatusName = "finished"
            },
            new CompetitionStatus 
            {
                StatusName = "canceled"
            }
        );
    }
}