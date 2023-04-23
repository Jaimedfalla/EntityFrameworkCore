using ef7_example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef7_example.Domain.Configurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("Actor");
        builder.Property(a => a.Name).IsRequired();
        builder.Property(a => a.Fortune).HasPrecision(18,2);
        builder.Property(a => a.Biography).HasMaxLength(int.MaxValue);
        
        // builder.Ignore(a => a.Age); //Esta es otra forma de ignorar el mapeo de una propiedad
    }
}