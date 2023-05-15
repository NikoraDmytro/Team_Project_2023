using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class JudgingStaffConfiguration
    : IEntityTypeConfiguration<JudgingStaff>
{
    public void Configure(EntityTypeBuilder<JudgingStaff> builder)
    {
        builder.ToTable("judging_staff");

        builder.HasKey(js => js.ApplicationNum);

        builder
            .Property(js => js.ApplicationNum)
            .HasColumnName("application_num");

        builder
            .Property(js => js.JudgeRoleId)
            .HasColumnName("judge_role_id")
            .IsRequired();

        builder
            .HasOne(js => js.JudgeRole)
            .WithMany()
            .HasForeignKey(js => js.JudgeRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(js => js.MembershipCardNum)
            .HasColumnName("membership_card_num");
        
        builder
            .HasOne(js => js.Judge)
            .WithMany()
            .HasForeignKey(js => js.MembershipCardNum)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(js => js.DayangId)
            .HasColumnName("dayang_id");

        builder
            .HasOne(js => js.Dayang)
            .WithMany(d => d.Judges)
            .HasForeignKey(c => c.DayangId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}