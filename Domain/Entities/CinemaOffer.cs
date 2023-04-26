namespace Domain.Entities;

public class CinemaOffer
{
    public int Id { get; set; }
    public DateTime InitialDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Discount { get; set; }
    public int CinemaId { get; set; }
}