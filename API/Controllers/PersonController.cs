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

        // Hämta alla personer
        [HttpGet(Name = "GetPersons")]
        public async Task<ActionResult<ICollection<Person>>> GetPersons()
        {
            var persons = await _context.Persons
                .Select(p => new {
                    p.Id,
                    p.Name,
                    p.PhoneNumber
                })
                .ToListAsync();

            return Ok(persons);
        }

        // Koppla en person till ett nytt intresse
        [HttpPut("{personId:int}/{interestId:int}", Name = "AddPersonInterest")]
        public async Task<IActionResult> AddPersonInterest(int personId, int interestId)
        {
            // Hämta personen från databasen
            var person = await _context.Persons
                .Where(p => p.Id == personId)
                .FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound(new { errorMessage = "Personen hittades inte." });
            }

            // Hämta intresset från databasen
            var interest = await _context.Interests
                .FirstOrDefaultAsync(i => i.Id == interestId);

            if (interest == null)
            {
                return NotFound(new { errorMessage = "Intresset hittades inte." });
            }

            // Kontrollera om relationen redan finns (Person-Interest relation)
            var personInterest = await _context.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interestId);

            if (personInterest != null)
            {
                return BadRequest(new { errorMessage = "Personen har redan det här intresset." });
            }

            // Skapa ny person-interest relation
            var newPersonInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interestId
            };

            _context.PersonInterests.Add(newPersonInterest);

            // Hämta länken som är kopplad till intresset
            var interestLink = await _context.Links
                .FirstOrDefaultAsync(l => l.PersonId == personId && l.InterestId == interestId);

            if (interestLink == null)
            {
                // Skapa ny länk om den inte redan finns
                var newLink = new Link
                {
                    Url = "https://example.com", // Sätt en lämplig URL
                    PersonId = personId,
                    InterestId = interestId
                };

                _context.Links.Add(newLink);
            }

            // Spara förändringarna
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Intresset {interest.Title} kopplades till {person.Name}." });
        }

        // Lägga till nya länkar för en specifik person och ett specifikt intresse
        [HttpPut("{personId:int}/{interestId:int}/addlink")]
        public async Task<IActionResult> AddLinkToPersonInterest(int personId, int interestId, [FromBody] string url)
        {
            var personInterest = await _context.PersonInterests
                .Include(pi => pi.Person)
                .Include(pi => pi.Interest)
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interestId);

            if (personInterest == null)
            {
                return NotFound(new { errorMessage = "Person-Interest koppling hittades inte." });
            }

            // Skapa en ny länk och koppla den till PersonInterest
            var link = new Link
            {
                Url = url,
                PersonId = personInterest.PersonId,
                InterestId = personInterest.InterestId
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Ny länk '{url}' skapades och kopplades till {personInterest.Person.Name} och {personInterest.Interest.Title}." });
        }


    }
}
