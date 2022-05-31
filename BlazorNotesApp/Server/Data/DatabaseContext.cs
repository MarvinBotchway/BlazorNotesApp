namespace BlazorNotesApp.Server.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteModel>().HasData
                (
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

                );
        }

        public DbSet<NoteModel> Notes { get; set; }

    }
}
