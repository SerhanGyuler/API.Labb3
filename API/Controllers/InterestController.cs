using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
            var person = await _context.Persons
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Name,
                    Interests = p.Links.SelectMany(l => l.Interests.Select(i => new
                    {
                        l.Url,
                        InterestTitle = i.Title,
                        InterestDescription = i.Description
                    })).ToList()
                })
                .FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound(new { errorMessage = "Personen hittades inte." });
            }

            return Ok(person);
        }


    }
}
