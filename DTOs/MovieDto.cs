namespace ef7_example.DTOs;

public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsPlaying { get; set; }
        public DateTime Premiere { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<int> Genders { get; set; } = new List<int>();
        public ICollection<CinemaDto> CinemaDtos{get;set;}
        public ICollection<MovieActorDto> MoviesActors {get;set;}
    }