using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class JudgeConfiguration: IEntityTypeConfiguration<Judge>
{
    public void Configure(EntityTypeBuilder<Judge> builder)
    {
        builder.ToTable("judges");

        builder.HasKey(j => j.MembershipCardNum);

        builder
            .Property(j => j.MembershipCardNum)
            .HasColumnName("membership_card_num");
        
        builder
            .HasOne(j => j.Sportsman)
            .WithOne()
            .HasForeignKey<Judge>(j => j.MembershipCardNum)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(j => j.JudgeCategoryId)
            .HasColumnName("judge_category_id");

        builder
            .HasOne(j => j.JudgeCategory)
            .WithMany()
            .HasForeignKey(j => j.JudgeCategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}