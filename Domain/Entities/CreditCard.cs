namespace Domain.Entities;

public class CreditCard : Pay
{
    public int LastFourDigits { get; set; }
}