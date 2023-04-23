using ef7_example.Domain.Enums;

namespace ef7_example.DTOs;

public class MovieTheaterDto
{
    public decimal Price { get; set; }
    public MovieTheaterType Type { get; set; }
    public Currency Currency { get; set; }
}