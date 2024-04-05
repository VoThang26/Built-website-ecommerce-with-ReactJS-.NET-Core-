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
    public class Shipping_RateController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Shipping_RateController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Shipping_Rate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping_Rate>>> GetShipping_Rates()
        {
            return await _context.Shipping_Rates.ToListAsync();
        }

        // GET: api/Shipping_Rate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping_Rate>> GetShipping_Rate(Guid id)
        {
            var shipping_Rate = await _context.Shipping_Rates.FindAsync(id);

            if (shipping_Rate == null)
            {
                return NotFound();
            }

            return shipping_Rate;
        }

        // POST: api/Shipping_Rate
        [HttpPost]
        public async Task<ActionResult<Shipping_Rate>> PostShipping_Rate(Shipping_Rate shipping_Rate)
        {
            _context.Shipping_Rates.Add(shipping_Rate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShipping_Rate), new { id = shipping_Rate.id }, shipping_Rate);
        }

        // PUT: api/Shipping_Rate/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping_Rate(Guid id, Shipping_Rate shipping_Rate)
        {
            if (id != shipping_Rate.id)
            {
                return BadRequest();
            }

            _context.Entry(shipping_Rate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Shipping_RateExists(id))
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

        // DELETE: api/Shipping_Rate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping_Rate(Guid id)
        {
            var shipping_Rate = await _context.Shipping_Rates.FindAsync(id);
            if (shipping_Rate == null)
            {
                return NotFound();
            }

            _context.Shipping_Rates.Remove(shipping_Rate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Shipping_RateExists(Guid id)
        {
            return _context.Shipping_Rates.Any(e => e.id == id);
        }
    }
}
