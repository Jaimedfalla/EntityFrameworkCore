using ef7_example.Domain.Enums;

namespace ef7_example.Domain.Entities;

public class MovieTheater
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int CinemaId { get; set; }
    public MovieTheaterType Type { get; set; }
    public virtual Cinema Cinema{ get; set; }
    public virtual HashSet<Movie> Movies{get;set;}
}