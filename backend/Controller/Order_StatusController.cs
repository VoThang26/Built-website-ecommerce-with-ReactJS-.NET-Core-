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
    public class Order_StatusController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Order_StatusController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Order_Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order_Status>>> GetOrderStatuses()
        {
            return await _context.Order_Statuses.ToListAsync();
        }

        // GET: api/Order_Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order_Status>> GetOrderStatus(Guid id)
        {
            var orderStatus = await _context.Order_Statuses.FindAsync(id);

            if (orderStatus == null)
            {
                return NotFound();
            }

            return orderStatus;
        }

        // POST: api/Order_Status
        [HttpPost]
        public async Task<ActionResult<Order_Status>> PostOrderStatus(Order_Status orderStatus)
        {
            _context.Order_Statuses.Add(orderStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderStatus), new { id = orderStatus.id }, orderStatus);
        }

        // PUT: api/Order_Status/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderStatus(Guid id, Order_Status orderStatus)
        {
            if (id != orderStatus.id)
            {
                return BadRequest();
            }

            _context.Entry(orderStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderStatusExists(id))
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

        // DELETE: api/Order_Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderStatus(Guid id)
        {
            var orderStatus = await _context.Order_Statuses.FindAsync(id);
            if (orderStatus == null)
            {
                return NotFound();
            }

            _context.Order_Statuses.Remove(orderStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderStatusExists(Guid id)
        {
            return _context.Order_Statuses.Any(e => e.id == id);
        }
    }
}
