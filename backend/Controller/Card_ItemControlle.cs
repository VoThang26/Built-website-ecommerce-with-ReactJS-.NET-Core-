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
    public class Card_ItemController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Card_ItemController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Card_Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card_Item>>> GetCardItems()
        {
            return await _context.Card_Items.ToListAsync();
        }

        // GET: api/Card_Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card_Item>> GetCardItem(Guid id)
        {
            var cardItem = await _context.Card_Items.FindAsync(id);

            if (cardItem == null)
            {
                return NotFound();
            }

            return cardItem;
        }

        // POST: api/Card_Item
        [HttpPost]
        public async Task<ActionResult<Card_Item>> PostCardItem(Card_Item cardItem)
        {
            _context.Card_Items.Add(cardItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCardItem), new { id = cardItem.id }, cardItem);
        }

        // PUT: api/Card_Item/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardItem(Guid id, Card_Item cardItem)
        {
            if (id != cardItem.id)
            {
                return BadRequest();
            }

            _context.Entry(cardItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardItemExists(id))
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

        // DELETE: api/Card_Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardItem(Guid id)
        {
            var cardItem = await _context.Card_Items.FindAsync(id);
            if (cardItem == null)
            {
                return NotFound();
            }

            _context.Card_Items.Remove(cardItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardItemExists(Guid id)
        {
            return _context.Card_Items.Any(e => e.id == id);
        }
    }
}
