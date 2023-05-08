using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class PayConfiguration : IEntityTypeConfiguration<Pay>
{
    public void Configure(EntityTypeBuilder<Pay> builder)
    {
        builder.HasDiscriminator(p => p.PayType)
            .HasValue<PayPal>(Enums.PayType.PayPal)
            .HasValue<CreditCard>(Enums.PayType.TC);

        builder.Property(p => p.Ammont).HasPrecision(18,2);    
    }
}