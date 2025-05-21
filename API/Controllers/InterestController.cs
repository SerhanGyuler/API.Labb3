using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly AppDbContext _context;
        public InterestController(AppDbContext context)
        {
            _context = context;
        }

        // Hämta alla intressen kopplade till en specifik person
        [HttpGet("{id:int}/interests")]
        public async Task<ActionResult<IEnumerable<object>>> GetInterestsByPersonId(int id)
        {
            // Hämta personens relaterade intressen genom personInterest-kopplingen
            var personWithInterests = await _context.Persons
                .Where(p => p.Id == id)
                .Include(p => p.PersonInterests)  // Inkludera PersonInterest-relationen
                .ThenInclude(pi => pi.Interest)  // Inkludera Interest-relationen
                .ThenInclude(i => i.PersonInterests) // För att få tillgång till Links via PersonInterest
                .ThenInclude(pi => pi.Links) // Inkludera Links från PersonInterest
                .Select(p => new
                {
                    p.Name,
                    Interests = p.PersonInterests.Select(pi => new
                    {
                        InterestTitle = pi.Interest.Title,
                        InterestDescription = pi.Interest.Description,
                        Links = pi.Links.Select(link => new
                        {
                            link.Url
                        }).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (personWithInterests == null)
            {
                return NotFound(new { errorMessage = "Personen hittades inte." });
            }

            return Ok(personWithInterests);
        }

    }
}
