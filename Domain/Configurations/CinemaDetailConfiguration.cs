using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class CinemaDetailConfiguration : IEntityTypeConfiguration<CinemaDetail>
{
    public void Configure(EntityTypeBuilder<CinemaDetail> builder)
    {
       builder.ToTable("Cinema");
    }
}