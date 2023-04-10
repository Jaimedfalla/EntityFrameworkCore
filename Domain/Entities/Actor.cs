namespace ef7_example.Domain.Entities;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Fortune { get; set; }
    public string Biography { get; set; }
    public DateTime? BirthDate { get; set; }

    public virtual ICollection<MovieActor> MoviesActors {get;set;} = new List<MovieActor>();
}