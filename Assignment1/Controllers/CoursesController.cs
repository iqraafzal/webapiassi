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
    [Route("api/Courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public CoursesController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public IEnumerable<Courses> GetCoursess()
        {
            return _context.Coursess;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourses([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courses = await _context.Coursess.FindAsync(id);

            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourses([FromRoute] string id, [FromBody] Courses courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courses.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(courses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesExists(id))
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

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> PostCourses([FromBody] Courses courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Coursess.Add(courses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourses", new { id = courses.CourseId }, courses);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourses([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courses = await _context.Coursess.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }

            _context.Coursess.Remove(courses);
            await _context.SaveChangesAsync();

            return Ok(courses);
        }

        private bool CoursesExists(string id)
        {
            return _context.Coursess.Any(e => e.CourseId == id);
        }
    }
}