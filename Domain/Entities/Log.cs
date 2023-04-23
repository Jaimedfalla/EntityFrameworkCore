using System.ComponentModel.DataAnnotations.Schema;

namespace ef7_example.Domain.Entities;

public class Log
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)] //Este atributo se coloca cuando se quiere generar el id de manera manual
    public Guid Id { get; set; }
    public string Message { get; set; }    
}