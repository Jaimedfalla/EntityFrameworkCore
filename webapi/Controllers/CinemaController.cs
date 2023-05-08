using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using webapi.DTOs;
using Persistence.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;

namespace webapi.Controllers;

[ApiController]
[Route("api/cinemas")]
public class CinemaController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CinemaController(ApplicationDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CinemaDto>> Get()
    {
        return await _context.Cinemas
            .ProjectTo<CinemaDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    [HttpGet("netxto")]
    public async Task<IActionResult> Get(double latitude, double longitude)
    {
        var geometry = NtsGeometryServices.Instance.CreateGeometryFactory(srid:4326);
        var myLocation = geometry.CreatePoint(new NetTopologySuite.Geometries.Coordinate(longitude,latitude));
        int maxDistanceMeters = 2000;
        var cinemas = await _context.Cinemas
            .Where(c => c.Location.IsWithinDistance(myLocation,maxDistanceMeters))
            .OrderBy(c => c.Location.Distance(myLocation))
            .Select(c => new{
                c.Name,
                Distance = Math.Round(c.Location.Distance(myLocation))
            }).ToListAsync();

        return Ok(cinemas);
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var geometry = NtsGeometryServices.Instance.CreateGeometryFactory(srid:4326);
        var cinemaLocation = geometry.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-74.09532666324002, 4.749347627228026));

        Cinema cinema = new Cinema
        {
            Name="Cinemark Plaza Imperial con Restrict",
            Location = cinemaLocation,
            Offer = new CinemaOffer{
                Discount = 5,
                EndDate = DateTime.Today.AddDays(7),
                InitialDate = DateTime.Today
            },
            MovieTheaters = new HashSet<MovieTheater>{
                new MovieTheater{
                    Price = 5_000,
                    Currency = Domain.Enums.Currency.ColombianPeso,
                    Type = Domain.Enums.MovieTheaterType.TwoD
                },
                new MovieTheater{
                    Price = 11_000,
                    Currency = Domain.Enums.Currency.Euro,
                    Type = Domain.Enums.MovieTheaterType.ThreeD
                }
            }
        };

        _context.Add(cinema);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("dto")]
    public async Task<IActionResult> Post(CinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Add(cinema);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) {
        int affected = await _context.Cinemas.Where(c => c.Id==id).ExecuteDeleteAsync();

        if(affected == 0) return NotFound();

        return NoContent();        
    }
}