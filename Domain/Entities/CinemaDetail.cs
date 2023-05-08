using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class CinemaDetail
{
    public int Id { get; set; }
    //Table spliting exige tener una columna requerida
    [Required]
    public string History { get; set; }
    public string Principles { get; set; }
    public string Mission { get; set; }
    public string EthicalCode { get; set; }

    //Para hacer table spliting, se debe configurar una relación 1 a 1
    public Cinema Cinema { get; set; }
}