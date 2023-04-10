using AutoMapper;
using AutoMapper.QueryableExtensions;
using ef7_example.DTOs;
using ef7_example.Infraestructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;

namespace ef7_example.Controllers;

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
}