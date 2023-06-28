using System.Collections.Immutable;
using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(128);

            builder.Property(x=> x.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);
            
            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(128);

            builder.Property(x => x.Role)
                .IsRequired()
                .HasColumnType("role")
                .HasColumnType("INT");

            builder
                .HasOne(x => x.Class)
                .WithMany(x => x.ClassUsers)
                .HasForeignKey(x => x.IdClass)
                .HasConstraintName("FK_class_user")
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
