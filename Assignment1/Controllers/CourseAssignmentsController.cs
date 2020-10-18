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
    [Route("api/CA")]
    [ApiController]
    public class CourseAssignmentsController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public CourseAssignmentsController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseAssignments
        [HttpGet]
        public IEnumerable<CourseAssignments> GetCourseAsignmentss()
        {
            return _context.CourseAsignmentss;
        }

        // GET: api/CourseAssignments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseAssignments([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseAssignments = await _context.CourseAsignmentss.FindAsync(id);

            if (courseAssignments == null)
            {
                return NotFound();
            }

            return Ok(courseAssignments);
        }

        // PUT: api/CourseAssignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseAssignments([FromRoute] string id, [FromBody] CourseAssignments courseAssignments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseAssignments.Assignment_Name)
            {
                return BadRequest();
            }

            _context.Entry(courseAssignments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseAssignmentsExists(id))
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

        // POST: api/CourseAssignments
        [HttpPost]
        public async Task<IActionResult> PostCourseAssignments([FromBody] CourseAssignments courseAssignments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CourseAsignmentss.Add(courseAssignments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseAssignments", new { id = courseAssignments.Assignment_Name }, courseAssignments);
        }

        // DELETE: api/CourseAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseAssignments([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseAssignments = await _context.CourseAsignmentss.FindAsync(id);
            if (courseAssignments == null)
            {
                return NotFound();
            }

            _context.CourseAsignmentss.Remove(courseAssignments);
            await _context.SaveChangesAsync();

            return Ok(courseAssignments);
        }

        private bool CourseAssignmentsExists(string id)
        {
            return _context.CourseAsignmentss.Any(e => e.Assignment_Name == id);
        }
    }
}