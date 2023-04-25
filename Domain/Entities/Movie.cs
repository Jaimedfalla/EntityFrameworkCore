namespace ef7_example.Domain.Entities;

public class Movie : BaseAuditableEntity
{
    public string Title { get; set; }=null!;
    public bool IsPlaying { get; set; }
    public DateTime Premiere { get; set; }
    public string PosterUrl { get; set; }

    public HashSet<Comment> Comments { get; set; } = new();
    public HashSet<Gender> Genders {get;set;} = new();
    public HashSet<MovieActor> MoviesActors {get;set;}
    public HashSet<MovieTheater> MovieTheaters { get; set; }
}