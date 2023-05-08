using AutoMapper;
using Persistence.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace webapi.Controllers;

[ApiController]
[Route("api/actors")]
public class PersonController:ControllerBase
{
    public readonly ApplicationDbContext _context;
    public readonly IMapper _mapper;

    public PersonController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id) {
        Person person = await _context.People
                .Include(p => p.SentMessages)
                .Include(p => p.MessagesReceived)
                .FirstOrDefaultAsync(p=>p.Id== id);

        return Ok(person);
    }
}