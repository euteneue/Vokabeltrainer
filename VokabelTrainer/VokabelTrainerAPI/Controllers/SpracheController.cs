#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VokabelTrainerAPI.Data;
using VokabelTrainerAPI.Models;

namespace VokabelTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpracheController : ControllerBase
    {
        private readonly VokabelTrainerAPIContext _context;

        public SpracheController(VokabelTrainerAPIContext context)
        {
            _context = context;
        }

        // GET: api/Sprache
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sprache>>> GetSprache()
        {
            return await _context.Sprache.ToListAsync();
        }

        // GET: api/Sprache/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sprache>> GetSprache(int id)
        {
            var sprache = await _context.Sprache.FindAsync(id);

            if (sprache == null)
            {
                return NotFound();
            }

            return sprache;
        }

        // PUT: api/Sprache/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSprache(int id, Sprache sprache)
        {
            if (id != sprache.Id)
            {
                return BadRequest();
            }

            _context.Entry(sprache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpracheExists(id))
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

        // POST: api/Sprache
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sprache>> PostSprache(Sprache sprache)
        {
            try
            {
                _context.Sprache.Add(sprache);
                await _context.SaveChangesAsync();
            } catch (DbUpdateException e)
            {
                return BadRequest("Sprache can't be created - is it unique?");
            }

            return CreatedAtAction("GetSprache", new { id = sprache.Id }, sprache);
        }

        // DELETE: api/Sprache/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSprache(int id)
        {
            var sprache = await _context.Sprache.FindAsync(id);
            if (sprache == null)
            {
                return NotFound();
            }

            _context.Sprache.Remove(sprache);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpracheExists(int id)
        {
            return _context.Sprache.Any(e => e.Id == id);
        }
    }
}
