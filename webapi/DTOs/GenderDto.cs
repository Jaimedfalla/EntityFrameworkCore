using System.ComponentModel.DataAnnotations;

namespace webapi.DTOs;

public class GenderDto
{
    [Required]
    [StringLength(maximumLength:150)]
    public string Name {get;set;}=null!;
}