﻿using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings;

public class LinePlayerMap: IEntityTypeConfiguration<LinePlayer>
{
    public void Configure(EntityTypeBuilder<LinePlayer> builder)
    {
        builder.ToTable("line_player");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();  
        
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128);
        
        builder.Property(x => x.Image)
            .IsRequired()
            .HasColumnName("image")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(512);

        builder.Property(x => x.Goals)
            .IsRequired()
            .HasColumnName("goals")
            .HasColumnType("INT");

        builder.Property(x => x.Assists)
            .IsRequired()
            .HasColumnName("assists")
            .HasColumnType("INT");
        
        builder.Property(x => x.YellowCard)
            .IsRequired()
            .HasColumnName("yellow_card")
            .HasColumnType("INT");
        
        builder.Property(x => x.RedCard)
            .IsRequired()
            .HasColumnName("red_card")
            .HasColumnType("INT");
        
        builder.Property(x => x.Wins)
            .IsRequired()
            .HasColumnName("wins")
            .HasColumnType("INT");
        
        builder.Property(x => x.Fouls)
            .IsRequired()
            .HasColumnName("fouls")
            .HasColumnType("INT");
        
        
        builder
            .HasOne(x => x.Class)
            .WithMany(x => x.ClassLinePlayer)
            .HasForeignKey(x => x.IdClass)
            .HasConstraintName("FK_class_lineplayer");

        builder
            .HasOne(x => x.TeamClass)
            .WithMany(x => x.TeamClassLinePlayers)
            .HasForeignKey(x => x.IdTeamClass)
            .HasConstraintName("FK_teamclass_lineplayer");
        
        builder
            .HasOne(x => x.Gender)
            .WithMany(x => x.GenderLinePlayers)
            .HasForeignKey(x => x.IdGender)
            .HasConstraintName("FK_gender_lineplayer");
    }
}
