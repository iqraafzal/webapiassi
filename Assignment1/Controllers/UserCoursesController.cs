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
    [Route("api/[controller]")]
    [ApiController]
    public class UserCoursesController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public UserCoursesController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/UserCourses
        [HttpGet]
        public IEnumerable<UserCourses> GetUsercourses()
        {
            return _context.Usercourses;
        }

        // GET: api/UserCourses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserCourses([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userCourses = await _context.Usercourses.FindAsync(id);

            if (userCourses == null)
            {
                return NotFound();
            }

            return Ok(userCourses);
        }

        // PUT: api/UserCourses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCourses([FromRoute] string id, [FromBody] UserCourses userCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userCourses.Full_Name)
            {
                return BadRequest();
            }

            _context.Entry(userCourses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCoursesExists(id))
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

        // POST: api/UserCourses
        [HttpPost]
        public async Task<IActionResult> PostUserCourses([FromBody] UserCourses userCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Usercourses.Add(userCourses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCourses", new { id = userCourses.Full_Name }, userCourses);
        }

        // DELETE: api/UserCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCourses([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userCourses = await _context.Usercourses.FindAsync(id);
            if (userCourses == null)
            {
                return NotFound();
            }

            _context.Usercourses.Remove(userCourses);
            await _context.SaveChangesAsync();

            return Ok(userCourses);
        }

        private bool UserCoursesExists(string id)
        {
            return _context.Usercourses.Any(e => e.Full_Name == id);
        }
    }
}