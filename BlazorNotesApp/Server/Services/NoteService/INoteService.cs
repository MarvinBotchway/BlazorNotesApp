namespace BlazorNotesApp.Server.Services.NoteService
{
    public interface INoteService
    {
        Task<ServiceResponse<List<NoteModel>>> GetNotesAsync();
        Task<ServiceResponse<NoteModel>> GetSingleNoteAsync(int? id);
    }
}
