using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class DivisionConfiguration
    : IEntityTypeConfiguration<Division>
{
    public void Configure(EntityTypeBuilder<Division> builder)
    {
        builder.ToTable("divisions",
            t =>
            {
                t.HasCheckConstraint("CHK_divisions_sex",
                    "sex IN ('M', 'F')");
                t.HasCheckConstraint("CHK_divisions_weight",
                    "min_weight IS NOT NULL OR  max_weight IS NOT NULL");
            });

        builder.HasKey(d => d.DivisionId);

        builder
            .Property(d => d.DivisionId)
            .HasColumnName("division_id");

        builder
            .Property(d => d.Name)
            .HasColumnName("division_name")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasIndex(d => d.Name)
            .IsUnique();
        
        builder
            .Property(d => d.MinWeight)
            .HasColumnName("min_weight")
            .IsRequired(false);

        builder
            .Property(d => d.MaxWeight)
            .HasColumnName("max_weight")
            .IsRequired(false);

        builder
            .Property(d => d.MinAge)
            .HasColumnName("min_age")
            .IsRequired();
        
        builder
            .Property(d => d.MaxAge)
            .HasColumnName("max_age")
            .IsRequired();

        builder
            .Property(d => d.Sex)
            .HasMaxLength(1)
            .HasColumnName("sex")
            .HasColumnType("varchar(1)")
            .HasConversion<string>()
            .IsRequired();
        
        builder
            .Property(d => d.MinBeltId)
            .HasColumnName("min_belt_id")
            .IsRequired();
        
        builder
            .Property(d => d.MaxBeltId)
            .HasColumnName("max_belt_id")
            .IsRequired();

        builder
            .HasOne(s => s.MinBelt)
            .WithMany()
            .HasForeignKey(s => s.MinBeltId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(s => s.MaxBelt)
            .WithMany()
            .HasForeignKey(s => s.MaxBeltId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}