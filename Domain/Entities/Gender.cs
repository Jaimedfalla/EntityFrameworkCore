namespace Domain.Entities;

////Con la siguiente línea se puede crear un índice sobre la tabla y el campo indicado
//[Index(nameof(Name),IsUnique = true)]
public class Gender{
    public int Id {get;set;}
    
    public string Name {get;set;}

    public bool IsDeleted { get; set; }

    public HashSet<Movie> Movies {get;set;} = new();
}