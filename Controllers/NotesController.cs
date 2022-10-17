using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApi.Models;
using NotesApi.Context;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext _context;
        public NotesController(NotesDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<Notes>> GetNotesAsync([FromQuery]int count)
        {
            var result = await _context.Notes!.ToListAsync();
            if (result != null)
                return Ok(result);
            return NotFound("No notes have been added.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> GetNote(int id)
        {
            var result = await _context.Notes!.FirstOrDefaultAsync(r => r.Id == id);
            if (result != null)
                return Ok(result);
            return NotFound("The note you are looking for is not available.");
        }

        [HttpPost("new")]
        public async Task<ActionResult<Notes>> PostNewNote([FromBody]Notes value)
        {
            if (ModelState.IsValid)
            {
                await _context.Notes!.AddAsync(value);
                _context.SaveChanges();
                return Ok(value);
            }
            return BadRequest("Something went wrong while submitting your note. Please check your input.");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Notes>> UpdateDetails(int id, [FromBody]Notes value)
        {
            var result = await _context.Notes!.FirstOrDefaultAsync(r => r.Id == id);
            if (result != null)
            {
                _context.Entry<Notes>(result).CurrentValues.SetValues(value);
                _context.SaveChanges();
                return Ok(value);
            }
            return NotFound("The note to be updated was not found");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Notes>> DeleteNote(int id)
        {
            var note = await _context.Notes!.FirstOrDefaultAsync(n => n.Id == id);
            if (note != null)
            {
                _context.Notes!.Remove(note);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest("The note given was deletion is not availale");
        }

    }
}