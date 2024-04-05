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
    public class Order_ItemController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Order_ItemController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Order_Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order_Item>>> GetOrderItems()
        {
            return await _context.Order_Items.ToListAsync();
        }

        // GET: api/Order_Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order_Item>> GetOrderItem(Guid id)
        {
            var orderItem = await _context.Order_Items.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // POST: api/Order_Item
        [HttpPost]
        public async Task<ActionResult<Order_Item>> PostOrderItem(Order_Item orderItem)
        {
            _context.Order_Items.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderItem), new { id = orderItem.id }, orderItem);
        }

        // PUT: api/Order_Item/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(Guid id, Order_Item orderItem)
        {
            if (id != orderItem.id)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
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

        // DELETE: api/Order_Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var orderItem = await _context.Order_Items.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.Order_Items.Remove(orderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderItemExists(Guid id)
        {
            return _context.Order_Items.Any(e => e.id == id);
        }
    }
}
