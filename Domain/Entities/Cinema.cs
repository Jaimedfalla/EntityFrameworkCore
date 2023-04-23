using NetTopologySuite.Geometries;

namespace ef7_example.Domain.Entities;

public class Cinema
{
    public int Id { get; set; }
    public string Name {get; set; }
    public Point Location { get; set; }
    public CinemaOffer Offer { get; set; }
    public HashSet<MovieTheater> MovieTheaters{ get; set; }
}