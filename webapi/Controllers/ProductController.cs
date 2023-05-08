using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace webapi.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController: ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Product> products = await _context.Products.ToListAsync();

        return Ok(products);
    }

    [HttpGet("merchs")]
    public async Task<IActionResult> GetMerchs()
    {
        //Set se utiliza sobre todo en los casos cuando se utliza entidades derivadas en diferentes tablas
        IEnumerable<Merchandising> merchs = await _context.Set<Merchandising>().ToListAsync(); 

        return Ok(merchs);
    }

    
    [HttpGet("movies")]
    public async Task<IActionResult> GetMovies()
    {
        //Set se utiliza sobre todo en los casos cuando se utliza entidades derivadas en diferentes tablas
        IEnumerable<MovieForRent> movies = await _context.Set<MovieForRent>().ToListAsync(); 

        return Ok(movies);
    }
}