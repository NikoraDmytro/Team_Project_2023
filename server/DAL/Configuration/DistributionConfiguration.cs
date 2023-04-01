using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class DistributionConfiguration
    : IEntityTypeConfiguration<Distribution>
{
    public void Configure(EntityTypeBuilder<Distribution> builder)
    {
        builder.ToTable("distributions");

        builder.HasKey(d => d.DistributionId);

        builder
            .Property(d => d.DistributionId)
            .HasColumnName("distribution_id");

        builder
            .Property(d => d.SerialNum)
            .HasColumnName("serial_num")
            .IsRequired();

        builder
            .Property(d => d.DayangId)
            .HasColumnName("dayang_id");

        builder
            .HasOne(d => d.Dayang)
            .WithMany(da => da.Distributions)
            .HasForeignKey(d => d.DayangId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .Property(d => d.DivisionId)
            .HasColumnName("division_id");
        
        builder
            .HasOne(d => d.Division)
            .WithMany()
            .HasForeignKey(d => d.DivisionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(d => new { d.DayangId, d.SerialNum })
            .IsUnique();
    }
}