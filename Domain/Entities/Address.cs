using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[NotMapped]
public class Address
{
    public string Location { get; set; }    
    public string City { get; set; }

    public string Country { get; set; }
}