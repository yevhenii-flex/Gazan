using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gazan.WEB.Data;
using Gazan.WEB.Models;
using System.Runtime.InteropServices.ComTypes;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Gazan.Backend.Models;

namespace Gazan.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriticalValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CriticalValuesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("IsCritical")]
        public IActionResult IsCritical(int substanceId, int substanceValue)
        {
            double averageCriticalValue = _context.CriticalValues.Where(c => c.HarmfulSubstanceId == substanceId && c.IsApproved).Select(c => c.Value).Average();

            if (averageCriticalValue > substanceValue) return Ok(true);
            else return Ok(false);
        }
        // GET: api/CriticalValues
        [HttpGet]
        public async Task<IActionResult> GetCriticalValues()
        {
            return Ok(_mapper.Map<List<CriticalValueViewModel>>(await _context.CriticalValues.Include(c => c.HarmfulSubstance).ToListAsync()));
        }

        // GET: api/CriticalValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CriticalValue>> GetCriticalValue(int id)
        {
            var criticalValue = await _context.CriticalValues.FindAsync(id);

            if (criticalValue == null)
            {
                return NotFound();
            }

            return criticalValue;
        }

        // PUT: api/CriticalValues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriticalValue(int id, CriticalValue criticalValue)
        {
            if (id != criticalValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(criticalValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriticalValueExists(id))
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

        // POST: api/CriticalValues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "expert")]
        public async Task<ActionResult<CriticalValue>> PostCriticalValue(CriticalValue criticalValue)
        {
            _context.CriticalValues.Add(criticalValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCriticalValue", new { id = criticalValue.Id }, criticalValue);
        }

        // DELETE: api/CriticalValues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CriticalValue>> DeleteCriticalValue(int id)
        {
            var criticalValue = await _context.CriticalValues.FindAsync(id);
            if (criticalValue == null)
            {
                return NotFound();
            }

            _context.CriticalValues.Remove(criticalValue);
            await _context.SaveChangesAsync();

            return criticalValue;
        }

        private bool CriticalValueExists(int id)
        {
            return _context.CriticalValues.Any(e => e.Id == id);
        }
    }
}
