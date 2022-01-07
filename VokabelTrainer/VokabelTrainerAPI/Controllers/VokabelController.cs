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
    public class VokabelController : ControllerBase
    {
        private readonly VokabelTrainerAPIContext _context;

        public VokabelController(VokabelTrainerAPIContext context)
        {
            _context = context;
        }

        // GET: api/Vokabel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VokabelSimpel>>> GetVokabel()
        {
            return (await _context.Vokabel
                 .Include(vokabel => vokabel.Sprache)
                 .Include(vokabel => vokabel.Typ)
                 .AsNoTracking()
                 .Select(v => new VokabelSimpel { Id = v.Id, Abschnitt = v.Abschnitt, Tip = v.Tip, Wort = v.Wort, Uebersetzung = v.Uebersetzung, Sprache = v.Sprache.Name, WortTyp = v.Typ.Typ })
                 .ToListAsync());
        }

        // GET: api/Vokabel/id/5
        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<VokabelSimpel>> GetVokabel(int id)
        {
            var vokabel = await _context.Vokabel
                .Include(vokabel=> vokabel.Sprache)
                .Include(vokabel => vokabel.Typ)  
                .Where(vokabel => vokabel.Id == id)
                .Select(v => new VokabelSimpel { Id = v.Id, Abschnitt = v.Abschnitt, Tip = v.Tip, Wort = v.Wort, Uebersetzung = v.Uebersetzung, Sprache = v.Sprache.Name, WortTyp = v.Typ.Typ })
                .FirstOrDefaultAsync();

            
            if (vokabel == null)
            {
                return NotFound();
            }

            return vokabel;
        }


        // GET: api/Vokabel/lang/English
        [HttpGet("lang/{lang}")]
        public async Task<ActionResult<IEnumerable<VokabelSimpel>>> GetVokabel(string lang)
        {
            var vokabel = await _context.Vokabel
                .Include(vokabel => vokabel.Sprache)
                .Include(vokabel => vokabel.Typ)
                .Where(vokabel => vokabel.Sprache.Name == lang)
                .AsNoTracking()
                .Select(v => new VokabelSimpel { Id = v.Id, Abschnitt = v.Abschnitt, Tip = v.Tip, Wort = v.Wort, Uebersetzung = v.Uebersetzung, Sprache = v.Sprache.Name, WortTyp = v.Typ.Typ })
                .ToListAsync();

            return vokabel;
        }

        // PUT: api/Vokabel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVokabel(int id, Vokabel vokabel)
        {
            if (id != vokabel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vokabel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VokabelExists(id))
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

        // POST: api/Vokabel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vokabel>> PostVokabel(Vokabel vokabel)
        {
            if (vokabel != null && vokabel.Sprache != null)
            {
                var sprache = _context.Sprache.Where(e => e.Name == vokabel.Sprache.Name).First();
                var typ = _context.WortTyp.Where(e => e.Typ == vokabel.Typ.Typ).First();

                if (typ != null) vokabel.Typ = typ;
                if (sprache != null) vokabel.Sprache = sprache;
            }

            _context.Vokabel.Add(vokabel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVokabel", new { id = vokabel.Id }, vokabel);
        }

        // DELETE: api/Vokabel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVokabel(int id)
        {
            var vokabel = await _context.Vokabel.FindAsync(id);
            if (vokabel == null)
            {
                return NotFound();
            }

            _context.Vokabel.Remove(vokabel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VokabelExists(int id)
        {
            return _context.Vokabel.Any(e => e.Id == id);
        }
    }
}
