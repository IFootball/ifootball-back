using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings;

public class PlayerMap: IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("player");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();


        builder.Property(x => x.PlayerType)
            .IsRequired()
            .HasColumnName("player_type")
            .HasColumnType("INT");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128);
        
        builder.Property(x => x.Image)
            .IsRequired(false)
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
            .HasOne(x => x.TeamClass)
            .WithMany(x => x.TeamClassPlayers)
            .HasForeignKey(x => x.IdTeamClass)
            .HasConstraintName("FK_teamclass_lineplayer");
        
        builder
            .HasOne(x => x.Gender)
            .WithMany(x => x.GenderPlayers)
            .HasForeignKey(x => x.IdGender)
            .HasConstraintName("FK_gender_lineplayer");
    }
}
