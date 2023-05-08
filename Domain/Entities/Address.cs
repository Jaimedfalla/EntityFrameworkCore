using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Owned] //Esta entidad se utiliza para definir una entidad centralizada para definir propiedades en otras entidades, por lo que no se requiere tabla
// Este concepto se utiliza cuando se quiere reutilizar un concepto en varias entidades
public class Address
{
    public string Location { get; set; }    
    public string City { get; set; }

    [Required]
    public string Country { get; set; }
}