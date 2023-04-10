namespace ef7_example.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }=null!;
    public bool IsPlaying { get; set; }
    public DateTime Premiere { get; set; }
    public string PosterUrl { get; set; }

    public virtual HashSet<Comment> Comments { get; set; } = new();
    public virtual HashSet<Gender> Genders {get;set;} = new();
    public virtual HashSet<MovieActor> MoviesActors {get;set;}
    public virtual HashSet<MovieTheater> MovieTheaters { get; set; }
}