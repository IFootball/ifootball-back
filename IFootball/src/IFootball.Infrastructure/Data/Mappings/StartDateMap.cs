using IFootball.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFootball.Infrastructure.Data.Mappings;

public class StartDateMap : IEntityTypeConfiguration<StartDate>
{
    public void Configure(EntityTypeBuilder<StartDate> builder)
    {
        builder.ToTable("start_date");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StartDateOfMatches)
            .IsRequired()
            .HasColumnName("start_date_of_matches")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);
    }
}