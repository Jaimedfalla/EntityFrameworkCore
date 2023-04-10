using ef7_example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef7_example.Domain.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("Gender");
        builder.HasIndex(g => g.Name).IsUnique();
    }
}