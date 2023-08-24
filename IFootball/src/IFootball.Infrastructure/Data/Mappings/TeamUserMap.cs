using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings;

public class TeamUserMap : IEntityTypeConfiguration<TeamUser>
{
    public void Configure(EntityTypeBuilder<TeamUser> builder)
    {
        builder.ToTable("team_user");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();  
        
        builder.Property(x => x.IdCaptain)
            .IsRequired()
            .HasColumnName("id_captain")
            .HasColumnType("INT");
        
        builder
            .HasOne(x => x.Goalkeeper)
            .WithMany(x => x.TeamUsersGoalkeeper)
            .HasForeignKey(x => x.IdGoalkeeper)
            .HasConstraintName("FK_goalkeeper_teamuser");
        
        builder
            .HasOne(x => x.PlayerFour)
            .WithMany(x => x.TeamUsersFour)
            .HasForeignKey(x => x.IdPlayerFour)
            .HasConstraintName("FK_playerFour_teamuser");
        
        builder
            .HasOne(x => x.PlayerTwo)
            .WithMany(x => x.TeamUsersTwo)
            .HasForeignKey(x => x.IdPlayerTwo)
            .HasConstraintName("FK_playerTwo_teamuser");
        
        builder
            .HasOne(x => x.PlayerOne)
            .WithMany(x => x.TeamUsersOne)
            .HasForeignKey(x => x.IdPlayerOne)
            .HasConstraintName("FK_playerOne_teamuser");
        
        builder
            .HasOne(x => x.PlayerThree)
            .WithMany(x => x.TeamUsersThree)
            .HasForeignKey(x => x.IdPlayerThree)
            .HasConstraintName("FK_playerThree_teamuser");

        builder
            .HasOne(x => x.ReservePlayerOne)
            .WithMany(x => x.TeamUsersReserveOne)
            .HasForeignKey(x => x.IdReservePlayerOne)
            .HasConstraintName("FK_reserveplayerone_teamuser");
        builder
            .HasOne(x => x.ReservePlayerTwo)
            .WithMany(x => x.TeamUsersReserveTwo)
            .HasForeignKey(x => x.IdReservePlayerTwo)
            .HasConstraintName("FK_reserveplayertwo_teamuser");
        
        
        
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserTeamsUser)
            .HasForeignKey(x => x.IdUser)
            .HasConstraintName("FK_user_teamuser");
        
        builder
            .HasOne(x => x.Gender)
            .WithMany(x => x.GenderTeamUsers)
            .HasForeignKey(x => x.IdGender)
            .HasConstraintName("FK_gender_teamuser");
    }
}