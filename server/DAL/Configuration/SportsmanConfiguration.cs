using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class SportsmanConfiguration: IEntityTypeConfiguration<Sportsman>
{
    public void Configure(EntityTypeBuilder<Sportsman> builder)
    {
        builder.ToTable("sportsmen", 
            t => 
                t.HasCheckConstraint("CHK_sportsmen_sex", "sex IN ('M', 'F')"));
        
        builder.HasKey(s => s.MembershipCardNum);

        builder
            .Property(s => s.MembershipCardNum)
            .HasColumnName("membership_card_num");

        builder
            .Property(s => s.BirthDate)
            .HasColumnName("birth_date")
            .IsRequired();

        builder
            .Property(s => s.Sex)
            .HasColumnName("sex")
            .HasMaxLength(1)
            .HasColumnType("varchar(1)")
            .HasConversion<string>()
            .IsRequired();

        builder
            .Property(s => s.Rank)
            .HasColumnName("belt_rank")
            .HasMaxLength(4)
            .HasDefaultValue("10");

        builder
            .Property(s => s.UserId)
            .HasColumnName("user_id");

        builder
            .Property(s => s.CoachMembershipCardNum)
            .HasColumnName("coach_membership_card_num");

        builder
            .Property(s => s.SportsCategoryId)
            .HasColumnName("sports_category_id");
        
        builder
            .HasOne(s => s.Belt)
            .WithMany()
            .HasForeignKey(s => s.Rank);

        builder
            .HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<Sportsman>(s => s.UserId);

        builder
            .HasOne(s => s.Coach)
            .WithMany(c => c.Sportsmen)
            .HasForeignKey(s => s.CoachMembershipCardNum)
            .IsRequired(false);

        builder
            .HasOne(s => s.SportsCategory)
            .WithMany()
            .HasForeignKey(s => s.SportsCategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}