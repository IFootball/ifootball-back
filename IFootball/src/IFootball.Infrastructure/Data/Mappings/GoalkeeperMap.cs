using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings;

public class GoalkeeperMap: IEntityTypeConfiguration<Goalkeeper>
{
    public void Configure(EntityTypeBuilder<Goalkeeper> builder)
    {
        builder.ToTable("goalkeeper");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();  
        
        
        builder.Property(x => x.TakenGols)
            .IsRequired()
            .HasColumnName("taken_gols")
            .HasColumnType("INT");
        
        builder.Property(x => x.PenaltySaves)
            .IsRequired()
            .HasColumnName("penalty_saves")
            .HasColumnType("INT");
        
        builder.Property(x => x.Saves)
            .IsRequired()
            .HasColumnName("saves")
            .HasColumnType("INT");
        
        
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
            .WithMany(x => x.ClassGoalkeepers)
            .HasForeignKey(x => x.IdClass)
            .HasConstraintName("FK_class_goalkeeper");

        builder
            .HasOne(x => x.TeamClass)
            .WithMany(x => x.TeamClassGoalkeepers)
            .HasForeignKey(x => x.IdTeamClass)
            .HasConstraintName("FK_teamclass_goalkeeper");
        
        builder
            .HasOne(x => x.Gender)
            .WithMany(x => x.GenderGoalkeepers)
            .HasForeignKey(x => x.IdGender)
            .HasConstraintName("FK_gender_goalkepper");
    }
}