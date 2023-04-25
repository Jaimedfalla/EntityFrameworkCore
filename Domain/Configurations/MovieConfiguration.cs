using ef7_example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef7_example.Domain.Configurations;

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
    }
}