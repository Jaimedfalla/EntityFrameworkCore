using ef7_example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef7_example.Domain.Configurations;

public class CinemaConfigurations : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.ToTable("Cinema");
        builder.Property(c => c.Name).IsRequired();
    }
}