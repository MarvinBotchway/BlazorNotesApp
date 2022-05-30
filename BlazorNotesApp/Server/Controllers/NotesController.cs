using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorNotesApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public List<NoteModel> notes = new List<NoteModel>()
        {
            new NoteModel()
            {
                Id = 1,
                Heading = "First Note",
                Body = "This is the first note about the first thing I want to talk about",
                IsChecked = false,
            },
            new NoteModel()
            {
                Id = 2,
                Heading = "Second Note",
                Body = "This is the Second note about the second thing I want to talk about",
                IsChecked = true,
            }
        };


        [HttpGet]
        public async Task<ActionResult<List<NoteModel>>> GetNotes()
        {
            return Ok( notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteModel>> GetSingleNote(int id)
        {
            var result = notes.FirstOrDefault<NoteModel>(n => n.Id == id);
            if (result == null) return NotFound();
            return Ok( result);
        }

        



    }
}
