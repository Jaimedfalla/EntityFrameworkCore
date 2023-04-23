using ef7_example.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ef7_example.Domain.Converters;

public class CurrencyToSymbol:ValueConverter<Currency,string>
{
    public CurrencyToSymbol()
        :base(
            value => ConvertCurrencyToString(value),
            value => ConvertStringToCurrency(value)
        )
    {
        
    }

    private static string ConvertCurrencyToString(Currency currency){
        return currency switch
        {
            Currency.ColombianPeso  => "$",
            Currency.UnitedStatesDollar => "USD$",
            Currency.Euro => "€",
            _ => ""
        };
    }

    private static Currency ConvertStringToCurrency(string value){
        return value switch
        {
            "$" =>Currency.ColombianPeso,
            "USD$" => Currency.UnitedStatesDollar,
            "€" => Currency.Euro,
            _ => Currency.Unknown
        };
    }
}
