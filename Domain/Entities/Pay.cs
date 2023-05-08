using Domain.Enums;

namespace Domain.Entities;

public abstract class Pay
{
    public int Id { get; set; }
    public decimal Ammont { get; set; }
    public DateTime TransactionDate { get; set; }
    public PayType PayType { get; set; }
}