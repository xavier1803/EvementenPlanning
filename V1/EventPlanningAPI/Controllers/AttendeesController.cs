using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvementenPlanning.Models;

namespace EventPlanningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly EventplanningContext _context;

        public AttendeesController(EventplanningContext context)
        {
            _context = context;
        }

        // GET: api/Attendees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendees()
        {
          if (_context.Attendees == null)
          {
              return NotFound();
          }
            return await _context.Attendees.ToListAsync();
        }

        // GET: api/Attendees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendee>> GetAttendee(int id)
        {
          if (_context.Attendees == null)
          {
              return NotFound();
          }
            var attendee = await _context.Attendees.FindAsync(id);

            if (attendee == null)
            {
                return NotFound();
            }

            return attendee;
        }

        // PUT: api/Attendees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendee(int id, Attendee attendee)
        {
            if (id != attendee.Id)
            {
                return BadRequest();
            }

            _context.Entry(attendee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeeExists(id))
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

        // POST: api/Attendees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attendee>> PostAttendee(Attendee attendee)
        {
          if (_context.Attendees == null)
          {
              return Problem("Entity set 'EventplanningContext.Attendees'  is null.");
          }
            _context.Attendees.Add(attendee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendee", new { id = attendee.Id }, attendee);
        }

        // DELETE: api/Attendees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendee(int id)
        {
            if (_context.Attendees == null)
            {
                return NotFound();
            }
            var attendee = await _context.Attendees.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }

            _context.Attendees.Remove(attendee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendeeExists(int id)
        {
            return (_context.Attendees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
