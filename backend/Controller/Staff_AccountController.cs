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
    public class Staff_AccountController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Staff_AccountController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Staff_Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetStaffAccounts()
        {
            var staff_Accounts = await _context
                .StaffAccounts
                .Select(sa => new
                {
                    sa.id,
                    sa.role_id,
                    sa.first_name,
                    sa.last_name,
                    sa.phone_number,
                    sa.email,
                    sa.active,
                    sa.image,
                    sa.placeholder,
                    sa.registered_at,
                    sa.updated_at,
                    sa.created_by,
                    sa.updated_by
                })
                .ToListAsync();

            return staff_Accounts;
        }

        // GET: api/Staff_Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff_Account>> GetStaff_Account(Guid id)
        {
            var staff_Account = await _context.StaffAccounts.FindAsync(id);

            if (staff_Account == null)
            {
                return NotFound();
            }

            return staff_Account;
        }

        // POST: api/Staff_Account
        [HttpPost]
        public async Task<ActionResult<Staff_Account>> PostStaff_Account(Staff_Account staff_Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaffAccounts.Add(staff_Account);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaff_Account), new { id = staff_Account.id }, staff_Account);
        }

        // PUT: api/Staff_Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff_Account(Guid id, Staff_Account staff_Account)
        {
            if (id != staff_Account.id)
            {
                return BadRequest();
            }

            _context.Entry(staff_Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Staff_AccountExists(id))
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

        // DELETE: api/Staff_Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff_Account(Guid id)
        {
            var staff_Account = await _context.StaffAccounts.FindAsync(id);
            if (staff_Account == null)
            {
                return NotFound();
            }

            _context.StaffAccounts.Remove(staff_Account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Staff_AccountExists(Guid id)
        {
            return _context.StaffAccounts.Any(e => e.id == id);
        }
    }
}
