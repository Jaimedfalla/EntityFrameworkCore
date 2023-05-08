using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movie");
        builder.Property(m => m.Title).IsRequired();
        builder.OwnsMany(c => c.Comments,ownedNavigationBuilder =>
            ownedNavigationBuilder.ToJson()
        );
        //Cuando es Unicode, se permiten caracteres espciales y se recomienda usarlo para texto escrito por el usuario
        builder.Property(m => m.PosterUrl).HasMaxLength(500).IsUnicode(false);

        /* builder.HasMany(p => p.Genders)
            .WithMany(g => g.Movies)
            //Cambiar el nombre de la tabla intermedia
            .UsingEntity(j => j.ToTable("GendersMovies")); */
    }
}