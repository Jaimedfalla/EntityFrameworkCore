using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("Actor");
        builder.Property(a => a.Name).IsRequired();
        builder.Property(a => a.Fortune).HasPrecision(18,2);
        builder.Property(a => a.Biography).HasMaxLength(int.MaxValue);

        //Aquí se configuran las columnas de la entidad Address como columnas de la propiedad Home de Actor
        builder.OwnsOne(a => a.Home,add =>{
            add.Property(d => d.City).HasColumnName("HomeCity");
            add.Property(d => d.Country).HasColumnName("HomeCountry");
            add.Property(d => d.Location).HasColumnName("Location");
        });
        
        // builder.Ignore(a => a.Age); //Esta es otra forma de ignorar el mapeo de una propiedad
    }
}