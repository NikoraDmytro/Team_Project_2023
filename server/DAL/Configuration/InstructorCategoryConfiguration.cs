using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class InstructorCategoryConfiguration
    :IEntityTypeConfiguration<InstructorCategory>
{
    public void Configure(EntityTypeBuilder<InstructorCategory> builder)
    {
        builder.ToTable("instructor_categories");

        builder.HasKey(ic => ic.Id);

        builder
            .Property(ic => ic.Id)
            .HasColumnName("id");

        builder
            .Property(ic => ic.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .HasIndex(ic => ic.Name)
            .IsUnique();
    }
}