namespace BlazorNotesApp.Server.Services.NoteService
{
    public class NoteService : INoteService
    {
        private readonly DatabaseContext _context;

        public NoteService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<NoteModel>>> GetNotesAsync()
        {
            var response = new ServiceResponse<List<NoteModel>>()
            {
                Data = await _context.Notes.ToListAsync()
            };
         
            
           return response;
            
        }

        public async Task<ServiceResponse<NoteModel>> GetSingleNoteAsync(int? id)
        {
            var response = new ServiceResponse<NoteModel>() 
            {
                Data = _context.Notes.FirstOrDefault<NoteModel>(n => n.Id == id)
            };

            return response;
        }
    }
}
