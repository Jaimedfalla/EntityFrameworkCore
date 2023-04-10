using ef7_example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef7_example.Domain.Configurations;

public class CinemaSupplyConfiguration : IEntityTypeConfiguration<CinemaOffer>
{
    public void Configure(EntityTypeBuilder<CinemaOffer> builder)
    {
        builder.ToTable("CinemaOffer");
        builder.Property(cs => cs.Discount).HasPrecision(precision: 5, scale:2);
    }
}