using AutoMapper;
using Domain.Entities;
using webapi.DTOs;
using Persistence.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers;

[ApiController]
[Route("api/movies/{movieId:int}/comments")]
public class CommentController: ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CommentController(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int movieId, CommentDTO commentDTO)
    {
        Movie exist = await _context.Movies.AsTracking().FirstOrDefaultAsync(m => m.Id==movieId);

        if(exist is null) return NotFound();

        Comment comment = _mapper.Map<Comment>(commentDTO);
        exist.Comments.Add(comment);
        _context.Entry(exist).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok();
    }
}