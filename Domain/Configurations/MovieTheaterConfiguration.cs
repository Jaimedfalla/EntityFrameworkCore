using ef7_example.Domain.Entities;
using ef7_example.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef7_example.Domain.Configurations;

public class MovieTheaterConfiguration : IEntityTypeConfiguration<MovieTheater>
{
    public void Configure(EntityTypeBuilder<MovieTheater> builder)
    {
        builder.Property(mt => mt.Price).HasPrecision(9,2);
        builder.Property(mt => mt.Type).HasDefaultValue(MovieTheaterType.ThreeD);
    }
}