using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings;

public class CoachMap: IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.ToTable("coche");

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

        
        builder
            .HasOne(x => x.Class)
            .WithMany(x => x.ClassCoches)
            .HasForeignKey(x => x.IdClass)
            .HasConstraintName("FK_class_coach");

        builder
            .HasOne(x => x.TeamClass)
            .WithOne(x => x.TeamClassCoach)
            .HasForeignKey<Coach>(x => x.IdTeamClass)
            .HasConstraintName("FK_teamclass_coach");
        
        builder
            .HasOne(x => x.Gender)
            .WithMany(x => x.GenderCoaches)
            .HasForeignKey(x => x.IdGender)
            .HasConstraintName("FK_gender_coach");
    }
}  