using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Configurations;

public class MerchandisingConfiguration : IEntityTypeConfiguration<Merchandising>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Merchandising> builder)
    {
        builder.ToTable("Merchandising");

        Merchandising product1 = new(){
            Id = 1,
            EnableInInventory = true,
            IsClothe =true,
            Name = "T-Shirt One Piece",
            Weight= 1,
            Volume = 1,
            Price = 11
        };

        builder.HasData(product1);
    }
}