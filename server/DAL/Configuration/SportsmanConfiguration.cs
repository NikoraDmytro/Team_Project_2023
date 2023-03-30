using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class SportsmanConfiguration: IEntityTypeConfiguration<Sportsman>
{
    public void Configure(EntityTypeBuilder<Sportsman> builder)
    {
        builder.HasKey(s => s.MembershipCardNum);

        builder
            .Property(s => s.MembershipCardNum)
            .HasColumnName("membership_card_num");

        builder
            .Property(s => s.SportsCategory)
            .HasColumnName("sports_category")
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

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
            .HasOne(s => s.Belt)
            .WithMany()
            .HasForeignKey(s => s.Rank);

        builder
            .HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<Sportsman>(s => s.UserId);

        builder.ToTable("sportsmen", 
            t => 
                t.HasCheckConstraint("CHK_sportsmen_user_id", "sex IN ('M', 'F')"));
    }
}