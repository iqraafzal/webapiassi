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
    public class AssignmentsController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public AssignmentsController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public IEnumerable<Assignments> GetAsignmentss()
        {
            return _context.Asignmentss;
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignments = await _context.Asignmentss.FindAsync(id);

            if (assignments == null)
            {
                return NotFound();
            }

            return Ok(assignments);
        }

        // PUT: api/Assignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignments([FromRoute] int id, [FromBody] Assignments assignments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignments.Assignmentid)
            {
                return BadRequest();
            }

            _context.Entry(assignments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentsExists(id))
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

        // POST: api/Assignments
        [HttpPost]
        public async Task<IActionResult> PostAssignments([FromBody] Assignments assignments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Asignmentss.Add(assignments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignments", new { id = assignments.Assignmentid }, assignments);
        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignments = await _context.Asignmentss.FindAsync(id);
            if (assignments == null)
            {
                return NotFound();
            }

            _context.Asignmentss.Remove(assignments);
            await _context.SaveChangesAsync();

            return Ok(assignments);
        }

        private bool AssignmentsExists(int id)
        {
            return _context.Asignmentss.Any(e => e.Assignmentid == id);
        }
    }
}