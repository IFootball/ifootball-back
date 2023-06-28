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
        
        builder
            .HasOne(x => x.Goalkeeper)
            .WithMany(x => x.TeamUsers)
            .HasForeignKey(x => x.IdGoalkeeper)
            .HasConstraintName("FK_goalkeeper_teamuser");
        
        builder
            .HasOne(x => x.Coach)
            .WithMany(x => x.TeamUsers)
            .HasForeignKey(x => x.IdCoach)
            .HasConstraintName("FK_coach_teamuser");
        
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
            .HasOne(x => x.LinePlayerFrontLeft)
            .WithMany(x => x.TeamUsersFrontLeft)
            .HasForeignKey(x => x.IdLinePlayerFrontLeft)
            .HasConstraintName("FK_lineplayerfrontleft_teamuser");
        
        builder
            .HasOne(x => x.LinePlayerFrontRight)
            .WithMany(x => x.TeamUsersFrontRight)
            .HasForeignKey(x => x.IdLinePlayerFrontRight)
            .HasConstraintName("FK_lineplayerfrontright_teamuser");
        
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