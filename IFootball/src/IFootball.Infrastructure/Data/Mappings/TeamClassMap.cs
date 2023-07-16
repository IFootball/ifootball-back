using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings;

public class TeamClassMap: IEntityTypeConfiguration<TeamClass>
{
    public void Configure(EntityTypeBuilder<TeamClass> builder)
    {
        builder.ToTable("team_class");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(x => x.Class)
            .WithMany(x => x.TeamClasses)
            .HasForeignKey(x => x.IdClass)
            .HasConstraintName("FK_class_teamclass");
        
        builder
            .HasOne(x => x.Gender)
            .WithMany(x => x.GenderTeamClasses)
            .HasForeignKey(x => x.IdGender)
            .HasConstraintName("FK_gender_teamclass");
    }
}