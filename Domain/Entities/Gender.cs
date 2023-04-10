namespace ef7_example.Domain.Entities;

public class Gender{
    public int Id {get;set;}
    public string Name {get;set;}

    public HashSet<Movie> Movies {get;set;} = new();
}