using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Person {

    public int Id { get; set; }
    
    public string Name { get; set; }

    //InverseProperty indica a cual llave foránea corresponde la colección
    [InverseProperty("Emitting")]
    public HashSet<Message> MessagesReceived { get; set; }

    [InverseProperty("Recipient")]
    public HashSet<Message> SentMessages { get; set; }
}