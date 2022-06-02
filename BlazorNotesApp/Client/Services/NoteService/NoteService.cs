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

        public async Task GetNotesAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<NoteModel>>>("api/note");
            if (response != null && response.Data != null) Notes = response.Data;
        }

        public async Task<NoteModel> GetSingleNoteAsync(int? id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<NoteModel>>($"api/note/{id}");
            if (response != null && response.Data != null) return response.Data;

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
