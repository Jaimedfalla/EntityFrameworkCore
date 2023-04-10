using System.ComponentModel.DataAnnotations;

namespace ef7_example.DTOs;

public class ActorDto
{
    [Required]
    [StringLength(maximumLength:150)]
    public string Name { get; set; } = null!;
    public decimal Fortune { get; set; }
    public DateTime BirthDate { get; set; }
}