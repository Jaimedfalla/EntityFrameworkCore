using System.ComponentModel.DataAnnotations.Schema;

namespace ef7_example.Domain.Entities;

public class Actor : BaseAuditableEntity
{
    public string Name { get; set; }
    public decimal Fortune { get; set; }
    public string Biography { get; set; }
    public DateTime? BirthDate { get; set; }

    [NotMapped]
    public int? Age{
        get{
            if(!BirthDate.HasValue) return null;

            DateTime dateValue = BirthDate.Value;
            int age = DateTime.Today.Year - dateValue.Year;

            if(new DateTime(DateTime.Today.Year,dateValue.Month,dateValue.Day)>DateTime.Today)
                age--;

            return age;
        }
    }

    public Address Address { get; set; }

    public ICollection<MovieActor> MoviesActors {get;set;} = new List<MovieActor>();
}