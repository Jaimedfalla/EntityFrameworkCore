using System.ComponentModel.DataAnnotations;

namespace ef7_example.DTOs;

public class GenderDto
{
    [Required]
    [StringLength(maximumLength:150)]
    public string Name {get;set;}=null!;
}