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
    public class SellController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public SellController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Sell
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sell>>> GetSells()
        {
            return await _context.Sells.ToListAsync();
        }

        // GET: api/Sell/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sell>> GetSell(int id)
        {
            var sell = await _context.Sells.FindAsync(id);

            if (sell == null)
            {
                return NotFound();
            }

            return sell;
        }

        // POST: api/Sell
        [HttpPost]
        public async Task<ActionResult<Sell>> PostSell(Sell sell)
        {
            _context.Sells.Add(sell);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSell), new { id = sell.id }, sell);
        }

        // PUT: api/Sell/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSell(int id, Sell sell)
        {
            if (id != sell.id)
            {
                return BadRequest();
            }

            _context.Entry(sell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellExists(id))
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

        // DELETE: api/Sell/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSell(int id)
        {
            var sell = await _context.Sells.FindAsync(id);
            if (sell == null)
            {
                return NotFound();
            }

            _context.Sells.Remove(sell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellExists(int id)
        {
            return _context.Sells.Any(e => e.id == id);
        }
    }
}
