using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class JudgeRoleConfiguration
    : IEntityTypeConfiguration<JudgeRole>
{
    public void Configure(EntityTypeBuilder<JudgeRole> builder)
    {
        builder.ToTable("judge_roles");

        builder.HasKey(jr => jr.Id);

        builder
            .Property(jr => jr.Id)
            .HasColumnName("id");
        
        builder
            .Property(jr => jr.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder
            .HasIndex(jr => jr.Name)
            .IsUnique();
    }
}