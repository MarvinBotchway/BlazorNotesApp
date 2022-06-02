
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorNotesApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<NoteModel>>>> GetNotesAsync()
        {
            var response = await _noteService.GetNotesAsync();
            return Ok(response);



            //var notes = await _context.Notes
            //    .ToListAsync();
            //return Ok( notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteModel>> GetSingleNoteAsync(int id)
        {
            //var note = _context.Notes
            //    .FirstOrDefault<NoteModel>(n => n.Id == id);
            //if (note == null) return NotFound();
            //return Ok( note );

            var response = await _noteService.GetSingleNoteAsync(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<NoteModel>>> CreateNote(NoteModel note, int id)
        {
            //var DbNote = _context.Notes
            //    .FirstOrDefault<NoteModel>(n => n.Id == id);
            //if (DbNote == null) return NotFound();

            //DbNote.Heading = note.Heading;
            //DbNote.Body = note.Body;
            //DbNote.IsChecked = note.IsChecked;

            //await _context.SaveChangesAsync();

            //return Ok(await GetDbNotes());

            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<NoteModel>>> DeleteNote(int id)
        {
            //var DbNote = _context.Notes
            //    .FirstOrDefault<NoteModel>(n => n.Id == id);
            //if (DbNote == null) return NotFound();

            //_context.Notes.Remove(DbNote);

            //await _context.SaveChangesAsync();

            //return Ok(await GetDbNotes());

            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<List<NoteModel>>> CreateNote(NoteModel note)
        {
            //await _context.Notes.AddAsync(note);
            //await _context.SaveChangesAsync();

            //return Ok(await GetDbNotes());

            throw new NotImplementedException();
        }

        private async Task<List<NoteModel>> GetDbNotes()
        {
            //return await _context.Notes.ToListAsync();

            throw new NotImplementedException();
        }


    }
}
