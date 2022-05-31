using System.Net.Http.Json;

namespace BlazorNotesApp.Client.Services.NotesService
{
    public class NotesService : INotesService
    {
        private readonly HttpClient _http;

        public NotesService(HttpClient http)
        {
            _http = http;
        }

        public List<NoteModel> Notes { get; set; }

        public async Task GetNotes()
        {
            var result = await _http.GetFromJsonAsync<List<NoteModel>>("api/notes");
            if (result != null) Notes = result;
        }

        public async Task<NoteModel> GetSingleNote(int? id)
        {
            var result = await _http.GetFromJsonAsync<NoteModel>($"api/notes/{id}");
            if (result != null) return result;
            throw new Exception("No Note Here");
        }
    }
}
