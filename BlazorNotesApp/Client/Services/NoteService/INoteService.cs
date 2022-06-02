namespace BlazorNotesApp.Client.Services.NotesService
{
    public interface INoteService
    {
        public List<NoteModel> Notes { get; set; }

        Task GetNotes();
        Task<NoteModel> GetSingleNote(int? id);
        Task CreateNote(NoteModel note);
        Task UpdateNote(NoteModel note, int? id);
        Task DeleteNote(int? id);

    }
}
