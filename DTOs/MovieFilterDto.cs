namespace ef7_example.DTOs;

public class MovieFilterDTO
{
    public string Title { get; set; }
    public int GenderId { get; set; }
    public bool IsPlaying { get; set; }
    public bool UpcomingReleases { get; set; }
}