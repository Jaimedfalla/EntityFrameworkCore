using Domain.Enums;

namespace webapi.DTOs;

public class MovieTheaterDto
{
    public decimal Price { get; set; }
    public MovieTheaterType Type { get; set; }
    public Currency Currency { get; set; }
}