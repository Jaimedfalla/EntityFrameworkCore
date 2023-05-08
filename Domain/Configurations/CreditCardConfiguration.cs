using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.Property(t => t.LastFourDigits).HasColumnType("CHAR(4)").IsRequired();

        CreditCard pay1 = new CreditCard{
            Id=1,
            TransactionDate = new DateTime(2023,05,06),
            Ammont = 5_000_000,
            PayType = Enums.PayType.TC,
            LastFourDigits = 9897
        };

        CreditCard pay2 = new CreditCard{
            Id=2,
            TransactionDate = new DateTime(2023,05,06),
            Ammont = 2_000_000,
            PayType = Enums.PayType.TC,
            LastFourDigits = 3258
        };

        builder.HasData(pay1,pay2);
    }
}