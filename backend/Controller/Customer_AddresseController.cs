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
    public class Customer_AddresseController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Customer_AddresseController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Customer_Addresse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer_Addresse>>> GetCustomer_Addresses()
        {
            return await _context.Customer_Addresses.ToListAsync();
        }

        // GET: api/Customer_Addresse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer_Addresse>> GetCustomer_Addresse(Guid id)
        {
            var customer_Addresse = await _context.Customer_Addresses.FindAsync(id);

            if (customer_Addresse == null)
            {
                return NotFound();
            }

            return customer_Addresse;
        }

        // POST: api/Customer_Addresse
        [HttpPost]
        public async Task<ActionResult<Customer_Addresse>> PostCustomer_Addresse(Customer_Addresse customer_Addresse)
        {
            _context.Customer_Addresses.Add(customer_Addresse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer_Addresse), new { id = customer_Addresse.id }, customer_Addresse);
        }

        // PUT: api/Customer_Addresse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer_Addresse(Guid id, Customer_Addresse customer_Addresse)
        {
            if (id != customer_Addresse.id)
            {
                return BadRequest();
            }

            _context.Entry(customer_Addresse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_AddresseExists(id))
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

        // DELETE: api/Customer_Addresse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer_Addresse(Guid id)
        {
            var customer_Addresse = await _context.Customer_Addresses.FindAsync(id);
            if (customer_Addresse == null)
            {
                return NotFound();
            }

            _context.Customer_Addresses.Remove(customer_Addresse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Customer_AddresseExists(Guid id)
        {
            return _context.Customer_Addresses.Any(e => e.id == id);
        }
    }
}
