namespace ef7_example.Domain.Entities;

public class MovieActor
{
    public int MovieId { get; set; }
    public int ActorId { get; set; }
    public string Character{get; set;} = null!;
    public int Order { get; set; }

    public virtual Movie Movie {get; set;} = null!;
    public virtual Actor Actor {get; set;} = null!;
}