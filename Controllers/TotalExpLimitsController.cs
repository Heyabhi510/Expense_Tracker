using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalExpLimitsController : ControllerBase
    {
        private readonly DashboardContext _context;

        public TotalExpLimitsController(DashboardContext context)
        {
            _context = context;
        }

        // GET: api/TotalExpLimits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TotalExpLimit>>> GetTotalExpense()
        {
          if (_context.TotalExpense == null)
          {
              return NotFound();
          }
            return await _context.TotalExpense.ToListAsync();
        }

        // GET: api/TotalExpLimits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TotalExpLimit>> GetTotalExpLimit(int id)
        {
          if (_context.TotalExpense == null)
          {
              return NotFound();
          }
            var totalExpLimit = await _context.TotalExpense.FindAsync(id);

            if (totalExpLimit == null)
            {
                return NotFound();
            }

            return totalExpLimit;
        }

        // PUT: api/TotalExpLimits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTotalExpLimit(int id, TotalExpLimit totalExpLimit)
        {
            if (id != totalExpLimit.ExpLimitId)
            {
                return BadRequest();
            }

            _context.Entry(totalExpLimit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotalExpLimitExists(id))
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

        // POST: api/TotalExpLimits
        [HttpPost]
        public async Task<ActionResult<TotalExpLimit>> PostTotalExpLimit(TotalExpLimit totalExpLimit)
        {
          if (_context.TotalExpense == null)
          {
              return Problem("Entity set 'DashboardContext.TotalExpense'  is null.");
          }
            _context.TotalExpense.Add(totalExpLimit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTotalExpLimit", new { id = totalExpLimit.ExpLimitId }, totalExpLimit);
        }

        // DELETE: api/TotalExpLimits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTotalExpLimit(int id)
        {
            if (_context.TotalExpense == null)
            {
                return NotFound();
            }
            var totalExpLimit = await _context.TotalExpense.FindAsync(id);
            if (totalExpLimit == null)
            {
                return NotFound();
            }

            _context.TotalExpense.Remove(totalExpLimit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TotalExpLimitExists(int id)
        {
            return (_context.TotalExpense?.Any(e => e.ExpLimitId == id)).GetValueOrDefault();
        }
    }
}
