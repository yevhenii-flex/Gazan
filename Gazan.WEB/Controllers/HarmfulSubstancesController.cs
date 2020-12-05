using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gazan.WEB.Data;
using Gazan.WEB.Models;

namespace Gazan.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarmfulSubstancesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HarmfulSubstancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HarmfulSubstances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HarmfulSubstance>>> GetHarmfulSubstances()
        {
            return await _context.HarmfulSubstances.ToListAsync();
        }

        // GET: api/HarmfulSubstances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HarmfulSubstance>> GetHarmfulSubstance(int id)
        {
            var harmfulSubstance = await _context.HarmfulSubstances.FindAsync(id);

            if (harmfulSubstance == null)
            {
                return NotFound();
            }

            return harmfulSubstance;
        }

        // PUT: api/HarmfulSubstances/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHarmfulSubstance(int id, HarmfulSubstance harmfulSubstance)
        {
            if (id != harmfulSubstance.Id)
            {
                return BadRequest();
            }

            _context.Entry(harmfulSubstance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HarmfulSubstanceExists(id))
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

        // POST: api/HarmfulSubstances
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HarmfulSubstance>> PostHarmfulSubstance(HarmfulSubstance harmfulSubstance)
        {
            _context.HarmfulSubstances.Add(harmfulSubstance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHarmfulSubstance", new { id = harmfulSubstance.Id }, harmfulSubstance);
        }

        // DELETE: api/HarmfulSubstances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HarmfulSubstance>> DeleteHarmfulSubstance(int id)
        {
            var harmfulSubstance = await _context.HarmfulSubstances.FindAsync(id);
            if (harmfulSubstance == null)
            {
                return NotFound();
            }

            _context.HarmfulSubstances.Remove(harmfulSubstance);
            await _context.SaveChangesAsync();

            return harmfulSubstance;
        }

        private bool HarmfulSubstanceExists(int id)
        {
            return _context.HarmfulSubstances.Any(e => e.Id == id);
        }
    }
}
