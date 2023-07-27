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

        builder
            .HasOne(x => x.Player)
            .WithOne(x => x.Goalkeeper)
            .HasForeignKey<Goalkeeper>(x => x.IdPlayer)
            .HasConstraintName("FK_player_goalkeeper");
    }
}