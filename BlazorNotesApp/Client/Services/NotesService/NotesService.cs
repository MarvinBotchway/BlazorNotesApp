using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorNotesApp.Client.Services.NotesService
{
    public class NotesService : INotesService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public NotesService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<NoteModel> Notes { get; set; } = new List<NoteModel>();

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

        public async Task CreateNote(NoteModel note)
        {
            var result = await _http.PostAsJsonAsync<NoteModel>("api/notes", note);
            await SetNotes(result);
        }



        private async Task SetNotes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<NoteModel>>();
            if (response != null) Notes = response;
            _navigationManager.NavigateTo("notes");
        }
    }
}
