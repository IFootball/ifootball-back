using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings;

public class GenderMap: IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("gender");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();    
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("INT");
    }
}