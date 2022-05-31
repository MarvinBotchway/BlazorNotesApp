using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorNotesApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public NotesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteModel>>> GetNotes()
        {
            var notes = await _context.Notes
                .ToListAsync();
            return Ok( notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteModel>> GetSingleNote(int id)
        {
            var note = _context.Notes
                .FirstOrDefault<NoteModel>(n => n.Id == id);
            if (note == null) return NotFound();
            return Ok( note );
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<List<NoteModel>>> CreateNote(NoteModel note, int id)
        {
            var DbNote = _context.Notes
                .FirstOrDefault<NoteModel>(n => n.Id == id);
            if (DbNote == null) return NotFound();

            DbNote.Heading = note.Heading;
            DbNote.Body = note.Body;
            DbNote.IsChecked = note.IsChecked;

            await _context.SaveChangesAsync();

            return Ok(await GetDbNotes());
        }

        [HttpPut]
        public async Task<ActionResult<List<NoteModel>>> CreateNote(NoteModel note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

            return Ok(await GetDbNotes());
        }

        private async Task<List<NoteModel>> GetDbNotes()
        {
            return await _context.Notes.ToListAsync();

        }


    }
}
