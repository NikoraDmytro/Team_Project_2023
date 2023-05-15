using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class JudgeCategoryConfiguration
    :IEntityTypeConfiguration<JudgeCategory>
{
    public void Configure(EntityTypeBuilder<JudgeCategory> builder)
    {
        builder.ToTable("judge_categories");
        
        builder.HasKey(jc => jc.Id);

        builder
            .Property(jc => jc.Id)
            .HasColumnName("id");

        builder
            .Property(jc => jc.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .HasIndex(jc => jc.Name)
            .IsUnique();
    }
}