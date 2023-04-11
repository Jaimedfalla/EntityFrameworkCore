using AutoMapper;
using AutoMapper.QueryableExtensions;
using ef7_example.Domain.Entities;
using ef7_example.DTOs;
using ef7_example.Infraestructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ef7_example.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController:ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MovieController(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieDTO>> Get(int id)
    {
        //Método Eager Loading
        var movie = await _context.Movies
            .Include(p => p.Genders.OrderByDescending(g => g.Name))
            .Include(p => p.MovieTheaters)
                .ThenInclude(s => s.Cinema)
            .Include(p => p.MoviesActors)
                .ThenInclude(pa => pa.Actor)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (movie is null)
        {
            return NotFound();
        }

        var movieDto = _mapper.Map<MovieDTO>(movie);
        movieDto.CinemaDtos = movieDto.CinemaDtos.DistinctBy(c => c.Id).ToList();

        return movieDto;
    }

    [HttpGet("projecto/{id:int}")]
    public async Task<ActionResult<MovieDTO>> GetProjectTo(int id)
    {
        var movie = await _context.Movies
            .ProjectTo<MovieDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (movie is null)
        {
            return NotFound();
        }

        movie.CinemaDtos = movie.CinemaDtos.DistinctBy(c => c.Id).ToList();

        return movie;
    }

    [HttpPost]
    public async Task<ActionResult> Post(MovieDTO movieCreation)
    {
        Movie movie = _mapper.Map<Movie>(movieCreation);

        if (movie.Genders is not null)
        {
            foreach (var gender in movie.Genders)
            {
                _context.Entry(gender).State = EntityState.Unchanged;
            }
        }

        if (movie.MoviesActors is not null)
        {
            for (int i = 0; i < movie.MoviesActors.Count; i++)
            {
                movie.MoviesActors.ElementAt(i).Order = i + 1;
            }
        }

        _context.Add(movie);
        await _context.SaveChangesAsync();
        
        return Ok();
    }

    [HttpGet("{page:int}/paginate/{size:int?}")]
    public async Task<IEnumerable<MovieDTO>> Paginate(int page = 1,int size = 20){

        IReadOnlyCollection<Movie> movies = await _context.Movies
            .Skip(page > 1 ? page * size:0)
            .Take(size)
            .OrderBy(m => m.Title)
            .ToListAsync();
        return _mapper.Map<IEnumerable<MovieDTO>>(movies);
    }

    [HttpGet("explicitloading/{id:int}")]
    public async Task<IActionResult> ExplicitGet(int id)
    {
        var movie = await _context.Movies.AsTracking().FirstOrDefaultAsync(m => m.Id==id);

        await _context.Entry(movie).Collection(m => m.Genders).LoadAsync();

        if(movie is null)
        {
            return NotFound();
        }

        var dto = _mapper.Map<MovieDTO>(movie);

        return Ok(dto);
    }
}