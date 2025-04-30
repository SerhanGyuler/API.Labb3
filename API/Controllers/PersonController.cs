using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        // Hämta alla personer i systemet
        [HttpGet(Name = "GetPersons")]
        public async Task<ActionResult<ICollection<Person>>> GetPersons()
        {
            return Ok(await _context.Persons.ToListAsync());
        }

        // Koppla en person till ett nytt intresse
        [HttpPut("{personId:int}/{interestId:int}", Name = "AddPersonInterest")]
        public async Task<IActionResult> AddPersonInterest(int personId, int interestId)
        {
            var person = await _context.Persons
                .Where(p => p.Id == personId)
                .FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound(new { errorMessage = "Personen hittades inte." });
            }

            var interest = await _context.Interests
                .FirstOrDefaultAsync(i => i.Id == interestId);

            if (interest == null)
            {
                return NotFound(new { errorMessage = "Intresset hittades inte." });
            }

            // Hämta en länk som är kopplad till detta intresse
            var interestLink = await _context.Links
                .FirstOrDefaultAsync(l => l.Interests.Any(i => i.Id == interestId));
             
            if (interestLink == null)
            {
                return NotFound(new { errorMessage = "Ingen länk hittades för intresset." });
            }

            // Skapa ny länk-koppling
            var link = new Link
            {
                Url = interestLink.Url,
                Persons = new List<Person> { person },
                Interests = new List<Interest> { interest }
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Intresset {interest.Title} kopplades till {person.Name}." });
        }

        // Lägga till nya länkar för en specifik person och ett specifikt intresse
        [HttpPut("{personId:int}/{interestId:int}/addlink")]
        public async Task<IActionResult> AddLinkToPersonInterest(int personId, int interestId, [FromBody] string url)
        {
            var person = await _context.Persons
                .Where(p => p.Id == personId)
                .Include(p => p.Links)
                .FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound(new { errorMessage = "Personen hittades inte." });
            }

            var interest = await _context.Interests.FindAsync(interestId);

            if (interest == null)
            {
                return NotFound(new { errorMessage = "Intresset hittades inte." });
            }

            // Skapa en ny länk
            var link = new Link
            {
                Url = url,
                Persons = new List<Person> { person },
                Interests = new List<Interest> { interest }
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Ny länk '{url}' skapades och kopplades till {person.Name} och {interest.Title}." });
        }
    }
}
