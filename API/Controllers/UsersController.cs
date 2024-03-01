using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var appUser = await _context.User.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
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

        // POST: api/AppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostUser(AppUser appUser)
        {
            _context.User.Add(appUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var appUser = await _context.User.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.User.Remove(appUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppUserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
