using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
    {
        builder.HasKey(pa => new{pa.ActorId, pa.MovieId});

        //Configurar una relación muchos a muchos manualmente que se puede evitar con la declaración por convención
        builder.HasOne(pa => pa.Actor)
            .WithMany(pa => pa.MoviesActors)
            .HasForeignKey(pa => pa.ActorId);

        builder.HasOne(pa => pa.Movie)
            .WithMany(pa => pa.MoviesActors)
            .HasForeignKey(pa => pa.MovieId);
    }
}