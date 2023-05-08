namespace Domain.Entities;

public class Merchandising : Product
{
    public bool EnableInInventory { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    public bool IsClothe { get; set; }
    public bool IsCollectible { get; set; }
}