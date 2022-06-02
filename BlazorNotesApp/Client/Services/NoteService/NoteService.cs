using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorNotesApp.Client.Services.NotesService
{
    public class NoteService : INoteService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public NoteService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<NoteModel> Notes { get; set; } = new List<NoteModel>();

        public async Task GetNotes()
        {
            var response = await _http.GetFromJsonAsync<List<NoteModel>>("api/note");
            if (response != null) Notes = response;
        }

        public async Task<NoteModel> GetSingleNote(int? id)
        {
            var result = await _http.GetFromJsonAsync<NoteModel>($"api/note/{id}");
            if (result != null) return result;
            throw new Exception("No Note Here");
        }

        public async Task CreateNote(NoteModel note)
        {
            var result = await _http.PostAsJsonAsync<NoteModel>("api/note", note);
            await SetNotes(result);
        }

        public async Task UpdateNote(NoteModel note, int? id)
        {
            var result = await _http.PutAsJsonAsync<NoteModel>($"api/note/{id}", note);
            await SetNotes(result);
        }

        public async Task DeleteNote(int? id)
        {
            var result = await _http.DeleteAsync($"api/note/{id}");
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
