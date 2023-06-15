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
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Class)
                .WithMany(x => x.ClassUsers)
                .HasForeignKey(x => x.IdClass)
                .HasConstraintName("FK_ClassUser");
                //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
