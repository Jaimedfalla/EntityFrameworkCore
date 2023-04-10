namespace ef7_example.Domain.Entities;

public class Comment
{
    public int Id { get; set; }

    public string Content{get;set;}

    public bool Recommend {get;set;}

    public int MovieId{get;set;}

    public virtual Movie Movie{get;set;} = null!;
}