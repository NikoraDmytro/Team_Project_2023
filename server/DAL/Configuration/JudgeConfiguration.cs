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
            .HasOne(c => c.Sportsman)
            .WithOne()
            .HasForeignKey<Judge>(c => c.MembershipCardNum)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(j => j.JudgeCategory)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .HasColumnName("judge_category")
            .IsRequired();
    }
}