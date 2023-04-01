using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class JudgeRoleConfiguration
    : IEntityTypeConfiguration<JudgeRole>
{
    public void Configure(EntityTypeBuilder<JudgeRole> builder)
    {
        builder.ToTable("judge_roles");

        builder.HasKey(jr => jr.RoleName);
        
        builder
            .Property(jr => jr.RoleName)
            .HasColumnName("role_name")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.HasData(
            new JudgeRole() 
            {
                RoleName = "side_judge"
            },
            new JudgeRole() 
            {
                RoleName = "referee"
            },
            new JudgeRole() 
            {
                RoleName = "chief_judge"
            },
            new JudgeRole() 
            {
                RoleName = "deputy_chief_judge"
            },
            new JudgeRole() 
            {
                RoleName = "reserve_judge"
            }
        );
    }
}