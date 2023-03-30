using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class CoachConfiguration: IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.ToTable("coaches");

        builder.HasKey(c => c.MembershipCardNum);
        
        builder
            .Property(c => c.MembershipCardNum)
            .HasColumnName("membership_card_num");

        builder
            .HasOne(c => c.Sportsman)
            .WithOne()
            .HasForeignKey<Coach>(c => c.MembershipCardNum);

        builder
            .HasOne<Club>(c => c.Club)
            .WithMany(c => c.Coaches)
            .HasForeignKey(c => c.ClubId)
            .IsRequired();

        builder
            .Property(c => c.ClubId)
            .HasColumnName("club_id");

        builder
            .Property(c => c.InstructorCategory)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(c => c.Phone)
            .HasColumnName("phone")
            .HasColumnType("char(16)")
            .HasMaxLength(16)
            .IsRequired();

        builder
            .HasIndex(c => c.Phone)
            .IsUnique();
    }
}