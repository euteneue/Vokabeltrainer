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
    public class WortTypController : ControllerBase
    {
        private readonly VokabelTrainerAPIContext _context;

        public WortTypController(VokabelTrainerAPIContext context)
        {
            _context = context;
        }

        // GET: api/WortTyp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WortTyp>>> GetWortTyp()
        {
            return await _context.WortTyp.ToListAsync();
        }

        // GET: api/WortTyp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WortTyp>> GetWortTyp(int id)
        {
            var wortTyp = await _context.WortTyp.FindAsync(id);

            if (wortTyp == null)
            {
                return NotFound();
            }

            return wortTyp;
        }

        // PUT: api/WortTyp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWortTyp(int id, WortTyp wortTyp)
        {
            if (id != wortTyp.Id)
            {
                return BadRequest();
            }

            _context.Entry(wortTyp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WortTypExists(id))
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

        // POST: api/WortTyp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WortTyp>> PostWortTyp(WortTyp wortTyp)
        {
            try
            { 
                _context.WortTyp.Add(wortTyp);
                await _context.SaveChangesAsync();
            } 
            catch (DbUpdateException)
            {
                return BadRequest("Sprache can't be created - is it unique?");
            }

            return CreatedAtAction("GetWortTyp", new { id = wortTyp.Id }, wortTyp);
        }

        // DELETE: api/WortTyp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWortTyp(int id)
        {
            var wortTyp = await _context.WortTyp.FindAsync(id);
            if (wortTyp == null)
            {
                return NotFound();
            }

            _context.WortTyp.Remove(wortTyp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WortTypExists(int id)
        {
            return _context.WortTyp.Any(e => e.Id == id);
        }
    }
}
