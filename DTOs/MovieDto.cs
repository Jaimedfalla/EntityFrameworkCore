namespace ef7_example.DTOs;

public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsPlaying { get; set; }
        public DateTime Premiere { get; set; }
        public ICollection<GenderDto> Genders { get; set; } = new List<GenderDto>();
        public ICollection<CinemaDto> CinemaDtos{get;set;}
        public ICollection<ActorDto> Actors {get;set;}
    }