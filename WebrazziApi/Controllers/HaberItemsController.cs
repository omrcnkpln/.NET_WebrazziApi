using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebrazziApi.Models;

//try it, try it hard
namespace WebrazziApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaberItemsController : ControllerBase
    {
        private readonly HaberContext _context;

        public HaberItemsController(HaberContext context)
        {
            _context = context;
        }

        // GET: api/HaberItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HaberItem>>> GetHaberItems()
        {
            return await _context.HaberItems.ToListAsync();
        }

        // GET: api/HaberItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HaberItem>> GetHaberItem(long id)
        {
            var haberItem = await _context.HaberItems.FindAsync(id);

            if (haberItem == null)
            {
                return NotFound();
            }

            return haberItem;
        }

        // PUT: api/HaberItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHaberItem(long id, HaberItem haberItem)
        {
            if (id != haberItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(haberItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HaberItemExists(id))
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

        // POST: api/HaberItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HaberItem>> PostHaberItem(HaberItem haberItem)
        {
            _context.HaberItems.Add(haberItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHaberItem", new { id = haberItem.Id }, haberItem);
        }

        // DELETE: api/HaberItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHaberItem(long id)
        {
            var haberItem = await _context.HaberItems.FindAsync(id);
            if (haberItem == null)
            {
                return NotFound();
            }

            _context.HaberItems.Remove(haberItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HaberItemExists(long id)
        {
            return _context.HaberItems.Any(e => e.Id == id);
        }
    }
}
