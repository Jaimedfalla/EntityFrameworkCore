using System.ComponentModel.DataAnnotations;

namespace ef7_example.DTOs;
public class CinemaDto
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public CinemaOfferCreateDto CinemaOffer { get; set; }
    public ICollection<MovieTheaterDto> MovieTheaters { get; set; }
}