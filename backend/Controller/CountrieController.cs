using vohoangthang.Exercise02.Context;
using vohoangthang.Exercise02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vohoangthang.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrieController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public CountrieController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Countrie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Countrie>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Countrie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countrie>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // POST: api/Countrie
        [HttpPost]
        public async Task<ActionResult<Countrie>> PostCountry(Countrie country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountry), new { id = country.id }, country);
        }

        // PUT: api/Countrie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Countrie country)
        {
            if (id != country.id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Countrie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.id == id);
        }
    }
}
