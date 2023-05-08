namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Persistence.Database;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

[Route("api/pays")]
[ApiController]
public class PayController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PayController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Pay> pays = await _context.Pays.ToListAsync();
        
        return Ok(pays);
    }

    [HttpGet("Cards")]
    public async Task<ActionResult> GetCardsAsync()
    {
        IEnumerable<CreditCard> cards = await _context.Pays.OfType<CreditCard>().ToListAsync();        

        return Ok(cards);
    }

    [HttpGet("Paypal")]
    public async Task<ActionResult> GetPayPalAsync()
    {
        IEnumerable<PayPal> cards = await _context.Pays.OfType<PayPal>().ToListAsync();        

        return Ok(cards);
    }
}