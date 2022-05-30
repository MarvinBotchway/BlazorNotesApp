﻿using System.Net.Http.Json;

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

        public Task<NoteModel> GetSingleNote(int id)
        {
            throw new NotImplementedException();
        }
    }
}