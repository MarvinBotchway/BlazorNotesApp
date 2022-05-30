namespace BlazorNotesApp.Client.Services.NotesService
{
    public interface INotesService
    {
        public List<NoteModel> Notes { get; set; }

        Task GetNotes();
        Task<NoteModel> GetSingleNote(int id);
    }
}
