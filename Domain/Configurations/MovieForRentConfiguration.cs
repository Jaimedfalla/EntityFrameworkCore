using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class MovieForRentConfiguration : IEntityTypeConfiguration<MovieForRent>
{
    public void Configure(EntityTypeBuilder<MovieForRent> builder)
    {
       builder.ToTable("MovieForRent");

       MovieForRent movieForRent = new(){
        Id=2,
        Name="Spider-Man",
        MovieId = 1,
        Price = 5.99m
       };

       builder.HasData(movieForRent);
    }
}
