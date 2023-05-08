using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class CinemaConfigurations : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.ToTable("Cinema");
        builder.Property(c => c.Name).IsRequired();

        //Se configura una relación 1 a 1
        builder.HasOne(c=> c.Offer)
            .WithOne()
            .HasForeignKey<CinemaOffer>(o => o.CinemaId);

        //Configuración de 1 a muchos
        builder.HasMany(c => c.MovieTheaters)
            .WithOne(s => s.Cinema)
            .HasForeignKey(s => s.CinemaId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.Detail)
            .WithOne(d => d.Cinema)
            .HasForeignKey<CinemaDetail>(c => c.Id);

        builder.OwnsOne(a => a.Address,add => {
            add.Property(d => d.Location).HasColumnName("Address");
            add.Property(d => d.City).HasColumnName("City");
            add.Property(d => d.Country).HasColumnName("Country");
        });
    }
}