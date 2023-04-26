using Domain.Enums;

namespace Domain.Entities;

public class MovieTheater
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int CinemaId { get; set; }
    public MovieTheaterType Type { get; set; }
    public Cinema Cinema{ get; set; }
    public Currency Currency { get; set; }
    public HashSet<Movie> Movies{get;set;}
}