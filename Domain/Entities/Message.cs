namespace Domain.Entities;

public class Message {

    public int Id { get; set; }

    public string Content { get; set; }

    public int EmittingId { get; set; }

    public int RecipientId { get; set; }

    public Person Emitting { get; set; }

    public Person Recipient { get; set; }

}