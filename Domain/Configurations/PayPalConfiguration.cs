using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class PaypalConfiguration : IEntityTypeConfiguration<PayPal>
{
    public void Configure(EntityTypeBuilder<PayPal> builder)
    {
        builder.Property(p=> p.Email).IsRequired();

        PayPal pay3 = new PayPal{
            Id = 3,
            TransactionDate = new DateTime(2023,05,06),
            Ammont = 157,
            PayType = Enums.PayType.PayPal,
            Email = "pomek40395@saeoil.com"
        };

        PayPal pay4 = new PayPal{
            Id=4,
            TransactionDate = new DateTime(2023,05,06),
            Ammont = 2_000_000,
            PayType = Enums.PayType.PayPal,
            Email = "devilinme@bukanimers.com"
        };

        builder.HasData(pay3,pay4);
    }
}