﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

internal class CompetitionStatusConfiguration
    : IEntityTypeConfiguration<CompetitionStatus>
{
    public void Configure(EntityTypeBuilder<CompetitionStatus> builder)
    {
        builder.ToTable("competition_statuses");

        builder.HasKey(cs => cs.Id);
        
        builder
            .Property(ic => ic.Id)
            .HasColumnName("id");
        
        builder
            .Property(ic => ic.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .HasIndex(ic => ic.Name)
            .IsUnique();
    }
}