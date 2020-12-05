using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gazan.WEB.Data;
using Gazan.WEB.Models;
using Gazan.WEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gazan.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_mapper.Map<IEnumerable<ApplicationUserViewModel>>(_context.ApplicationUsers.ToList()));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var user = _mapper.Map<ApplicationUserViewModel>(_context.ApplicationUsers.Where(u => u.Id == id).FirstOrDefault());
            if (user == null) return NotFound();

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<object> Post([FromBody] RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return Ok(_mapper.Map<ApplicationUserViewModel>(user));
            }
            else if (result.Errors.Any())
            {
                List<string> errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);
                }
                return BadRequest(errors);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ApplicationUserViewModel user)
        {
            var dbUser = _context.ApplicationUsers.Where(u => u.Id == user.Id).FirstOrDefault();
            if (id != user.Id)
            {
                return BadRequest();
            }
            dbUser.Email = user.Email;
            dbUser.PhoneNumber = user.PhoneNumber;
            //_context.Entry(dbUser).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("This email alredy taken");
                }
            }

            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = _context.ApplicationUsers.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.ApplicationUsers.Remove(user);
            _context.SaveChanges();

            return Ok(_mapper.Map<ApplicationUserViewModel>(user));
        }

        private bool UserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
