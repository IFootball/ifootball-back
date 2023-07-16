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
            .IsRequired(false)
            .HasColumnName("id_captain")
            .HasColumnType("INT");
        
        builder
            .HasOne(x => x.Goalkeeper)
            .WithMany(x => x.TeamUsers)
            .HasForeignKey(x => x.IdGoalkeeper)
            .HasConstraintName("FK_goalkeeper_teamuser");
        
        builder
            .HasOne(x => x.LinePlayerBackLeft)
            .WithMany(x => x.TeamUsersBackLeft)
            .HasForeignKey(x => x.IdLinePlayerBackLeft)
            .HasConstraintName("FK_lineplayerbackleft_teamuser");
        
        builder
            .HasOne(x => x.LinePlayerBackRight)
            .WithMany(x => x.TeamUsersBackRight)
            .HasForeignKey(x => x.IdLinePlayerBackRight)
            .HasConstraintName("FK_lineplayerbackright_teamuser");
        
        builder
            .HasOne(x => x.LinePlayerFront)
            .WithMany(x => x.TeamUsersFront)
            .HasForeignKey(x => x.IdLinePlayerFront)
            .HasConstraintName("FK_lineplayerfront_teamuser");
        
        builder
            .HasOne(x => x.LinePlayerMiddle)
            .WithMany(x => x.TeamUsersMiddle)
            .HasForeignKey(x => x.IdLinePlayerMiddle)
            .HasConstraintName("FK_lineplayermiddle_teamuser");
        
        builder
            .HasOne(x => x.ReservePlayerOne)
            .WithMany(x => x.TeamUsersReserveOne)
            .HasForeignKey(x => x.IdReservePlayerOne)
            .HasConstraintName("FK_reserveplayerone_teamuser")
            .IsRequired(false);
        builder
            .HasOne(x => x.ReservePlayerTwo)
            .WithMany(x => x.TeamUsersReserveTwo)
            .HasForeignKey(x => x.IdReservePlayerTwo)
            .HasConstraintName("FK_reserveplayertwo_teamuser")
            .IsRequired(false);
        
        
        
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