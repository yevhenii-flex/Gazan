using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gazan.WEB.Data;
using Gazan.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace Gazan.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DimensionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Dimensions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dimension>>> GetDimensions()
        {
            return await _context.Dimensions.ToListAsync();
        }

        // GET: api/Dimensions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dimension>> GetDimension(int id)
        {
            var dimension = await _context.Dimensions.FindAsync(id);

            if (dimension == null)
            {
                return NotFound();
            }

            return dimension;
        }

        // PUT: api/Dimensions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDimension(int id, Dimension dimension)
        {
            if (id != dimension.Id)
            {
                return BadRequest();
            }

            _context.Entry(dimension).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimensionExists(id))
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

        // POST: api/Dimensions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Dimension>> PostDimension(Dimension dimension)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dimension.ApplicationUserId = user.Id;

            _context.Dimensions.Add(dimension);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDimension", new { id = dimension.Id }, dimension);
        }

        // DELETE: api/Dimensions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dimension>> DeleteDimension(int id)
        {
            var dimension = await _context.Dimensions.FindAsync(id);
            if (dimension == null)
            {
                return NotFound();
            }

            _context.Dimensions.Remove(dimension);
            await _context.SaveChangesAsync();

            return dimension;
        }

        private bool DimensionExists(int id)
        {
            return _context.Dimensions.Any(e => e.Id == id);
        }
    }
}
