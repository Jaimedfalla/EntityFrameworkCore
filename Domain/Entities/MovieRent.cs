namespace Domain.Entities;

public class MovieRent
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public DateTime DateRenting { get; set; }
    public int PayId { get; set; }
    public Pay Pay { get; set; }
    public Movie Movie { get; set; }
}