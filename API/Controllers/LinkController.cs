﻿using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LinkController(AppDbContext context)
        {
            _context = context;
        }

        // Hämta alla länkar kopplade till en specifik person
        [HttpGet("{id:int}/links")]
        public async Task<ActionResult<IEnumerable<object>>> GetLinksByPersonId(int id)
        {
            var person = await _context.Persons
                .Where(p => p.Id == id)
                .Include(p => p.PersonInterests) // PersonInterest för personen
                .ThenInclude(pi => pi.Links) // Links via PersonInterest
                .Select(p => new
                {
                    p.Name,
                    Links = p.PersonInterests.SelectMany(pi => pi.Links.Select(l => new
                    {
                        l.Url
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
