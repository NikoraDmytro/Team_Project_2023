﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230401142751_ConfiguriedJudgeRoleEntity")]
    partial class ConfiguriedJudgeRoleEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Belt", b =>
                {
                    b.Property<string>("Rank")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("rank");

                    b.HasKey("Rank");

                    b.ToTable("belts", (string)null);

                    b.HasData(
                        new
                        {
                            Rank = "1"
                        },
                        new
                        {
                            Rank = "2"
                        },
                        new
                        {
                            Rank = "3"
                        },
                        new
                        {
                            Rank = "4"
                        },
                        new
                        {
                            Rank = "5"
                        },
                        new
                        {
                            Rank = "6"
                        },
                        new
                        {
                            Rank = "7"
                        },
                        new
                        {
                            Rank = "8"
                        },
                        new
                        {
                            Rank = "9"
                        },
                        new
                        {
                            Rank = "10"
                        },
                        new
                        {
                            Rank = "I"
                        },
                        new
                        {
                            Rank = "II"
                        },
                        new
                        {
                            Rank = "III"
                        },
                        new
                        {
                            Rank = "IV"
                        },
                        new
                        {
                            Rank = "V"
                        },
                        new
                        {
                            Rank = "VI"
                        },
                        new
                        {
                            Rank = "VII"
                        },
                        new
                        {
                            Rank = "VIII"
                        },
                        new
                        {
                            Rank = "IX"
                        });
                });

            modelBuilder.Entity("Core.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("club_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("clubs", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Coach", b =>
                {
                    b.Property<int>("MembershipCardNum")
                        .HasColumnType("int")
                        .HasColumnName("membership_card_num");

                    b.Property<int>("ClubId")
                        .HasColumnType("int")
                        .HasColumnName("club_id");

                    b.Property<string>("InstructorCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("char(16)")
                        .HasColumnName("phone");

                    b.HasKey("MembershipCardNum");

                    b.HasIndex("ClubId");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("coaches", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("competition_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompetitionId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("city");

                    b.Property<string>("CompetitionLevel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("competition_level");

                    b.Property<string>("CurrentStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(30)")
                        .HasDefaultValue("pending")
                        .HasColumnName("current_status");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.Property<DateTime?>("WeightingDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("weighting_date");

                    b.HasKey("CompetitionId");

                    b.HasIndex("CurrentStatus");

                    b.HasIndex("Name", "StartDate")
                        .IsUnique();

                    b.ToTable("competitions", (string)null);
                });

            modelBuilder.Entity("Core.Entities.CompetitionStatus", b =>
                {
                    b.Property<string>("StatusName")
                        .HasMaxLength(30)
                        .HasColumnType("char(30)")
                        .HasColumnName("status_name");

                    b.HasKey("StatusName");

                    b.ToTable("competition_statuses", (string)null);

                    b.HasData(
                        new
                        {
                            StatusName = "pending"
                        },
                        new
                        {
                            StatusName = "accepting_applications"
                        },
                        new
                        {
                            StatusName = "accepting_applications_closed"
                        },
                        new
                        {
                            StatusName = "started"
                        },
                        new
                        {
                            StatusName = "finished"
                        },
                        new
                        {
                            StatusName = "canceled"
                        });
                });

            modelBuilder.Entity("Core.Entities.Competitor", b =>
                {
                    b.Property<int>("ApplicationNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("application_num");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationNum"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int")
                        .HasColumnName("competition_id");

                    b.Property<int>("MembershipCardNum")
                        .HasColumnType("int")
                        .HasColumnName("membership_card_num");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("belt_rank");

                    b.Property<int?>("WeightingResult")
                        .HasColumnType("int")
                        .HasColumnName("weighting_result");

                    b.HasKey("ApplicationNum");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("MembershipCardNum")
                        .IsUnique();

                    b.HasIndex("Rank");

                    b.ToTable("competitors", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Dayang", b =>
                {
                    b.Property<int>("DayangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("dayang_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayangId"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int")
                        .HasColumnName("competition_id");

                    b.HasKey("DayangId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("dayangs", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Judge", b =>
                {
                    b.Property<int>("MembershipCardNum")
                        .HasColumnType("int")
                        .HasColumnName("membership_card_num");

                    b.Property<string>("JudgeCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("judge_category");

                    b.HasKey("MembershipCardNum");

                    b.ToTable("judges", (string)null);
                });

            modelBuilder.Entity("Core.Entities.JudgeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.ToTable("judge_roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "side_judge"
                        },
                        new
                        {
                            Id = 2,
                            Name = "referee"
                        },
                        new
                        {
                            Id = 3,
                            Name = "chief_judge"
                        },
                        new
                        {
                            Id = 4,
                            Name = "deputy_chief_judge"
                        },
                        new
                        {
                            Id = 5,
                            Name = "reserve_judge"
                        });
                });

            modelBuilder.Entity("Core.Entities.Shuffle", b =>
                {
                    b.Property<int>("ShuffleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("shuffle_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShuffleId"));

                    b.Property<int>("CompetitorInBlueId")
                        .HasColumnType("int")
                        .HasColumnName("competitor_in_blue_id");

                    b.Property<int?>("CompetitorInRedId")
                        .HasColumnType("int")
                        .HasColumnName("competitor_in_red_id");

                    b.Property<int>("LapNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("lap_num");

                    b.Property<int>("PairSerialNum")
                        .HasColumnType("int")
                        .HasColumnName("pair_serial_num");

                    b.HasKey("ShuffleId");

                    b.HasIndex("CompetitorInBlueId", "CompetitorInRedId")
                        .IsUnique()
                        .HasFilter("[competitor_in_red_id] IS NOT NULL");

                    b.HasIndex("CompetitorInBlueId", "LapNum")
                        .IsUnique();

                    b.HasIndex("CompetitorInRedId", "LapNum")
                        .IsUnique()
                        .HasFilter("[competitor_in_red_id] IS NOT NULL");

                    b.ToTable("shuffles", null, t =>
                        {
                            t.HasCheckConstraint("CHK_shuffles_competitor_in_blue_id", "competitor_in_blue_id != competitor_in_red_id");
                        });
                });

            modelBuilder.Entity("Core.Entities.Sportsman", b =>
                {
                    b.Property<int>("MembershipCardNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("membership_card_num");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembershipCardNum"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<int?>("CoachMembershipCardNum")
                        .HasColumnType("int")
                        .HasColumnName("coach_membership_card_num");

                    b.Property<string>("Rank")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)")
                        .HasDefaultValue("10")
                        .HasColumnName("belt_rank");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("sex");

                    b.Property<string>("SportsCategory")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sports_category");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("MembershipCardNum");

                    b.HasIndex("CoachMembershipCardNum");

                    b.HasIndex("Rank");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("sportsmen", null, t =>
                        {
                            t.HasCheckConstraint("CHK_sportsmen_user_id", "sex IN ('M', 'F')");
                        });
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Regular",
                            NormalizedName = "REGULAR"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Coach", b =>
                {
                    b.HasOne("Core.Entities.Club", "Club")
                        .WithMany("Coaches")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Sportsman", "Sportsman")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Coach", "MembershipCardNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Sportsman");
                });

            modelBuilder.Entity("Core.Entities.Competition", b =>
                {
                    b.HasOne("Core.Entities.CompetitionStatus", "CompetitionStatus")
                        .WithMany()
                        .HasForeignKey("CurrentStatus");

                    b.Navigation("CompetitionStatus");
                });

            modelBuilder.Entity("Core.Entities.Competitor", b =>
                {
                    b.HasOne("Core.Entities.Competition", "Competition")
                        .WithMany("Competitors")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Sportsman", "Sportsman")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Competitor", "MembershipCardNum")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Belt", "Belt")
                        .WithMany()
                        .HasForeignKey("Rank")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Belt");

                    b.Navigation("Competition");

                    b.Navigation("Sportsman");
                });

            modelBuilder.Entity("Core.Entities.Dayang", b =>
                {
                    b.HasOne("Core.Entities.Competition", "Competition")
                        .WithMany("Dayangs")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("Core.Entities.Judge", b =>
                {
                    b.HasOne("Core.Entities.Sportsman", "Sportsman")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Judge", "MembershipCardNum")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sportsman");
                });

            modelBuilder.Entity("Core.Entities.Shuffle", b =>
                {
                    b.HasOne("Core.Entities.Competitor", "CompetitorInBlue")
                        .WithMany()
                        .HasForeignKey("CompetitorInBlueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Competitor", "CompetitorInRed")
                        .WithMany()
                        .HasForeignKey("CompetitorInRedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CompetitorInBlue");

                    b.Navigation("CompetitorInRed");
                });

            modelBuilder.Entity("Core.Entities.Sportsman", b =>
                {
                    b.HasOne("Core.Entities.Coach", "Coach")
                        .WithMany("Sportsmen")
                        .HasForeignKey("CoachMembershipCardNum");

                    b.HasOne("Core.Entities.Belt", "Belt")
                        .WithMany()
                        .HasForeignKey("Rank");

                    b.HasOne("Core.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Sportsman", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Belt");

                    b.Navigation("Coach");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Club", b =>
                {
                    b.Navigation("Coaches");
                });

            modelBuilder.Entity("Core.Entities.Coach", b =>
                {
                    b.Navigation("Sportsmen");
                });

            modelBuilder.Entity("Core.Entities.Competition", b =>
                {
                    b.Navigation("Competitors");

                    b.Navigation("Dayangs");
                });
#pragma warning restore 612, 618
        }
    }
}
