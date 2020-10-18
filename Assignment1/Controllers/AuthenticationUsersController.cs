using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthenticationUsersController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public AuthenticationUsersController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/AuthenticationUsers
        [HttpGet]
        public IEnumerable<AuthenticationUser> GetAuthUsers()
        {
            return _context.AuthUsers;
           // return new string[] { "value1", "value2" };
        }

        // GET: api/AuthenticationUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthenticationUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authenticationUser = await _context.AuthUsers.FindAsync(id);

            if (authenticationUser == null)
            {
                return NotFound();
            }

            return Ok(authenticationUser);
        }

        // PUT: api/AuthenticationUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthenticationUser([FromRoute] int id, [FromBody] AuthenticationUser authenticationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authenticationUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(authenticationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthenticationUserExists(id))
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

        // POST: api/AuthenticationUsers
        [HttpPost]
        public async Task<IActionResult> PostAuthenticationUser([FromBody] AuthenticationUser authenticationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AuthUsers.Add(authenticationUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthenticationUser", new { id = authenticationUser.Id }, authenticationUser);
        }

        // DELETE: api/AuthenticationUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthenticationUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authenticationUser = await _context.AuthUsers.FindAsync(id);
            if (authenticationUser == null)
            {
                return NotFound();
            }

            _context.AuthUsers.Remove(authenticationUser);
            await _context.SaveChangesAsync();

            return Ok(authenticationUser);
        }

        private bool AuthenticationUserExists(int id)
        {
            return _context.AuthUsers.Any(e => e.Id == id);
        }
    }
}